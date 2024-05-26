using System;
using System.Collections.Generic;
using System.Linq;
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
        #region private
        /// <summary> ロゴ1つのフェードSequenceを作成 </summary>
        private Sequence CreateLogoFade(string logoAdds)
            => DOTween.Sequence()
                .AppendCallback(() => m_splashLogo.Set(logoAdds))
                .AppendInterval(1f)
                .Append(m_splashLogo
                    .DOFade(endValue: 1f, duration: 1f)
                    .SetEase(Ease.OutSine))
                .AppendInterval(1f)
                .Append(m_splashLogo
                    .DOFade(endValue: 0f, duration: 1f)
                    .SetEase(Ease.InSine));

        /// <summary> ロゴの一連のフェードSequenceを作成 </summary>
        private du.Util.PhasedSequence CreateShowSplashLogosSequence()
        {
            du.Util.PhasedSequence logoFadeSequence = new();
            string commonAddress = Adds.Stocks + "EleCuit/OutGame/Splash/";
            List<string> logoAddsList = new()
            {
                "yutorisan.png",
                "direct.png",
            };
            foreach (string logoAdds in logoAddsList)
            {
                logoFadeSequence.Add(logoAdds, CreateLogoFade(commonAddress + logoAdds));
            }
            logoFadeSequence.Add("Last", DOTween.Sequence().AppendInterval(0.5f));
            return logoFadeSequence;
        }

        private void Initialize()
        {
            m_splashLogo.Alpha = 0f;
        }
        private async void TransitionToTitleScene()
        {
            await du.Mgr.Sequence.SwitchScene("Scenes/OutGame/Splash", "Scenes/OutGame/Title");
        }
        #endregion

        #region mono
        private void Start()
        {
            Initialize();
            var logoFadeSequence = CreateShowSplashLogosSequence();
            m_background.Set(() => logoFadeSequence.CompleteCurrentPhase()); // 画面タップでロゴ1つ分スキップ
            logoFadeSequence
                .OnComplete(() => TransitionToTitleScene())
                .Play();
        }
        #endregion
        #endregion
    }
}
