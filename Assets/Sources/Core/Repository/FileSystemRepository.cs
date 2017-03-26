using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Repository
{
    public class FileSystemRepository<T> : IRepository<T> where T:class,new()
    {

        public void Insert(T instance)
        {
            throw new NotImplementedException();
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
