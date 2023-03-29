using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(CarValidatior))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(a => a.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(a => a.BrandId == brandId));
        }



        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(a => a.ColorId == colorId));
        }


    }
}
