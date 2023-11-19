using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
   public static class ServiceExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<ISaleService,SaleService>();
            services.AddScoped<IOfferService,OfferService>();
            services.AddScoped<ICustomerDal, EfCustomerDAL>();
            services.AddScoped<ISaleDal, EfSaleDAL>();
            services.AddScoped<IOfferDal, EfOfferDAL>();
            
        }

    }
}
