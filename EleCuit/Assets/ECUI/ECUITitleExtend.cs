// -----------------------------------
// このファイルは初回のみの自動生成スクリプトです
// 生成後は手動編集が可能です
// -----------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using du.dUI;
using du.UI;

namespace EC.ECUI
{
    /// <summary>
    /// </summary>
    public sealed partial class ECUITitle
    {
        #region field
        [SerializeField] private ECUITitleInfoLabels m_titleInfoLabels;
        private dUIModalDialog m_menuModal;
        private UIBlinker m_tapToStartBlinker;
        #endregion

        #region public
        public async void TransitionToLoadingScene()
        {
            // 遷移を開始したらもうボタンは押せない
            m_menuButton.SetInteractable(false);
            m_touchableScreen.SetInteractable(false);

            m_tapToStartBlinker.Begin(time => Mathf.Cos(time * 40.0f) > 0.0f ? 0.8f : 0.4f);
            { // TOdO: 開発用に擬似ローディング時間
                var ct = this.GetCancellationTokenOnDestroy();
                await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: ct);
            }
            await du.Mgr.Sequence.ChangeScene("Scenes/OutGame/Loading");
        }
        public async void OpenConfigModal()
        {
            if (m_menuModal == null)
            {
                dUIModalBuilder<dUIModalDialog> modalBuilder = new();
                await modalBuilder.CreateModalAsync(
                    Adds.Assets + "OutGame/Title/TitleMenu/ECUITitleMenuModal.prefab",
                    transform.parent);
                if (!modalBuilder.IsSucceeded) { return; }
                var modal = modalBuilder.ModalInstance;
                modal.Set(new dUIModalDialog.Entity
                {
                    caption = "Menu",
                    okButton = null,
                    cancelButton = null,
                    closeButton = modal.Close,
                    backgroundBlackout = modal.Close,
                });
                m_menuModal = modal;
            }
            m_menuModal.Open();
        }
        #endregion
        #region private
        private void InitializeInfoLabels()
        {
            m_titleInfoLabels.Set(new ECUITitleInfoLabels.Entity
            {
                clientVer = "app ver. " + "0.0.1",
                assetHash = "asset ver. " + "UNDER CONSTRUCTION",
                userID = "ID: " + "Develop User",
            });
            m_titleInfoLabels.SetCopyRight(CopyRightLinesToCollection("copyRight.1"));
        }
        private IReadOnlyCollection<string> CopyRightLinesToCollection(string label)
        {
            var cr = MD.MasterCopyRightRepository.Instance.GetOrNull(label);
            List<string> ret = new();
            if (cr.Line01.Length > 0) { ret.Add(cr.Line01); }
            if (cr.Line02.Length > 0) { ret.Add(cr.Line02); }
            return ret;
        }
        #endregion

        #region mono
        private void Start()
        {
            Set(new Entity
            {
                logoImage = Adds.Stocks + "EleCuit/OutGame/Logo/EleCuitLogo_BlackBase.png",
                tapToStart = Adds.GUIProKitSprite + "Demo/Demo_Play/Play_ActionText_Frame_Red.png",
                tapToStartText = "Tap To Start",
                menuButton = OpenConfigModal,
                touchableScreen = TransitionToLoadingScene,
            });
            InitializeInfoLabels();
            m_tapToStartBlinker = m_tapToStart.GetComponent<UIBlinker>();
            m_tapToStartBlinker.Begin(time => Mathf.Cos(time * 3.0f) * 0.4f + 0.6f);
        }
        #endregion
    }

}
