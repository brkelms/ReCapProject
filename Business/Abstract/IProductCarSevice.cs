using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductCarSevice
    {
        List<Car> GetAll();
        List<Car> GetById(int Id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetCarsByColorId(int Id);
        List<Car> GetCarsByBrandId(int Id);
    }
}
