using Common.Utility;
using UnityEngine;

namespace Gameplay
{
    public class ScoreBehaviour : Singleton<ScoreBehaviour>
    {
        private int _currentScore;

        public void Initialize()
        {
            _currentScore = 0;
        }
        
        public int Get()
        {
            return _currentScore;
        }

        public void Increase() => _currentScore++;
    }
}