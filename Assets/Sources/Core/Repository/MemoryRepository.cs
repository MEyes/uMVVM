using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.Sources.Core.Repository
{
    public class MemoryRepository<T> : IRepository<T> where T : class, new()
    {
        private Dictionary<object, T> repository = new Dictionary<object, T>();
        protected PropertyInfo KeyPropertyInfo { get; private set; }

        public MemoryRepository()
        {
            FindKeyPropertyInDataType();
        }

        public void Insert(T instance)
        {
            try
            {
                var id = KeyPropertyInfo.GetValue(instance, null);
                repository[id] = instance;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
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

        private void FindKeyPropertyInDataType()
        {
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object[] attributes = propertyInfo.GetCustomAttributes(typeof(RepositoryKey), false);
                if (attributes != null && attributes.Length == 1)
                {
                    KeyPropertyInfo = propertyInfo;
                }
                else
                {
                    throw new Exception("more than one repository key exist");
                }
            }
           
        }
    }
}
