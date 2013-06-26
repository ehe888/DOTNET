using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }
    }
}