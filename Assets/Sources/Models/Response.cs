using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Models
{
    [System.Serializable]
    public class Response
    {
        public DateTime DateTime;
        public string User;
        public int Age;
        public string Data;

        public override string ToString()
        {
            return "Date：" + Data+"-User:"+User+"-Age:"+Age;
        }
    }
}
