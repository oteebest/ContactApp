using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Api.AppService
{
    public static class SwaggerService
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CyberPay Micro Insurance API", Version = "v1" });

                c.CustomSchemaIds((type) => type.IsNested ? type.FullName : type.Name);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
                });
            });
        }

        //public static void AddDocumentation(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddApiVersioning();
        //    // Register the Swagger generator, defining one or more Swagger documents
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new Info { Title = "Wallet API", Version = "v1" });
        //        c.CustomSchemaIds((type) => type.IsNested ? type.FullName : type.Name);

        //        // Set the comments path for the Swagger JSON and UI.
        //        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //        var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
        //        c.IncludeXmlComments(xmlPath);

        //        c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
        //        c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
        //            { "Bearer", Enumerable.Empty<string>() },
        //        });
        //    });
        //}

    }
}
