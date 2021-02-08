using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using ReCap.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ReCap.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id =1, BrandId=1,ColorId=1,DailyPrice = 2500, Descriptions="Kırmızı Volvo",ModelYear ="2012" },
                new Car{Id =2, BrandId=2,ColorId=2,DailyPrice = 1500, Descriptions="Beyaz Honda Civic",ModelYear ="2020" },
                new Car{Id =3, BrandId=3,ColorId=3,DailyPrice = 1050, Descriptions="Siyah BMW",ModelYear ="2015" },
                new Car{Id =4, BrandId=3,ColorId=3,DailyPrice = 1050, Descriptions="Siyah BMW",ModelYear ="2018" }
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            //var deleteCar = _car.Where(x => x.Id == car.Id);
            var deleteCar = _car.FirstOrDefault(x => x.Id == car.Id);
            _car.Remove(deleteCar);
        }

        public Car GetById(int id)
        {
            return _car.FirstOrDefault(x => x.Id == id);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Update(Car car)
        {
            var updateCar = _car.FirstOrDefault(x => x.Id == car.Id);
            updateCar.ColorId = car.ColorId;
            updateCar.BrandId = car.BrandId;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.ModelYear = car.ModelYear;
            updateCar.Descriptions = car.Descriptions;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
