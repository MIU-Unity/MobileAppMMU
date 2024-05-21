using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public void Start()
        {
            HintBehaviour.Instance.Initialize();
            AttemptsBehaviour.Instance.Initialize();
            TimerBehaviour.Instance.Initialize(1);
            
            GameplayEventHandler.Instance.Initialize(); // всегда последним
            
            //add more instances when they release
            //add more instances when they release
        }
    }
}