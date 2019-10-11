using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAVehicle.DAL.Entities
{
    public class OptionVehicleVehicle
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [ForeignKey("OptionVehicle")]
        public Guid OptionVehicleId { get; set; }

        public OptionVehicle OptionVehicle { get; set; }
    }
}
