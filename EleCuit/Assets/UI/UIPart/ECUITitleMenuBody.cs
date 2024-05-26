using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using du.dUI;

namespace EC.ECUI
{

    /// <summary>
    /// タイトル画面のメニューモーダルの中身
    /// </summary>
    public sealed class ECUITitleMenuBody : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIButton m_menuButton00;
        [SerializeField] private dUIButton m_menuButton01;
        [SerializeField] private dUIButton m_menuButton02;
        [SerializeField] private dUIButton m_menuButton10;
        [SerializeField] private dUIButton m_menuButton11;
        [SerializeField] private dUIButton m_menuButton12;
        [SerializeField] private dUIButton m_menuButton20;
        [SerializeField] private dUIButton m_menuButton21;
        [SerializeField] private dUIButton m_menuButton22;
        [SerializeField] private dUIButton m_menuButton30;
        [SerializeField] private dUIButton m_menuButton31;
        [SerializeField] private dUIButton m_menuButton32;
        [SerializeField] private dUILoadImage m_bodyBackground;
        #endregion

        #region entity
        [Serializable]
        public class Entity
        {
            public UnityAction menuButton00;
            public UnityAction menuButton01;
            public UnityAction menuButton02;
            public UnityAction menuButton10;
            public UnityAction menuButton11;
            public UnityAction menuButton12;
            public UnityAction menuButton20;
            public UnityAction menuButton21;
            public UnityAction menuButton22;
            public UnityAction menuButton30;
            public UnityAction menuButton31;
            public UnityAction menuButton32;
            public string bodyBackground;
        }
        public void Set(Entity entity)
        {
            m_menuButton00.Set(entity.menuButton00);
            m_menuButton01.Set(entity.menuButton01);
            m_menuButton02.Set(entity.menuButton02);
            m_menuButton10.Set(entity.menuButton10);
            m_menuButton11.Set(entity.menuButton11);
            m_menuButton12.Set(entity.menuButton12);
            m_menuButton20.Set(entity.menuButton20);
            m_menuButton21.Set(entity.menuButton21);
            m_menuButton22.Set(entity.menuButton22);
            m_menuButton30.Set(entity.menuButton30);
            m_menuButton31.Set(entity.menuButton31);
            m_menuButton32.Set(entity.menuButton32);
            m_bodyBackground.Set(entity.bodyBackground);
        }
        #endregion

        #region manual
        #region public
        public struct ButtonDesc
        {
            public string text;
            public UnityAction callback;
            public ButtonDesc(string text, UnityAction callback) : this()
            {
                this.text = text;
                this.callback = callback;
            }
            public ButtonDesc(string text) : this(text, () => { }) { }
        }
        public void Set(IEnumerable<ButtonDesc> buttonDescs)
        {
            int index = 0;
            foreach (var desc in buttonDescs)
            {
                // Button(index).Set(desc.text, desc.callback); // TOdO
                Button(index).Set(desc.callback);
                ++index;
            }
        }
        #endregion

        #region field
        private List<dUIButton> Buttons;
        #endregion

        #region private
        /// <returns> 範囲外のindexが指定された場合はnull </returns>
        /// <param name="x"> 0 <= x < 3 </param>
        /// <param name="y"> 0 <= y < 4 </param>
        private dUIButton Button(int x, int y)
        {
            if (x < 0 || 2 < x || y < 0 || 3 < y) { return null; }
            return Button(y * 3 + x);
        }
        /// <returns> 範囲外のindexが指定された場合はnull </returns>
        /// <param name="index"> 0 <= index < 12 </param>
        private dUIButton Button(int index)
        {
            if (index < 0 || 11 < index) { return null; }
            Buttons ??= new()
            {
                m_menuButton00,
                m_menuButton01,
                m_menuButton02,
                m_menuButton10,
                m_menuButton11,
                m_menuButton12,
                m_menuButton20,
                m_menuButton21,
                m_menuButton22,
                m_menuButton30,
                m_menuButton31,
                m_menuButton32,
            };
            return Buttons[index];
        }
        #endregion

        #region mono
        private void Start()
        {
            Set(new List<ButtonDesc>
            {
                new ("お知らせ"),
                new ("よくある質問"),
                new ("お問い合わせ"),
                new ("キャッシュクリア"),
                new ("データ引き継ぎ"),
                new ("一括ダウンロード"),
                new ("アセット整理"),
                new ("利用規約等"),
                new ("権利表記"),
                new ("公式Twitter"),
                new ("応援レビュー"),
                new ("アカウント削除"),
            });
        }
        #endregion
        #endregion
    }
}
