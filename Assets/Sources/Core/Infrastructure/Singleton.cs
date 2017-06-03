using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Sources.Core.Infrastructure
{
    public class Singleton<T>:MonoBehaviour where T:MonoBehaviour,new()
    {
        private  T _instance;
        private bool _isBeingDestory;

        public  T Instance
        {
            get
            {
                if (_instance==null && !_isBeingDestory)
                {
                    _instance = Create();
                }
                return _instance;
            }
        }
        protected Singleton()
        {
            
        }

        protected virtual T Create()
        {
            var gameObject=new GameObject(typeof(T).Name,typeof(T));
            return gameObject.GetComponent<T>();
        }

        protected virtual void OnApplicationQuit()
        {
            if (_instance!=null)
            {
                Destroy(_instance.gameObject);
                _instance = null;
            }
        }

        protected virtual void OnDestory()
        {
            _isBeingDestory = true;
        }
    }
}
