using UnityEngine;

namespace Kamatte.Core
{
    public class SceneBootstrap_Title : MonoBehaviour    //  タイトルシーンの初期化役
    {
        private void Start()
        {
            UIManager.Instance.ChangeUI(GameStateID.Title);
            ScreenFader.Instance.Init(0f);
        }
    }
}