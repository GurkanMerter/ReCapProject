using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(a=>a.Id == id);
        }

        List<Car> ICarService.GetByBrandId(int brandId)
        {
            return _carDal.GetAll(a=>a.BrandId == brandId);
        }

        List<Car> ICarService.GetByColorId(int colorId)
        {
            return _carDal.GetAll(a => a.ColorId == colorId);
        }
    }
}
