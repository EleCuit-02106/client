using System.ComponentModel;
using System;
using UnityEngine;
using EleCuit.Parts;
using Sirenix.OdinInspector;
using EleCuit.Settings;
using UnityUtility;

namespace EleCuit.Course
{
    public interface ICoursePiece
    {
        /// <summary>
        /// CoursePieceの種別
        /// </summary>
        /// <value></value>
        PieceType PieceType { get; set; }
        /// <summary>
        /// 種別がPartの場合、Partの種別
        /// </summary>
        /// <value></value>
        PartType? PartType { get; set; }
        /// <summary>
        /// 種別がWireの場合、Wireの種別
        /// </summary>
        /// <value></value>
        WireType? WireType { get; set; }
        /// <summary>
        /// 現在の状態に基づいて再描画する
        /// </summary>
        void Refresh();
        /// <summary>
        /// 書き換え可能かどうか
        /// </summary>
        /// <value></value>
        bool IsReplaceable { get; }
        ICoursePieceAcceptOrDenySign AcceptOrDenySign { get; }
    }
    public class CoursePiece : MonoBehaviour, ICoursePiece
    {
        private SpriteRenderer m_spriteRenderer;
        private PieceType m_pieceType;
        private PartType? m_partType;
        private WireType? m_wireType;

        [SerializeField] private Sprite m_noneSprite;
        private bool isFirstUpdate = true;
        void Update()
        {
            if (isFirstUpdate) this.Refresh();
            isFirstUpdate = false;
        }

        void Start()
        {
            AcceptOrDenySign = GetComponentInChildren<ICoursePieceAcceptOrDenySign>();
        }

        public ICoursePieceAcceptOrDenySign AcceptOrDenySign { get; private set; }

        public PieceType PieceType
        {
            get => m_pieceType;
            set
            {
                m_pieceType = value;
                switch (value)
                {
                    case PieceType.None:
                        PartType = null;
                        WireType = null;
                        break;
                    case PieceType.Part:
                        WireType = null;
                        break;
                    case PieceType.Wire:
                        PartType = null;
                        break;
                    default:
                        throw new InvalidEnumArgumentException();
                }
            }
        }
        public PartType? PartType
        {
            get => m_partType;
            set
            {
                if (m_pieceType != PieceType.Part) throw new InvalidOperationException();
                m_partType = value;
            }
        }
        public WireType? WireType
        {
            get => m_wireType;
            set
            {
                if (m_pieceType != PieceType.Wire) throw new InvalidOperationException();
                m_wireType = value;
            }
        }
        public bool IsReplaceable => m_pieceType == PieceType.None;

        [Button]
        public void Refresh()
        {
            switch (PieceType)
            {
                case PieceType.None:
                    m_spriteRenderer.color = new Color(0, 0, 0, 0.2f);
                    m_spriteRenderer.sprite = m_noneSprite;
                    break;
                case PieceType.Part:
                    if (!m_partType.HasValue) throw new InvalidOperationException("PartTypeが設定されていません");
                    m_spriteRenderer.color = new Color(1, 1, 1, 1);
                    m_spriteRenderer.sprite = PartsSetting.Instance.ResisteredPartDataTable[m_partType.Value].Sprite;
                    break;
                case PieceType.Wire:
                    if (!m_partType.HasValue) throw new InvalidOperationException("WireTypeが設定されていません");
                    m_spriteRenderer.color = new Color(1, 1, 1, 1);

                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            var table = PartsSetting.Instance.ResisteredPartDataTable;
            if (m_partType.HasValue) m_spriteRenderer.sprite = table[m_partType.Value].Sprite;
            m_spriteRenderer.NormalizeSize();
            if (PieceType != PieceType.None)
            {
                this.m_spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }

        [Button]
        private void setNone()
        {
            this.PieceType = PieceType.None;
            Refresh();
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
    }
}