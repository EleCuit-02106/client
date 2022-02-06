using System.Collections;
using System.Collections.Generic;
using EleCuit.Course;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using System.Linq;
using UnityUtility;

namespace EleCuit.Renderer
{
    public class CourseRenderer : SerializedMonoBehaviour
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
        // /// <summary>
        // /// 最初のマップピースの描画座標
        // /// </summary>
        // [SerializeField]
        // private Vector2 m_initPosition;

        private void OnValidate()
        {
            Renderer();
        }

        [Button]
        public void Renderer()
        {
            DestroyAll();

            float height = m_cource.Cource.RowCount * m_cellSize;
            float initHeight = height / 2;

            m_cource.Cource.DoForEachCell((cell, value) =>
            {
                Vector2 position = new Vector2(0, initHeight) + new Vector2(cell.Column * m_cellSize, cell.Row * -m_cellSize);
                Instantiate(m_basePiece, position, Quaternion.identity, m_courceGaomeObject.transform).transform.localScale = m_cellSize.ToVector2();
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
    }
}