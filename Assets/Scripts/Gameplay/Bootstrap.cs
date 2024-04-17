using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public void Start()
        {
            GameplayEventHandler.Instance.Initialize();
            //add more instances when they release, like HintBehaviour, AttemptsBehaviour, etc.
        }
    }
}