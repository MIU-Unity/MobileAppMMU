using System;
using UnityEngine;

namespace Common.Utility
{
    public abstract class Singleton<T> : MonoBehaviour where T : class
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    throw new NullReferenceException($"{typeof(T).Name} not found!");
                }

                return _instance;
            }
        }
    }
}