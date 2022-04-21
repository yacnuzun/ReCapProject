using Business.Concrete;
using DataAccess.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
foreach (var cardt in carManager.GetProductDetail())
{
    Console.WriteLine(cardt.CarName+cardt.ColorName+cardt.BrandName+cardt.DailyPrice);
}