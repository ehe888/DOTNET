using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.DTO
{
    public class StaffFlattenDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public String UserAccountUserName { get; set; }

        public String UserAccountPassword { get; set; }
    }
}