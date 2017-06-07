using System;
using System.Collections.Generic;
using System.Text;
using Assets.Sources.Core.Infrastructure;
using Assets.Sources.Core.Network;
using Assets.Sources.Models;
using UnityEngine;

namespace Assets.Sources.Core.Repository
{
    [System.Serializable]
    public class ResponseWrapper<T>
    {
        public List<T> Items;
    }

    public class RemoteRepository<T> where T : class, new() 
    {
        public void Get<R>(string url, T instance, Action<R> onSuccess) where R : class, new()
        {
            //reflactor
            var sb = new StringBuilder();
            sb.Append("?");
            foreach (var property in instance.GetType().GetProperties())
            {
                var propertyName = property.Name;
                var value = property.GetValue(instance, null);
                sb.Append(propertyName + "=" + value + "&");
            }

            var httpRequest = new HttpRequest
            {
                Url = url,
                Method = HttpMethod.Get,
                Parameters = sb.ToString().TrimEnd('&')
            };
            HttpClient.Instance.SendAsync(httpRequest, httpResponse =>
            {
                if (httpResponse.IsSuccess)
                {
                    var data = httpResponse.Data;
                    var result = JsonUtility.FromJson<R>(data);
                    onSuccess(result);
                }
                //异常处理
            });
        }

        public void Post<R>(string url, T instance, Action<R> onSuccess) where R : class, new()
        {
            //reflactor
            var sb = new StringBuilder();
            foreach (var property in instance.GetType().GetProperties())
            {
                var propertyName = property.Name;
                var value = property.GetValue(instance, null);
                sb.Append(propertyName + "=" + value + "&");
            }

            var httpRequest = new HttpRequest
            {
                Url = url,
                Method = HttpMethod.Post,
                Parameters = sb.ToString().TrimEnd('&')
            };

            HttpClient.Instance.SendAsync(httpRequest, httpResponse =>
            {
                if (httpResponse.IsSuccess)
                {
                    var data = httpResponse.Data;
                    var result = JsonUtility.FromJson<R>(data);
                    Debug.Log(result.ToString());
                    onSuccess(result);
                }
                //异常处理
            });
        }
    }
}
