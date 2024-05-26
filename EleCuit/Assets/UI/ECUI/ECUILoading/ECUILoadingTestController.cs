using UnityEngine;
using du.dUI;

namespace EC.ECUI
{

    public sealed class ECUILoadingTestController : dUICompositiveTestControllerBase
    {
        #region field
        [SerializeField] private ECUILoading m_view;
        [SerializeField] private ECUILoading.Entity m_entity;
        [SerializeField] private bool m_isShowButton;
        #endregion
    }
}
