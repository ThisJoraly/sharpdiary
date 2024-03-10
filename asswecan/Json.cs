using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asswecan
{
    public class Json
    {
        public void Serialize<T>(string fileName, T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(fileName, json);
        }
        public T Deserialize<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
