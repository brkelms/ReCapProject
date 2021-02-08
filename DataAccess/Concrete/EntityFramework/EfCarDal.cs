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
        public void Add(Car entity)
        {
            if ((entity.CarName.Length > 2)&&(entity.DailyPrice>0))
            {
                using (DatamContext context = new DatamContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            else
                Console.WriteLine("");
        }

        public void Delete(Car entity)
        {
            using (DatamContext context = new DatamContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (DatamContext context = new DatamContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DatamContext context = new DatamContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }
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

        public void Update(Car entity)
        {
            using (DatamContext context = new DatamContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
