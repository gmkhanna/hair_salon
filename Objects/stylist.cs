using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalonApp
{
    public class Stylist
    {
        private int _id;
        private string _handle;

        public Stylist(string handle, int id = 0)
        {
            _id = id;
            _handle = handle;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool handleEquality = this.GetStylistType() == newStylist.GetStylistType();
                return (handleEquality);
            }
        }


        public static List<Stylist> GetAll()
        {
            List<Stylist> stylistList = new List<Stylist> {};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                    string stylistType = rdr.GetString(1);

                Stylist newStylist = new Stylist(stylistType, stylistId);
                stylistList.Add(newStylist);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return stylistList;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (handle) OUTPUT INSERTED.id VALUES (@StylistType);", conn);

            SqlParameter handleParameter = new SqlParameter();
            handleParameter.ParameterName = "@StylistType";
            handleParameter.Value = this.GetStylistType();
            cmd.Parameters.Add(handleParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Stylist Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);

            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
                stylistIdParameter.Value = id.ToString();
            cmd.Parameters.Add(stylistIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundStylistId = 0;
            string foundStylistType = null;

            while (rdr.Read())
            {
                foundStylistId = rdr.GetInt32(0);
                foundStylistType = rdr.GetString(1);
            }
            Stylist foundStylist = new Stylist(foundStylistType, foundStylistId);

            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
            return foundStylist;
        }

        public List<Client> GetClients()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);
            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetStylistId();
            cmd.Parameters.Add(stylistIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            List<Client> clients = new List<Client> {};
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);

                Client newClient = new Client(clientName, clientStylistId, clientId);
                clients.Add(newClient);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return clients;
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public int GetStylistId()
        {
            return _id;
        }

        public string GetStylistType()
        {
            return _handle;
        }

        public void SetType(string newType)
        {
            _handle = newType;
        }

    }
}
