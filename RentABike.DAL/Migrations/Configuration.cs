using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RentAVehicleDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentAVehicleDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // MARQUE
            if (!context.Brands.Any() && !context.Models.Any())
            {
                var id = Guid.NewGuid();
                context.Brands.Add(new Brand { Id = id, Name = "Honda" });

                var idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 600, DistanceMax = 200, Name = "CBR 600", Price = 20, Weight = 160, PictureLink = "https://www.motoplanete.com/honda/zoom-700px/CBR-600-RR-2004-700px.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "GUDFJ84051gf", PlateNumber = "EE8841"});

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 1000, DistanceMax = 200, Name = "CBR 1000", Price = 25, Weight = 160, PictureLink = "https://www.motoplanete.com/honda/zoom-700px/Honda-CBR-1000-RR-Fireblade-2019-700px.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "sfefzeg540", PlateNumber = "EE8840" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 2000, DistanceMax = 200, Name = "Civic", Price = 30, Weight = 1300, PictureLink = "https://www.primehonda128.com/assets/stock/colormatched_01/white/640/cc_2019hoc02_01_640/cc_2019hoc020087_01_640_wx.jpg?height=400" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "FZEGZEZF4451", PlateNumber = "EE8839" });

                id = Guid.NewGuid();
                context.Brands.Add(new Brand { Id = id, Name = "Yamaha" });
                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 700, DistanceMax = 200, Name = "MT07", Price = 15, Weight = 160, PictureLink = "https://cdn2.yamaha-motor.eu/prod/product-assets/2019/MT07/2019-Yamaha-MT07-EU-Yamaha_Blue-Studio-001-03.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "OPKIZEFN4512", PlateNumber = "EE8838" });

                id = Guid.NewGuid();
                context.Brands.Add(new Brand { Id = id, Name = "Audi" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 1800, DistanceMax = 200, Name = "A3", Price = 40, Weight = 1400, PictureLink = "https://images.caradisiac.com/images/4/4/2/4/174424/S1-audi-a3-une-serie-limitee-sport-limited-581473.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "RGKLB112", PlateNumber = "EJ5541" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 2000, DistanceMax = 200, Name = "A5", Price = 60, Weight = 1400, PictureLink = "https://i.gaw.to/content/photos/33/57/335762_2018_Audi_A5.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "MOIKU151", PlateNumber = "EJ5500" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 3000, DistanceMax = 200, Name = "TT", Price = 70, Weight = 1300, PictureLink = "https://www.autoscout24.be/assets/auto/images/model/audi/audi-tt/audi-tt-m-02.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "MMIRTEF481", PlateNumber = "EE4851" });

                id = Guid.NewGuid();
                context.Brands.Add(new Brand { Id = id, Name = "BMW" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 1800, DistanceMax = 200, Name = "Série 3", Price = 50, Weight = 1400, PictureLink = "https://img-4.linternaute.com/MdvwX_aaTgdqBx9n0P_89YByHtE=/1240x/smart/fd849892ac194474adee1a3a44c0f48d/ccmcms-linternaute/10980317.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "4784DF1G0E", PlateNumber = "JS4512" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 2000, DistanceMax = 200, Name = "Série 4", Price = 60, Weight = 1400, PictureLink = "https://cdn.drivek.it/configurator-covermobile/cars/fr/500/BMW/SERIES-4/31202_BERLINE-A-HAYON-5-PORTES/bmw-series-4-gran-coupe-mobile-cover.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "4840DF5HE4F1", PlateNumber = "JY4100" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 3000, DistanceMax = 200, Name = "Z4", Price = 70, Weight = 1300, PictureLink = "https://www.sudinfo.be/sites/default/files/dpistyles_v2/ena_sp_16_9_illustration_principale/2018/09/19/node_75596/29583596/public/2018/09/19/B9716973172Z.1_20180919110755_000+G2NC2I3GI.1-0.jpg?itok=vwDOv7Ca" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "GDFG84051ZERF", PlateNumber = "LI1200" });

                id = Guid.NewGuid();
                context.Brands.Add(new Brand { Id = id, Name = "Mercedes" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "GFDGH5410", PlateNumber = "MO4504" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 1800, DistanceMax = 200, Name = "Classe A", Price = 43, Weight = 1400, PictureLink = "https://res.cloudinary.com/gocar/image/upload/f_auto,q_auto,w_970,h_546/news/2018/05/2018mercedesaclasslarge.jpg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "POLUI40UJY", PlateNumber = "MP5044" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 2000, DistanceMax = 200, Name = "Classe C", Price = 54, Weight = 1400, PictureLink = "https://www.mercedes-benz.be/fr/passengercars/mercedes-benz-cars/models/c-class/saloon/equipment/equipment_line_comparison/_jcr_content/comparisonslider/par/comparisonslide_7143/exteriorImage.MQ6.12.20180731095014.jpeg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "4840KYJL80R", PlateNumber = "OK4501" });

                idMod = Guid.NewGuid();
                context.Models.Add(new Model { Id = idMod, BrandId = id, Displacement = 3000, DistanceMax = 200, Name = "CLS", Price = 80, Weight = 1300, PictureLink = "https://www.mercedes-benz.be/fr/passengercars/mercedes-benz-cars/models/cls/coupe/facts-and-lines/equipment-lines/_jcr_content/comparisonslider/par/comparisonslide_426c/exteriorImage.MQ6.12.20171207180759.jpeg" });
                context.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), ModelId = idMod, Year = 2018, Mileage = 1500, ChassisNumber = "ASDG041GH", PlateNumber = "LJ4500" });

                context.SaveChanges();
            }

            // DEPOT
            if (!context.Depots.Any())
            {
                context.Depots.Add(new Depot { Id = Guid.NewGuid(), Name = "Arlon", City = "Arlon" });
                context.Depots.Add(new Depot { Id = Guid.NewGuid(), Name = "Liege", City = "Liege" });
                context.Depots.Add(new Depot { Id = Guid.NewGuid(), Name = "Bruxelles", City = "Bruxelles" });
                context.Depots.Add(new Depot { Id = Guid.NewGuid(), Name = "Anvers", City = "Anvers" });
                context.Depots.Add(new Depot { Id = Guid.NewGuid(), Name = "Charleroi", City = "Charleroi" });

                context.SaveChanges();
            }


            //CLIENT
            if (!context.Clients.Any())
            {
                context.Clients.Add(new Client
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Parse("1987-09-02"),
                    DriverLicenseNumber = "XX JJJDD",
                    Email = "Sasuke@gmail.com",
                    FirstName = "Uchiha",
                    Surname = "Sasuke",
                    Password = "joker"
                });

                context.Clients.Add(new Client
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Parse("1965-03-22"),
                    DriverLicenseNumber = "XX JJJDD",
                    Email = "Naruto@gmail.com",
                    FirstName = "Uzumaki",
                    Surname = "Naruto",
                    Password = "joker"
                });

                context.Clients.Add(new Client
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Parse("1998-11-02"),
                    DriverLicenseNumber = "XX JJJDD",
                    Email = "SonGoku@gmail.com",
                    FirstName = "Goku",
                    Surname = "Son",
                    Password = "joker"
                });

                context.SaveChanges();
            }


            // RESERVATION
            if (!context.OptionBookings.Any())
            {
                context.OptionBookings.Add(new OptionBooking
                {
                    Id = Guid.NewGuid(),
                    Name = "Assurance Omnium",
                    IsFixedPrice = false,
                    PriceValue = 10
                });

                context.OptionBookings.Add(new OptionBooking
                {
                    Id = Guid.NewGuid(),
                    Name = "Assurance Vol",
                    IsFixedPrice = false,
                    PriceValue = 3
                });

                context.OptionBookings.Add(new OptionBooking
                {
                    Id = Guid.NewGuid(),
                    Name = "Assurance Annulation",
                    IsFixedPrice = true,
                    PriceValue = 15
                });

                context.SaveChanges();
            }


            // AGE COEFFICIENT
            if (!context.AgeCoefficients.Any())
            {
                context.AgeCoefficients.Add(new AgeCoefficient
                {
                    Id = Guid.NewGuid(),
                    StartAge = 18,
                    EndAge = 24,
                    Percentage = 10
                });

                context.AgeCoefficients.Add(new AgeCoefficient
                {
                    Id = Guid.NewGuid(),
                    StartAge = 25,
                    EndAge = 28,
                    Percentage = 5
                });

                context.AgeCoefficients.Add(new AgeCoefficient
                {
                    Id = Guid.NewGuid(),
                    StartAge = 29,
                    EndAge = 55,
                    Percentage = -5
                });

                context.AgeCoefficients.Add(new AgeCoefficient
                {
                    Id = Guid.NewGuid(),
                    StartAge = 56,
                    EndAge = 99,
                    Percentage = 6
                });

                context.SaveChanges();
            }

            // PERIOD COEFFICIENT
            if (!context.PeriodCoefficients.Any())
            {
                context.PeriodCoefficients.Add(new PeriodCoefficient
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(6)
                });

                context.SaveChanges();
            }


            //OPTIONS VEHICULE
            if (!context.OptionVehicles.Any())
            {
                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "Boite automatique",
                });

                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "Siège chauffant",
                });

                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "Phare Led",
                });

                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "Assistance parking",
                });

                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "GPS",
                });

                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "Aide vocal",
                });

                context.OptionVehicles.Add(new OptionVehicle
                {
                    Id = Guid.NewGuid(),
                    Name = "Régulateur de vitesse",
                });
            }

            // Option vehicules vehicles


            // AVIS



            // roles
            using (var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context)))
            {
                using (var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    //system Role
                    if (!roleManager.RoleExists("admin"))
                    {
                        roleManager.Create(new IdentityRole("admin"));
                    }
                    if (!roleManager.RoleExists("user"))
                    {
                        roleManager.Create(new IdentityRole("user"));
                    }

                    if (!userManager.Users.Any(x => x.UserName == "admin"))
                    {
                        var admin = new IdentityUser() { UserName = "admin" };
                        if (userManager.Create(admin, "admin123") != IdentityResult.Success)
                        {
                            throw new Exception("failed");
                        }

                        userManager.AddToRole(admin.Id, "admin");
                    }

                    if (!userManager.Users.Any(x => x.UserName == "user"))
                    {
                        var user = new IdentityUser() {UserName = "user"};
                        if (userManager.Create(user, "user1234") != IdentityResult.Success)
                        {
                            throw new Exception("Failed");
                        }

                        userManager.AddToRole(user.Id, "user");
                    }
                    
                    context.SaveChanges();
                }
            }
        }
    }
}
