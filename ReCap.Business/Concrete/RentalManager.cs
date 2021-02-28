using ReCap.Business.Abstract;
using ReCap.Business.Constants;
using ReCap.Business.ValidationRules.FluentValidation;
using ReCap.Core.Aspects.Autofac.Validation;
using ReCap.Core.Utilities.Result;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

       [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(x => x.CarId == rental.CarId && x.ReturnDate == null);
           
            if(result != null )
            {
                return new ErrorResult(Messages.RentalCarNotAvailable);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.SuccessListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == id), Messages.SuccessListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
