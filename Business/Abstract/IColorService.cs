﻿using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);
        List<Color> GetAll();
        Color GetById(int colorId);
    }
}