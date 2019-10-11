using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("Vehicle")]
    [AllowAnonymous]
    public class VehicleController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public List<VehicleDTO> GetVehicleList()
        {
            VehicleManager vehicleManager = new VehicleManager();

            var vehicleList = vehicleManager.GetVehicleList();

            return vehicleList;
        }

        [HttpGet]
        [Route("Filtered/{brandId?}/{modelId?}")]
        public List<VehicleDTO> GetVehicleListFiltered(Guid? brandId = null, Guid? modelId = null)
        {
            VehicleManager vehicleManager = new VehicleManager();

            var vehicleList = vehicleManager.GetVehicleList(brandId, modelId);

            return vehicleList;
        }


        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public Guid AddVehicle(VehicleDTO vehicleDto)
        {
            VehicleManager vehicleManager = new VehicleManager();

            return vehicleManager.CreateVehicle(vehicleDto);
        }

        [HttpGet]
        [Route("Detail")]
        public VehicleDTO GetVehicleDetail(Guid id)
        {
            VehicleManager vehicleManager = new VehicleManager();

            var vehicleDetail = vehicleManager.GetVehicleDetail(id);

            return vehicleDetail;
        }

        [Route("Update")]
        public void UpdateVehicle(VehicleDTO vehicle)
        {
            VehicleManager vehicleManager = new VehicleManager();

            vehicleManager.UpdateVehicle(vehicle);
        }

    }
}