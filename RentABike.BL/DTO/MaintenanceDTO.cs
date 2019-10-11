using System;

namespace RentAVehicle.BL.DTO
{
    public class MaintenanceDTO
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Comment { get; set; }

        public Guid VehicleId { get; set; }

        public VehicleDTO Vehicle { get; set; }
    }
}
