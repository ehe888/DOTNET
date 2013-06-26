using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.Models
{
    public class User
    {
        public virtual long Id { get; set; }

        public virtual String UserName { get; set; }

        public virtual String Password { get; set; }
    }
}