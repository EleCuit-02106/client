using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using du.App;
using EleCuit.Parts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityUtility.Enums;

namespace EleCuit.Settings
{
    public interface IPartsSetting
    {
        IReadOnlyList<PartData> ResisteredPartDatas { get; }
        PartData GetPartData(PartType type);
    }
    public class PartsSetting : SingletonSerializedMonoBehaviour<PartsSetting, IPartsSetting>, IPartsSetting
    {
        private const string TypeDuplicatedErrorMessage = "登録されているPartTypeが重複しています";
        private const string ExistNotResisteredTypeErrorMessage = "登録されていないPartTypeが存在します";

        /// <summary>
        /// ここにゲーム内で使用するPartDataを登録する
        /// </summary>
        [SerializeField]
        [InfoBox(TypeDuplicatedErrorMessage, nameof(m_isTypeDuplicated), InfoMessageType = InfoMessageType.Error)]
        [InfoBox(ExistNotResisteredTypeErrorMessage, nameof(m_isExistNotResisteredType), InfoMessageType = InfoMessageType.Error)]
        private IReadOnlyList<PartData> m_resisteredParts;
        public IReadOnlyList<PartData> ResisteredPartDatas => m_resisteredParts;

        private bool m_isTypeDuplicated;
        private bool m_isExistNotResisteredType;

        private void Start()
        {
            if (m_isTypeDuplicated) throw new InvalidOperationException(TypeDuplicatedErrorMessage);
            if (m_isExistNotResisteredType) throw new InvalidOperationException(ExistNotResisteredTypeErrorMessage);
        }

        private void OnValidate()
        {
            //PartTypeが重複して登録されていないかチェック
            m_isTypeDuplicated =
                m_resisteredParts
                    .GroupBy(data => data.Type)
                    .Where(group => group.Count() > 1)
                    .Count() > 0;
            //登録されていないTypeがないかチェック
            m_isExistNotResisteredType =
                EnumUtils.All<PartType>()
                         .Except(m_resisteredParts.Select(data => data.Type))
                         .Count() > 0;
        }

        public IReadOnlyDictionary<PartType, PartData> PartTypePartDataTable =>
            m_resisteredParts.ToDictionary(data => data.Type, data => data);

        public PartData GetPartData(PartType type)
        {
            throw new NotImplementedException();
        }
    }
}