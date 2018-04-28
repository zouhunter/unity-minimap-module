using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
namespace MiniMap
{
    public class MapItem : MonoBehaviour
    {
        [SerializeField]
        private int _mapKey;
        public int mapKey { get { return _mapKey; } }

        public Vector2 worldSize;
        public Vector2 worldPos;
        [Header("中心对齐的icon父级")]
        public RectTransform rect;

        private Vector2 rectPos { get { return rect.transform.position; } }
        private Vector2 rectSize { get { return rect.sizeDelta * 0.5f; } }

        void OnEnable()
        {
            MiniMapSystem.Instence.Regist(this);
        }

        void OnDisable()
        {
            MiniMapSystem.Instence.Remove(this);
        }

        /// <summary>
        /// 更新ui标记点坐标
        /// </summary>
        /// <param name="pos"></param>
        public Vector3 GetUIPositon(Vector3 pos)
        {
            Vector2 uipos = MinimapUtility.SwitchPos(worldPos, rectPos, worldSize, rectSize, new Vector2(pos.x, pos.z));
            return uipos;
        }

        public Transform GetIconParent()
        {
            return transform;
        }
    }

}