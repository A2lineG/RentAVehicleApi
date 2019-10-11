using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class Client
    {
        public Client()
        {
            Opinions = new HashSet<Opinion>();
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string DriverLicenseNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public virtual ICollection<Opinion> Opinions { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
