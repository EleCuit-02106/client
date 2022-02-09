using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Zenject;
using EleCuit.Inventory;
using EleCuit.Settings;
using EleCuit.Parts;
using Sirenix.OdinInspector;
using UnityUtility;
using UnityUtility.Linq;
using UnityUtility.Enums;

namespace EleCuit.UI
{
    public interface IReadOnlyPartToolBoxButtons
    {
        IReadOnlyDictionary<PartType, Bounds> PartTypeOfButtonBoundsTable { get; }
        /// <summary>
        /// 引数に指定した座標にあるツールボックス内のPartTypeを取得する
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        PartType? GetPointedPartType(Vector2 point);
    }
    public class PartToolBox : MonoBehaviour, IReadOnlyPartToolBoxButtons
    {
        [Inject]
        private IRxPartInventory m_partInventory;

        [SerializeField]
        private PartButton m_buttonPrefab;

        private Dictionary<PartType, Bounds> m_partTypeBoundsTable;

        void Start()
        {
            // PartInventoryの情報からPartButtonを生成する
            var buttonTypeTable =
                m_partInventory
                    .ObservablePartInventories
                    .DictionarySelect((initStock, type) =>
                    {
                        // PartsSettingから該当PartTypeの設定情報を取得
                        var partdata = PartsSetting.Instance.GetPartData(type);
                        // prefabをインスタンス化して設定情報で初期化
                        var button = Instantiate(m_buttonPrefab, transform);
                        button.Initialize(partdata, initStock.Value);
                        // PartInventoryの在庫更新情報を購読する
                        initStock.Subscribe(stk => button.Stock = stk).AddTo(this);
                        return button;
                    })
                    .ToDictionary();
            // RectTransformは更新タイミングが不定のため強制的にCanvasを更新する
            // 参考：https://docs.unity3d.com/ja/2019.4/Manual/class-RectTransform.html
            Canvas.ForceUpdateCanvases();
            // PatyTypeごとのBounds情報を取得する
            m_partTypeBoundsTable =
                buttonTypeTable
                    .DictionarySelect(button => button.GetComponent<RectTransform>().GetWorldBounds())
                    .ToDictionary();
        }

        public PartType? GetPointedPartType(Vector2 point)
        {
            foreach (var type in EnumUtils.All<PartType>().Where(type => m_partTypeBoundsTable.ContainsKey(type)))
            {
                if (m_partTypeBoundsTable[type].Contains(point))
                {
                    return type;
                }
            }
            return null;
        }

        public IReadOnlyDictionary<PartType, Bounds> PartTypeOfButtonBoundsTable => m_partTypeBoundsTable;
    }
}