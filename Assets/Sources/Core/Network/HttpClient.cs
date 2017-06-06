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
            //传递一个Data进来
            //反射
			switch (httpRequest.Method)
            {
                case HttpMethod.Get:
				HttpTool.Instance.StartCoroutine(Get(httpRequest.Url,httpRequest.Parameters, responseHandler));
                    break;
                case HttpMethod.Post:
                    break;
            }
        }

		private IEnumerator Get(string url,string parameters,Action<HttpResponse> responseHandler)
        {
			using (var www = UnityWebRequest.Get(url+parameters))
            {
                yield return www.Send();

                HttpResponse response = new HttpResponse
                {
                    IsSuccess = !www.isError,
                    Error = www.error,
                    StatusCode = www.responseCode,
                    Data = www.downloadHandler.text
                };

                responseHandler(response);

            }
        }

		private IEnumerator Post(string url ,string parameters,Action<HttpResponse> responseHandler)
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
			formData.Add(new MultipartFormDataSection(parameters));

			UnityWebRequest www = UnityWebRequest.Post(url, formData);
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
