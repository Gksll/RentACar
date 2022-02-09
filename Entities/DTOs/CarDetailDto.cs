﻿using Core.Entities;

namespace Entities.Concrete
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int ModelYear { get; set; }
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
