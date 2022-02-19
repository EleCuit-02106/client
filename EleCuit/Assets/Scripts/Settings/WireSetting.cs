using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using du.App;
using EleCuit.Course;
using Sirenix.OdinInspector;
using UnityUtility.Enums;

namespace EleCuit.Settings
{
    public class WireSetting : SingletonSerializedMonoBehaviour<WireSetting>
    {
        private const string UnresisteredTypeExistedErrMsg = "未登録のWireTypeが存在します";

        private bool m_isTypeDuplicated;
        private bool m_isUnresisteredTypeExist;

        [SerializeField]
        [InfoBox(UnresisteredTypeExistedErrMsg, nameof(m_isUnresisteredTypeExist), InfoMessageType = InfoMessageType.Error)]
        private IReadOnlyDictionary<WireType, Sprite> m_wireSettngTable;

        void Start()
        {
            if (m_isUnresisteredTypeExist) throw new InvalidOperationException(UnresisteredTypeExistedErrMsg);
        }

        void OnValidate()
        {
            //未登録のWireTypeチェック
            m_isUnresisteredTypeExist =
                EnumUtils.All<WireType>()
                    .Except(m_wireSettngTable.Keys)
                    .Count() > 0;
        }

        public IReadOnlyDictionary<WireType, Sprite> WireSettingTable => m_wireSettngTable;
    }
}