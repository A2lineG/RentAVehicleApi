using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class VehicleManager : BaseManager
    {
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<VehicleDTO> GetVehicleList()
        {
            var vehicleList = _dbContext.Vehicles
                                        .Include(x => x.Model.Brand).ToList();

            List<VehicleDTO> vehicleDtoList = _mapper.Map<List<VehicleDTO>>(vehicleList);

            return vehicleDtoList;
        }
        /// <summary>
        /// GET WITH filtered
        /// </summary>
        /// <returns></returns>
        public List<VehicleDTO> GetVehicleList(Guid? brandId, Guid? modelId)
        {
            var vehicleList = _dbContext.Vehicles    
                                .Include(x => x.Model.Brand)
                                .Include(x => x.OptionVehicleVehicles.Select(y => y.OptionVehicle));

            if (modelId.HasValue)
            {
                vehicleList = vehicleList.Where(v => v.Model.Id == modelId);
            } else if (brandId.HasValue)
            {
                vehicleList = vehicleList.Where(v => v.Model.Brand.Id == brandId);
            }

            List<VehicleDTO> vehicleDtoList = _mapper.Map<List<VehicleDTO>>(vehicleList);

            return vehicleDtoList;
        }

        /// <summary>
        /// CREATE VEHICLE
        /// </summary>
        public Guid CreateVehicle(VehicleDTO vehicleDto)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);

            vehicle.Id = Guid.NewGuid();

            foreach (var optionVehicleVehicle in vehicle.OptionVehicleVehicles)
            {
                optionVehicleVehicle.Id = Guid.NewGuid();
                optionVehicleVehicle.VehicleId = vehicle.Id;
            }

            _dbContext.Vehicles.Add(vehicle);
            
            _dbContext.SaveChanges();

            return vehicle.Id;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="idVehicle"></param>
        /// <returns></returns>
        public void DeleteVehicle(Guid id)
        {
            var vehicle = _dbContext.Vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
            {
                throw new Exception("Véhicule n'existe pas");
            }

            _dbContext.Vehicles.Remove(vehicle);

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// DETAIL
        /// </summary>
        /// <param name="idVehicle"></param>
        /// <returns></returns>
        public VehicleDTO GetVehicleDetail(Guid idVehicle)
        {
            var dbContext = new RentAVehicleDB();

            var vehicle = dbContext.Vehicles
                                    .Include(x => x.Model.Brand)
                                    .Include(x => x.OptionVehicleVehicles.Select(y => y.OptionVehicle))
                                    .Include(x => x.Maintenances)
                                    .FirstOrDefault(x => x.Id == idVehicle);

            VehicleDTO vehicleDto = _mapper.Map<VehicleDTO>(vehicle);

            return vehicleDto;
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        public void UpdateVehicle(VehicleDTO vehicleDto)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);

            foreach (var optionVehicleVehicle in vehicle.OptionVehicleVehicles)
            {
                if (optionVehicleVehicle.Id == Guid.Empty)
                {
                    // insert
                    optionVehicleVehicle.Id = Guid.NewGuid();
                    _dbContext.Entry(optionVehicleVehicle).State = EntityState.Added;
                }
            }

            _dbContext.Entry(vehicle).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
    }
}
