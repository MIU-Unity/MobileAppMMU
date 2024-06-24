using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Newtonsoft.Json;
using UI;
using UnityEngine;
using Object = System.Object;

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
            await QuestionsQueue.Instance.Initialize();

            // var x = await CustomHttpClient.Instance.Get("/tags");
            //
            // var y = JsonConvert.DeserializeObject<ServerResponse<TagEntity>>(x);
            //
            // Debug.Log(y.data[0].value);
        }
    }
}