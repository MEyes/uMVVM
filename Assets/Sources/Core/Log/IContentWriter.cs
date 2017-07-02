using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public interface IContentWriter
    {
        void Write(string message);
    }
}
