using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        public static string ImagesPath = "wwwroot\\Uploads\\Images\\";
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            //var result=  BusinessRules.Run(CheckCarImageCount(carImage.CarId), CheckImagePath(carImage.CarId));
            //  if (result !=null)
            //  {
            //      return result;
            //  }
            if (carImage.ImagePath == String.Empty)
            {
                carImage.ImagePath = "DefaultImage.jpg";
            }
            carImage.ImagePath = _fileHelper.Upload(file, ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Add(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(GetById(carImage.Id).Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == carImageId), Messages.Get);
        }

        public IDataResult<List<CarImage>> ListImages(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), "Resimler listelendi");
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            _fileHelper.Update(file, ImagesPath + carImage.ImagePath, ImagesPath);
            CarImage ca = GetById(carImage.Id).Data;
            ca.CarId = carImage.Id;
            ca.ImagePath = carImage.ImagePath;
            ca.Date = DateTime.Now;
            _carImageDal.Update(ca);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Update(CarImage entity)
        {
            throw new NotImplementedException();
        }

        private IResult CheckCarImageCount(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult("En fazla 5 fotoğraf olabilir!");
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckImagePath(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id);
            foreach (var item in result)
            {
                if (item.ImagePath == String.Empty)
                {
                    item.ImagePath = "DefaultImage.jpg";
                }
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }
    }
}
