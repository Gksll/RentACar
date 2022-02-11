using Business.Concrete;
using Core.Utilities.Helpers;
using DataAccessLayer.Concrete;
using Entities.Concrete;

CarImageManager c = new CarImageManager(new EfCarImageDal(),new FileHelperManager());
CarImage ci = new CarImage() { CarId=9,Date=DateTime.Now,ImagePath= @"C:\Users\Red_Beard\Pictures\w" };
c.Add(ci);
foreach (var item in c.GetAll().Data)
{
    Console.WriteLine(item.Id+"-"+item.CarId+"-"+item.ImagePath+"-"+item.Date);
}