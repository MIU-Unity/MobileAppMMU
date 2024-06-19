using System;
using UnityEngine;

namespace Data
{
    public class Difficult
    {
        private const int MAX_DIFFICULTY = 3;
        
        private static int _currentDifficulty;
        
        public static int Get()
        {
            return _currentDifficulty;
        }
        
        public static void Set(int value)
        {
            if (value is < 1 or > MAX_DIFFICULTY)
                throw new Exception($"Invalid difficulty. Value must be between 0 and {MAX_DIFFICULTY}");
            
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
    }
}
