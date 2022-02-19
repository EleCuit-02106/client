using System.Collections;
using System.Collections.Generic;
using EleCuit.Course;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using System.Linq;
using UnityUtility;
using UnityUtility.Collections;

namespace EleCuit.Renderer
{
    public interface ICourseRenderingSetting
    {
        /// <summary>
        /// 画面座標で指し示したPieceを取得する
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <returns></returns>
        ICoursePiece GetPointedPiece(Vector2 screenPoint);
    }
    public class CourseRenderer : SerializedMonoBehaviour, ICourseRenderingSetting
    {
        [SerializeField] private IReadOnlyCourse m_course;
        /// <summary>
        /// 白枠SquareのPrefab
        /// </summary>
        [SerializeField, BoxGroup("Prefabs")] private CoursePiece m_basePiece;
        [SerializeField] private GameObject m_courceGaomeObject;
        /// <summary>
        /// ひとつのマップピースの一辺の長さ
        /// </summary>
        [SerializeField] private float m_cellSize;
        /// <summary>
        /// セル同士の間隔
        /// </summary>
        [SerializeField] private float m_cellMargin;

        private Map<CoursePiece> m_pieceMap;
        private Vector2 m_initPosition;

        [Button]
        public void Renderer()
        {
            DestroyAll();

            float height = m_course.CourseBody.RowCount * m_cellSize;
            float initHeight = height / 2;

            m_initPosition = new Vector2(0, initHeight);
            m_pieceMap = new Map<CoursePiece>(m_course.CourseBody.ColumnCount, m_course.CourseBody.RowCount);
            foreach (var cell in m_course.CourseBody.GetCellEnumerable())
            {
                Vector2 position = m_initPosition + new Vector2(cell.Column * (m_cellSize + m_cellMargin), cell.Row * -(m_cellSize + m_cellMargin));
                CoursePiece piece = CoursePiece.Instantiate(m_basePiece, position, m_courceGaomeObject.transform, cell.Value);
                m_pieceMap[cell.Column, cell.Row] = piece;
            }
        }

        private void DestroyAll()
        {
            foreach (Transform item in m_courceGaomeObject.transform)
            {
                Destroy(item.gameObject);
            }
        }

        private UnityEngine.Camera m_camera;
        public ICoursePiece GetPointedPiece(Vector2 screenPoint)
        {
            m_camera ??= UnityEngine.Camera.main;
            Vector2 worldPoint = m_camera.ScreenToWorldPoint(screenPoint);
            int column = (int)(worldPoint.x / m_cellSize);
            int row = (int)((-worldPoint.y + m_initPosition.y) / m_cellSize);
            if (!m_pieceMap.IsWithInRange(column, row)) return null;
            return m_pieceMap[column, row];
        }
    }
}