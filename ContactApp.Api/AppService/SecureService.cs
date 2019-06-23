using ContactApp.Infrastructure.DataContext;
using ContactApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Api.AppService
{
    public static class SecureService
    {
        public static void ConfigureSecurity(this IServiceCollection services, IConfiguration _config)
        {
            services.AddIdentity<User, IdentityRole>()
           .AddEntityFrameworkStores<ContactDataContext>();

            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           { 
            
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                
                   ValidIssuer = _config["AuthTokens:Issuer"],
                   ValidAudience = _config["AuthTokens:Audience"],
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthTokens:Key"])),
                   ValidateLifetime = true
               };
           });

        }


     

    }
}
