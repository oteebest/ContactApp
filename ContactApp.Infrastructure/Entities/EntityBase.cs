using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Infrastructure.Entities
{
    public class EntityBase
    {
        public string Id { get; set; }

        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

    }
}
