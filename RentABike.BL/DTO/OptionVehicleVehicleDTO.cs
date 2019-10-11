using System;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.DTO
{
    public class OptionVehicleVehicleDTO
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public Guid OptionVehicleId { get; set; }

        public VehicleDTO Vehicle { get; set; }

        public OptionVehicleDTO OptionVehicle { get; set; }
    }
}
