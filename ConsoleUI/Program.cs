using Business.Concrete;
using DataAccess.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
var result = carManager.GetCarDetail();
if (result.Success==true)
{
    foreach (var cardt in carManager.GetCarDetail().Data)
    {
        Console.WriteLine(cardt.CarName + cardt.ColorName + cardt.BrandName + cardt.DailyPrice);
    }
}
else
{
    Console.WriteLine(result.Message);
}
