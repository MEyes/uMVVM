using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Sources.Core.Infrastructure
{
    public class SerializerXml : ISerializer
    {
        public static readonly SerializerXml Instance = new SerializerXml();

        private readonly XmlWriterSettings _settingsForCompactOutput = new XmlWriterSettings()
        {
            OmitXmlDeclaration = true
        };

        private readonly XmlWriterSettings _settingsForReadableOutput = new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            Indent = true,
            IndentChars = "  ",
            NewLineChars = "\r\n",
            NewLineHandling = NewLineHandling.Replace
        };

        public static readonly List<Type> ExtraTypes = new List<Type>();

        public string Serialize<T>(T obj, bool readableOutput = false) where T : class, new()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(obj.GetType(), ExtraTypes.ToArray());
                using (StringWriter writer = new StringWriter())
                {
                    XmlWriterSettings settings = (readableOutput ? _settingsForReadableOutput : _settingsForCompactOutput);
                    using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                    {
                        xmlSerializer.Serialize(xmlWriter, obj);
                        string xml = writer.ToString();
                        return xml;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Unable to serialize ");
                throw new Exception(e.ToString());
            }
        }

        public T Deserialize<T>(string xml) where T : class, new()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StringReader(xml))
                {
                    T obj = (T)xmlSerializer.Deserialize(reader);
                    return obj;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Unable to deserialize");
                throw new Exception(e.ToString());
            }
        }
    }
}
