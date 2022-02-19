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
    }
    public class CoursePiece : MonoBehaviour, ICoursePiece
    {
        private SpriteRenderer m_spriteRenderer;
        private PieceType m_pieceType;
        private PartType? m_partType;
        private WireType? m_wireType;

        public PieceType PieceType
        {
            get => m_pieceType;
            private set => m_pieceType = value;
        }
        public PartType? PartType
        {
            get => m_partType;
            set
            {
                m_partType = value;
                Refresh();
            }
        }
        public WireType? WireType
        {
            get => m_wireType;
            set
            {
                m_wireType = value;
                Refresh();
            }
        }
        public bool IsReplaceable => m_pieceType == PieceType.None;

        [Button]
        public void Refresh()
        {
            var table = PartsSetting.Instance.ResisteredPartDataTable;
            if (m_partType.HasValue) m_spriteRenderer.sprite = table[m_partType.Value].Sprite;
            m_spriteRenderer.NormalizeSize();
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

        private bool isFirstUpdate = true;
        void Update()
        {
            if (isFirstUpdate) this.Refresh();
            isFirstUpdate = false;
        }
    }
}