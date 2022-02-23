using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using EleCuit.Course;
using UniRx;

namespace EleCuit.Renderer
{
    /// <summary>
    /// 電子回路部品をドラッグして配置しようとしたとき、配置可否Gizmoを描画する
    /// </summary>
    public class PartAcceptSignRenderer : MonoBehaviour
    {
        [Inject]
        private IRxPartSetupAcceptOrDeny m_partSetupAcceptOrDeny;

        void Start() 
        {
            ICoursePieceAcceptOrDenySign before = null;
            m_partSetupAcceptOrDeny
                .ObservablePartSetupAcceptOrDeny()
                .Subscribe(pair =>
                {
                    before?.ClearStatus();
                    pair.piece.AcceptOrDenySign.SetStatus(pair.status);
                    before = pair.piece.AcceptOrDenySign;
                });
        }
    }
}