using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using du.Debug;

namespace EleCuit {

/// <summary>
/// Application の立ち上げ時、AppBaseなどの常駐Scene群の次に起動される
/// サーバ接続、UserLogin、AssetDL などを行う
/// </summary>
public class TitleSetupScene : MonoBehaviour
{
    #region const
    enum SetupStage {
        ServerConnect,
        UserLogin,
        AssetDownload,
        Max,
        Min = ServerConnect,
    }
    #endregion

    #region field
    #endregion

    #region property
    private SetupStage Stage { get; set; } = SetupStage.Min;
    private bool IsInProgress { get; set; } = false;
    #endregion

    #region private
    private async UniTask ConnectToServer() {
        LLog.MainBoot.Log("Start to connect to server");
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        LLog.MainBoot.Log("Completed connecting to server");
    }
    private async UniTask UserLogin() {
        LLog.MainBoot.Log("Start to user login");
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        LLog.MainBoot.Log("Completed user login");
    }
    private async UniTask DownloadAsset() {
        LLog.MainBoot.Log("Start to download asset");
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        LLog.MainBoot.Log("Completed downloading asset");
    }
    #endregion

    #region mono
    private async void Start()
    {
        LLog.MainBoot.Log("Start to setup application");
        await ConnectToServer();
        await UserLogin();
        await DownloadAsset();
        LLog.MainBoot.Log("Completed application setup");

        Screen.SetResolution(10, 10, false, 60);
        du.Mgr.Sequence.ChangeScene("Scenes/OutGame/Title");
    }
    #endregion
}

}
