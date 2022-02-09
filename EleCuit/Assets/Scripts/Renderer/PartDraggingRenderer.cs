using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EleCuit.UserCommand;
using UnityEngine;
using Zenject;
using UniRx;
using UnityUtility.Linq;
using EleCuit.PrefabController;
using EleCuit.Settings;
using EleCuit.Parts;
using UnityUtility.Enums;

namespace EleCuit.Renderer
{
    /// <summary>
    /// ドラッグ中の電子回路部品を描画する
    /// </summary>
    public class PartDraggingRenderer : MonoBehaviour
    {
        [Inject]
        private IRxPartDragCommandPublisher m_partDragCommandPublisher;
        /// <summary>
        /// レンダリングするオブジェクトのPrefab
        /// </summary>
        [SerializeField]
        private PartDragRenderPrefabController m_renderPrefab;
        /// <summary>
        /// レンダリング先オブジェクト
        /// </summary>
        [SerializeField]
        private GameObject m_renderingOnObject;

        private IReadOnlyDictionary<PartType, GameObject> m_partTypePrefabTable;

        private void Start()
        {
            // すべてのPartTypeのレンダリングオブジェクトを生成しておく
            m_partTypePrefabTable =
                PartsSetting.Instance.ResisteredPartDataTable
                    .DictionarySelect(data =>
                    {
                        var prefab = Instantiate(m_renderPrefab, m_renderingOnObject.transform);
                        prefab.SetSprite(data.Sprite);
                        prefab.gameObject.SetActive(false);
                        return prefab.gameObject;
                    })
                    .ToDictionary();

            //本当は外部に依存するのは良くないが…
            GameObject renderObject = null;
            m_partDragCommandPublisher
                .ObservableDraggingPart()
                .Do(pair => renderObject = m_partTypePrefabTable[pair.type])
                .DoOnCompleted(() => renderObject.SetActive(false))
                .Repeat()
                .Subscribe(pair =>
                {
                    renderObject.transform.position = pair.point;
                    if (!renderObject.activeSelf) renderObject.SetActive(true);
                })
                .AddTo(this);
        }
    }
}