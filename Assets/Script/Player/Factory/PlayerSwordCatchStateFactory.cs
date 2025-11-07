using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerStateFacotry_SwordCatch : SMFactoryBase<PlayerSwordCatchStateID>    //  プレイヤーの白刃取り状態を生成するファクトリ
    {
        PlayerSwordCatchSM _playerSwordCatchStateMachine;    //  プレイヤーのステートマシーン

        public PlayerStateFacotry_SwordCatch(PlayerSwordCatchSM stateMachine)    //  コンストラクタ
        {
            _playerSwordCatchStateMachine = stateMachine;

            Register(PlayerSwordCatchStateID.Idle, () => new PlayerIdleState_SwordCatch(_playerSwordCatchStateMachine));    //  State登録
            Register(PlayerSwordCatchStateID.TryCatch, () => new PlayerTryCatchState(_playerSwordCatchStateMachine));       //  State登録
        }
    }
}