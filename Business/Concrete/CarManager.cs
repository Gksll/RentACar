using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public IResult Add(Car car)
        {
            _CarDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _CarDal.Delete(GetById(car.CarId).Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_CarDal.Get(c => c.CarId == carId),Messages.Get);
        }

        public IResult Update(Car car)
        {
            Car c = GetById(car.CarId).Data;
            c.CarId = car.CarId;
            c.ModelName = car.ModelName;
            c.ModelYear = car.ModelYear;
            c.Description = car.Description;
            c.DailyPrice = car.DailyPrice;
            c.BrandId = car.BrandId;
            c.ColorId = car.ColorId;
            _CarDal.Update(c);
            return new SuccessResult(Messages.Updated);
        }
    }
}
