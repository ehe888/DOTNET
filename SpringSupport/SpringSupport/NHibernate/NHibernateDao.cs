using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic.Support;
using NHibernate;

namespace SpringSupport.NHibernate
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


        public IEnumerable<T> Load(int top, int skip)
        {
            return this.HibernateTemplate.ExecuteFind<T>(delegate(ISession session)
            {
                IQuery query = session.CreateQuery(String.Format("from {0}", typeof(T).FullName));
                query.SetMaxResults(top);
                query.SetFirstResult(skip);
                return query.List<T>();
            });
        }
    }
}
