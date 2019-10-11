using System;
using System.Collections.Generic;

namespace RentAVehicle.BL.DTO
{
     public class OptionVehicleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<OptionVehicleVehicleDTO> OptionVehicleVehicles { get; set; }
    }
}
