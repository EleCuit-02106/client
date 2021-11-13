using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EleCuit.UI
{
    public class PartButton : MonoBehaviour
    {
        private Image m_iconImage;
        private TextMeshProUGUI m_stockText;

        void Awake()
        {
            m_iconImage = GetComponentsInChildren<Image>().Where(img => img.name == "IconImage").First(); //自身のImageを取ってしまうため
            m_stockText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public Sprite Icon
        {
            get => m_iconImage.sprite;
            set => m_iconImage.sprite = value;
        }
        public int Stock
        {
            get => int.Parse(m_stockText.text);
            set => m_stockText.text = value.ToString();
        }
    }
}