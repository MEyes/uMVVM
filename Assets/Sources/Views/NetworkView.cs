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
            var repository=new RemoteRepository<Badge,Response>();
            //repository.Get("localhost:80/Home/Get?token=abc");

            //repository.Insert(new Badge());
        }
    }
}
