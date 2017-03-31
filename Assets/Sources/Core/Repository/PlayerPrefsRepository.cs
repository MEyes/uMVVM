using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Sources.Core.Infrastructure;
using UnityEngine;

namespace Assets.Sources.Core.Repository
{
    public class PlayerPrefsRepository<T> : IRepository<T> where T : class, new()
    {
        protected ISerializer Serializer { get; set; }
        protected string KeysIndexName { get; set; }
        private List<object> keysIndex;
        private List<object> KeysIndex
        {
            get
            {
                if (keysIndex == null)
                {
                    keysIndex = LoadIndex();
                }

                return keysIndex;
            }
        }

        public PlayerPrefsRepository(ISerializer serializer = null)
        {
            KeysIndexName = GetKeyPath("KeysIndex");
            Serializer = (serializer != null ? serializer : SerializerXml.Instance);
        }

        public void Insert(T instance)
        {
            try
            {
                string serializedObject = Serializer.Serialize<T>(instance, true);
                PlayerPrefs.SetString(KeysIndexName, serializedObject);
              
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
           
        }


        public void Delete(T instance)
        {
            throw new NotImplementedException();
        }

        public void Update(T instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }

        private static string GetKeyPath(object key)
        {
            return string.Format("{0}/{1}", typeof(T).Name, key.ToString());
        }

        private List<object> LoadIndex()
        {
            if (PlayerPrefs.HasKey(KeysIndexName))
            {
                string serializeObject = PlayerPrefs.GetString(KeysIndexName);
                return Serializer.Deserialize<List<object>>(serializeObject);
            }
            else
            {
                return new List<object>();
            }
        }

        private void SaveIndex()
        {
            string serializedObject = Serializer.Serialize<List<object>>(KeysIndex, true);
            PlayerPrefs.SetString(KeysIndexName, serializedObject);
        }
    }
}
