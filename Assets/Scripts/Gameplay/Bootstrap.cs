using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public void Start()
        {
            const int difficulty = 1;
            TimerBehaviour.Instance.Initialize(difficulty);
            GameplayEventHandler.Instance.Initialize();
            //add more instances when they release, like HintBehaviour, AttemptsBehaviour, etc.
        }
    }
}