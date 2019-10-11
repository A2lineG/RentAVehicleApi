using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class DepotManager : BaseManager
    {
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<DepotDTO> GetDepotList()
        {
            var dbContext = new RentAVehicleDB();
            
            var depotList = dbContext.Depots.ToList();

            List<DepotDTO> depot = _mapper.Map<List<DepotDTO>>(depotList);

            return depot;
        }

        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="depotDto"></param>
        public void InsertDepot(DepotDTO depotDto)
        {
            var dbContext = new RentAVehicleDB();

            Depot depot = _mapper.Map<Depot>(depotDto);

            depot.Id = Guid.NewGuid();

            dbContext.Depots.Add(depot);

            dbContext.SaveChanges();
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="depotDto"></param>
        public void UpdateDepot(DepotDTO depotDto)
        {
            var dbContext = new RentAVehicleDB();

            Depot depot = _mapper.Map<Depot>(depotDto);

            dbContext.Depots.Attach(depot);

            dbContext.SaveChanges();
            
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDepot(Guid id)
        {
            var dbContext = new RentAVehicleDB();

            var depot = dbContext.Depots.FirstOrDefault(x => x.Id == id);

            if (depot == null)
            {
                throw new Exception("Depot n'existe pas");
            }

            dbContext.Depots.Remove(depot);

            dbContext.SaveChanges();
        }


    }
}
