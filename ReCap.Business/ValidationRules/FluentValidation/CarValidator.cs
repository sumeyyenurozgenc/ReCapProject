using FluentValidation;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.ValidationRules.FluentValidation
{
  public  class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.DailyPrice).GreaterThan(0).WithMessage("DailyPrice 0'dan büyük olmalı!");
        }
    }
}
