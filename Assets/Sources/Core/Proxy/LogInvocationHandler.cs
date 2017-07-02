using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Sources.Core.Log;
using UnityEngine;

namespace Assets.Sources.Core.Proxy
{
    public class LogInvocationHandler:IInvocationHandler
    {
        public void PreProcess()
        {
            LogFactory.Instance.Resolve<ConsoleLogStrategy>().Log("Pre Process");
        }

        public object Invoke(object target, MethodInfo method, object[] args)
        {
            PreProcess();
            var result= method.Invoke(target, args);
            PostProcess();
            return result;
        }

        public void PostProcess()
        {
            LogFactory.Instance.Resolve<ConsoleLogStrategy>().Log("Post Process");
        }
    }
}
