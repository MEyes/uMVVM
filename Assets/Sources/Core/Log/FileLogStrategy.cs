using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public class FileLogStrategy:LogStrategy
    {
        public FileLogStrategy()
        {
            SetContentWriter();
        }
        protected sealed override void SetContentWriter()
        {
            Writer = new FileContentWriter(); 
        }
        protected override void RecordMessage(string message)
        {
            Writer.Write(message);
        }

    }
}
