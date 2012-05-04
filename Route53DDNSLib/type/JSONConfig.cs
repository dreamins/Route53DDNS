using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

using Route53DDNSLib.exception;

namespace Route53DDNSLib.type
{
    [DataContract]
    public class JSONConfig<T>
    {
        protected void write(string configFileName)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(configFileName, FileMode.Create);
                write(stream);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        protected void write(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, this);
        }

        protected static T load(string configFileName)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(configFileName, FileMode.Open);
                return load(stream);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        protected static T load(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
