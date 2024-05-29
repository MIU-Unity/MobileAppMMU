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
        
        public Dictionary<string, T>[] Parse(string fileName)
        {
            string fullPath = _path + (fileName.StartsWith("/") ? fileName : "/" + fileName);

            if (!File.Exists(fullPath))
            {
                throw new Exception("File not exist");
            }

            string fileData = File.ReadAllText(fullPath);
            
            var result = JsonConvert.DeserializeObject<Dictionary<string, T>[]>(fileData);
            
            return result;
        }

        public Dictionary<string, Dictionary<string, string>>[] Test(string fileName)
        {
            var resultDictionary = new Dictionary<string, Dictionary<string, string>>();

            var hint = new Dictionary<string, string>();
            hint.Add("light", "Наводящая подсказка первого уровня");
            hint.Add("full", "Пряма подсказка первого уровня");
            
            resultDictionary.Add("1", hint);

            return new Dictionary<string, Dictionary<string, string>>[] {resultDictionary};
        }
    }
}