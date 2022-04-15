using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;


CarManager carManager = new CarManager(new EfCarDal());

foreach (var cars in carManager.GetAll())
{
    Console.WriteLine(cars.CarName);
}