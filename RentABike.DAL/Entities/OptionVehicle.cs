using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentAVehicle.DAL.Entities
{
    public class OptionVehicle
    {
        public OptionVehicle()
        {
            OptionVehicleVehicles = new HashSet<OptionVehicleVehicle>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<OptionVehicleVehicle> OptionVehicleVehicles { get; set; }
    }
}
