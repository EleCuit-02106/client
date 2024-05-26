using System;
using System.Collections.Generic;
using UnityEngine;
using du.dUI;

namespace EC.ECUI
{

    /// <summary>
    /// </summary>
    public sealed class ECUITitleInfoLabels : dUICompositiveBase
    {
        #region dUI field
        [SerializeField] private dUIText m_clientVer;
        [SerializeField] private dUIText m_assetHash;
        [SerializeField] private dUIText m_userID;
        [SerializeField] private dUIText m_crBottom;
        [SerializeField] private dUIText m_crMiddle;
        [SerializeField] private dUIText m_crTop;
        #endregion

        #region entity
        [Serializable]
        public class Entity
        {
            public string clientVer;
            public string assetHash;
            public string userID;
            public string crBottom;
            public string crMiddle;
            public string crTop;
        }
        public void Set(Entity entity)
        {
            m_clientVer.Set(entity.clientVer);
            m_assetHash.Set(entity.assetHash);
            m_userID.Set(entity.userID);
            m_crBottom.Set(entity.crBottom);
            m_crMiddle.Set(entity.crMiddle);
            m_crTop.Set(entity.crTop);
        }
        #endregion

        #region manual
        #region public
        public void SetCopyRight(IReadOnlyCollection<string> copyRights)
        {
            int lineIndex = copyRights.Count;
            const string crFormat = "© {0}";
            foreach (string copyRight in copyRights)
            {
                dUIText copyRightLine = lineIndex switch
                {
                    3 => m_crTop,
                    2 => m_crMiddle,
                    1 => m_crBottom,
                    _ => null,
                };
                if (copyRight != null)
                {
                    copyRightLine.Set(string.Format(crFormat, copyRight));
                }
                --lineIndex;
            }
        }
        #endregion
        #endregion
    }
}
