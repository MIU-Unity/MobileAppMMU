using Common.Utility;
using UnityEngine;

namespace Data
{
    public class SaveLoadManager : Singleton<SaveLoadManager>
    {
        public void Save()
        {
            Difficult.Save();
            Level.Save();
        }
        
        public void Load()
        {
            Difficult.Load();
            Level.Load();
        }

        public void Reset()
        {
            Difficult.Reset();
            Level.Reset();
        }
    }
}