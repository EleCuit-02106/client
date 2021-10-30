using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Course
{
    /// <summary>
    /// 電線の配置可否判定を依頼できる
    /// </summary>
    public interface ICircuitSetupApprovalRequest
    {

    }
    /// <summary>
    /// リクエストされた電線を配置できるかを判定する
    /// </summary>
    public class CircuitSetupAcceptor : ICircuitSetupApprovalRequest
    {

    }
}