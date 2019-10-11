using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;
using System.Data.Entity;

namespace RentAVehicle.BL.Manager
{
    public class OpinionManager : BaseManager
    {
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<OpinionDTO> GetOpinionList()
        {
            var opinionList = _dbContext.Opinions.ToList();

            List<OpinionDTO> opinion = _mapper.Map<List<OpinionDTO>>(opinionList);

            return opinion;
        }

        /// <summary>
        /// get Opinion by client
        /// </summary>
        // GET
        public List<OpinionDTO> GetOpinionByClient(Guid clientId){
           
            var modelMapper = _dbContext.Opinions
                .Include(a => a.Vehicle)
                .Where(x => x.ClientId == clientId)
                .ToList();

            var opinionList = _mapper.Map<List<OpinionDTO>>(modelMapper);

            return opinionList;
        }
    }
}
