using System;
using UnityEngine;

namespace Data
{
    public class Difficult
    {
        public const int MAX_DIFFICULTY = 3;
        
        private static int _currentDifficulty;
        
        public static int Get()
        {
            return _currentDifficulty;
        }

        public static string GetName()
        {
            switch (_currentDifficulty)
            {
                case 1:
                    return "Легкая";
                case 2:
                    return "Средняя";
                case 3:
                    return "Сложная";
                default:
                    throw new Exception($"Invalid difficulty. Value must be between 0 and {MAX_DIFFICULTY}");
            }
        }
        
        public static void Set(int value)
        {
            if (value is < 1 or > MAX_DIFFICULTY)
                throw new Exception($"Invalid difficulty. Value must be between 0 and {MAX_DIFFICULTY}. " +
                                    $"Input value: {value}");
            
            _currentDifficulty = value;
        }

        public static void Save()
        {
            PlayerPrefs.SetInt("Difficulty", _currentDifficulty);
        }
        
        public static void Load()
        {
            Set(PlayerPrefs.GetInt("Difficulty", 1));
        }
        
        public static void Reset()
        {
            _currentDifficulty = 1;
            Save();
        }
    }
}
