using System;
using System.Collections.Generic;

namespace RentAVehicle.BL.DTO
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }

        public int Year { get; set; }

        public int Mileage { get; set; }

        public Guid ModelId { get; set; }

        public string PlateNumber { get; set; }

        public string ChassisNumber { get; set; }

        //Opinion
        public decimal? OpinionAverage { get; set; }
        
        // Options
        public List<string> OptionNames { get; set; }

        public List<OptionVehicleVehicleDTO> OptionVehicleVehicles { get; set; }

        public ModelDTO Model { get; set; }

        public List<MaintenanceDTO> Maintenances { get; set; }
    }
}
