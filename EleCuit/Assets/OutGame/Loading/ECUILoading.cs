using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using du.dUI;

namespace EC.ECUI
{

    /// <summary>
    /// ローディング画面
    /// </summary>
    public sealed class ECUILoading : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIText m_titleLabel;
        #endregion

        #region entity
        [Serializable]
        public class Entity
        {
            public string titleLabel;
        }
        public void Set(Entity entity)
        {
            m_titleLabel.Set(entity.titleLabel);
        }
        #endregion

        #region manual
        public async void TransitionToNextScene()
        {
            { // TOdO: 開発用に擬似ローディング時間
                var ct = this.GetCancellationTokenOnDestroy();
                await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: ct);
            }
            du.Debug.LLog.Debug.Log("DDEV", "activeScene:" + du.Mgr.Sequence.ActiveScenePath);
            await du.Mgr.Sequence.ChangeScene("Scenes/OutGame/Config");
        }

        #region mono
        private void Start()
        {
            Set(new Entity()
            {
                titleLabel = "Loading...",
            });
            TransitionToNextScene();
        }
        #endregion
        #endregion
    }
}
