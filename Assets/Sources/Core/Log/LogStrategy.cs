using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public abstract class LogStrategy
    {
        protected abstract bool DoLog(string logItem);

        public bool Log(string app,string key,string cause)
        {
            return DoLog(app + " " + key + " " + cause);
        }
    }
}
