using AutoMapper;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class BaseManager
    {
        protected IMapper _mapper;
        protected RentAVehicleDB _dbContext;

        public BaseManager()
        {
            _dbContext = new RentAVehicleDB();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking, BookingDTO>().ReverseMap();
                cfg.CreateMap<Brand, BrandDTO>().ReverseMap();
                cfg.CreateMap<ModelDTO, Model>().ReverseMap();
                cfg.CreateMap<Opinion, OpinionDTO>().ReverseMap();
                cfg.CreateMap<OptionBookingBooking, OptionBookingBookingDTO>().ReverseMap();
                cfg.CreateMap<OptionBooking, OptionBookingDTO>().ReverseMap();
                cfg.CreateMap<OptionVehicle, OptionVehicleDTO>().ReverseMap();
                cfg.CreateMap<OptionVehicleVehicle, OptionVehicleVehicleDTO>().ReverseMap();
                cfg.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
                cfg.CreateMap<PeriodCoefficient, PeriodCoefficientDTO>().ReverseMap();
                cfg.CreateMap<AgeCoefficient, AgeCoefficientDTO>().ReverseMap();
                cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                cfg.CreateMap<Depot, DepotDTO>().ReverseMap();
                cfg.CreateMap<Maintenance, MaintenanceDTO>().ReverseMap();
            });

            _mapper = new Mapper(config);
        }
    }
}
