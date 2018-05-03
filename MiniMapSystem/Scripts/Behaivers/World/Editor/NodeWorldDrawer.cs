using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace MiniMap
{

    [CustomEditor(typeof(NodeWorld), true)]
    public class NodeWorldDrawer : Editor
    {
        SerializedProperty script;
        
        SerializedProperty itemInfo;
        SerializedProperty icon;
        SerializedProperty mapKeys;
        SerializedProperty posHolder;
        SerializedProperty updateIcon;
        SerializedProperty updateIconRot;
        SerializedProperty iconPrefab;
        SerializedProperty updateTime;
        private void OnEnable()
        {
            InitProps();
        }
        private void InitProps()
        {
            script = serializedObject.FindProperty("m_Script");
            itemInfo = serializedObject.FindProperty("itemInfo");
            icon=serializedObject.FindProperty("icon");
            mapKeys=serializedObject.FindProperty("mapKeys");
            posHolder=serializedObject.FindProperty("posHolder");
            updateIcon=serializedObject.FindProperty("updateIcon");
            updateIconRot=serializedObject.FindProperty("updateIconRot");
            iconPrefab=serializedObject.FindProperty("iconPrefab");
            updateTime=serializedObject.FindProperty("updateTime");
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();
            EditorGUILayout.PropertyField(itemInfo);
            EditorGUILayout.PropertyField(iconPrefab);
            EditorGUILayout.PropertyField(icon);
            EditorGUILayout.PropertyField(mapKeys,true);
            EditorGUILayout.PropertyField(posHolder);
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