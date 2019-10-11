using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("Client")]
    [AllowAnonymous]
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("Detail")]
        [AllowAnonymous]
        public ClientDTO GetClientDetail(Guid id)
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClient(id);

            return client;
        }


        /// <summary>
        /// detail by user logged
        /// </summary>
        /// <param name="vehicleDto"></param>

        [HttpGet]
        [Route("DetailClientByLoggedUser")]
        public ClientDTO GetDetailClientByLoggedUser()
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClientByMail(User.Identity.Name);
            

            var clientDetail = clientManager.GetClientDetail(client.Id);

            return clientDetail;
        }



        [HttpGet]
        [Route("List")]
        public List<ClientDTO> GetClientList()
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClientList();

            return client;
        }

        [HttpPost]
        [Route("Add")]
        public void AddClient(ClientDTO client)
        {
            ClientManager clientManager = new ClientManager();

            clientManager.AddClient(client);
        }

        [HttpPut]
        [Route("Update")]
        public void UpDateClient(ClientDTO client)
        {
            ClientManager clientManager = new ClientManager();

            clientManager.UpDateClient(client);
        }

        [HttpDelete]
        [Route("Delete")]
        public void DeleteClient(Guid id)
        {
            ClientManager clientManager = new ClientManager();

            clientManager.DeleteClient(id);
        }
    }
}