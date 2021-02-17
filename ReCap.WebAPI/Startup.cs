using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReCap.Business.Abstract;
using ReCap.Business.Concrete;
using ReCap.DataAccess.Abstract;
using ReCap.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReCap.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddSingleton<ICarService, CarManager>();
            services.AddSingleton<ICarDal, EFCarDal>();
            services.AddSingleton<IColorService, ColorManager>();
            services.AddSingleton<IColorDal, EFColorDal>();
            services.AddSingleton<IBrandService, BrandManager>();
            services.AddSingleton<IBrandDal, EFBrandDal>();
            services.AddSingleton<ICustomerService, CustomerManager>();
            services.AddSingleton<ICustomerDal, EFCustomerDal>();
            services.AddSingleton<IRentalService, RentalManager>();
            services.AddSingleton<IRentalDal, EFRentalDal>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDal, EFUserDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
