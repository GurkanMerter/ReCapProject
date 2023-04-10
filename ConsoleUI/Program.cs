using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal(),new ColorManager(new EfColorDal()));

            foreach (var c in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(c.CarName + " / " + c.BrandName + " / " + c.ColorName + " / " + c.DailyPrice);
                
            }

        }
    }
}
