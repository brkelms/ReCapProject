using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryProductCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id+" "+car.BrandId+" "+car.ColorId+" "+ car.ModelYear+" "+car.DailyPrice+" "+car.Description);
                Console.WriteLine("-----------------------------------------------------------------------------------------");
            }
            Console.ReadKey();
        }
    }
}
