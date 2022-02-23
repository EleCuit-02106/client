using System;
using System.Collections.Generic;
using System.Linq;
using du.App;
using EleCuit.Course;
using EleCuit.Course.Wire;
using EleCuit.Parts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityUtility.Enums;

namespace EleCuit.Settings
{
    public interface IPartsSetting
    {
        IReadOnlyDictionary<PartType, PartData> ResisteredPartDataTable { get; }
        IReadOnlyDictionary<WireType, WireData> ResisteredWireDataTable { get; }
        PartData GetPartData(PartType type);
    }
    public class PartsSetting : SingletonSerializedMonoBehaviour<PartsSetting, IPartsSetting>, IPartsSetting
    {
        private const string PartTypeDuplicatedErrorMessage = "登録されているPartTypeが重複しています";
        private const string WireTypeDuplicatedErrorMessage = "登録されているWireTypeが重複しています";
        private const string ExistNotResisteredPartTypeErrorMessage = "登録されていないPartTypeが存在します";
        private const string ExistNotResisteredWireTypeErrorMessage = "登録されていないWireTypeが存在します";

        /// <summary>
        /// ここにゲーム内で使用するPartDataを登録する
        /// </summary>
        [SerializeField]
        [InfoBox(PartTypeDuplicatedErrorMessage, nameof(m_isPartTypeDuplicated), InfoMessageType = InfoMessageType.Error)]
        [InfoBox(ExistNotResisteredPartTypeErrorMessage, nameof(m_isExistNotResisteredPartType), InfoMessageType = InfoMessageType.Error)]
        private IReadOnlyList<PartData> m_partDataResistry;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        [InfoBox(WireTypeDuplicatedErrorMessage, nameof(m_isWireTypeDuplicated), InfoMessageType = InfoMessageType.Error)]
        [InfoBox(ExistNotResisteredWireTypeErrorMessage, nameof(m_isExistNotResisteredWireType), InfoMessageType = InfoMessageType.Error)]
        private IReadOnlyList<WireData> m_wireDataResistry;

        private bool m_isPartTypeDuplicated;
        private bool m_isWireTypeDuplicated;
        private bool m_isExistNotResisteredPartType;
        private bool m_isExistNotResisteredWireType;

        private void Start()
        {
            if (m_isPartTypeDuplicated) throw new InvalidOperationException(PartTypeDuplicatedErrorMessage);
            if (m_isWireTypeDuplicated) throw new InvalidOperationException(WireTypeDuplicatedErrorMessage);
            if (m_isExistNotResisteredPartType) throw new InvalidOperationException(ExistNotResisteredPartTypeErrorMessage);
            if (m_isExistNotResisteredWireType) throw new InvalidOperationException(ExistNotResisteredWireTypeErrorMessage);
        }

        private void OnValidate()
        {
            //PartTypeが重複して登録されていないかチェック
            m_isPartTypeDuplicated =
                m_partDataResistry
                    .GroupBy(data => data.Type)
                    .Where(group => group.Count() > 1)
                    .Count() > 0;
            //登録されていないTypeがないかチェック
            m_isExistNotResisteredPartType =
                EnumUtils.All<PartType>()
                         .Except(m_partDataResistry.Select(data => data.Type))
                         .Count() > 0;
            //PartTypeが重複して登録されていないかチェック
            m_isWireTypeDuplicated =
                m_wireDataResistry
                    .GroupBy(data => data.Type)
                    .Where(group => group.Count() > 1)
                    .Count() > 0;
            //登録されていないTypeがないかチェック
            m_isExistNotResisteredWireType =
                EnumUtils.All<WireType>()
                         .Except(m_wireDataResistry.Select(data => data.Type))
                         .Count() > 0;
        }

        public IReadOnlyDictionary<PartType, PartData> ResisteredPartDataTable =>
            m_partDataResistry.ToDictionary(data => data.Type, data => data);

        public IReadOnlyDictionary<WireType, WireData> ResisteredWireDataTable =>
            m_wireDataResistry.ToDictionary(data => data.Type, data => data);

        public PartData GetPartData(PartType type) =>
            m_partDataResistry.First(data => data.Type == type);
    }
}