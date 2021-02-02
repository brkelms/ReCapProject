using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            Console.WriteLine(car.Id + " id'sine sahip arabanız eklendi!");
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
            return car.GetById(Id);
        }
        public void Update(Car car)
        {
            Console.WriteLine(car.Id + " id'sine sahip arabanın özellikleri güncellendi!");
        }
    }
}
