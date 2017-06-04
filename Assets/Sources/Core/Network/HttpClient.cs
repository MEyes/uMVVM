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
            //传递一个Data进来
            //反射
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
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
            formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

            UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", formData);
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
