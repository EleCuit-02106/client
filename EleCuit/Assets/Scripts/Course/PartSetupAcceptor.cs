using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using EleCuit.UserCommand;
using UniRx;
using UnityUtility;
using UnityUtility.Enums;
using EleCuit.Parts;
using EleCuit.Renderer;
using Sirenix.OdinInspector;
using UnityUtility.Rx.Operators;
using UniRx.Diagnostics;

namespace EleCuit.Course
{
    /// <summary>
    /// 電気回路部品の配置可否判定を依頼できる
    /// </summary>
    public interface IRxPartSetupAcceptOrDeny
    {
        IObservable<AcceptOrDeny> ObservablePartSetupAcceptOrDeny();
    }
    /// <summary>
    /// リクエストされた電気回路部品の配置可否を判定する
    /// </summary>
    public class PartSetupAcceptor : SerializedMonoBehaviour, IRxPartSetupAcceptOrDeny
    {
        [Inject]
        private IRxPartDragCommandPublisher m_partDragCommandPublisher;
        [SerializeField]
        private ICourseRenderingSetting m_courseRenderer;

        void Start()
        {
            m_partDragCommandPublisher
                .ObservableDraggingPart()
                .Select(pair => (type: pair.type, piece: m_courseRenderer.GetPointedPiece(pair.point)))
                .Where(pair => pair.piece != null)
                .DistinctUntilChanged(pair => pair.piece)
                .Repeat()
                .Subscribe(pair => pair.piece.PartType = pair.type);
        }

        public IObservable<AcceptOrDeny> ObservablePartSetupAcceptOrDeny()
        {
            throw new NotImplementedException();
        }
    }

    public enum AcceptOrDeny
    {
        Accept,
        Deny
    }
}