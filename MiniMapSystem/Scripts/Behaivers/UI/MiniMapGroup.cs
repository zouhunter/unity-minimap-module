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
        [SerializeField]
        private int currmapIndex;

        private MapItem mapCurrent { get { return mapList[currmapIndex]; } }
       

        void Awake(){
            selector.InitSelector(mapList.Count, SwitchMapByToggle);
            selector.SetState(currmapIndex,true);
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
            if (floor >= 0 && floor < mapList.Count && currmapIndex != floor)
            {
                currmapIndex = floor;
                selector.SetState(currmapIndex,true);
            }
        }
    }

}