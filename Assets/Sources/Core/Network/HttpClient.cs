using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.HTTP;
using Assets.Sources.Core.Infrastructure;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Sources.Core.Network
{
    public class HttpClient
    {
        public static readonly HttpClient Instance=new HttpClient();
        private HttpClient()
        {
            
        }

		public void SendAsync(HttpRequest httpRequest,Action<HttpResponse> responseHandler)
        {
			switch (httpRequest.Method)
            {
                case HttpMethod.Get:
				HttpTool.Instance.StartCoroutine(Get(httpRequest.Url,httpRequest.Parameters, responseHandler));
                    break;
			case HttpMethod.Post:
				HttpTool.Instance.StartCoroutine (Post(httpRequest.Url,httpRequest.Parameters,responseHandler));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static IEnumerator Get(string url, string parameters, Action<HttpResponse> onComplete)
        {
            using (var www = UnityWebRequest.Get(url + parameters))
            {
                yield return www.Send();
                var response = new HttpResponse
                {
                    IsSuccess = !www.isError, Error = www.error, StatusCode = www.responseCode, Data = www.downloadHandler.text
                };

                onComplete(response);
            }
        }

        private static IEnumerator Post(string url, string parameters, Action<HttpResponse> onComplete)
        {
            var formData = new List<IMultipartFormSection>
            {
                new MultipartFormDataSection(parameters)
            };

            using (var www = UnityWebRequest.Post(url, formData))
            {
                yield return www.Send();
                var response = new HttpResponse
                {
                    IsSuccess = !www.isError, Error = www.error, StatusCode = www.responseCode, Data = www.downloadHandler.text
                };

                onComplete(response);
            }
        }
    }
}
