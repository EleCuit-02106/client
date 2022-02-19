using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using EleCuit.Parts;
using Sirenix.OdinInspector;
using EleCuit.Settings;
using UnityUtility;

namespace EleCuit.Course
{
    public interface ICoursePiece
    {
        PieceType PieceType { get; }
        PartType? PartType { get; set; }
        WireType? WireType { get; set; }

        bool IsReplaceable { get; }
        void Refresh();
    }
    public class CoursePiece : MonoBehaviour, ICoursePiece
    {
        private SpriteRenderer m_spriteRenderer;
        private PieceType m_pieceType;
        private PartType? m_partType;
        private WireType? m_wireType;

        [SerializeField] private Sprite m_noneSprite;

        public PieceType PieceType
        {
            get => m_pieceType;
            private set
            {
                m_pieceType = value;
                if (value == PieceType.None)
                {
                    m_spriteRenderer.color = new Color(0, 0, 0, 0.2f);
                    m_spriteRenderer.sprite = m_noneSprite;
                    if (PartType is not null) PartType = null;
                    if (WireType is not null) WireType = null;
                }
            }
        }
        public PartType? PartType
        {
            get => m_partType;
            set
            {
                m_partType = value;
                if (value is not null)
                {
                    PieceType = PieceType.Part;
                }
            }
        }
        public WireType? WireType
        {
            get => m_wireType;
            set
            {
                m_wireType = value;
                if (value is not null)
                {
                    PieceType = PieceType.Circuit;
                }
            }
        }
        public bool IsReplaceable => m_pieceType == PieceType.None;

        [Button]
        public void Refresh()
        {
            var table = PartsSetting.Instance.ResisteredPartDataTable;
            if (m_partType.HasValue) m_spriteRenderer.sprite = table[m_partType.Value].Sprite;
            m_spriteRenderer.NormalizeSize();
            if (PieceType != PieceType.None)
            {
                this.m_spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }

        public static CoursePiece Instantiate(CoursePiece prefab, Vector2 position, Transform parent, CoursePieceInfo info)
        {
            CoursePiece piece = Instantiate(prefab, position, Quaternion.identity, parent);
            piece.m_spriteRenderer = piece.GetComponent<SpriteRenderer>();
            piece.m_pieceType = info.PieceType;
            piece.m_partType = info.PartType;
            piece.m_wireType = info.WireType;
            return piece;
        }

        [Button]
        private void setNone()
        {
            this.PieceType = PieceType.None;
            Refresh();
        }

        private bool isFirstUpdate = true;
        void Update()
        {
            if (isFirstUpdate) this.Refresh();
            isFirstUpdate = false;
        }
    }
}