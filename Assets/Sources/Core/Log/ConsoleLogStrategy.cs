using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public class ConsoleLogStrategy:LogStrategy
    {
        protected override void RecordMessage(string message)
        {
            Debug.Log(message);
        }

        protected override IContentWriter Writer { get; set; }
    }
}
