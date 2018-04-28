using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Sprites;
using UnityEngine.Scripting;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;
using UnityEngine.Assertions.Comparers;
using System.Collections;
using System.Collections.Generic;
namespace MiniMap
{

    [CustomEditor(typeof(MapRegionRecorder))]
    public class MapRegionRecorderDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("RecordToMiniMap"))
            {
                ((MapRegionRecorder)target).RecordToMiniMap();
            }
        }
    }
}