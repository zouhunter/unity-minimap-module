using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
namespace MiniMap
{
    public static class MinimapUtility {
        /// <summary>
        /// 比例缩放
        /// </summary>
        /// <param name="posA"></param>
        /// <param name="outer"></param>
        /// <param name="scaleA"></param>
        /// <param name="scaleB"></param>
        /// <returns></returns>
        public static Vector2 SwitchPos(Vector2 centerA, Vector2 centerB, Vector2 scaleA, Vector2 scaleB, Vector2 posA)
        {
            Vector2 posB = Vector2.zero;
            posB.x = RatioCalc(posA.x, scaleA.x, scaleB.x, centerA.x, centerB.x);
            posB.y = RatioCalc(posA.y, scaleA.y, scaleB.y, centerA.y, centerB.y);
            return posB;
        }
        /// <summary>
        /// 比例计算
        /// </summary>
        /// <returns></returns>
        private static float RatioCalc(float en, float enMax, float ouMax, float enZero, float ouZero)
        {
            return ouZero + (ouMax / enMax) * (en - enZero);
        }
    }

}
