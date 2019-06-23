using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Api.AppService;
using ContactApp.Api.Filters;
using ContactApp.Api.Middleware;
using ContactApp.Api.MiddleWare;
using ContactApp.Api.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace ContactApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var AllowCorsForList =  Configuration.GetSection("AllowCorsForList").Value.Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(AllowCorsForList)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .WithExposedHeaders("Content-Disposition", "Content-Length"); ;
                });
            });

            services.AddMvc( options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
                

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IdentityInitializer>();

            services.AddCoreServices();

            services.RegisterSwagger();

            services.ConfigureSecurity(Configuration);

            services.InitializeRepositories(Configuration);


           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IdentityInitializer identitySeeder, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }



            app.UseCors(MyAllowSpecificOrigins);

            app.UseMiddleware<MaintainCorsHeaderMiddleware>();

            app.ConfigureExceptionHandler(loggerFactory);


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact App API");
            });


            

            app.UseHttpsRedirection();

            app.UseMvc();

            

            identitySeeder.Seed().Wait();

        }
    }
}
