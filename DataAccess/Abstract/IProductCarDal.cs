using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductCarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetProductDetails();
        List<CarDetailDtoLarge> GetCarsDetails();
        List<CarDetailDtoLarge> GetAlls(int brandId);
        List<CarDetailDtoLarge> GetCAll(int colorId);
        List<CarDetailDtoLarge> GetCarAll(int carId);

    }
}
