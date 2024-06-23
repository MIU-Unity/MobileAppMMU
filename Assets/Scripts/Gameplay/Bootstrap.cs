using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Newtonsoft.Json;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class Bootstrap : MonoBehaviour
    {
        public async void Start()
        {
            // yield return new WaitForFixedUpdate();
            AttemptsBehaviour.Instance.Initialize();
            TimerBehaviour.Instance.Initialize(Difficult.Get());
            ScoreBehaviour.Instance.Initialize();
            GameplayEventHandler.Instance.Initialize();
            QuestionsQueue.Instance.Initialize();

            var x = await CustomHttpClient.Instance.Get("https://jsonplaceholder.org/posts/1");

            var y = JsonConvert.DeserializeObject<Dictionary<string, string>>(x);
            
            Debug.Log(y["id"]);
        }
    }
}