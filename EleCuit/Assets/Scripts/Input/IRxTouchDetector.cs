using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Input
{
    public interface IRxSingleTouchInput
    {
        IObservable<Vector2> ObservableTouchPosition();
    }
    public interface IRxMultiTouchInput
    {
        IObservable<Vector2[]> ObservableTouchPositions();
    }
}
