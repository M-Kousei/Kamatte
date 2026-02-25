using UnityEngine;

namespace Kamatte.Core
{
    public class SceneBootstrap_Title : MonoBehaviour    //  タイトルシーンの初期化役
    {

        //  --  UnityLifeCycle

        void Start()
        {
            UIManager.Instance.ChangeUI(GameStateID.Title);    //  タイトル画面のUIに変更
            ScreenFader.Instance.Init(0f);    //  フェードPanelを初期化
        }
    }
}