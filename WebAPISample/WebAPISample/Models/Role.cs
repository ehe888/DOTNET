using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.Models
{
    public class Role
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}