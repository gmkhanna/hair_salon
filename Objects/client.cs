using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalonApp
{
    public class Client
    {
        private _id;
        private _name;
        private _stylistId;

        public Client(string name, int stylistId, int id=0)
        {
            _id = id;
            _name = name;
            _stylistId = stylistId;

        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool clientEquality = this.GetName() == newClient.GetName();
                bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
                return (clientEquality && stylistIdEquality);
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> clientList = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);

                Client newClient = new Client (clientId, clientName, clientStylistId);
                clientList.Add(newClient);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return clientList;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_Id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientStylistId);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@ClientName";
            nameParameter.Value = this.GetName();

            SqlParameter stylistIdParameter = new SqlParameter;
            stylistIdParameter.ParameterName = "@ClientStylistId";
            stylistIdParameter.Value = this.GetStylistId();

            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(stylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while
            {
                    this._id = Getint32(0);
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

        public static Client Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FRMO clients WHERE id = @ClientId);", conn);

            SqlParameter idParameter = new SqlParameter();
            idParameter.ParameterName = "@ClientId";
            idParameter.Value = id.ToString();
            cmd.Parameters.Add(idParameter)

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundClientId = 0;
            string foundClientName = null;
            int foundClientStylistId = 0;

            while (rdr.Read())
            {
                int foundClientId = rdr.GetInt32(0);
                string foundClientName = rdr.GetString(1);
                int foundClientStylistId = rdr.GetInt32(2);
            }

            Client foundClient = new Client (foundClientId, foundClientName, foundClientStylistId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundClient;
        }

        

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand ("Delete FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int GetID()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newname)
        {
            name = newName;
        }

        public string GetStylistId()
        {
            return _stylistId;
        }

    }
}
