using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

namespace MiniMap
{
    public class ToggleListSelector : MapSelector
    {
        [SerializeField]
        private List<Toggle> toggleList;
        private bool isSetting;
        public override void InitSelector(int mapCount,UnityAction<int> onSelect)
        {
            if (toggleList.Count != mapCount)
            {
                Debug.LogError("区域数目和按扭数目不相同！");
                return;
            }

            for (int i = 0; i < toggleList.Count; i++)
            {
                int index = i;
                //手动点击切换地图
                toggleList[i].onValueChanged.AddListener((x) => {
                    if (x && onSelect != null && !isSetting) onSelect(index);
                });
            }
        }
        public override void SetState(int currmapIndex)
        {
            isSetting = true;
            toggleList[currmapIndex].isOn = true;
            isSetting = false;
        }
    }
   
}

