using RentAVehicle.DAL.Entities;

namespace RentAVehicle.DAL
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class RentAVehicleDB : IdentityDbContext<IdentityUser>
    {
        public RentAVehicleDB()
            : base("name=RentAVehicleDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<AgeCoefficient> AgeCoefficients { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Opinion> Opinions { get; set; }

        public virtual DbSet<OptionBooking> OptionBookings { get; set; }

        public virtual DbSet<OptionBookingBooking> OptionBookingBookings { get; set; }

        public virtual DbSet<OptionVehicle> OptionVehicles { get; set; }

        public virtual DbSet<OptionVehicleVehicle> OptionVehicleVehicles { get; set; }

        public virtual DbSet<PeriodCoefficient> PeriodCoefficients { get; set; }
        
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<Depot> Depots { get; set; }

        public virtual DbSet<Maintenance> Maintenances { get; set; }
    }
}