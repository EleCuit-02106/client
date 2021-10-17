using System;
using System.Collections;
using System.Collections.Generic;
using EleCuit.Part;
using UnityEngine;

namespace EleCuit.Input
{
    /// <summary>
    /// ユーザーが電子回路部品をドラッグしていることを検出する
    /// </summary>
    public interface IRxPartDraggingDetector
    {
        /// <summary>
        /// ドラッグされている電子回路部品と現在の位置の購読を提供します
        /// </summary>
        /// <returns></returns>
        IObservable<(IPart part, Vector2 position)> ObservableDraggingPart();
    }
    public class PartDraggingDetector : MonoBehaviour, IRxPartDraggingDetector
    {
        private IRxTouchDetector touchDetector;

        void Start()
        {
            throw new NotImplementedException();
        }

        public IObservable<(IPart part, Vector2 position)> ObservableDraggingPart()
        {
            throw new NotImplementedException();
        }

    }
}