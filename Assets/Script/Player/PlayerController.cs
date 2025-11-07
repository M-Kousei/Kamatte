using UnityEngine;
using Kamatte.Core;
using Kamatte.Animation;

namespace Kamatte.Player
{
    public class PlayerController : MonoBehaviour    //  プレイヤー制御クラス
    {
        [SerializeField] PlayerStatus playerStatus;             //  プレイヤーのステータス
        Transform rightHandTransform;                           //  右手のトランスフォーム
        Transform leftHandTransform;                            //  左手のトランスフォーム
        PlayerUpperSMFactory playerUpperSMFactory;                        //  プレイヤーの上位ファクトリー
        PlayerUpperSM playerUpperSM;                                    //  プレイヤー上位ステートマシーン
        Animator playerAnimator;                                //  プレイヤーアニメーター

        private void Awake()
        {
            PlayerContext.Instance.RegistPlayerCotroller(this);
            playerAnimator = this.GetComponent<Animator>();
        }

        public void Initialize(Transform rightHnadTF, Transform leftHandTF)    //  初期化
        {
            playerUpperSMFactory = new PlayerUpperSMFactory();
            playerUpperSM = new PlayerUpperSM();
            playerUpperSM.Initialize(playerUpperSMFactory);

            rightHandTransform = rightHnadTF;
            leftHandTransform = leftHandTF;
        }

        private void OnEnable()
        {
            SwordCatchEventBus.OnCatchPressed += StartCatchAnimation;
            //SwordCatchEventBus.OnCatchPressed += (GPTででたSMの中のStateChange系を定義してこのイベントに登録)
        }

        private void OnDisable()
        {
            SwordCatchEventBus.OnCatchPressed -= StartCatchAnimation;
        }
        void Update()
        {
            playerUpperSM.Update();
        }

        void StartCatchAnimation()    //  刀を取る操作をした時の処理
        {
            LogUtility.Log(LogPrefix.PlayerController, "刀取りモーション開始", LogLevel.Debug);
            playerAnimator.SetTrigger(SwordCatchAnimHash_Player.GetAnimation(SwordCatchAnimID_Player.CatchSword));
        }
    }
}