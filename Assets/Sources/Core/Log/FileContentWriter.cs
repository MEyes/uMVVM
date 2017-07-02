using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Log
{
    public class FileContentWriter:IContentWriter
    {
        public void Write(string message)
        {
            //IO
            Debug.Log("File Log!：{0}"+message);
        }
    }
}
