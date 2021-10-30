using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Inventory
{
    /// <summary>
    /// <see cref="CircuitInventory"/>に読み取り専用でアクセスできる
    /// </summary>
    public interface IReadOnlyCircuitInventory
    {

    }
    /// <summary>
    /// <see cref="CircuitInventory"/>を初期化できる
    /// </summary>
    public interface ICircuitInventoryInitializer
    {

    }
    /// <summary>
    /// 描画可能な電線の長さを保持して管理する
    /// </summary>
    public class CircuitInventory : IReadOnlyCircuitInventory, ICircuitInventoryInitializer
    {

    }
}