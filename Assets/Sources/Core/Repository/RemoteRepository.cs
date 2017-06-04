using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.Infrastructure;
using Assets.Sources.Core.Network;
using Assets.Sources.Models;
using UnityEngine;

namespace Assets.Sources.Core.Repository
{
    public class RemoteRepository<T, R>:IRepository<T> where T : class, new() where R : class, new()
    {
        public void Get()
        {
            HttpClient.Instance.SendAsync("http://localhost/Home/Get",HttpMethod.Get, (response) =>
            {
                var data = response.Data;
                var result = JsonUtility.FromJson<R>(data);
                Debug.Log(result.ToString());
            });
        }

        public void Insert(T instance)
        {
           
        }

        public void Delete(T instance)
        {
            throw new NotImplementedException();
        }

        public void Update(T instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }
    }

    public class UserRepository : RemoteRepository<Response, Response>
    {
        
    }
}
