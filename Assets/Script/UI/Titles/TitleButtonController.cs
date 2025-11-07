using UnityEngine;

namespace Kamatte.Core
{
    public class TitleButtonController : MonoBehaviour, IUIController    //  タイトル画面のボタンに反応を入れる
    {
        [SerializeField] private ButtonManager buttonManager;

        //  ボタン初期化
        public void Init()
        {
            // ボタン登録など
            buttonManager.Register(ButtonID.GoPlayButton, OnGoPlayPressed);

            // UI初期状態の設定など
            buttonManager.EnableAllButtons();
        }

        //    ボタン初期化解除
        public void Deinit()
        {
            // ボタンのイベント解除（※ Unregister を実装しておく）
            buttonManager.Unregister(ButtonID.GoPlayButton);

            // UIの一時非表示や状態クリアなど
            buttonManager.DisableAllButtons();
        }

        //  ゲーム開始を押したときの処理
        async void OnGoPlayPressed()
        {
            await ScreenFader.Instance.FadeOut(1f);
            SceneUtility.LoadScene(SceneNameMap.GetName(SceneID.Shop));
        }

        void OnExitPressed()
        {
            // アプリ終了処理
        }
    }
}