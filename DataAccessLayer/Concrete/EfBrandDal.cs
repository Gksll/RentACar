using Core.DAL.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace DataAccessLayer.Concrete
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarContext>, IBrandDal
    {
    }
}
