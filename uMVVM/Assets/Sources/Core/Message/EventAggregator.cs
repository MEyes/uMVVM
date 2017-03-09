using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Infrastructure
{
    public delegate void EventHandler<T>(object sender, EventArgs<T> args);
    public class EventAggregator<T>
    {
        public static readonly EventAggregator<T> Instance=new EventAggregator<T>();
        private readonly Dictionary<string, EventHandler<T>> _events =  new Dictionary<string, EventHandler<T>>();
        private EventAggregator()
        {

        }
       
        public  void SubscribeEvent(string name, EventHandler<T> handler)
        {
            if (!_events.ContainsKey(name))
            {
                _events.Add(name, handler);
            }
            else
            {
                _events[name] += handler;
            }

        }
        public void PublishEvent(string name, object sender, EventArgs<T> args)
        {
            if (_events.ContainsKey(name) && _events[name] != null)
            {
                _events[name](sender, args);
            }
        }

    }

    public class EventArgs<T> : EventArgs
    {
        public T Item { get; set; }

        public EventArgs(T item)
        {
            Item = item;
        }
    }
}
