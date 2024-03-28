using System;
using UnityEngine;

namespace Plugins.DebugAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DebugAttribute : PropertyAttribute
    {
        public readonly object[] Arguments;

        public DebugAttribute()
        {
            Arguments = new object[] {};
        }

        public DebugAttribute(params object[] parameters)
        {
            Arguments = parameters;
        }
        
    }
}