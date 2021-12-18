using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;
using UniRx;
using Zenject;
using EleCuit.Inventory;
using EleCuit.Settings;

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
            foreach (var (partType, stock) in m_partInventory.ObservablePartInventories)
            {
                var partData = PartsSetting.Instance.GetPartData(partType);
                var button = Instantiate(m_buttonPrefab, transform);
                button.Initialize(partData, stock.Value);
                stock.Subscribe(stk => button.Stock = stk).AddTo(this);
            }
        }
    }
}