using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Inventory
{
    /// <summary>
    /// <see cref="ScoreInventory"/>に読み取り専用でアクセスできる
    /// </summary>
    public interface IReadOnlyScoreInventory
    {

    }
    /// <summary>
    /// プレイヤーのスコアを保持して管理する
    /// </summary>
    public class ScoreInventory : IReadOnlyScoreInventory
    {

    }
}