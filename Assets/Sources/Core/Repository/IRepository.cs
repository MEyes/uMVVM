using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Repository
{
    public interface IRepository<T> where T:class,new()
    {
        void Insert(T instance);
        void Delete(T instance);
        void Update(T instance);
        IEnumerable<T> Select(Func<T,bool> func );
    }
}
