using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Infrastructure
{
    public class SerializerJson:ISerializer
    {
        public static readonly SerializerJson Instance=new SerializerJson();
        private SerializerJson()
        {
            
        }
        public string Serialize<T>(T obj, bool readableOutput = false) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T Deserialize<T>(string json) where T : class, new()
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
