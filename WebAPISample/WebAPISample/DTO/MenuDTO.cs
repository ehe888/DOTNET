using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.DTO
{
    public class MenuDTO
    {
        public long Id { get; set; }

        public String Name { get; set; }

        public IEnumerable<MenuDTO> Children { get; set; }
    }
}