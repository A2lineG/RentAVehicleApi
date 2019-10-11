using System;

namespace RentAVehicle.BL.DTO
{
    public class OpinionDTO
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public decimal Rating { get; set; }
        
        public ClientDTO Client { get; set; }

        public VehicleDTO Vehicle { get; set; }
    }
}
