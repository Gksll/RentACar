using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        void Add(Rental rental);
        void Delete(Rental rental);
        void Update(Rental rental);
        List<Rental> GetAll();
        Rental GetById(int rentalId);
    }
}
