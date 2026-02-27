using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerController : MonoBehaviour    //  プレイヤー制御クラス
    {
        PlayerHitBoxMgr playerHitBoxMgr;              //  プレイヤーヒットボックス管理クラス

        [SerializeField] Vector3 StarEffectPos;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip catchClip;

        public StateReader_SwordCatch StateReader { get; private set; }
        public StateWriter_SwordCatch StateWriter { get; private set; }
        public bool isHited = false;
        bool isSound= false;

        private void Awake()
        {
            PlayerContext.Instance.RegistPlayerCotroller(this);
        }

        public void Initialize(PlayerHitBoxData hitBoxData, Transform headTF, StateReader_SwordCatch reader, StateWriter_SwordCatch writer)    //  初期化
        {
            playerHitBoxMgr = new PlayerHitBoxMgr(hitBoxData, this, headTF, StarEffectPos, reader, writer);

            StateReader = reader;
            StateWriter = writer;
        }

        void Update()
        {
            playerHitBoxMgr.Update();
        }
        //void OnDrawGizmos()
        //{
        //    if (playerHitBoxMgr.ActiveBox == null)
        //        return;

        //    // 中心座標を解決
        //    Vector3 center = playerHitBoxMgr.ResolveCenter(playerHitBoxMgr._playerHeadTF);
        //    Vector3 size = playerHitBoxMgr.ActiveBox.size;

        //    Gizmos.color = Color.red;
        //    Gizmos.matrix = Matrix4x4.TRS(center, playerHitBoxMgr._playerHeadTF.rotation, Vector3.one);
        //    Gizmos.DrawWireCube(Vector3.zero, size);
        //}

        public void ActiveHitBox()
        {
            playerHitBoxMgr.EnableHitBox(HitBoxID.SwordCatch);
        }

        public void EraseHitBox()
        {
            playerHitBoxMgr.DisableHitBox(HitBoxID.SwordCatch);
            isSound = false;
        }
        public void PlayCatchSound()
        {
            if (StateReader.AcceseState().CatchState.IsCatchSword && !isSound)
            {
                isSound = true;
                audioSource.PlayOneShot(catchClip, 0.6f);
            }
        }
    }
}