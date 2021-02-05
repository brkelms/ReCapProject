using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : IProductCarSevice
    {
        IProductCarDal car;

        public CarManager(IProductCarDal carDal)
        {
            car = carDal;
        }
        public void Add(Car car)
        {
            if ((car.CarName.Length > 2) && (car.DailyPrice > 0))
            {
                Console.WriteLine(car.Id + " id'sine sahip arabanız eklendi!");
            }
            else
                Console.WriteLine("Araba ismi 2 harften fazla ve arabanın günlük fiyatı 0'dan farklı olmalıdır.");
        }
        public void Delete(Car car)
        {
            Console.WriteLine(car.Id + " id'sine sahip arabanız listeden kaldırıldı!");
        }
        public List<Car> GetAll()
        {
            return car.GetAll();
        }

        public List<Car> GetById(int Id)
        {
            throw new NotImplementedException();
        }
        //public List<Car> GetById(int Id)
        //{
        //   // return car.GetById(Id);
        //}
        public void Update(Car car)
        {
            Console.WriteLine(car.Id + " id'sine sahip arabanın özellikleri güncellendi!");
        }

        List<Car> IProductCarSevice.GetCarsByBrandId(int Id)
        {
            return car.GetAll(c => c.BrandId == Id);
        }

        List<Car> IProductCarSevice.GetCarsByColorId(int Id)
        {
            return car.GetAll(c => c.ColorId == Id);
        }
    }
}
