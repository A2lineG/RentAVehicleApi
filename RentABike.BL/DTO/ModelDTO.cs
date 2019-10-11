using System;

namespace RentAVehicle.BL.DTO
{
    public class ModelDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Displacement { get; set; }

        public decimal Weight { get; set; }

        public decimal Price { get; set; }

        public decimal IncreasePrice { get; set; }

        public decimal DistanceMax { get; set; }

        public string PictureLink { get; set; }

        public Guid BrandId { get; set; }

        public BrandDTO Brand { get; set; }
    }
}
