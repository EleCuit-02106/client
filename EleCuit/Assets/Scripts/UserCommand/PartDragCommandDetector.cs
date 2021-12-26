using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Diagnostics;
using EleCuit.Input;
using Zenject;
using UnityUtility.Linq;
using UnityUtility.Enums;
using EleCuit.Parts;
using System.Linq;
using System;
using Sirenix.Utilities;
using du.di;
using EleCuit.UI;
using UnityUtility;
using Sirenix.OdinInspector;

namespace EleCuit.UserCommand
{
    /// <summary>
    /// 部品をドラッグしているコマンドを発行する
    /// </summary>
    public interface IRxPartDragCommandPublisher
    {
        /// <summary>
        /// 電子回路部品のドラッグ開始から終了までの座標軌跡を発行します。
        /// 終了したらOnCompletedするので再度購読が必要
        /// </summary>
        /// <param name="type">購読する部品</param>
        /// <returns></returns>
        IObservable<Vector2> ObservableDraggingPart(PartType type);
    }
    /// <summary>
    /// インプット情報から部品のドラッグコマンドを識別する
    /// </summary>
    public class PartDragCommandDetector : SerializedMonoBehaviour, IRxPartDragCommandPublisher
    {
        [SerializeField]
        private IReadOnlyPartToolBoxButtons m_partToolBox;

        public IObservable<Vector2> ObservableDraggingPart(PartType partType) =>
            ObservableTouchInput
                .ObservableTouchBegan()
                .Where(_ => m_partToolBox.PartTypeOfButtonBoundsTable.ContainsKey(partType))
                .Where(point => m_partToolBox.PartTypeOfButtonBoundsTable[partType].Contains(point))
                .SelectMany(ObservableTouchInput.ObservableTouchMoved())
                .TakeUntil(ObservableTouchInput.ObservableTouchEnded());
    }
}