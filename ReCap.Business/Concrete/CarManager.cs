using ReCap.Business.Abstract;
using ReCap.Business.Constants;
using ReCap.Business.ValidationRules.FluentValidation;
using ReCap.Core.Aspects.Autofac.Validation;
using ReCap.Core.Utilities.Result;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using ReCap.Entities.DTOs;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new ErrorResult(Messages.SuccessAdd);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.SuccessListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id), Messages.SuccessListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id), Messages.SuccessListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
