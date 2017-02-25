using Nancy;
using HairSalonApp;
using System.Collections.Generic;

namespace HairSalonApp
{
    public class HomeModule: NancyModule
    {
        public HomeModule()
        {
            // Take you to the homepage
            Get["/"] = _ => {
                return View["index.cshtml"];
            };
            // Stylist Page : rendered
            Get["/stylists"] = _ => {
                var stylistList = Stylist.GetAll();
                return View["stylists.cshtml", stylistList];
            };
            // Stylist Page : new entry post action
            Post["/stylists"] = _ => {
                var newStylist = new Stylist(Request.Form["stylist"]);
                newStylist.Save();
                var stylistList = Stylist.GetAll();
                return View["stylists.cshtml", stylistList];
            };
            // // Delete a stylist
            // Delete["/stylists/{stylistId}"] = parameters => {
            //     Stylist specificStylist = Stylist.Find(parameters.stylistId);
            //     specificStylist.Delete();
            //     List<Stylist> stylistList = Stylist.GetAll();
            //     return View["stylists.cshtml", stylistList];
            // };
            // // Edit a stylist
            // Patch["/stylists/{stylistId}/updated"] = parameters => {
            //     Stylist selectedStylist = Stylist.Find(parameters.stylistId);
            //     selectedStylist.Update(Request.Form["stylist-type"]);
            //     return View["stylistUpdated.cshtml"];
            // };
            // // Take you to the page to edit a stylist
            // Get["/stylists/{stylistId}/edit"] = parameters => {
            //     Stylist selectedStylist = Stylist.Find(parameters.stylistId);
            //     return View["stylistEdit.cshtml", selectedStylist];
            // };
            //
            // // Get an id for each stylist and take you to the clicked on stylists client page
            // Get["/stylists/{id}"] = parameters => {
            //     Dictionary<string, object> model = new Dictionary<string, object>();
            //     Stylist selectedStylist = Stylist.Find(parameters.id);
            //     List<Client> addedClients = selectedStylist.GetClients();
            //     model.Add("client", addedClients);
            //     model.Add("stylist", selectedStylist);
            //     return View["clients.cshtml", model];
            // };
            // // Take the client entered and post in on the clients page
            // Post["/stylist/{id}/clients"] = parameters => {
            //     Dictionary<string, object> model = new Dictionary<string, object>();
            //     Stylist selectedStylist = Stylist.Find(Request.Form["stylist-id"]);
            //     List<Client> stylistClient = selectedStylist.GetClients();
            //     string clientEntered = Request.Form["client"];
            //     Client newClient = new Client(clientEntered, selectedStylist.GetStylistId());
            //     newClient.Save();
            //     stylistClient.Add(newClient);
            //     model.Add("client", stylistClient);
            //     model.Add("stylist", selectedStylist);
            //     return View["clients.cshtml", model];
            // };
            // //
            // Get["/stylist/{id}/client/{clientId}"] = parameters => {
            //     Dictionary<string, object> model = new Dictionary<string, object>();
            //     Stylist selectedStylist = Stylist.Find(parameters.id);
            //     List<Client> allClients = selectedStylist.GetClients();
            //     model.Add("stylist", selectedStylist);
            //     model.Add("client", allClients);
            //     return View["clients.cshtml", model];
            // };
            // // Delete a client from a client
            // Delete["/stylists/{id}/clients/{clientId}"] = parameters => {
            //     Dictionary<string, object> model = new Dictionary<string, object>();
            //     Stylist selectedStylist = Stylist.Find(parameters.id);
            //     Client specificClient = Client.Find(parameters.clientId);
            //     specificClient.Delete();
            //     List<Client> clientList = selectedStylist.GetClients();
            //     model.Add("stylist", selectedStylist);
            //     model.Add("client", clientList);
            //     return View["clients.cshtml", model];
            // };
            // // Take you to the page to edit a client
            // Get["/clients/{clientId}/edit"] = parameters => {
            //     Client selectedClient = Client.Find(parameters.clientId);
            //     return View["edit_client_form.cshtml", selectedClient];
            // };
            //
            // // Edit a client
            // Patch["/clients/{clientId}/updated"] = parameters => {
            //     Client selectedClient = Client.Find(parameters.clientId);
            //     selectedClient.Update(Request.Form["client"]);
            //     return View["client_updated.cshtml"];
            // };
        }
    }
}
