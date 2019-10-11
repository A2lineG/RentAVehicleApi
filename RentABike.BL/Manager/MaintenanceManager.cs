using System;
using System.Collections.Generic;
using System.Linq;
using RentAVehicle.BL.DTO;
using System.Data.Entity;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class MaintenanceManager : BaseManager
    {

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<MaintenanceDTO> GetMaintenanceByDate(DateTime startDate, DateTime endDate)
        {
            var maintenanceList = _dbContext.Maintenances
                                            .Include(x => x.Vehicle)
                                            .Where(x => x.Start <= endDate && x.Start >= startDate )
                                            .ToList();

            List<MaintenanceDTO> maintenanceDtoList = _mapper.Map<List<MaintenanceDTO>>(maintenanceList);

            return maintenanceDtoList;
        }

        /// <summary>
        /// CREATE MAINTENANCE
        /// </summary>
        public MaintenanceDTO CreateMaintenance(MaintenanceDTO maintenanceDto)
        {
            Maintenance maintenance = _mapper.Map<Maintenance>(maintenanceDto);

            maintenance.Id = new Guid();

            _dbContext.Maintenances.Add(maintenance);

            _dbContext.SaveChanges();

            return _mapper.Map<MaintenanceDTO>(maintenance);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="maintenanceId"></param>
        /// <returns></returns>
        public void DeleteMaintenance(Guid maintenanceId)
        {
            var maitnenance = _dbContext.Maintenances.FirstOrDefault(x => x.Id == maintenanceId);

            if (maitnenance == null)
            {
                throw new Exception("Cet entretien n'existe pas...");
            }

            _dbContext.Maintenances.Remove(maitnenance);

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="maintenanceDto"></param>
        /// <returns></returns>
        public MaintenanceDTO UpdateMaintenance(MaintenanceDTO maintenanceDto)
        {
            Maintenance maintenance = _mapper.Map<Maintenance>(maintenanceDto);

            _dbContext.Entry(maintenance).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return _mapper.Map<MaintenanceDTO>(maintenance);
        }
    }
}
