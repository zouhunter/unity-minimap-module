using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace MiniMap
{

    [CustomEditor(typeof(NodeWorld), true)]
    public class NodeWorldDrawer : Editor
    {
        SerializedProperty updateTime;
        SerializedProperty updateIcon;
        SerializedProperty updateIconRot;
        private void OnEnable()
        {
            InitProps();
        }
        private void InitProps()
        {
            updateIcon=serializedObject.FindProperty("updateIcon");
            updateIconRot=serializedObject.FindProperty("updateIconRot");
            updateTime=serializedObject.FindProperty("updateTime");
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.PropertyField(updateIcon);
            if(updateIcon.boolValue)
            {
                EditorGUILayout.PropertyField(updateTime);
                EditorGUILayout.PropertyField(updateIconRot);
            }
            serializedObject.ApplyModifiedProperties();

        }
    }
}