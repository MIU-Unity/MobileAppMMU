using System.Threading.Tasks;
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
        
        public async Task Load()
        {
            Difficult.Load();
            await Level.Load();
        }

        public void Reset()
        {
            Difficult.Reset();
            Level.Reset();
        }
    }
}