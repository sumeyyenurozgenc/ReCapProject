using FluentValidation;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.ValidationRules.FluentValidation
{
    public class ColorValidator :AbstractValidator<Color>
    {
        public ColorValidator()
        {

        }
    }
}
