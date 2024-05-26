// -----------------------------------
// このファイルは自動生成スクリプトです
// 手動で編集しないでください
// -----------------------------------
using System;
using UnityEngine;
using UnityEngine.Events;
using du.dUI;

namespace EC.ECUI
{

    /// <summary>
    /// タイトル画面
    /// </summary>
    public sealed partial class ECUITitle : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIText m_tapToStartText;
        [SerializeField] private dUIButton m_touchableScreen;
        [SerializeField] private dUIButton m_menuButton;
        [SerializeField] private dUILoadImage m_logoImage;
        [SerializeField] private dUILoadImage m_tapToStart;
        #endregion

        #region entity
        [Serializable]
        public class Entity
        {
            public string tapToStartText;
            public UnityAction touchableScreen;
            public UnityAction menuButton;
            public string logoImage;
            public string tapToStart;
        }
        public void Set(Entity entity)
        {
            m_tapToStartText.Set(entity.tapToStartText);
            m_touchableScreen.Set(entity.touchableScreen);
            m_menuButton.Set(entity.menuButton);
            m_logoImage.Set(entity.logoImage);
            m_tapToStart.Set(entity.tapToStart);
        }
        #endregion
    }
}
