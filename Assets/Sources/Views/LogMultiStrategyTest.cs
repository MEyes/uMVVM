using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Log;
using UnityEngine;

namespace Assets.Sources.Views
{
    public class LogMultiStrategyTest:MonoBehaviour
    {
        void Start()
        {
            LogFactory.Instance.Resolve<ConsoleLogStrategy>().Log("Welcome",true);

        }
    }
}
