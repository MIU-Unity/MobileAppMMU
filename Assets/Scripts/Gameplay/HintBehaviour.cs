using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Data;
using Plugins.DebugAttribute;

namespace Gameplay
{
    public class HintBehaviour : MonoBehaviour
    {
        private DateTime _lastGetting;
        private readonly string[] _allowedTypes = { "light", "full" };
        private readonly Dictionary<string, bool> _usedHints = new()
        {
            { "light", false },
            { "full", false }
        };

        private static readonly JSONParser<Dictionary<string, string>> Parser = new();
        private static readonly Dictionary<string, Dictionary<string, string>> HintsData = Parser.Parse("HintsData.json");

        
        // [Debug]
        void Initialize()
        {
            _lastGetting = DateTime.Now;
            if (HintsData.Count < 1)
            {
                throw new Exception("Data is empty");
            }
        }
        
        /// <summary>
        /// Получение подсказки
        /// </summary>
        /// <param name="level">Номер уровня</param>
        /// <param name="type">"light" | "full"</param>
        [Debug(1, "light")]
        public string Get(int level, string type)
        {
            CheckIsValidType(type);

            string reason = string.Empty;
            
            if (!CheckIsCanGet(type, ref reason))
            {
                throw new Exception($"Подсказка недоступна ({reason})");
            }
            
            _usedHints[type] = true;
            _lastGetting = DateTime.Now;
            
            Debug.Log(HintsData[level.ToString()][type]);

            return HintsData[level.ToString()][type];
        }
        
        private bool CheckIsCanGet(string type, ref string reason)
        {
            bool flag = true;
            
            if (IsHintUsed(type))
            {
                flag = false;
                reason = "Already used";
            }
            
            if (DateTime.Now < _lastGetting.AddSeconds(5))
            {
                flag = false;
                reason = "Less then 5 seconds ago";
            }
            
            return flag;
        }

        public bool IsHintUsed(string type)
        {
            CheckIsValidType(type);
            return _usedHints[type];
        }

        private bool CheckIsValidType(string type)
        {
            if (!_allowedTypes.Any(type.Contains))
            {
                throw new Exception($"'type' has not valid value: {type}");
            }

            return true;
        }
    }
}