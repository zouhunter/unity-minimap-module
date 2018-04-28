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

        protected NodeWorld worldItem;
        protected MapItem map;

        public void InitICON(NodeWorld worldItem, MapItem map)
        {
            this.map = map;
            this.worldItem = worldItem;
            image.sprite = worldItem.icon;
            transform.SetParent(map.GetIconParent(), false);
        }
    }

}
