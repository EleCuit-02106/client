using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using du.Debug;

namespace EleCuit.Parts
{
    /// <summary>
    /// 抵抗部品
    /// </summary>
    public class Resistance : Part, IVoltagePart
    {
        [SerializeField]
        private float m_owm;

        public override void Affect()
        {
            LLog.Debug.Log(nameof(Resistance) + "Affected!");
        }
    }
}