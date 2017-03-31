using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Infrastructure
{
    public interface ISerializer
    {
        string Serialize<T>(T obj, bool readableOutput = false) where T : class, new();
        T Deserialize<T>(string json) where T : class, new();
    }
}
