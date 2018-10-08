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
        public bool reverse;
        [Header("中心对齐的icon父级")]
        public RectTransform rect;

        private Vector2 rectPos { get { return rect.transform.position; } }
        private Vector2 rectSize { get { return rect.sizeDelta; } }
        private CanvasScaler canvasScaler;
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
        public Vector3 GetUIPositon(Vector3 wpos)
        {
            var pos = new Vector2(wpos.x, wpos.z);
            if (reverse)
            {
                pos = worldPos * 2 - pos;
            }

            Vector2 uipos = MinimapUtility.SwitchPos(worldPos, rectPos, worldSize, rectSize, pos);
            return uipos;
        }

        public Vector3 GetWorldPos(Vector2 pos)
        {
            if (reverse)
            {
                pos = rectPos * 2 - pos;
            }
            var newRectSize = WorpRectSize(rectSize);
            var targetPos = MinimapUtility.SwitchPos(rectPos, worldPos, newRectSize, worldSize, pos);

            return new Vector3(targetPos.x, 0, targetPos.y);
        }

        public bool Contains(Vector3 wpos)
        {
            var pos = new Vector2(wpos.x, wpos.z);

            if (reverse)
            {
                pos = worldPos * 2 - pos;
            }

            var halfx = Mathf.Abs(worldSize.x * 0.5f);
            var halfz = Mathf.Abs(worldSize.y * 0.5f);
            if (pos.x > -halfx + worldPos.x && pos.x < halfx + worldPos.x)
            {
                if (pos.y > -halfz + worldPos.y && pos.y < halfz + worldPos.y)
                {
                    return true;
                }
            }
            return false;
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

        private Vector2 WorpRectSize(Vector2 rectSize)
        {
            if (canvasScaler == null)
                canvasScaler = GetComponentInParent<CanvasScaler>();
            if (canvasScaler == null) return rectSize;

            if (canvasScaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                rectSize = rectSize * ((Screen.width / canvasScaler.referenceResolution.x) *(1 - canvasScaler.matchWidthOrHeight) + 
                    (canvasScaler.matchWidthOrHeight) *((Screen.height /canvasScaler.referenceResolution.y)));
            }
            return rectSize;
        }
    }

}