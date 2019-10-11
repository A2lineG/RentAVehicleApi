using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class ClientManager : BaseManager
    {
        /// <summary>
        /// GET CLIENT
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientDTO GetClient(Guid id)
        {
            var clientMapper = _dbContext.Clients.FirstOrDefault(x => x.Id == id);

            ClientDTO client = _mapper.Map<ClientDTO>(clientMapper);

            return client;
        }

        public ClientDTO GetClientDetail(Guid id)
        {
            var clientMapper = _dbContext.Clients.FirstOrDefault(x => x.Id == id);

            ClientDTO client = _mapper.Map<ClientDTO>(clientMapper);

            return client;
        }

        /// <summary>
        /// GET CLIENT BY MAIL
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ClientDTO GetClientByMail(string email)
        {
            var clientMapper = _dbContext.Clients.FirstOrDefault(x => x.Email == email);
            if (clientMapper == null) return null;

            ClientDTO client = _mapper.Map<ClientDTO>(clientMapper);

            return client;
        }

        /// <summary>
        /// GET LIST CLIENT
        /// </summary>
        /// <returns></returns>
        public List<ClientDTO> GetClientList()
        {
            var clientMapper = _dbContext.Clients.ToList();

            List<ClientDTO> client = _mapper.Map<List<ClientDTO>>(clientMapper);

            return client;
        }

        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="clientDto"></param>
        public void AddClient(ClientDTO clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);

            client.Id = Guid.NewGuid();

            _dbContext.Clients.Add(client);

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="clientDto"></param>
        public void UpDateClient(ClientDTO clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);

            _dbContext.Entry(client).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteClient(Guid id)
        {
            var client = _dbContext.Clients.FirstOrDefault(x => x.Id == id);

            if (client == null)
            {
                throw new Exception("Client n'existe pas");
            }

            _dbContext.Clients.Remove(client);

            _dbContext.SaveChanges();
        }
    }
}