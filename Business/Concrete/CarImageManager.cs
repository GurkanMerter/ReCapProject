using Business.Abstract;
using Business.Constants;
using Core.Helpers.FileHelper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file,CarImage carImage)
        {
            

            IResult result = BusinessRules.Run(CheckForImageLimit(carImage.CarId));

            if(result != null)
            {
                return result;
            }

            carImage.Path = _fileHelper.Upload(file, PathConstants.ImagesPath);         //lokalde
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);                                                 //vtde

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.Path);
            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p=>p.Id== id));
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            _fileHelper.Update(file, PathConstants.ImagesPath + carImage.Path, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckImageExists(id));
            if(result != null) 
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId== id));
        }

        // bussines rules

        public IResult CheckForImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId== carId).Count;

            if(result>=5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }

        public IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId== carId).Count;

            if (result > 0)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, Path = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }


    }
}
