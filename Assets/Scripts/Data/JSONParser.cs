using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Data
{
    public class JSONParser<T>
    {
         private readonly string _path = Application.dataPath + "/Data";
        
        public Dictionary<string, T> Parse(string fileName)
        {
            string fullPath = _path + (fileName.StartsWith("/") ? fileName : "/" + fileName);

            if (!File.Exists(fullPath))
            {
                throw new Exception("File not exist");
            }

            string fileData = File.ReadAllText(fullPath);
            
            var result = JsonConvert.DeserializeObject<Dictionary<string, T>>(fileData);
            
            return result;
        }
    }
}