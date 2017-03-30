using System;
using Assets.Sources.Core.Infrastructure;

namespace Assets.Sources.Core.Factory
{
    public class TransientObjectFactory : IObjectFactory
    {
        public object AcquireObject(string className)
        {
            return AcquireObject(TypeFinder.ResolveType(className));
        }

        public object AcquireObject(Type type)
        {
            var obj = Activator.CreateInstance(type, false);
            return obj;
        }

        public object AcquireObject<TInstance>() where TInstance : class, new()
        {
            var instance = new TInstance();
            return instance;
        }

        public void ReleaseObject(object obj)
        {
           
        }
    }
}
