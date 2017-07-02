using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public class NullLogStrategy:LogStrategy
    {
        protected override bool DoLog(string logItem)
        {
            throw new NotImplementedException();
        }
    }
}
