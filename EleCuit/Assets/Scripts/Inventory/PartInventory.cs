using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EleCuit.Parts;
using System.Linq;
using UniRx;
using UnityUtility.Linq;
using Sirenix.OdinInspector;

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
        IReadOnlyDictionary<PartType, IReadOnlyReactiveProperty<int>> ObservablePartInventories { get; }
    }
    public interface IPartInventory
    {
        void AddStock(PartType type, int amount = 1);
        void SpendStock(PartType type, int amount = 1);
    }
    /// <summary>
    /// プレイヤーが所持している電子回路部品の数を保持して管理する
    /// </summary>
    public class PartInventory : SerializedMonoBehaviour, IPartInventory, IRxPartInventory
    {
        /// <summary>
        /// 部品の在庫を管理する倉庫
        /// </summary>
        [SerializeField]
        private Dictionary<PartType, ReactiveProperty<int>> m_partInventory;

        [Button, BoxGroup("在庫操作")]
        public void AddStock(PartType type, int amount = 1) =>
            m_partInventory[type].Value += amount;
        [Button, BoxGroup("在庫操作")]
        public void SpendStock(PartType type, int amount = 1) =>
            m_partInventory[type].Value -= amount;

        public IReadOnlyDictionary<PartType, IReadOnlyReactiveProperty<int>> ObservablePartInventories =>
            m_partInventory.DictionarySelect(rp => (IReadOnlyReactiveProperty<int>)rp).ToDictionary();

    }
}