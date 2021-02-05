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
            //CarManager carManager = new CarManager(new InMemoryProductCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id+" "+car.BrandId+" "+car.ColorId+" "+ car.ModelYear+" "+car.DailyPrice+" "+car.Description);
            //    Console.WriteLine("-----------------------------------------------------------------------------------------");
            //}

            CarManager carManager1 = new CarManager(new EfCarDal());
            //carManager1.Add(new Car {Id=7, BrandId=1, ColorId=3, ModelYear=2018, DailyPrice=100, Description="Bu yeni eklediğim bir araba" });
            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.ReadKey();
        }
    }
}
