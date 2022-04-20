using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int Id);
        List<Brand> GetCarsByBrandId(int id);
        List<Brand> GetCarsByColorId(int id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);

    }
}
