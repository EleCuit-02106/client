using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Course
{
    /// <summary>
    /// CoursePieceに対するPartの配置可否インジケータ
    /// </summary>
    public interface ICoursePieceAcceptOrDenySign
    {
        void SetStatus(AcceptOrDeny status);
        void ClearStatus();
    }
    public class CoursePieceAcceptOrDenySign : MonoBehaviour, ICoursePieceAcceptOrDenySign
    {
        [SerializeField]
        private Color m_acceptColor;
        [SerializeField]
        private Color m_denyColor;
        private Color m_defaultColor;
        private SpriteRenderer m_renderer;
        void Start()
        {
            m_renderer = GetComponent<SpriteRenderer>();
            m_defaultColor = m_renderer.color;
        }

        public void ClearStatus()
        {
            m_renderer.color = m_defaultColor;
        }

        public void SetStatus(AcceptOrDeny status)
        {
            m_renderer.color = status switch
            {
                AcceptOrDeny.Accept => m_acceptColor,
                AcceptOrDeny.Deny   => m_denyColor,
                _                   => throw new InvalidEnumArgumentException()
            };
        }
    }
}