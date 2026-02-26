using UnityEngine;
using Kamatte.SwordCatch;

namespace Kamatte.Core
{
    public class ShopStateInitializer : BaseStateController    //  ショップシーンの初期化
    {
        [SerializeField] SwingTimeController swingTimeController;
        [SerializeField] Animator swingerAnimator;
        SwordSwingController swordSwingController;

        protected override void Awake()
        {
            InitEffect();    //  フェードイン実行
            InitOthers();
        }

        protected override void InitGameState()    //  ゲームの状態を設定
        {
            //SceneBootstrap_Title.Instance.OnSwordCatch();    //  今は直白刃取り
        }

        protected override void InitUI()    //  UIを初期化
        {

        }

        protected override void InitAudio()    //  BGMや効果音を再生
        {

        }
        protected override void InitEffect()    //  BGMや効果音を再生
        {
        }

        protected override void InitOthers()    //  その他任意の処理（必要に応じて）
        {
            swordSwingController = new SwordSwingController();
            swingTimeController.Initialize(swordSwingController);
        }
    }
}