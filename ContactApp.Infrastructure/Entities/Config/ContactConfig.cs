using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Infrastructure.Entities.Config
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasIndex(u => new { u.UserId, u.Email }).IsUnique();

            builder.HasIndex(u => new { u.UserId, u.Mobile }).IsUnique();

        }
    }
}
