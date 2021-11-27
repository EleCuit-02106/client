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
    public class TouchDetector : IRxSingleTouchInput, IRxMultiTouchInput
    {
        public TouchDetector()
        {
            //ObservableTouchInput.
        }

        public IObservable<Vector2> ObservableTouchPosition()
        {
            throw new NotImplementedException();
        }

        public IObservable<Vector2[]> ObservableTouchPositions()
        {
            throw new NotImplementedException();
        }
    }
}