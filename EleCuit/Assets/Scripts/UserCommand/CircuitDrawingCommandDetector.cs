using System;
using EleCuit.Course;
using EleCuit.Input;
using EleCuit.Inventory;
using Zenject;
using UniRx;


namespace EleCuit.UserCommand
{
    /// <summary>
    /// 導線を描画しているコマンドを発行する
    /// </summary>
    public interface IRxCircuitDrawingCommandPublisher
    {

    }
    /// <summary>
    /// インプットから電線の描画を識別する
    /// </summary>
    public class CircuitDrawingCommandDetector : IRxCircuitDrawingCommandPublisher
    {
    }
}