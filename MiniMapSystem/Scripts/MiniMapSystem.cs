using UnityEngine;
using UnityEngine.UI;
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
    public class MiniMapSystem
    {
        private List<MapItem> maps = new List<MapItem>();
        private List<NodeWorld> nodes = new List<NodeWorld>();

        private MiniMapSystem() { }
        private static MiniMapSystem _instence;
        public static MiniMapSystem Instence
        {
            get
            {
                if (_instence == null)
                {
                    _instence = new MiniMapSystem();
                }
                return _instence;
            }
        }

        /// <summary>
        /// 注册地图
        /// </summary>
        /// <param name="map"></param>
        public void Regist(MapItem map)
        {
            if(!maps.Contains(map))
            {
                maps.Add(map);

                foreach (var node in nodes)
                {
                    if(node.mapKeys.Contains(map.mapKey))
                    {
                        node.RegistNodeIcon(map);
                    }
                }
            }
        }
        /// <summary>
        /// 移除地图
        /// </summary>
        /// <param name="map"></param>
        public void Remove(MapItem map)
        {
            if (maps.Contains(map))
            {
                maps.Remove(map);

                foreach (var node in nodes)
                {
                    if (node.mapKeys.Contains(map.mapKey))
                    {
                        node.RemoveNodeIcon(map);
                    }
                }
            }
        }
        /// <summary>
        /// 注释标记点
        /// </summary>
        /// <param name="node"></param>
        public void Regist(NodeWorld node)
        {
            if (!nodes.Contains(node))
            {
                nodes.Add(node);

                foreach (var map in maps)
                {
                    if (node.mapKeys.Contains(map.mapKey))
                    {
                        node.RegistNodeIcon(map);
                    }
                }
            }
        }

        /// <summary>
        /// 移除标记点
        /// </summary>
        /// <param name="node"></param>
        public void Remove(NodeWorld node)
        {
            if (nodes.Contains(node))
            {
                nodes.Remove(node);

                foreach (var map in maps)
                {
                    if (node.mapKeys.Contains(map.mapKey))
                    {
                        node.RemoveNodeIcon(map);
                    }
                }
            }
        }
    }
}