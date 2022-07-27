using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            
            using(ReCapContext context = new ReCapContext())
            {
                if(car.Description.Count() < 2)
                {
                    Console.Error.WriteLine("Arabanın ismi minimum 2 harf olmalıdır");
                    
                }
                else if(car.DailyPrice <= 0)
                {
                    Console.Error.WriteLine("Arabanın fiyatı 0 dan büyük olmalıdır");
                }
                else
                {
                    var addedEntity = context.Entry(car);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                
            }
        }

        public void Delete(Car car)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().FirstOrDefault(filter);
            }
        }

        

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car car)
        {
            using(ReCapContext context = new ReCapContext())
            {
                context.Cars.Update(car);
            }
        }
    }
}
