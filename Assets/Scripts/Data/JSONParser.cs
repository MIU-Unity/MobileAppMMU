using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
            
            return JsonUtility.FromJson<Dictionary<string, T>>(fullPath);
        }
    }
}