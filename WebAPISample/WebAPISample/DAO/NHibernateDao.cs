using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.Data.NHibernate.Generic.Support;

namespace WebAPISample.DAO
{
    public class NHibernateDao<T> : HibernateDaoSupport, INHibernateDao<T>
    {

        public void Delete(T entity)
        {
            this.HibernateTemplate.Delete(entity);
        }

        public T Get(object id)
        {
            return this.HibernateTemplate.Load<T>(id);   
        }

        public object Save(T entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public void Update(T entity)
        {
            this.HibernateTemplate.Update(entity);
        }
    }
}