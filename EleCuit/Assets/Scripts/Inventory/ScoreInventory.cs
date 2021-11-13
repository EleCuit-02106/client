using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace EleCuit.Inventory
{
    /// <summary>
    /// <see cref="ScoreInventory"/>に読み取り専用でアクセスできる
    /// </summary>
    public interface IRxScoreInventory
    {
        IReadOnlyReactiveProperty<int> RxScore { get; }
    }
    /// <summary>
    /// プレイヤーのスコアを保持して管理する
    /// </summary>
    public class ScoreInventory : MonoBehaviour, IRxScoreInventory
    {
        private readonly IReactiveProperty<int> m_score = new ReactiveProperty<int>();

        public IReadOnlyReactiveProperty<int> RxScore => m_score;
    }
}