using UnityEngine;
using Kamatte.Player;

namespace Kamatte.Core
{
    public class PlayerInitializer : MonoBehaviour   //  プレイヤーの初期化
    {
        PlayerController _playerController;    //  プレイヤーコントローラー
        Transform _rightHandTransform;         //  右手のトランスフォーム
        Transform _leftHandTransform;          //  左手のトランスフォーム

        void Start()
        {
            _playerController = PlayerContext.Instance._playerController;
            _rightHandTransform = PlayerContext.Instance.rightHandTransform;
            _leftHandTransform = PlayerContext.Instance.leftHandTransform;

            _playerController.Initialize(_rightHandTransform, _leftHandTransform);    //  コントローラー初期化
        }
    }
}