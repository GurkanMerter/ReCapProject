using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{ Id = 1,BrandId = 1, ColorId = 1,DailyPrice=450000, ModelYear=1999,Description="Polo", },
                new Car{ Id = 2,BrandId = 1, ColorId = 5,DailyPrice=325000, ModelYear=2009,Description="Civic", },
                new Car{ Id = 3,BrandId =2, ColorId = 12,DailyPrice=120000, ModelYear=2019,Description="Golf", },
                new Car{ Id = 4,BrandId =3, ColorId = 14,DailyPrice=230000, ModelYear=2018,Description="Passat", },
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(x => x.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
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
