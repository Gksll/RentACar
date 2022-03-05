using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult AddTransactionalTest(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(GetById(customer.Id).Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId),Messages.Get);
        }

        public IResult Update(Customer customer)
        {
            Customer c = GetById(customer.Id).Data;
            c.CompanyName = customer.CompanyName;
            c.Id = customer.Id;
            c.UserId = customer.UserId;
            _customerDal.Update(c);
            return new SuccessResult(Messages.Updated);
        }
    }
}
