using UnityEngine;

namespace Kamatte.Core
{
    public sealed class GameModeChagneBootstrap : MonoBehaviour    //  ゲームモード変更クラス系のBootstrap
    {
        private void Awake()
        {
            GameModeChanger _changer = new GameModeChanger();

            var stateMachine = new GameModeStateMachine(GameMode.Title, _changer);

            var service = new GameModeService(stateMachine);

            ServiceLocator.Register<IGameModeService>(service);
        }
    }
}