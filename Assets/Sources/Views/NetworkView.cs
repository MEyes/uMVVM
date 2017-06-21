using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Infrastructure;
using Assets.Sources.Core.Network;
using Assets.Sources.Core.Proxy;
using Assets.Sources.Core.Repository;
using Assets.Sources.Models;
using uMVVM.Sources.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Views
{
    public class NetworkView:MonoBehaviour
    {
        public Image greenRect;

        private bool stop;
        void Start()
        {

            var repository=new RemoteRepository<Identity>();
            //Proxy

            Proxy.Instance.SetTarget(repository)
                .SetMethod("Test")
                .SetArgs(new object[] {})
                .SetInvocationHandler(new LogInvocationHandler())
                .Invoke();

            //Loding
            repository.Get<Response<User>>("http://localhost/User/List",
                new Identity() {DeviceId = SystemInfo.deviceUniqueIdentifier, Token = TokenHelper.Create()},
                (response) =>
                {
                    Debug.Log(response.Items[0].Address.Name);
                    stop = true;
                });
        }

        void Update()
        {
            if (!stop)
            {
                greenRect.transform.Rotate(Vector3.left, Time.deltaTime * 180);
            }
        }
    }
}
