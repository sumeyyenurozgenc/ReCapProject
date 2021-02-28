using FluentValidation;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.ValidationRules.FluentValidation
{
    public class BrandValidator :AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b=>b.BrandName).MinimumLength(2).WithMessage("Marka adı en az 2 karakter olmalı!");
            RuleFor(b => b.BrandName).NotEmpty().WithMessage("Marka adı boş olamaz!");
        }
    }
}
