using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Network;
using uMVVM.Sources.Infrastructure;
using UnityEngine;

namespace Assets.Sources.Views
{
    public class NetworkView:MonoBehaviour
    {
        void Start()
        {
            HttpClient.Instance.Get((value) =>
            {
                Debug.Log(value);
            });
        }
    }
}
