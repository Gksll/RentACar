using Core.DAL;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccessLayer.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        public List<RentalDto> rentalDtos();
    }
}
