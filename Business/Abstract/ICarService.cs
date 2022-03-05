using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService:IMethodService<Car>
    {
        IDataResult<List<CarsDto>> GetCarDto();
    }
}
