using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
namespace MiniMap
{

    public class MiniMapSystem : MonoBehaviour
    {
        public Transform mapParent;
        [SerializeField]
        private List<MapItem> mapList;
        [SerializeField]
        private List<Toggle> toggleList;
        private MapItem mapCurrent { get { return mapList[currmapIndex]; } }
        private int currmapIndex;

        void Awake(){
            RegisterToggleSwitchEvent();
        }

        void RegisterToggleSwitchEvent()
        {
            if (toggleList.Count != mapList.Count)
            {
                Debug.LogError("区域数目和按扭数目不相同！");
                return;
            }

            for (int i = 0; i < toggleList.Count; i++)
            {
                int index = i;
                //手动点击切换地图
                toggleList[i].onValueChanged.AddListener((x) => {
                    if (x) SwitchMapByToggle(index);
                });
            }
        }

        void SwitchMapByToggle(int floor)
        {
            currmapIndex = floor;
            for (int i = 0; i < mapList.Count; i++) {
                mapList[i].gameObject.SetActive(i == currmapIndex);
            }
        }

        public void SwitchMap(int floor)
        {
            if (floor > 0 && floor < mapList.Count && currmapIndex != floor)
            {
                currmapIndex = floor;
                toggleList[currmapIndex].isOn = true;
            }
        }
    }

}