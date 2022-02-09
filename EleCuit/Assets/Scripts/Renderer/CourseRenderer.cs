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
        GameObject GetPointedPiece(Vector2 screenPoint);
    }
    public class CourseRenderer : SerializedMonoBehaviour, ICourseRenderingSetting
    {
        [SerializeField]
        private IReadOnlyCourse m_cource;
        /// <summary>
        /// 白枠SquareのPrefab
        /// </summary>
        [SerializeField, BoxGroup("Prefabs")]
        private GameObject m_basePiece;
        [SerializeField]
        private GameObject m_courceGaomeObject;
        /// <summary>
        /// ひとつのマップピースの一辺の長さ
        /// </summary>
        [SerializeField]
        private float m_cellSize;

        private Map<GameObject> m_gameObjectMap;
        private Vector2 m_initPosition;

        [Button]
        public void Renderer()
        {
            DestroyAll();

            float height = m_cource.Cource.RowCount * m_cellSize;
            float initHeight = height / 2;

            m_initPosition = new Vector2(0, initHeight);

            m_gameObjectMap = new Map<GameObject>(m_cource.Cource.ColumnCount, m_cource.Cource.RowCount);
            m_cource.Cource.DoForEachCell((cell, value) =>
            {
                Vector2 position = m_initPosition + new Vector2(cell.Column * m_cellSize, cell.Row * -m_cellSize);
                GameObject obj = Instantiate(m_basePiece, position, Quaternion.identity, m_courceGaomeObject.transform);
                m_gameObjectMap[cell] = obj;
                obj.transform.localScale = m_cellSize.ToVector2();
            });
        }

        private void DestroyAll()
        {
            Debug.Log("destroyAllが呼ばれました");
            foreach (Transform item in m_courceGaomeObject.transform)
            {
                Debug.Log("Destroy!!");
                Destroy(item.gameObject);
            }
        }

        private UnityEngine.Camera m_camera;
        public GameObject GetPointedPiece(Vector2 screenPoint)
        {
            m_camera ??= UnityEngine.Camera.main;
            Vector2 worldPoint = m_camera.ScreenToWorldPoint(screenPoint);
            int column = (int)(worldPoint.x / m_cellSize);
            int row = (int)((-worldPoint.y + m_initPosition.y) / m_cellSize);
            if(!m_gameObjectMap.IsWithInRange(column, row)) return null;
            return m_gameObjectMap[column, row];
        }
    }
}