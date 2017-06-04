using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Sources.Core.HTTP;
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

        public void Get(Action<string> action )
        {
            HttpTool.Instance.StartCoroutine(WaitUntilResponseReceived(action));
        }

        public void Post()
        {
            HttpTool.Instance.StartCoroutine(Upload());
        }

        private IEnumerator WaitUntilResponseReceived(Action<string> action)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("http://www.cnblogs.com"))
            {
                yield return www.Send();

                if (www.isError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    // Show results as text
                    //Debug.Log(www.downloadHandler.text);

                    action(www.downloadHandler.text);
                    // Or retrieve results as binary data
                    byte[] results = www.downloadHandler.data;
                }
            }
        }

        private IEnumerator Upload()
        {
            WWWForm form = new WWWForm();
            form.AddField("myField", "myData");

            using (UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform", form))
            {
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
}
