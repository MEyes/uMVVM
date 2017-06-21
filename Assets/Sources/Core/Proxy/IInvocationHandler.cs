using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Assets.Sources.Core.Proxy
{
    public interface IInvocationHandler
    {
        void PreProcess();
        object Invoke(object proxy, MethodInfo method, object[] args);
        void PostProcess();
    }
}
