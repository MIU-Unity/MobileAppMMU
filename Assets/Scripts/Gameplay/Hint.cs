using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Hint : MonoBehaviour
    {
        private DateTime _lastGetting = DateTime.Now;
        private readonly Dictionary<string, bool> _usedHints = new()
        {
            { "light", false },
            { "full", false }
        };

        private readonly Dictionary<int, Dictionary<string, string>> _data = new()
        {
            {1, new Dictionary<string, string>()
            {
                { "light", "Наводящая подсказка для 1 уровня" },
                { "full", "Прямая подсказка для 1 уровня" },
            }},
            {2, new Dictionary<string, string>()
            {
                { "light", "Наводящая подсказка для 2 уровня" },
                { "full", "Прямая подсказка для 2 уровня" },
            }},
            {3, new Dictionary<string, string>()
            {
                { "light", "Наводящая подсказка для 3 уровня" },
                { "full", "Прямая подсказка для 3 уровня" },
            }},
            {4, new Dictionary<string, string>()
            {
                { "light", "Наводящая подсказка для 4 уровня" },
                { "full", "Прямая подсказка для 4 уровня" },
            }},
            {5, new Dictionary<string, string>()
            {
                { "light", "Наводящая подсказка для 5 уровня" },
                { "full", "Прямая подсказка для 5 уровня" },
            }},
        };

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

        public string Get(int level, string type)
        {
            if (!CheckIsCanGet(type))
            {
                return "Подсказвка недоступна";
            }

            _usedHints[type] = true;
            _lastGetting = DateTime.Now;
            
            return _data[level][type];
        }
    }
}