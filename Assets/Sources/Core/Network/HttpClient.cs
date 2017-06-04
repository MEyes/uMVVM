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

        public void SendAsync(string url, HttpMethod method, Action<HttpResponse> responseHandler)
        {
            switch (method)
            {
                case HttpMethod.Get:
                    HttpTool.Instance.StartCoroutine(Get(url, responseHandler));
                    break;
                case HttpMethod.Post:
                    break;
            }
        }

        private IEnumerator Get(string url,Action<HttpResponse> responseHandler)
        {
            using (var www = UnityWebRequest.Get(url))
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

        private IEnumerator Post(string url ,Action<HttpResponse> responseHandler)
        {
            WWWForm form = new WWWForm();
            form.AddField("myField", "myData");

            using (var www = UnityWebRequest.Post("http://www.my-server.com/myform", form))
            {
                yield return www.Send();

                HttpResponse response = new HttpResponse
                {
                    IsSuccess = !www.isError,
                    Error = www.error,
                    StatusCode = www.responseCode,
                    Data = www.downloadHandler.text
                };
            }
        }
    }
}
