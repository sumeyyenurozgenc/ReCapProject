using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ReCap.Business.Abstract;
using ReCap.Business.Concrete;
using ReCap.Core.Utilities.Intercepters;
using ReCap.DataAccess.Abstract;
using ReCap.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Business.DependencyResolvers.Autofac
{
   public  class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();
            
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EFColorDal>().As<IColorDal>().SingleInstance();
            
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EFBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EFRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EFUserDal>().As<IUserDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
