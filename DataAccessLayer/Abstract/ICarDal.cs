using Core.DAL;
using Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}
