using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Djoz.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());    
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            //services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
        }
    }
}
