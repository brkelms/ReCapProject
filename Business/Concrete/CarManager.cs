using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : IProductCarSevice
    {
        IProductCarDal _carDal;

        public CarManager(IProductCarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if ((car.CarName.Length > 2) && (car.DailyPrice > 0))
            {
                _carDal.Add(car);
                Console.WriteLine(car.Id + " id'sine sahip arabanız eklendi!");
            }
            else
                Console.WriteLine("Araba ismi 2 harften fazla ve arabanın günlük fiyatı 0'dan farklı olmalıdır.");
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Id + " id'sine sahip arabanız listeden kaldırıldı!");
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetById(int Id)
        {
            return _carDal.GetAll(c => c.Id == Id);
        }

        public List<CarDetailDto> GetProductDetails()
        {
            return _carDal.GetProductDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.Id + " id'sine sahip arabanın özellikleri güncellendi!");
        }

        List<Car> IProductCarSevice.GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(c => c.BrandId == Id);
        }

        List<Car> IProductCarSevice.GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(c => c.ColorId == Id);
        }
    }
}
