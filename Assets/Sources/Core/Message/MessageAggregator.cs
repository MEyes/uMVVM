using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Message;

namespace Assets.Sources.Infrastructure
{
    public delegate void MessageHandler<T>(object sender, MessageArgs<T> args);
    public class MessageAggregator<T>
    {
        private readonly Dictionary<string, MessageHandler<T>> _messages = new Dictionary<string, MessageHandler<T>>();

        public static readonly MessageAggregator<T> Instance=new MessageAggregator<T>();
       
        private MessageAggregator()
        {

        }
       
        public void Subscribe(string name, MessageHandler<T> handler)
        {
            if (!_messages.ContainsKey(name))
            {
                _messages.Add(name, handler);
            }
            else
            {
                _messages[name] += handler;
            }

        }
        public void Publish(string name, object sender, MessageArgs<T> args)
        {
            if (_messages.ContainsKey(name) && _messages[name] != null)
            {
                //转发
                _messages[name](sender, args);
            }
        }

    }


}
