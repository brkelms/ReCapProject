using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductCarDal : IProductCarDal
    {
        List<Car> cars;
        public InMemoryProductCarDal()
        {
            cars = new List<Car>
            {
                new Car{Id=1,BrandId=100,ColorId=1,CarName="Marka1",ModelYear=2010,DailyPrice=50000,Description="Bu bir Fiat"},
                new Car{Id=2,BrandId=100,ColorId=2,CarName="Marka1",ModelYear=2020,DailyPrice=140000,Description="Bu bir Opel"},
                new Car{Id=3,BrandId=200,ColorId=2,CarName="Marka2",ModelYear=2019,DailyPrice=120000,Description="Bu bir Opel"},
                new Car{Id=4,BrandId=200,ColorId=3,CarName="Marka2",ModelYear=2017,DailyPrice=140000,Description="Bu bir Opel Corsa"},
                new Car{Id=5,BrandId=300,ColorId=3,CarName="Marka3",ModelYear=2018,DailyPrice=400000,Description="Bu bir Mercedes"},
                new Car{Id=6,BrandId=300,ColorId=4,CarName="Marka3",ModelYear=2020,DailyPrice=500000,Description="Bu bir Mercedes bilmem ne"},
            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = cars.SingleOrDefault(c=>c.Id==car.Id);
            cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetAll()
        {
            return cars;
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetById(int Id)
        {
            return cars = cars.Where(c=> c.Id==Id).ToList();
        }
        public void Update(Car car)
        {
            Car carUpdate = cars.SingleOrDefault(c=> c.Id==car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
        }
    }
}
