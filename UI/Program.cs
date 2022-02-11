using Business.Concrete;
using Core.Utilities.Helpers;
using DataAccessLayer.Concrete;
using Entities.Concrete;

CarImageManager c = new CarImageManager(new EfCarImageDal(),new FileHelperManager());
CarImage car = new CarImage() { CarId = 9, ImagePath = "" };

//c.Add(car,);

foreach (var item in c.GetAll().Data)
{
    Console.WriteLine(item.Id + "-" + item.ImagePath + "-" + item.CarId + "-" + item.Date);
}
