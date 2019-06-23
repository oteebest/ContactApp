using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Models
{
    public class ContactViewModel : NewContactViewModel
    {
        public string Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

    }

}
