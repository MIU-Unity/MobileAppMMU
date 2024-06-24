using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Data
{
    public static class Level
    {
        private static int _currentLevel = PlayerPrefs.GetInt("level", 1);
        private static int _maxLevel;

        public static int GetCurrent()
        {
            return _currentLevel;
        }

        public static void SetCurrent(int level)
        {
            if (level < 1) level = 1;
            _currentLevel = level;
        }
        
        public static int GetMax()
        {
            return _maxLevel;
        }
        
        public static async Task Load()
        {
            _currentLevel = PlayerPrefs.GetInt("level", 1);
            
            var x = await CustomHttpClient.Instance.Get($"/levels");
            var y = JsonConvert.DeserializeObject<ServerResponse<LevelEntity>>(x);
            _maxLevel = PlayerPrefs.GetInt("maxLevel", y.data.Count);
        }
        
        public static void Save()
        {
            PlayerPrefs.SetInt("level", _currentLevel);
        }

        public static void Reset()
        {
            _currentLevel = 1;
            Save();
        }
    }
}