using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatamContext>, IProductCarDal
    {
        public List<CarDetailDto> GetProductDetails()
        {
            using (DatamContext context = new DatamContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = (short)c.DailyPrice
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDtoLarge> GetCarsDetails()
        {
            using (DatamContext context = new DatamContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             join ci in context.CarImages
                             on c.Id equals ci.CarId

                             select new CarDetailDtoLarge
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = (short)c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePath = ci.ImagePath
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDtoLarge> GetAlls(int brandId)
        {
            using (DatamContext context = new DatamContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             join ci in context.CarImages
                             on c.Id equals ci.CarId

                             where b.BrandId == brandId

                             select new CarDetailDtoLarge
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = (short)c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ImagePath = ci.ImagePath
                             };


                return result.ToList();
            }
        }
    }
}
