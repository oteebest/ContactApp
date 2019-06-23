using ContactApp.Core.Models;
using ContactApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Infrastructure.Util
{
    public static class Mapper
    {
        public static Contact Map(this NewContactViewModel model,string userID)
        {
            if (model == null) return null;

            return new Contact
            {
                Email = model.Email,
                FirstName = model.FirstName,
                Mobile = model.Mobile,
                LastName = model.LastName,
                UserId = userID,
            };
        }


        public static ContactViewModel Map(this Contact model)
        {
            if (model == null) return null;

            return new ContactViewModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                Mobile = model.Mobile,
                LastName = model.LastName,
                Id = model.Id,
                DateCreated = model.DateCreated,
            };
        }

    }
}
