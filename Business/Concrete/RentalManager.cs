using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult AddTransactionalTest(Rental entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(GetById(rental.Id).Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDto>> RentalDto()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.rentalDtos());
        }

        public IResult Update(Rental rental)
        {
            Rental r = GetById(rental.Id).Data;
            r.Id = rental.Id;
            r.ReturnDate = rental.ReturnDate;
            r.RentDate = rental.RentDate;
            r.CustomerId = rental.CustomerId;
            r.CarId = rental.CarId;
            _rentalDal.Update(r);
            return new SuccessResult();
        }
    }
}
