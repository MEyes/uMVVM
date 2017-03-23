using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Message
{
    public class MessageArgs<T>
    {
        public T Item { get; set; }
        public MessageArgs(T item)
        {
            Item = item;
        }
    }
}
