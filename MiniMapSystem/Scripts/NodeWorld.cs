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

        public int mapID;
        public Transform posHolder;
        public bool updatePos;

        [SerializeField]
        private NodeIcon iconPrefab;
        private float timer;
        private float time = 3;
        protected MapItem map;
        private NodeIcon nodeicon;
        void Update()
        {
            if ((timer += Time.deltaTime) > time)
            {
                timer = 0;
                if (map == null)
                {

                    MapItem find = FindObjectOfType<MapItem>();
                    if (find.mapID == this.mapID)
                    {
                        map = find;
                        nodeicon = Instantiate(iconPrefab);
                        nodeicon.InitICON(this, find);
                        nodeicon.transform.position = map.GetUIPositon(posHolder.position);
                    }
                }
                else
                {
                    if (updatePos)
                    {
                        nodeicon.transform.position = map.GetUIPositon(posHolder.position);
                    }
                }
            }
        }
    }

}
