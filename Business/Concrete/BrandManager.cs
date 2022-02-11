using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(GetById(brand.BrandId).Data);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == brandId), Messages.Get);
        }

        public IResult Update(Brand brand)
        {
            Brand b = GetById(brand.BrandId).Data;
            b.BrandId = brand.BrandId;
            b.BrandName = brand.BrandName;
            _brandDal.Update(b);
            return new SuccessResult(Messages.Updated);
        }
    }
}
