using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentAVehicle.DAL.Entities
{
    public class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
