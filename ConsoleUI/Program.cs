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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var kiralamalar in rentalManager.GetAll().Data)
            {
                Console.WriteLine(kiralamalar.RentalId+ " / "+kiralamalar.CustomerId + " / " + kiralamalar.CarId + " / " + kiralamalar.RentDate+" / "+kiralamalar.ReturnDate );
            }
            //ArabaDetaylarınıGöster();
            //GosterTest();
           //EklemeTest();
        }

        private static void ArabaDetaylarınıGöster()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(cars.CarName + "/" + cars.BrandName + "/" + cars.ColorName + "/" + cars.DailyPrice);
            }
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
            carManager1.Add(new Car { BrandId = 1, ColorId = 2, CarName = "Fiat Sedan", ModelYear = 2015, DailyPrice = 60, Description = "Bu yeni eklediğim bir Fiat Sedan" });
            foreach (var car in carManager1.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.CarName + " " + car.ColorId + " " + car.DailyPrice + " " + car.Description);
            }
        }
    }
}
