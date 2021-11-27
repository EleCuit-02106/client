using System;
using System.Collections;
using System.Collections.Generic;
using EleCuit.Parts;
using UnityEngine;

namespace EleCuit.Input
{
    /// <summary>
    /// ユーザーが電線を描画していることを検知する
    /// </summary>
    public interface IRxCircuitDrawingInput
    {
        /// <summary>
        /// 描いている電線の座標の購読を提供します
        /// </summary>
        /// <returns></returns>
        IObservable<Vector2> ObservableCircuitDrawing();
    }
    public class CircuitDrawingDetector : MonoBehaviour, IRxCircuitDrawingInput
    {
        void Start()
        {
            throw new NotImplementedException();
        }

        public IObservable<Vector2> ObservableCircuitDrawing()
        {
            throw new NotImplementedException();
        }
    }
}