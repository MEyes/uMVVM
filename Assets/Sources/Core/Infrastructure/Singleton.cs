using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Infrastructure
{
    /// <summary>    ///     继承自该类，实现 Unity MonoBehaviour 单例模式.    /// </summary>
    public class Singleton<T>:MonoBehaviour where T:MonoBehaviour
    {
        private static  T _instance;
        private static bool _applicationIsQuitting=false;

        protected Singleton()
        {
        }

        public static  T Instance
        {
            get
            {
                if (_instance==null && !_applicationIsQuitting)
                {
                    _instance = Create();
                }
                return _instance;
            }
        }

        private static T Create()
        {
            var go=new GameObject(typeof(T).Name,typeof(T));
            DontDestroyOnLoad(go);
            return go.GetComponent<T>();
        }

        protected virtual void OnApplicationQuit()
        {
            if (_instance == null) return;
            Destroy(_instance.gameObject);
            _instance = null;
        }

        protected virtual void OnDestory()
        {
            _applicationIsQuitting = true;
        }
    }
}
