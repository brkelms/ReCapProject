﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarNoImage(carId));
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId)); 
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.ImageId == carImage.ImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarNoImage(int carId)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\DataAccess\Images\default.jpg");
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            }
            else
                return result;

           
        }
    }
}