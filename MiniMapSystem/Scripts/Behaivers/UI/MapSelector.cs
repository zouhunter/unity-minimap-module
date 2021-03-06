﻿using UnityEngine;
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
using System;

namespace MiniMap
{
    public abstract class MapSelector : MonoBehaviour
    {
        public abstract void InitSelector(int mapCount, UnityAction<int> onSelect);
        public abstract void SetState(int currmapIndex,bool trigger);
    }
}