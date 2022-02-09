using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        List<Brand> GetAll();
        Brand GetById(int cbrandId);
    }
}
