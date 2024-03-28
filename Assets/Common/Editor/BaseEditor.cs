using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Plugins.DebugAttribute;
using UnityEditor;
using UnityEngine;

namespace Common.Editor
{
    [CustomEditor(typeof(MonoBehaviour),editorForChildClasses:true)]
    public class BaseEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            IEnumerable<MethodInfo> methods = target.GetType()
                .GetMethods(BindingFlags.Instance | 
                            BindingFlags.Static | 
                            BindingFlags.Public |
                            BindingFlags.NonPublic);
            
            foreach (MethodInfo method in methods)
            {
                DebugAttribute debugAttribute = 
                    Attribute.GetCustomAttribute(method, typeof(DebugAttribute)) as DebugAttribute;
            
                if (debugAttribute != null)
                {
                    var arguments = debugAttribute.Arguments;
                    var btnStyle = new GUIStyle(GUI.skin.button);
                    btnStyle.padding = GUI.skin.box.padding;
                    Rect pos = new Rect(5,6.5f, 14, 14);
                    if (GUI.Button(new Rect(pos), EditorGUIUtility.IconContent("_Popup"),btnStyle))
                    {
                        if ((method.GetParameters().Length != 0 && arguments.Length == 0)
                            || (method.GetParameters().Length != arguments.Length))
                            throw new Exception(@$"The attribute belonging to the {method.Name} method must have the same parameters");
                        
                        method?.Invoke(target, arguments);
                    }
                }
            }
            
            base.OnInspectorGUI();
        }
        
        
    }
}