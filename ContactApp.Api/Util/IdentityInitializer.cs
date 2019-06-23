
using ContactApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Api.Util
{
        public class IdentityInitializer
        {
            // public SignInManager<User> _signIn;
            private readonly UserManager<User> _userMan;

            private readonly RoleManager<IdentityRole> _role;

            public IdentityInitializer(UserManager<User> userMan, RoleManager<IdentityRole> role)
            {
                _userMan = userMan;

                _role = role;
            }

            public async Task Seed()
            {

                var adminRole = await _role.FindByNameAsync("Admin");

                if (adminRole == null)
                {
                    await _role.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin", });

                }

                var user = await _userMan.FindByNameAsync("oteebest@yahoo.com");

                if (user == null)
                {

                    var result = await _userMan.CreateAsync(new User
                    {
                        FirstName = "Otee",
                        LastName = "Ziregbe",
                        Email = "oteebest@yahoo.com",
                        UserName = "oteebest@yahoo.com"
                    }, "Cyberpay1@!");


                }



            }

        }
    }


