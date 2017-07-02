using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public class DatabaseContentWriter : IContentWriter
    {
        public void Write(string message)
        {
            Debug.Log("Database Log!:"+message);
        }
    }
}
