using System.Collections;
using System.Collections.Generic;
using du.App;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EleCuit.Parts
{
    public interface IPartSettings
    {
        /// <summary>
        /// 部品のリストと初期在庫の設定
        /// </summary>
        IReadOnlyDictionary<PartData, int> StockSetting { get; }
    }
    /// <summary>
    /// 部品のマスターデータを設定する
    /// </summary>
    public class PartSettings : SingletonSerializedMonoBehaviour<PartSettings, IPartSettings>, IPartSettings
    {
        [SerializeField, DictionaryDrawerSettings(KeyLabel = "PartData", ValueLabel = "Quantity")]
        private Dictionary<PartData, int> m_initialStockSetting;

        IReadOnlyDictionary<PartData, int> IPartSettings.StockSetting => m_initialStockSetting;
    }
}