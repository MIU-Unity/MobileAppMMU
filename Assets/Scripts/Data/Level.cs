using UnityEngine;

namespace Data
{
    public static class Level
    {
        private static int _currentLevel;
        private static int _maxLevel;

        public static int GetCurrent()
        {
            return _currentLevel;
        }

        public static void SetCurrent(int level)
        {
            _currentLevel = level;
        }
        
        public static int GetMax()
        {
            return _maxLevel;
        }
        
        public static void Load()
        {
            _currentLevel = PlayerPrefs.GetInt("level", 1);
            _maxLevel = PlayerPrefs.GetInt("maxLevel", 10);
        }
        
        public static void Save()
        {
            PlayerPrefs.SetInt("level", _currentLevel);
            PlayerPrefs.SetInt("maxLevel", _maxLevel);
        }

        public static void Reset()
        {
            _currentLevel = 1;
            _maxLevel = 10;
            Save();
        }
    }
}