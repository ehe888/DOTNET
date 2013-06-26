using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Spring.Data.NHibernate.Generic.Support;
using WebAPISample.Models;
using NHibernate.Linq;

namespace WebAPISample.OData
{
    public class NHibernateContext : HibernateDaoSupport
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return this.Session.Query<Role>();
            }
        }
    }
}