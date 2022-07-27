using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id = 1,BrandId = 1, ColorId = 1,DailyPrice=450000, ModelYear=1999,Description="Sıfı Polo Acil Satılık", },
                new Car{ Id = 2,BrandId = 1, ColorId = 5,DailyPrice=325000, ModelYear=2009,Description="Sıfı Civic Acil Satılık", },
                new Car{ Id = 3,BrandId =2, ColorId = 12,DailyPrice=120000, ModelYear=2019,Description="Sıfı Golf Acil Satılık", },
                new Car{ Id = 4,BrandId =3, ColorId = 14,DailyPrice=230000, ModelYear=2018,Description="Sıfı Passat Acil Satılık", },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.FirstOrDefault(x=>x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate=_cars.FirstOrDefault(x=>x.Id==car.Id);
            carToUpdate.Id= car.Id;
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.Description=car.Description;
            carToUpdate.DailyPrice=car.DailyPrice;
        }
    }
}
