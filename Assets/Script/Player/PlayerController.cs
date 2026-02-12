using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerController : MonoBehaviour    //  プレイヤー制御クラス
    {
        [SerializeField] PlayerStatus playerStatus;    //  プレイヤーのステータス
        [SerializeField] Animator swordSwingAnim;    //  プレイヤーのステータス
        PlayerUpperSMFactory playerUpperSMFactory;    //  プレイヤーの上位ファクトリー
        PlayerUpperSM playerUpperSM;                  //  プレイヤー上位ステートマシーン
        PlayerHitBoxMgr playerHitBoxMgr;              //  プレイヤーヒットボックス管理クラス
        Animator playerAnimator;                      //  プレイヤーアニメーター

        [SerializeField] Vector3 StarEffectPos;

        public StateReader_SwordCatch StateReader { get; private set; }
        public StateWriter_SwordCatch StateWriter { get; private set; }
        public bool isCatching = false;
        public bool isHited = false;

        private void Awake()
        {
            PlayerContext.Instance.RegistPlayerCotroller(this);
            playerAnimator = this.GetComponent<Animator>();
        }

        public void Initialize(PlayerHitBoxData hitBoxData, Transform headTF, StateReader_SwordCatch reader, StateWriter_SwordCatch writer)    //  初期化
        {
            playerUpperSM = new PlayerUpperSM();
            playerHitBoxMgr = new PlayerHitBoxMgr(hitBoxData, this, swordSwingAnim, headTF, StarEffectPos);
            playerUpperSMFactory = new PlayerUpperSMFactory(playerHitBoxMgr);

            StateReader = reader;
            StateWriter = writer;

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
            Debug.Log(StateReader.AcceseState().CatchState.IsCatchSword);
        }

        void StartCatchAnimation()    //  刀を取る操作をした時の処理
        {
            if (!isHited)
            {
                LogUtility.Log(LogPrefix.PlayerController, "刀取りモーション開始", LogLevel.Debug);
                playerAnimator.SetTrigger(SwordCatchAnimHash_Player.GetAnimation(SwordCatchAnimID_Player.CatchSword));
            }
        }
        void OnDrawGizmos()
        {
            if (playerHitBoxMgr.ActiveBox == null)
                return;

            // 中心座標を解決
            Vector3 center = playerHitBoxMgr.ResolveCenter(playerHitBoxMgr._playerHeadTF);
            Vector3 size = playerHitBoxMgr.ActiveBox.size;

            Gizmos.color = Color.red;
            Gizmos.matrix = Matrix4x4.TRS(center, playerHitBoxMgr._playerHeadTF.rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, size);
        }

        public void ActiveHitBox()
        {
            Debug.Log("ダチの車中で書いた歌詞が");
            playerHitBoxMgr.EnableHitBox(HitBoxID.SwordCatch);
        }

        public void EraseHitBox()
        {
            Debug.Log("運ぶ現金");
            playerHitBoxMgr.DisableHitBox(HitBoxID.SwordCatch);
        }
    }
}