using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPISample.Models
{
    public class Role
    {
        public virtual long Id { get; set; }

        [StringLength(20)]
        public virtual string Name { get; set; }
    }
}