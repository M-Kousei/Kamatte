using Kamatte.Player;

namespace Kamatte.Core
{
    public class PlayerUpperSM : StateMachineBase<PlayerStateMachineID>    //  プレイヤーの上位ステートマシーン
    {
        PlayerSwordCatchSM _playerSwordCatchSM;    //  白刃取りステートマシーン

        IStateFactory<PlayerStateMachineID> _stateMachineFactory;

        public PlayerUpperSM()    //  コンストラクタ
        {

        }

        public override void Initialize(IStateFactory<PlayerStateMachineID> stateMachineFactory)    //  初期化
        {
            _stateMachineFactory = stateMachineFactory;
            ChangeState(_stateMachineFactory.CreateState(PlayerStateMachineID.SwordCatchSM));
        }

        public override void Update()
        {
            base.Update();
        }
    }
}