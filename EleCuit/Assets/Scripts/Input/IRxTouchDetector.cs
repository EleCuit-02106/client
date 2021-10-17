using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Input
{
    public interface IRxTouchDetector
    {
        /// <summary>
        /// タッチしている座標を購読します
        /// </summary>
        IObservable<Vector2[]> ObservableTouchPosition { get; }
    }
}
