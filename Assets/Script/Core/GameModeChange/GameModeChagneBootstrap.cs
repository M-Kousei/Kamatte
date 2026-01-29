using UnityEngine;

namespace Kamatte.Core
{
    public sealed class GameModeChagneBootstrap : MonoBehaviour    //  ゲームモード変更クラス系のBootstrap
    {
        private void Awake()
        {
            var stateMachine = new GameModeStateMachine(GameMode.Title);

            var service = new GameModeService(stateMachine);

            ServiceLocator.Register<IGameModeService>(service);
        }
    }
}