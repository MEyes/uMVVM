using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public class ConsoleLogStrategy:LogStrategy
    {
        protected override void SetContentWriter()
        {
           Writer=new ConsoleContentWriter();
        }
        protected override void RecordMessage(string message)
        {
            Writer.Write(message);
        }
    }
}
