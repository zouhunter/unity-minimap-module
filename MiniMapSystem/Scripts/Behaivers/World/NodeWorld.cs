using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Collections;

namespace MiniMap
{
    public class NodeWorld : MonoBehaviour
    {
        [SerializeField]
        private string iconPrefab;
        public string itemInfo;
        public Sprite icon;
        public Color color = Color.white;
        [SerializeField]
        private List<int> mapKeys = new List<int>();
        public Transform posHolder;
        [HideInInspector]
        public bool updateIcon;
        [HideInInspector]
        public bool updateIconRot;

        [HideInInspector]
        public float updateTime = 3;

        private float timer;
        private Dictionary<MapItem, NodeIcon> mapDic = new Dictionary<MapItem, NodeIcon>();// nodeicon;

        private void OnEnable()
        {
            SetIconsState(true);
            UpdateNodeIcons();
        }

        void Start()
        {
            if (posHolder == null)
                posHolder = transform;

            MiniMapSystem.Instence.Regist(this);
        }
        private void OnDisable()
        {
            SetIconsState(false);
        }

        void OnDestroy()
        {
            MiniMapSystem.Instence.Remove(this);
        }
        public void Update()
        {
            if (updateIcon && mapDic.Count > 0 && (timer += Time.deltaTime) > updateTime)
            {
                timer = 0;
                UpdateNodeIcons();
            }
        }

        public void RegistNodeIcon(MapItem map)
        {
            if (!mapDic.ContainsKey(map))
            {
                mapDic.Add(map, CreateNodeIcon(map));
            }
            if(gameObject.activeInHierarchy)
                StartCoroutine(DelyUpdate());
        }

        private IEnumerator DelyUpdate()
        {
            yield return new WaitForFixedUpdate();
            UpdateNodeIcons();
        }

        public void RemoveNodeIcon(MapItem map)
        {
            if (mapDic.ContainsKey(map))
            {
                var mapIcon = mapDic[map];
                if (mapIcon != null && mapIcon.gameObject != null)
                {
                    Destroy(mapIcon.gameObject);
                }
                mapDic.Remove(map);
            }
        }

        public bool WillShowOnMap(int key)
        {
            if (mapKeys.Contains(key))
            {
                return true;
            }
            if (mapKeys.Count == 0)
            {
                return true;
            }
            return false;
        }

        private NodeIcon CreateNodeIcon(MapItem map)
        {
            var nodeicon = map.CreateIcon(iconPrefab);
            nodeicon.InitICON(this, map);
            nodeicon.transform.localPosition = map.GetUIPositon(posHolder.position) - map.transform.position;
            return nodeicon;
        }

        private void UpdateNodeIcons()
        {
            foreach (var item in mapDic)
            {
                var map = item.Key;
                var nodeicon = item.Value;

                if (nodeicon != null && nodeicon.gameObject != null)
                {
                    var inMap = map.Contains(posHolder.position);
                    nodeicon.gameObject.SetActive(inMap);

                    if (nodeicon.gameObject.activeInHierarchy)
                    {
                        nodeicon.transform.localPosition = map.GetUIPositon(posHolder.position) - map.transform.position;
                        if (updateIconRot)
                        {
                            var rot = -transform.eulerAngles.y;
                            if (map.reverse){
                                rot = 180 + rot;
                            }
                            nodeicon.transform.eulerAngles = new Vector3(0, 0, rot);
                            
                        }
                    }
                }

            }
        }

        private void SetIconsState(bool enable)
        {
            foreach (var item in mapDic)
            {
                var nodeicon = item.Value;
                if (nodeicon)
                {
                    nodeicon.gameObject.SetActive(enable);
                }
            }
        }
    }
}