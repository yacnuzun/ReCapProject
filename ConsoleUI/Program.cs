using Business.Concrete;
using DataAccess.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.CarName);
}
Console.WriteLine("hello");