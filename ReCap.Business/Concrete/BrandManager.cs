using ReCap.Business.Abstract;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if(brand.BrandName.Length>=2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Araba marka adı başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Araba adı minimum 2 karakter olmalı.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Araba Marka adı silindi.");
        }

        public List<Brand> GetAll()
        {
            Console.WriteLine("Tüm araba markaları:");
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(x => x.Id == id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Araba Marka adı güncellendi.");
        }
    }
}
