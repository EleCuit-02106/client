using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace EleCuit
{

    [InitializeOnLoad]
    public class DeveloperWindow : EditorWindow
    {
        // メニューバーからこのウィンドウを開くためのメニュー項目を定義
        [MenuItem("Developer/DeveloperWindow")]
        public static void ShowWindow()
        {
            // ウィンドウを表示
            GetWindow<DeveloperWindow>("開発者ツール (DeveloperWindow)");
        }

        // ウィンドウの内容を描画するためのメソッド
        private void OnGUI()
        {
            GUILayout.Label("This is a custom editor window", EditorStyles.boldLabel);

            var largeButtonStyle = new GUIStyle(GUI.skin.button);
            largeButtonStyle.fontSize = 20;
            if (GUILayout.Button("Game Start!!", largeButtonStyle, GUILayout.Height(80)))
            {
                Debug.Log("<Editor.DeveloperWindow> Game Start!!");
                StartFromSpecificScene();
            }

            if (GUILayout.Button("Load Main"))
            {
                Debug.Log("<Editor.DeveloperWindow> Load Main");
                OnPlayModeStateChanged(PlayModeStateChange.ExitingPlayMode);
            }
        }

        #region GameStart
        // 再生開始時にロードするシーンのパス
        private const string startScenePath = "Assets/Internals/dUnitility/Sources/duScenes/AppBase.unity";
        private static string[] originalScenes = null;

        private void StartFromSpecificScene()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }

            // 現在開いているシーンを記憶
            originalScenes = new string[EditorSceneManager.loadedSceneCount];
            for (int i = 0; i < EditorSceneManager.loadedSceneCount; i++)
            {
                originalScenes[i] = EditorSceneManager.GetSceneAt(i).path;
            }
            Debug.Log($"<DDEV.Editor.DeveloperWindow> save original scenes ({originalScenes[0]})");

            EditorApplication.update += LoadSceneAndStartPlayMode;
        }

        private void LoadSceneAndStartPlayMode()
        {
            Debug.Log($"<DDEV.Editor.LoadSceneAndStartPlayMode> start");
            EditorApplication.update -= LoadSceneAndStartPlayMode;

            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                Debug.Log($"<DDEV.Editor.LoadSceneAndStartPlayMode> open {startScenePath}");
                EditorSceneManager.OpenScene(startScenePath);
                EditorApplication.isPlaying = true;

                // 再生終了時に元のシーンを開く
                EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
                Debug.Log($"<DDEV.Editor.LoadSceneAndStartPlayMode> set on finish callback");
            }
        }

        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            Debug.Log($"<DDEV.Editor.DeveloperWindow.OnPlayModeStateChanged> start");
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                Debug.Log($"<DDEV.Editor.DeveloperWindow.OnPlayModeStateChanged> state is ExistingPlayMode");
                // 元のシーンを開く

                // if (originalScenes != null)
                // {
                //     foreach (string scenePath in originalScenes)
                //     {
                //         EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
                //     }
                // }
                EditorSceneManager.OpenScene("Assets/Scenes/InGame/Main.unity", OpenSceneMode.Additive);
            }
        }
        #endregion
    }

}
