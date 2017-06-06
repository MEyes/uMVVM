using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Network;
using Assets.Sources.Core.Repository;
using Assets.Sources.Models;
using uMVVM.Sources.Infrastructure;
using UnityEngine;

namespace Assets.Sources.Views
{
    public class NetworkView:MonoBehaviour
    {
        void Start()
        {
            var repository=new RemoteRepository<Identity,User>();

//			repository.Get ("http://192.168.199.233/User/Get", new Identity (), (response) => {
//				
//			});
				
			repository.Post ("http://192.168.199.233/User/Post", new Identity (){Token="abc",DeviceId="def"}, (response) => {
				Debug.Log(response.Name);
			});
        }
    }
}
