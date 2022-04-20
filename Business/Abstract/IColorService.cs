using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int Id);
        List<Color> GetCarsByBrandId(int id);
        List<Color> GetCarsByColorId(int id);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);

    }
}
