using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using du.Debug;

namespace EleCuit.Parts
{
    /// <summary>
    /// 電球部品
    /// </summary>
    public class LightBulb : Part, IScorePart
    {
        [SerializeField]
        private float m_wat;

        public override void Affect()
        {
            LLog.Debug.Log(nameof(LightBulb) + "Affected!");
        }
    }
}