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
		public void Get(string url,T instance,Action<R> onSuccess)
        {
			//reflactor
			StringBuilder sb=new StringBuilder();
			sb.Append ("?");
			foreach (var property in instance.GetType().GetProperties()) {
				var propertyName = property.Name;
				var value = property.GetValue (instance, null);
				sb.Append (propertyName+"="+value+"&");

			}

			var httpRequest = new HttpRequest (){ Url = url, Method = HttpMethod.Get, Parameters = sb.ToString().TrimEnd('&') };
			HttpClient.Instance.SendAsync(httpRequest, (httpResponse) =>
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

        public void Post(string url,T instance,Action<R> onSuccess)
        {
			//reflactor
			StringBuilder sb=new StringBuilder();
			foreach (var property in instance.GetType().GetProperties()) {
				var propertyName = property.Name;
				var value = property.GetValue (instance, null);
				sb.Append (propertyName+"="+value+"&");

			}

			var httpRequest = new HttpRequest (){ Url = url, Method = HttpMethod.Post, Parameters = sb.ToString().TrimEnd('&')  };
			HttpClient.Instance.SendAsync(httpRequest, (httpResponse) =>
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
