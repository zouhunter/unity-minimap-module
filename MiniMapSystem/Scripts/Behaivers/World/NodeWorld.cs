using UnityEngine;
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
        private int _mapKey;
        public int mapKey { get { return _mapKey; } }
        public Transform posHolder;
        public bool updatePos;

        [SerializeField]
        private NodeIcon iconPrefab;
        private float timer;
        private float time = 3;
        private Dictionary<MapItem, NodeIcon> mapDic = new Dictionary<MapItem, NodeIcon>();// nodeicon;
        void OnEnable()
        {
            MiniMapSystem.Instence.Regist(this);
        }
        void OnDisable()
        {
            MiniMapSystem.Instence.Remove(this);
        }
        public void Update()
        {
            if (updatePos && mapDic.Count > 0 && (timer += Time.deltaTime) > time)
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
                mapDic.Remove(map);
            }
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