using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Data;

namespace Gameplay
{
    public class HintBehaviour : MonoBehaviour
    {
        private DateTime _lastGetting = DateTime.Now;
        private readonly string[] _allowedTypes = new[] { "light", "full" };
        private readonly Dictionary<string, bool> _usedHints = new()
        {
            { "light", false },
            { "full", false }
        };

        private static JSONParser<Dictionary<string, string>> _parser = new();
        private static Dictionary<string, Dictionary<string, string>> _data = _parser.Parse("HintsData.json");

        private bool CheckIsCanGet(string type)
        {
            bool flag = true;
            
            if (_usedHints[type])
            {
                flag = false;
            }
            
            if (DateTime.Now < _lastGetting.AddSeconds(5))
            {
                flag = false;
            }
            
            return flag;
        }
        
        /// <summary>
        /// Получение подсказки
        /// </summary>
        /// <param name="level">Номер уровня</param>
        /// <param name="type">"light" | "full"</param>
        public string Get(int level, string type)
        {
            if (!_allowedTypes.All(type.Contains))
            {
                throw new Exception($"'type' has not valid value: {type}");
            } 
            
            if (!CheckIsCanGet(type))
            {
                throw new Exception("Подсказка недоступна");
            }
            
            _usedHints[type] = true;
            _lastGetting = DateTime.Now;
            
            return _data[level.ToString()][type];
        }
    }
}