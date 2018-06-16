using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;

namespace MiniMap
{

    public class MapRegionRecorder : MonoBehaviour
    {
        [Header("调节可视尺寸")]
        public bool Show = false;
        [Range(10, 100)]
        public float halfx, harlz;
        [Range(-100, 100)]
        public float offsetx, offsetz;

        public Color GizmoColor = Color.blue;
       
        private Vector3 size;
        private Vector3 pos;
        void OnDrawGizmos()
        {
            if (Show)
            {
                Gizmos.color = GizmoColor;
                size.x = halfx;
                size.z = harlz;
                size.y = 2;
                pos.x = offsetx;
                pos.z = offsetz;
                Gizmos.DrawCube(pos, size * 2);
                UnityEditor.EditorUtility.SetDirty(this);
            }
        }
        [Header("两个尺寸")]
        public MapItem miniMap;
        public void RecordToMiniMap()
        {
            miniMap.worldSize = new Vector2(halfx, harlz) * 2;
            miniMap.worldPos = new Vector2(offsetx, offsetz);
            //if (reverse)
            //{
            //    miniMap.worldSize = -miniMap.worldSize;
            //}
            UnityEditor.EditorUtility.SetDirty(miniMap);
        }
    }
}
#endif