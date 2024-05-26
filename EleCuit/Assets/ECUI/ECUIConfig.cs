using UnityEngine;
using UnityEngine.Events;
using du.dUI;

namespace EC.ECUI
{

    /// <summary>
    /// 設定画面
    /// </summary>
    public sealed class ECUIConfig : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIText m_titleLabel;
        [SerializeField] private dUIButton m_startButton;
        [SerializeField] private dUIButton m_configButton;
        [SerializeField] private dUIButton m_quitButton;
        #endregion

        #region entity
        public struct Entity
        {
            public string titleLabel;
            public UnityAction startButton;
            public UnityAction configButton;
            public UnityAction quitButton;
        }
        public void Set(Entity entity)
        {
            m_titleLabel.Set(entity.titleLabel);
            m_startButton.Set(entity.startButton);
            m_configButton.Set(entity.configButton);
            m_quitButton.Set(entity.quitButton);
        }
        #endregion

        #region manual
        public async void TransitionToNextScene()
        {
            await du.Mgr.Sequence.ChangeScene("Scenes/OutGame/Title");
        }

        public void ChangeText()
        {
            m_titleLabel.Set($"Config:{m_value}");
            ++m_value;
        }

        #region mono
        private void Start()
        {
            Set(new Entity()
            {
                titleLabel = "Config",
                startButton = TransitionToNextScene,
                configButton = ChangeText,
                quitButton = TransitionToNextScene,
            });
        }
        #endregion

        #region field
        private int m_value = 0;
        #endregion
        #endregion
    }
}
