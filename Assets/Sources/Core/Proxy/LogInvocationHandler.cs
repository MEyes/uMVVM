using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Proxy
{
    public class LogInvocationHandler:IInvocationHandler
    {
        public void PreProcess()
        {
            Debug.Log("Process");
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
           Debug.Log("Post");
        }
    }
}
