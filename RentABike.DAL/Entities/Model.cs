using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class Model
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Displacement { get; set; }

        public decimal Weight { get; set; }

        public decimal Price { get; set; }

        public decimal IncreasePrice { get; set; }  

        public decimal DistanceMax { get; set; }

        public string PictureLink { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }

        public Brand Brand { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
