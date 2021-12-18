using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EleCuit.Parts;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace EleCuit.UI
{
    public class PartButton : MonoBehaviour
    {
        private bool m_isInitialized;
        private PartData m_partdata;
        private Image m_iconImage;
        private TextMeshProUGUI m_stockText;

        void Awake()
        {
            m_iconImage = GetComponentsInChildren<Image>().Where(img => img.name == "IconImage").First(); //自身のImageを取ってしまうため
            m_stockText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Initialize(PartData data, int initStock = 0)
        {
            if (m_isInitialized) throw new InvalidOperationException("Already Initialized.");

            m_partdata = data;
            m_iconImage.sprite = data.Icon;
            Stock = initStock;
        }

        public PartData PartData => m_partdata;
        public PartType Type => m_partdata.Type;

        public int Stock
        {
            get => int.Parse(m_stockText.text);
            set => m_stockText.text = value.ToString();
        }
    }
}