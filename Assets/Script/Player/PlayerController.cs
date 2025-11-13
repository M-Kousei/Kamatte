using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerController : MonoBehaviour    //  プレイヤー制御クラス
    {
        [SerializeField] PlayerStatus playerStatus;   //  プレイヤーのステータス
        PlayerUpperSMFactory playerUpperSMFactory;    //  プレイヤーの上位ファクトリー
        PlayerUpperSM playerUpperSM;                  //  プレイヤー上位ステートマシーン
        PlayerHitBoxMgr playerHitBoxMgr;              //  プレイヤーヒットボックス管理クラス
        Animator playerAnimator;                      //  プレイヤーアニメーター

        private void Awake()
        {
            PlayerContext.Instance.RegistPlayerCotroller(this);
            playerAnimator = this.GetComponent<Animator>();
        }

        public void Initialize(PlayerHitBoxData hitBoxData, Transform headTF)    //  初期化
        {
            playerUpperSM = new PlayerUpperSM();
            playerHitBoxMgr = new PlayerHitBoxMgr(hitBoxData, headTF);
            playerUpperSMFactory = new PlayerUpperSMFactory(playerHitBoxMgr);

            playerUpperSM.Initialize(playerUpperSMFactory);
        }

        private void OnEnable()
        {
            SwordCatchEventBus.OnCatchPressed += StartCatchAnimation;
        }

        private void OnDisable()
        {
            SwordCatchEventBus.OnCatchPressed -= StartCatchAnimation;
        }
        void Update()
        {
            playerUpperSM.Update();
            Debug.Log(27);
        }

        void StartCatchAnimation()    //  刀を取る操作をした時の処理
        {
            LogUtility.Log(LogPrefix.PlayerController, "刀取りモーション開始", LogLevel.Debug);
            playerAnimator.SetTrigger(SwordCatchAnimHash_Player.GetAnimation(SwordCatchAnimID_Player.CatchSword));
        }
        void OnDrawGizmos()
        {
            if (playerHitBoxMgr._activeBox == null)
                return;

            // 中心座標を解決
            Vector3 center = playerHitBoxMgr.ResolveCenter(playerHitBoxMgr._playerHeadTF);
            Vector3 size = playerHitBoxMgr._activeBox.size;

            Gizmos.color = Color.red;
            Gizmos.matrix = Matrix4x4.TRS(center, playerHitBoxMgr._playerHeadTF.rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, size);
        }
    }
}