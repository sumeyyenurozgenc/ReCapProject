using ReCap.Business.Abstract;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Günlük ücreti 0'dan büyük olmalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba silindi.");
        }

        public List<Car> GetAll()
        {
            Console.WriteLine("Tüm arabalar: ");
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(x => x.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(x => x.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(x => x.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba güncellendi.");
        }
    }
}
