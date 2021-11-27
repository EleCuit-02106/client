using System;
using System.Collections;
using System.Collections.Generic;
using du.di;
using EleCuit.Parts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityUtility.Linq;
using Zenject;

namespace EleCuit.Input
{
    /// <summary>
    /// ユーザーが電子回路部品をドラッグしていることを検出する
    /// </summary>
    public interface IRxPartDraggingInput
    {
        /// <summary>
        /// ドラッグされている電子回路部品と現在の位置の購読を提供します
        /// </summary>
        /// <returns></returns>
        IObservable<(IPart part, Vector2 position)> ObservableDraggingPart();
    }
    public class PartDraggingDetector : MonoBehaviour, IRxPartDraggingInput
    {
        [SerializeField]
        private RectTransform m_partInventoryPanelArea;

        void Start()
        {
            Vector3[] localCorners = new Vector3[4];
            Vector3[] worldCorners = new Vector3[4];

            m_partInventoryPanelArea.GetLocalCorners(localCorners);
            m_partInventoryPanelArea.GetWorldCorners(worldCorners);

            localCorners.Print("local");
            worldCorners.Print("world");
        }

        public IObservable<(IPart part, Vector2 position)> ObservableDraggingPart()
        {
            throw new NotImplementedException();
        }

    }
}