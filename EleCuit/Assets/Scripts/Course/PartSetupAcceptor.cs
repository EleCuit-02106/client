using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Course
{
    /// <summary>
    /// 電気回路部品の配置可否判定を依頼できる
    /// </summary>
    public interface IPartSetupApprovalRequest
    {

    }
    /// <summary>
    /// リクエストされた電気回路部品の配置可否を判定する
    /// </summary>
    public class PartSetupAcceptor : IPartSetupApprovalRequest
    {

    }
}