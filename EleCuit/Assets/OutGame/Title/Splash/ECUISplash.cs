using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using du.dUI;
using static du.Ex.ExdUI;

namespace EC.ECUI
{

    /// <summary>
    /// Splashシーン (ロゴのフェード表示)
    /// </summary>
    public sealed class ECUISplash : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIButton m_background;
        [SerializeField] private dUILoadImage m_splashLogo;
        #endregion

        #region entity
        [Serializable]
        public class Entity
        {
            public UnityAction background;
            public string splashLogo;
        }
        public void Set(Entity entity)
        {
            m_background.Set(entity.background);
            m_splashLogo.Set(entity.splashLogo);
        }
        #endregion

        #region manual
        #region field
        private Sequence m_fadeLogosSequence;
        #endregion

        #region private
        private void BeginFadeLogo(string logoAdds)
        {
            m_fadeLogosSequence.AppendCallback(
                () => m_splashLogo.Set(logoAdds));
            m_fadeLogosSequence.AppendInterval(1f);
            m_fadeLogosSequence.Append(m_splashLogo
                .DOFade(endValue: 1f, duration: 1f)
                .SetEase(Ease.OutSine));
            m_fadeLogosSequence.AppendInterval(1f);
            m_fadeLogosSequence.Append(m_splashLogo
                .DOFade(endValue: 0f, duration: 1f)
                .SetEase(Ease.InSine));
        }
        private void ShowSplashLogos()
        {
            List<string> logoAddsList = new()
            {
                Adds.Stocks + "EleCuit/OutGame/Splash/yutorisan.png",
                Adds.Stocks + "EleCuit/OutGame/Splash/direct.png",
            };
            m_splashLogo.Alpha = 0f;
            m_fadeLogosSequence = DOTween.Sequence();
            foreach (string logoAdds in logoAddsList)
            {
                BeginFadeLogo(logoAdds);
            }
            m_fadeLogosSequence.AppendInterval(1f);
            m_fadeLogosSequence.OnComplete(() => TransitionToTitleScene());
            m_fadeLogosSequence.Play();
        }
        private async void TransitionToTitleScene()
        {
            await du.Mgr.Sequence.ChangeScene("Scenes/OutGame/Title");
        }
        #endregion

        #region mono
        private void Start()
        {
            ShowSplashLogos();
        }
        #endregion
        #endregion
    }
}
