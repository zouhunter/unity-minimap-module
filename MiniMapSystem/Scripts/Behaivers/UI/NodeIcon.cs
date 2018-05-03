using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
namespace MiniMap
{
    [RequireComponent(typeof(Image))]
    public class NodeIcon : MonoBehaviour
    {
        protected Image m_image;

        protected NodeWorld worldItem;
        protected MapItem map;

        protected virtual void Awake()
        {
            m_image = GetComponent<Image>();
        }

        public virtual void InitICON(NodeWorld worldItem, MapItem map)
        {
            this.map = map;
            this.worldItem = worldItem;
            m_image.sprite = worldItem.icon;
        }
    }

}
