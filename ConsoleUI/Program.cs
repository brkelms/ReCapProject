using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
                CarManager carManager = new CarManager(new EfCarDal());
                foreach (var cars in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(cars.CarName + "/" + cars.BrandName+"/"+cars.ColorName+"/"+cars.DailyPrice);
                }
            
            //GosterTest();
            //EklemeTest();
        }

        private static void GosterTest()
        {
            CarManager carManager = new CarManager(new InMemoryProductCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
                Console.WriteLine("-----------------------------------------------------------------------------------------");
            }
        }

        private static void EklemeTest()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Car { BrandId = 1, ColorId = 3, CarName = "Fiat Linea", ModelYear = 2018, DailyPrice = 100, Description = "Bu yeni eklediğim bir Fiat Linea" });
            foreach (var car in carManager1.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.CarName + " " + car.ColorId + " " + car.DailyPrice + " " + car.Description);
            }
        }
    }
}
