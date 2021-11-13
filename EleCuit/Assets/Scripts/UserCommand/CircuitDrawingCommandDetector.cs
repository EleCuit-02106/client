using System;
using EleCuit.Course;
using EleCuit.Input;
using EleCuit.Inventory;
using Zenject;
using UniRx;


namespace EleCuit.UserCommand
{
    /// <summary>
    /// インプットから電線の描画を識別する
    /// </summary>
    public class CircuitDrawingCommandDetector
    {
        [Inject]
        private IRxCircuitDrawingDetector m_circuitDrawingDetector;
        [Inject]
        private IRxCircuitInventory m_circuitInventory;
        [Inject]
        private ICircuitSetupApprovalRequest m_circuitSetupApprovalRequest;

        public CircuitDrawingCommandDetector()
        {
            m_circuitDrawingDetector
                .ObservableCircuitDrawing()
                .Subscribe(pos =>
                {
                    //処理
                });
        }
    }
}