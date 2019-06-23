using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactApp.Infrastructure.Entities
{
    public class Contact : EntityBase
    {
     
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }

        public string Mobile { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }


    }
}
