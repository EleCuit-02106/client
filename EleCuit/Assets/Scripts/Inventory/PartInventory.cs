using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Inventory
{
    /// <summary>
    /// <see cref="PartInventory"/>に読み取り専用でアクセスできる
    /// </summary>
    public interface IReadOnlyPartInventory
    {

    }
    /// <summary>
    /// <see cref="PartInventory"/>の内容を初期化できる
    /// </summary>
    public interface IPartInventoryInitializer
    {

    }
    /// <summary>
    /// プレイヤーが所持している電子回路部品の数を保持して管理する
    /// </summary>
    public class PartInventory : IReadOnlyPartInventory, IPartInventoryInitializer
    {

    }
}