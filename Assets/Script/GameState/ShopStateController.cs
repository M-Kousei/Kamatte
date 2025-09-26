using Kamatte.Fading;

namespace Kamatte.GameState
{
    public class ShopStateController : BaseStateController    //  ショップシーンのコントローラー
    {
        protected override void Awake()
        {
            InitEffect();    //  フェードイン実行
        }

        protected override void InitGameState()    //  ゲームの状態を設定
        {

        }

        protected override void InitUI()    //  UIを初期化
        {

        }

        protected override void InitAudio()    //  BGMや効果音を再生
        {

        }
        protected override void InitEffect()    //  BGMや効果音を再生
        {
            ScreenFader.Instance.FadeIn(1f);    //  フェードイン
        }

        protected override void InitOthers()    //  その他任意の処理（必要に応じて）
        {

        }
    }
}