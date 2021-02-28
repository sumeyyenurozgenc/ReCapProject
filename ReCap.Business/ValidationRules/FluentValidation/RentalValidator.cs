using FluentValidation;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r=>r.RentDate).GreaterThan(DateTime.Now).WithMessage("Geçmiş güne kiralama yapılamaz");
        }
    }
}
