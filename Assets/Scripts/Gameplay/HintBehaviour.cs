using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utility;
using UnityEngine;
using Data;
using Plugins.DebugAttribute;

namespace Gameplay
{
    public enum HintType
    {
        light = 0,
        full = 1
    }
    
    public class HintBehaviour : Singleton<HintBehaviour>
    {
        private DateTime _lastGetting;
        private readonly string[] _allowedTypes = { "light", "full" };
        private readonly Dictionary<string, bool> _usedHints = new()
        {
            { HintType.light.ToString(), false },
            { HintType.full.ToString(), false }
        };

        private static readonly JSONParser<Dictionary<string, string>[]> Parser = new();
        private static readonly Dictionary<string, Dictionary<string, string>[]> HintsData = Parser.Parse("HintsData.json");

        
        // [Debug]
        public void Initialize()
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
        public string Get(int level, HintType type)
        {
            if (!HasValidType(type))
            {
                throw new Exception($"'type' has not valid value: {type}");
            }

            string reason = string.Empty;
            
            if (!IsHintAvailable(type, ref reason))
            {
                throw new Exception($"Подсказка недоступна ({reason})");
            }
            
            _usedHints[type.ToString()] = true;
            _lastGetting = DateTime.Now;
            
            Debug.Log(HintsData[level.ToString()][0 /* ЗАГЛУШКА */][type.ToString()]);

            return HintsData[level.ToString()][0 /* ЗАГЛУШКА */][type.ToString()];
        }
        
        private bool IsHintAvailable(HintType type, ref string reason)
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

        public bool IsHintUsed(HintType type)
        {
            if (!HasValidType(type))
            {
                throw new Exception($"'type' has not valid value: {type}");
            }
            return _usedHints[type.ToString()];
        }

        private bool HasValidType(HintType type)
        {
            return _allowedTypes.Any(type.ToString().Contains);
        }
    }
}