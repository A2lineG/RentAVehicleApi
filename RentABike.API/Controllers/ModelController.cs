using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("Model")]
    [AllowAnonymous]
    public class ModelController : ApiController
    {
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        public List<ModelDTO> GetModelList()
        {
            ModelManager modelManager = new ModelManager();

            var model = modelManager.GetModelList();

            return model;
        }

        [HttpGet]
        [Route("ListModelByBrand")]
        public List<ModelDTO> GetModelByBrand(Guid brandId)
        {
            ModelManager modelManager = new ModelManager();

            var model = modelManager.GetModelByBrand(brandId);

            return model;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Roles = "admin")]
        public void InsertModel(ModelDTO modelDto)
        {
            ModelManager modelManager = new ModelManager();

            modelManager.InsertModel(modelDto);
        }
    }
}