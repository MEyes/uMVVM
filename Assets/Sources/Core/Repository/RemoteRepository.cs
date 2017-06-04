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
    public class RemoteRepository<T, R> where T : class, new() where R : class, new()
    {
        public void Get(string url,Action<R> onSuccess)
        {
            HttpClient.Instance.SendAsync(url,HttpMethod.Get, (response) =>
            {
                if (response.IsSuccess)
                {
                    var data = response.Data;
                    var result = JsonUtility.FromJson<R>(data);
                    Debug.Log(result.ToString());
                    onSuccess(result);
                }
                //异常处理
            });
        }

        public void Post(string url,T instance,Action<R> onSuccess)
        {
            HttpClient.Instance.SendAsync(url, HttpMethod.Post, (response) =>
            {
                if (response.IsSuccess)
                {
                    var data = response.Data;
                    var result = JsonUtility.FromJson<R>(data);
                    Debug.Log(result.ToString());
                    onSuccess(result);
                }
                //异常处理
            });
        }

    }
}
