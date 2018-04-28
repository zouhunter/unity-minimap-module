using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
namespace MiniMap
{

    public class MiniMapGroup : MonoBehaviour
    {
        [SerializeField]
        private MapSelector selector;
        [SerializeField]
        private Transform mapParent;
        [SerializeField]
        private List<MapItem> mapList;

        private MapItem mapCurrent { get { return mapList[currmapIndex]; } }
        private int currmapIndex;

        void Awake(){
            selector.InitSelector(mapList.Count, SwitchMapByToggle);
        }

    
        private void SwitchMapByToggle(int floor)
        {
            currmapIndex = floor;
            for (int i = 0; i < mapList.Count; i++)
            {
                mapList[i].gameObject.SetActive(i == currmapIndex);
            }
        }

        public void SwitchMap(int floor)
        {
            if (floor > 0 && floor < mapList.Count && currmapIndex != floor)
            {
                currmapIndex = floor;
                selector.SetState(currmapIndex);
            }
        }
    }

}