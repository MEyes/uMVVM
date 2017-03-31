using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Infrastructure;

namespace Assets.Sources.Core.Repository
{
    public class RestRepository<T, R>:IRepository<T> where T : class, new() where R : class, new()
    {

        public void Insert(T instance)
        {
            //通过WWW像远程发送消息
        }

        public void Delete(T instance)
        {
            throw new NotImplementedException();
        }

        public void Update(T instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
