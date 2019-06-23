using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactApp.Core.Models
{
    public class NewContactViewModel
    {
        [Required(ErrorMessage = "Enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        public string Mobile { get; set; }

    }
}
