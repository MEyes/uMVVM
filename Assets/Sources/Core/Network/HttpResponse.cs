using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Network
{
    public class HttpResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public long StatusCode { get; set; }
        public string Data { get; set; }
    }
}
