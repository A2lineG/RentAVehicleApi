using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class OptionBookingManager : BaseManager
    {
        //private IMapper _mapper;

        //public OptionBookingManager()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<OptionBookingManager, OptionBooking>();
        //        cfg.CreateMap<OptionBooking, OptionBookingManager>();
        //    });

        //    _mapper = new Mapper(config);
        //}

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<OptionBookingDTO> GetOptionBookingList()
        {
            var dbContext = new RentAVehicleDB();

            var optionList = dbContext.OptionBookings.ToList();

            List<OptionBookingDTO> optionBooking = _mapper.Map<List<OptionBookingDTO>>(optionList);

            return optionBooking;
        }
    }
}
