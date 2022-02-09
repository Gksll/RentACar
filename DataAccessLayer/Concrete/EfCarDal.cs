using Core.DAL.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace DataAccessLayer.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
    }
}
