using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService:IMethodService<Rental>
    {
        IDataResult<List<RentalDto>> RentalDto();
    }
}
