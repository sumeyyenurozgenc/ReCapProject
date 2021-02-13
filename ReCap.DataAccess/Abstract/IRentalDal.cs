using ReCap.Core.DataAccess;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.DataAccess.Abstract
{
    public interface IRentalDal  : IEntityRepository<Rental>
    {
    }
}
