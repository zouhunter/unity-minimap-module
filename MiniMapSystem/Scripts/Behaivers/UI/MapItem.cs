using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

namespace MiniMap
{
    public class MapItem : MonoBehaviour
    {
        [SerializeField]
        private int _mapKey;
        public int mapKey { get { return _mapKey; } }

        public Vector2 worldSize;
        public Vector2 worldPos;
        public List<NodeIcon> iconPrefabs;

        [Header("中心对齐的icon父级")]
        public RectTransform rect;

        private Vector2 rectPos { get { return rect.transform.position; } }
        private Vector2 rectSize { get { return rect.sizeDelta * 0.5f; } }

        void Awake()
        {
            MiniMapSystem.Instence.Regist(this);
        }

        void OnDestroy()
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
        internal NodeIcon CreateIcon(string iconPrefabName)
        {
            var prefab = iconPrefabs.Find(x => x.name == iconPrefabName);
            if (prefab == null && iconPrefabs.Count > 0)
            {
                prefab = iconPrefabs[0];
            }
            var icon = Instantiate(prefab);
            icon.transform.SetParent(transform, false);
            icon.gameObject.SetActive(true);
            return icon;
        }
    }

}