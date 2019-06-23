using ContactApp.Core.Interfaces.Managers;
using ContactApp.Core.Interfaces.Repositories;
using ContactApp.Core.Managers;
using ContactApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Api.AppService
{
    public static class CoreService
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            //Managers
            services.AddScoped<IContactManager, ContactManager>();


       
        }
    }
}
