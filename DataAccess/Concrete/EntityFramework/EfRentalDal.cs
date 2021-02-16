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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatamContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (DatamContext context = new DatamContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id

                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId

                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = c.CarName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CustomerName = cu.CompanyName,
                                 DailyPrice = (short)c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();
            }
        }
    }

}
                
            
        
    

