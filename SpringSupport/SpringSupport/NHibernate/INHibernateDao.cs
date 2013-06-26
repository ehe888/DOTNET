using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringSupport.NHibernate
{
    public interface INHibernateDao<T>
    {
        void Delete(T entity);
        T Get(object id);
        object Save(T entity);
        void Update(T entity);

        /// <summary>
        /// 分页查询所有的内容
        /// </summary>
        /// <param name="top">取最前的x条记录，也即一页的大小</param>
        /// <param name="skip">略过前x条记录，skip = top * （当前页码 - 1）假设页码从1开始</param>
        /// <returns></returns>
        IEnumerable<T> Load(int top, int skip);
    }
}
