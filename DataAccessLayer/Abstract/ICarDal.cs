using Core.DAL;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
       public List<CarsDto> GetCars();
    }
}
