using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class OptionVehicleManager : BaseManager
    {

        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<OptionVehicleDTO> GetOptionVehicleList()
        {
            var dbContext = new RentAVehicleDB();

            var optionList = dbContext.OptionVehicles.ToList();

            List<OptionVehicleDTO> optionVehicle = _mapper.Map<List<OptionVehicleDTO>>(optionList);

            return optionVehicle;
        }
        

    }
}
