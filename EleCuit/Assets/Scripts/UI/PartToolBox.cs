using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility.Extensions;
using UniRx;
using Zenject;
using EleCuit.Inventory;

namespace EleCuit.UI
{
    public class PartToolBox : MonoBehaviour
    {
        [Inject]
        private IRxPartInventory m_partInventory;

        [SerializeField]
        private PartButton m_buttonPrefab;

        void Start()
        {
            foreach (var (partdata, stock) in m_partInventory.ObservablePartInventories)
            {
                var button = Instantiate(m_buttonPrefab, transform);
                button.Icon = partdata.Icon;
                button.Stock = stock.Value;
                stock.Subscribe(stk => button.Stock = stk).AddTo(this);
            }
        }
    }
}