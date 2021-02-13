using ReCap.Core.DataAccess.EntityFramework;
using ReCap.DataAccess.Abstract;
using ReCap.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.DataAccess.Concrete.EntityFramework
{
   public class EFUserDal : EFEntityRepositoryBase<User, ReCapDBContext>, IUserDal
    {
    }
}
