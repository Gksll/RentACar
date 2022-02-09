using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        void Add(CarImage carImage);
        void Delete(CarImage carImage);
        void Update(CarImage carImage);
        List<CarImage> GetAll();
        CarImage GetById(int carImageId);
    }
}
