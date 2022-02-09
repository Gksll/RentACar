using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int customerId);
    }
}
