using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.Models
{
    public class Staff
    {
        public virtual long Id { get; set; }

        public virtual String Name { get; set; }

        public virtual User UserAccount { get; set; }

    }
}