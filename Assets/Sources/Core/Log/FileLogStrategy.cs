using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public class FileLogStrategy:LogStrategy
    {

        protected override void RecordMessage(string message)
        {
            throw new NotImplementedException();
        }

        protected override IContentWriter Writer { get; set; }
    }
}
