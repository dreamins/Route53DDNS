using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

using Route53DDNS.exception;

namespace Route53DDNS.type
{
    [DataContract]
    class JSONConfig<T>
    {
        protected void write(string configFileName)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(configFileName, FileMode.OpenOrCreate);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, this);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        protected static T load(string configFileName)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(configFileName, FileMode.Open);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
