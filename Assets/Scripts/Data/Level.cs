using UnityEngine;

namespace Data
{
    public static class Level
    {
        private static int _currentLevel;
        private static int _maxOpenedLevel;

        public static int GetCurrent()
        {
            return _currentLevel;
        }

        public static int GetMax()
        {
            return _maxOpenedLevel;
        }
        
        public static void Load()
        {
            _currentLevel = PlayerPrefs.GetInt("level", 1);
            _maxOpenedLevel = PlayerPrefs.GetInt("maxLevel", 1);
        }
        
        public static void Save()
        {
            PlayerPrefs.SetInt("level", _currentLevel);
            PlayerPrefs.SetInt("maxLevel", _maxOpenedLevel);
        }
    }
}