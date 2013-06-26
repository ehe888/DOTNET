using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;
using System.Web.Http.OData;
using WebAPISample.OData;

namespace WebAPISample.Areas.Admin.Controllers
{
    public class RolesController : EntitySetController<Role, long>
    {

        private NHibernateContext NHibernateContext { get; set; }

        public override IQueryable<Role> Get()
        {
            return NHibernateContext.Roles;
        }
    }
}
