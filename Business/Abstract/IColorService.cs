using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int Id);

        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);

    }
}
