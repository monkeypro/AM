using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DataContractWebService
{
    public static class DataContractExtensions
    {
        const string path = @"c:\Temp\data.xml";

        public static void ToXmlFile<T>(this T data)
            where T : IDataContract
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(stream, data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} : {1}", ex.Source, ex.Message);
            }
        }

        public static T FromXmlFile<T>(this T data)
            where T : IDataContract
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    data = (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} : {1}", ex.Source, ex.Message);
            }

            return data;
        }

    }
}