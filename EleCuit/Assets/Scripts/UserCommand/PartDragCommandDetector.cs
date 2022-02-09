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
using UnityUtility.Rx.Operators;
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
        /// <returns></returns>
        IObservable<(PartType type, Vector2 point)> ObservableDraggingPart();
    }
    /// <summary>
    /// インプット情報から部品のドラッグコマンドを識別する
    /// </summary>
    public class PartDragCommandDetector : SerializedMonoBehaviour, IRxPartDragCommandPublisher
    {
        [SerializeField]
        private IReadOnlyPartToolBoxButtons m_partToolBox;

        public IObservable<(PartType type, Vector2 point)> ObservableDraggingPart() =>
            ObservableTouchInput
                .ObservableTouchBegan()
                .Select(point => m_partToolBox.GetPointedPartType(point))
                .ExcludeNull()
                .Select(type => type.Value)
                .SelectMany(type => ObservableTouchInput.ObservableTouchMoved().Select(point => (type, point)))
                .TakeUntil(ObservableTouchInput.ObservableTouchEnded());
    }
}