using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EleCuit.PrefabController
{
    public interface IPartDragRenderPrefabController
    {
        void SetSprite(Sprite sprite);
    }
    public class PartDragRenderPrefabController : MonoBehaviour, IPartDragRenderPrefabController
    {
        private Image m_displayImage;

        void Awake()
        {
            m_displayImage = GetComponent<Image>();
        }

        public void SetSprite(Sprite sprite) => m_displayImage.sprite = sprite;
    }
}