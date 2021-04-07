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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DatamContext>, ICustomerDal
    {
        public List<CustomerDto> GetCustomerDetails()
        {
            using (DatamContext context = new DatamContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId

                             select new CustomerDto
                             {
                                 UserId = u.UserId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
