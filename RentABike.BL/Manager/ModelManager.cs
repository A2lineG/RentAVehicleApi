using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;


namespace RentAVehicle.BL.Manager
{
    public class ModelManager : BaseManager
    {

        /// <summary>
        /// GET
        /// </summary>
        public List<ModelDTO> GetModelList()
        {
            var dbContext = new RentAVehicleDB();

            var modelMapper = dbContext.Models.Include("Brand").ToList();

            List<ModelDTO> model = _mapper.Map<List<ModelDTO>>(modelMapper);

            return model;

        }

        public List<ModelDTO> GetModelByBrand(Guid brandId)
        {
            using (var dbContext = new RentAVehicleDB())
            {
                var modelBrandMapper = dbContext.Models.Where(x => x.BrandId == brandId).ToList();

                List<ModelDTO> model = _mapper.Map<List<ModelDTO>>(modelBrandMapper);

                return model;
            }
        }

        /// <summary>
        /// INSERT
        /// </summary>
        public void InsertModel(ModelDTO modelDto)
        {
            var dbContext = new RentAVehicleDB();

            Model model = _mapper.Map<Model>(modelDto);

            model.Id = Guid.NewGuid();

            model.BrandId = model.Brand.Id;

            dbContext.Models.Add(model);

            dbContext.SaveChanges();

        }

        /// <summary>
        /// UPDATE
        /// </summary>
        // UPDATE
        public void UpdateModel()
        {
            

        }

        /// <summary>
        /// DELETE
        /// </summary>
        public void DeleteModel()
        {

        }
        
    }
}
