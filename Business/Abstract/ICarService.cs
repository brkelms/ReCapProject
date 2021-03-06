﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int Id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetCarsByColorId(int Id);
        IDataResult<List<Car>> GetCarsByBrandId(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDtoLarge>> GetCarsDetails();
        IDataResult<List<CarDetailDtoLarge>> GetCarsLargeByBrandId(int id);
        IDataResult<List<CarDetailDtoLarge>> GetCarsLargeByColorId(int id);
        IDataResult<List<CarDetailDtoLarge>> GetCarsLargeByCarId(int id);
    }
}
