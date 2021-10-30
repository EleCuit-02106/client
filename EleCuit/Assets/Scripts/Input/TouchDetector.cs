using System;
using System.Collections;
using System.Collections.Generic;
using du.di;
using UnityEngine;

namespace EleCuit.Input
{
    /// <summary>
    /// タッチを検出する
    /// </summary>
    public class TouchDetector : MonoBehaviour, IRxTouchDetector
    {
        void Start()
        {
            
        }

        public IObservable<Vector2[]> ObservableTouchPosition =>
            throw new NotImplementedException();
    }
}