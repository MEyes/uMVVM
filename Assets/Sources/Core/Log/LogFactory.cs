using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Core.Log
{
    public class LogFactory
    {
        public static LogFactory Instance=new LogFactory();
        public Dictionary<string,LogStrategy> Strategies=new Dictionary<string, LogStrategy>()
        {
            {typeof(ConsoleLogStrategy).ToString(),new ConsoleLogStrategy() },
            {typeof(FileLogStrategy).ToString(),new FileLogStrategy() },
            {typeof(DatabaseLogStrategy).ToString(),new DatabaseLogStrategy() }
        }; 
        public LogStrategy Resolve<T>() where T:LogStrategy
        {
            return Strategies[typeof (T).ToString()];
        }
    }
}
