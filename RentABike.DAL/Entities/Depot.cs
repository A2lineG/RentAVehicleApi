using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAVehicle.DAL.Entities
{
    public class Depot
    {
        public Depot()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
