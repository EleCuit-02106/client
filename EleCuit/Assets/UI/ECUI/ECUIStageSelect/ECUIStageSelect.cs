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
    /// </summary>
    public sealed partial class ECUIStageSelect : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIText m_stageTitle00;
        [SerializeField] private dUIText m_stageTitle01;
        [SerializeField] private dUIText m_stageTitle02;
        [SerializeField] private dUIText m_stageTitle03;
        [SerializeField] private dUIText m_stageTitle04;
        [SerializeField] private dUIText m_stageTitle05;
        [SerializeField] private dUIText m_stageTitle06;
        [SerializeField] private dUIText m_stageTitle07;
        [SerializeField] private dUIText m_stageTitle;
        [SerializeField] private dUIText m_difficultyValue;
        [SerializeField] private dUIText m_clearCountValue;
        [SerializeField] private dUIButton m_stageTemplate00;
        [SerializeField] private dUIButton m_stageTemplate01;
        [SerializeField] private dUIButton m_stageTemplate02;
        [SerializeField] private dUIButton m_stageTemplate03;
        [SerializeField] private dUIButton m_stageTemplate04;
        [SerializeField] private dUIButton m_stageTemplate05;
        [SerializeField] private dUIButton m_stageTemplate06;
        [SerializeField] private dUIButton m_stageTemplate07;
        [SerializeField] private dUIButton m_gameStartButton;
        #endregion

        #region entity
        [Serializable]
        public class Entity
        {
            public string stageTitle00;
            public string stageTitle01;
            public string stageTitle02;
            public string stageTitle03;
            public string stageTitle04;
            public string stageTitle05;
            public string stageTitle06;
            public string stageTitle07;
            public string stageTitle;
            public string difficultyValue;
            public string clearCountValue;
            public UnityAction stageTemplate00;
            public UnityAction stageTemplate01;
            public UnityAction stageTemplate02;
            public UnityAction stageTemplate03;
            public UnityAction stageTemplate04;
            public UnityAction stageTemplate05;
            public UnityAction stageTemplate06;
            public UnityAction stageTemplate07;
            public UnityAction gameStartButton;
        }
        public void Set(Entity entity)
        {
            m_stageTitle00.Set(entity.stageTitle00);
            m_stageTitle01.Set(entity.stageTitle01);
            m_stageTitle02.Set(entity.stageTitle02);
            m_stageTitle03.Set(entity.stageTitle03);
            m_stageTitle04.Set(entity.stageTitle04);
            m_stageTitle05.Set(entity.stageTitle05);
            m_stageTitle06.Set(entity.stageTitle06);
            m_stageTitle07.Set(entity.stageTitle07);
            m_stageTitle.Set(entity.stageTitle);
            m_difficultyValue.Set(entity.difficultyValue);
            m_clearCountValue.Set(entity.clearCountValue);
            m_stageTemplate00.Set(entity.stageTemplate00);
            m_stageTemplate01.Set(entity.stageTemplate01);
            m_stageTemplate02.Set(entity.stageTemplate02);
            m_stageTemplate03.Set(entity.stageTemplate03);
            m_stageTemplate04.Set(entity.stageTemplate04);
            m_stageTemplate05.Set(entity.stageTemplate05);
            m_stageTemplate06.Set(entity.stageTemplate06);
            m_stageTemplate07.Set(entity.stageTemplate07);
            m_gameStartButton.Set(entity.gameStartButton);
        }
        #endregion
    }
}
