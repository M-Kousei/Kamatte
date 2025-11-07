using UnityEngine;

namespace Kamatte.Player
{
    [DefaultExecutionOrder(-100)]
    public class PlayerContext : MonoBehaviour    //  プレイヤーコンテキスト
    {
        public Transform rightHandTransform;      //  右手のトランスフォーム
        public Transform leftHandTransform;       //  左手のランスフォーム
        public static PlayerContext Instance { get; private set; }              //  プロパティ

        public PlayerController _playerController { get; private set; }

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void RegistPlayerCotroller(PlayerController playerController)    //  プレイヤーコントローラー登録
        {
            _playerController = playerController;
        }
        //public void RegistPlayerMove(PlayerMove playerMove)    //  コントローラー登録メソッド
        //{
        //    _PlayerMove = playerMove;
        //}
    }
}