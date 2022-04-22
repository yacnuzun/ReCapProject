using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

RentalManager rentalManager = new RentalManager(new EfRentalDal());
var result=rentalManager.Add(new Rental() { CarId=1,CustomerId=2,});

    Console.WriteLine(result.Message);

void GetCustomerDetail()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    var result = customerManager.GetCustomerDetail();
    if (result.Success == true)
    {
        foreach (var customers in customerManager.GetCustomerDetail().Data)
        {
            Console.WriteLine(customers.FirstName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}
void GetCarDetail()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetail();
    if (result.Success == true)
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
}
