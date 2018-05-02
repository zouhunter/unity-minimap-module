﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

namespace MiniMap
{
    public class NodeWorld : MonoBehaviour
    {
        public string itemInfo;
        public Sprite icon;

        [SerializeField]
        private List<int> mapKeys = new List<int>();
        public Transform posHolder;
        public bool updatePos;

        [SerializeField]
        private NodeIcon iconPrefab;
        private float timer;
        public float updateTime = 3;
        private Dictionary<MapItem, NodeIcon> mapDic = new Dictionary<MapItem, NodeIcon>();// nodeicon;
        void Awake()
        {
            MiniMapSystem.Instence.Regist(this);
        }
        void OnDestroy()
        {
            MiniMapSystem.Instence.Remove(this);
        }
        public void Update()
        {
            if (updatePos && mapDic.Count > 0 && (timer += Time.deltaTime) > updateTime)
            {
                timer = 0;
                UpdateNodeIconsPos();
            }
        }

        public void RegistNodeIcon(MapItem map)
        {
            if(!mapDic.ContainsKey(map))
            {
                mapDic.Add(map, CreateNodeIcon(map));
            }
            UpdateNodeIconsPos();
        }

        public void RemoveNodeIcon(MapItem map)
        {
            if(mapDic.ContainsKey(map))
            {
                var mapIcon = mapDic[map];
                if(mapIcon != null && mapIcon.gameObject != null){
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
            if(mapKeys.Count == 0)
            {
                return true;
            }
            return false;
        }

        private NodeIcon CreateNodeIcon(MapItem map)
        {
            var nodeicon = Instantiate(iconPrefab);
            nodeicon.InitICON(this, map);
            nodeicon.transform.position = map.GetUIPositon(posHolder.position);
            return nodeicon;
        }

        private void UpdateNodeIconsPos()
        {
            foreach (var item in mapDic)
            {
                var map = item.Key;
                var nodeicon = item.Value;
                nodeicon.transform.position = map.GetUIPositon(posHolder.position);
            }
        }

    }
}