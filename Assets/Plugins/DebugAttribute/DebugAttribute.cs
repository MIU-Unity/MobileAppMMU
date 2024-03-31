using System;
using UnityEngine;

namespace Plugins.DebugAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DebugAttribute : PropertyAttribute
    {
        public readonly object[] Arguments;

        /// <summary>
        /// Attribute is used to mark methods that should be invoked when the user clicks a button in the inspector.
        /// </summary>
        public DebugAttribute()
        {
            Arguments = new object[] {};
        }

        /// <summary>
        /// Attribute is used to mark methods that should be invoked when the user clicks a button in the inspector.
        /// </summary>
        /// <param name="parameters">An array of objects that will be assigned to the Arguments property.</param>
        public DebugAttribute(params object[] parameters)
        {
            Arguments = parameters;
        }
        
    }
}