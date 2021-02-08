using Microsoft.EntityFrameworkCore;
using ReCap.Core.DataAccess.EntityFramework;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using ReCap.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReCap.DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from car in context.Cars
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 CarName = car.Descriptions,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
