using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfColorDal:EfEntityRepositoryBase<Color,ReCapDbContext>,IColorDal
    {

    }
}
