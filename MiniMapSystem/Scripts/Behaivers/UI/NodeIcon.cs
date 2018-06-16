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

        public virtual void InitICON(NodeWorld worldItem, MapItem map)
        {
            this.map = map;
            this.worldItem = worldItem;
            m_image = GetComponent<Image>();
            m_image.sprite = worldItem.icon;
            m_image.color = worldItem.color;
            gameObject.SetActive(worldItem.gameObject.activeSelf);
        }
    }

}
