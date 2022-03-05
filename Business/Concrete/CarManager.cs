using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
          _CarDal.Add(car);
            return new SuccessResult(Messages.Added);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            _CarDal.Delete(GetById(car.CarId).Data);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_CarDal.Get(c => c.CarId == carId),Messages.Get);
        }

        public IDataResult<List<CarsDto>> GetCarDto()
        {
            return new SuccessDataResult<List<CarsDto>>(_CarDal.GetCars());
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            Car c = GetById(car.CarId).Data;
            c.CarId = car.CarId;
            c.CarName = car.CarName;
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
