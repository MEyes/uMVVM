using System;
using System.Collections.Generic;
using System.Text;
using Assets.Sources.Core.Infrastructure;
using Assets.Sources.Core.Network;
using Assets.Sources.Models;
using UnityEngine;

namespace Assets.Sources.Core.Repository
{
    public class RemoteRepository<T> where T : class, new() 
    {
        public ISerializer Serializer { get; set; }

        public RemoteRepository(ISerializer serializer=null)
        {
            Serializer = serializer ?? SerializerJson.Instance;
        }
        public void Get<R>(string url, T instance, Action<R> onSuccess) where R : class, new()
        {
            var parameters= HttpUtility.BuildParameters(instance, new StringBuilder("?"));
            var httpRequest = new HttpRequest
            {
                Url = url,
                Method = HttpMethod.Get,
                Parameters = parameters
            };
            HttpClient.Instance.SendAsync(httpRequest, httpResponse =>
            {
                if (httpResponse.IsSuccess)
                {
                    onSuccess(Serializer.Deserialize<R>(httpResponse.Data));
                }
                //TODO:异常处理
            });
        }

        public void Post<R>(string url, T instance, Action<R> onSuccess) where R : class, new()
        {
            var parameters = HttpUtility.BuildParameters(instance, new StringBuilder());
            var httpRequest = new HttpRequest
            {
                Url = url,
                Method = HttpMethod.Post,
                Parameters = parameters
            };
            HttpClient.Instance.SendAsync(httpRequest, httpResponse =>
            {
                if (httpResponse.IsSuccess)
                {
                    //TODO:判断是否有Data
                    onSuccess(Serializer.Deserialize<R>(httpResponse.Data));
                }
            });
        }

        public void Test()
        {
            Debug.Log("Hello...");
        }
    }
}
