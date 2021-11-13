using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EleCuit.Parts;
using System.Linq;
using UniRx;
using UnityUtility.Linq;

namespace EleCuit.Inventory
{
    /// <summary>
    /// <see cref="PartInventory"/>に読み取り専用でアクセスできる
    /// </summary>
    public interface IRxPartInventory
    {
        /// <summary>
        /// すべての部品情報と、その在庫個数の購読権
        /// </summary>
        IReadOnlyDictionary<PartData, IReadOnlyReactiveProperty<int>> ObservablePartInventories { get; }
    }
    /// <summary>
    /// プレイヤーが所持している電子回路部品の数を保持して管理する
    /// </summary>
    public class PartInventory : MonoBehaviour, IRxPartInventory
    {
        /// <summary>
        /// 部品の在庫を管理する倉庫
        /// </summary>
        private IReadOnlyDictionary<PartData, ReactiveProperty<int>> m_partInventory;


        private void Start()
        {
            m_partInventory = PartSettings.Instance.StockSetting
                                .DictionarySelect(initStock => new ReactiveProperty<int>(initStock))
                                .ToDictionary();
        }

        public IReadOnlyDictionary<PartData, IReadOnlyReactiveProperty<int>> ObservablePartInventories =>
            m_partInventory.DictionarySelect(rp => (IReadOnlyReactiveProperty<int>)rp).ToDictionary();
    }
}