using ContactApp.Core.Interfaces.Repositories;
using ContactApp.Infrastructure.DataContext;
using ContactApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Api.AppService
{
    public static class InfrastructureService
    {
        public static void InitializeRepositories(this IServiceCollection services, IConfiguration config)
        {

            var connection = config.GetConnectionString("DatabaseConnection");


            services.AddDbContext<ContactDataContext>
                (options => options.UseSqlServer(connection, u => u.MigrationsAssembly("ContactApp.Api")) );

            services.AddScoped<DbContext, ContactDataContext>();


            services.AddScoped<IContactRepository, ContactRepository>();
            






        }

    }
}
