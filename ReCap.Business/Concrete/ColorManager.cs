using ReCap.Business.Abstract;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Araba rengi eklendi.");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Araba rengi silindi.");
        }

        public List<Color> GetAll()
        {
            Console.WriteLine("Tüm araba renkleri: ");
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(x => x.Id == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Araba rengi güncellendi.");
        }
    }
}
