using ContactApp.Infrastructure.Entities;
using ContactApp.Infrastructure.Entities.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Infrastructure.DataContext
{
    public class ContactDataContext :  IdentityDbContext<User>
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Log> Logs { get; set; }


        

        public ContactDataContext(DbContextOptions<ContactDataContext> options)
           : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EventConfig());

            builder.ApplyConfiguration(new ContactConfig());

            builder.ApplyConfiguration(new UserConfig());


        }


    }
}
