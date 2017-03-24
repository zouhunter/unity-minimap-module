using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
namespace MiniMap
{
    public class NodeIcon : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        private NodeWorld worldItem;
        private MapItem map;

        public void InitICON(NodeWorld worldItem, MapItem map)
        {
            this.map = map;
            this.worldItem = worldItem;
            image.sprite = worldItem.icon;
            transform.SetParent(map.GetIconParent(), false);
        }
    }

}
