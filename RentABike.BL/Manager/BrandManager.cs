using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class BrandManager : BaseManager
    {

        //GET
        public List<BrandDTO> GetBrandList()
        {
            using (RentAVehicleDB dbContext = new RentAVehicleDB())
            {
                var brandList = dbContext.Brands.ToList();

                List<BrandDTO> brandDtoList = _mapper.Map<List<BrandDTO>>(brandList);

                return brandDtoList;
            }
        }


        //INSERT
        public void InsertBrand(BrandDTO brandDTO)
        {
            RentAVehicleDB dbContext = new RentAVehicleDB();

            Brand brand = Mapper.Map<Brand>(brandDTO);

            brand.Id = Guid.NewGuid();

            dbContext.Brands.Add(brand);
            dbContext.SaveChanges();
        }



        //UPDATE
        public void UpdateBrand(Guid brandId)
        {
            RentAVehicleDB dbContext = new RentAVehicleDB();

            var brand = dbContext.Brands.FirstOrDefault(x => x.Id == brandId);

        }



        //DELETE
        public void DeleteBrand(Guid brandId)
        {
            RentAVehicleDB dbContext = new RentAVehicleDB();

            var brand = dbContext.Brands.SingleOrDefault(x => x.Id == brandId);

            if (brand == null)
            {
                throw new KeyNotFoundException();
            }

            dbContext.Brands.Remove(brand);
            dbContext.SaveChanges();
        }

    }
}
