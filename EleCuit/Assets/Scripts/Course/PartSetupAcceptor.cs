using System;
using System.Linq;
using UnityEngine;
using Zenject;
using EleCuit.UserCommand;
using UniRx;
using UnityUtility;
using EleCuit.Renderer;
using Sirenix.OdinInspector;
using UnityUtility.Rx.Operators;

namespace EleCuit.Course
{
    /// <summary>
    /// 電気回路部品の配置可否判定を依頼できる
    /// </summary>
    public interface IRxPartSetupAcceptOrDeny
    {
        IObservable<(ICoursePiece piece, AcceptOrDeny status)> ObservablePartSetupAcceptOrDeny();
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

        }

        public IObservable<(ICoursePiece, AcceptOrDeny)> ObservablePartSetupAcceptOrDeny() =>
            m_partDragCommandPublisher
                //ドラッグしている部品とその座標を購読
                .ObservableDraggingPart()
                //ドラッグをやめるとOnCompletedするので再購読
                .Repeat()
                //座標から該当するCoursePieceを取得
                .Select(pair => (type: pair.type, piece: m_courseRenderer.GetPointedPiece(pair.point)))
                //該当するCoursePieceがない場合はnullが返るので排除
                .ExcludeNull(pair => pair.piece)
                //CoursePieceが変化したときのみ
                .DistinctUntilChanged(pair => pair.piece)
                //配置可能ならAccept, 不能ならDeny
                .Select(pair => (pair.piece, pair.piece.IsReplaceable ? AcceptOrDeny.Accept : AcceptOrDeny.Deny))
                .Share();
        // .Subscribe(pair =>
        // {
        //     pair.piece.PartType = pair.type;
        //     pair.piece.Refresh();
        // });
    }

    public enum AcceptOrDeny
    {
        Accept,
        Deny
    }
}