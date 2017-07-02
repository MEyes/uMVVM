using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public class LogFactory
    {
        public static LogFactory Instance=new LogFactory();
        private readonly Dictionary<string,LogStrategy> _strategies=new Dictionary<string, LogStrategy>()
        {
            {typeof(ConsoleLogStrategy).Name,new ConsoleLogStrategy() },
            {typeof(FileLogStrategy).Name,new FileLogStrategy() },
            {typeof(DatabaseLogStrategy).Name,new DatabaseLogStrategy() }
        }; 
        public LogStrategy Resolve<T>() where T:LogStrategy
        {
            return _strategies[typeof(T).Name];
        }
    }
}
