using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPISample.DAO
{
    public interface INHibernateDao<T>
    {
        void Delete(T entity);
        T Get(object id);
        object Save(T entity);
        void Update(T entity);
    }
}
