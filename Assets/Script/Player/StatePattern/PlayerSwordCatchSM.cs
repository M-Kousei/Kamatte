using Kamatte.Player;

namespace Kamatte.Core
{
    public class PlayerSwordCatchSM : StateMachineBase<PlayerSwordCatchStateID>    //  白刃取り状態のプレイヤーステートマシーン
    {
        PlayerStateFacotry_SwordCatch _playerUpperSMFactory;    //  上位ステートマシーン
        public PlayerSwordCatchSM(PlayerUpperSMFactory playerUpperSMFactory)    //  コンストラクタ
        {
        }

        public override void Initialize(IStateFactory<PlayerSwordCatchStateID> stateFactory)    //  初期化
        {
            _playerUpperSMFactory = stateFactory as PlayerStateFacotry_SwordCatch;

            ChangeState(_playerUpperSMFactory.CreateState(PlayerSwordCatchStateID.Idle));    //  Idle状態に変更
        }

        public override void ChangeState(IState<PlayerSwordCatchStateID> nextState)     //  状態変更
        {
            base.ChangeState(nextState);
        }

        public override void OnUpdate()    //  ステート中の処理
        {
            base.OnUpdate();
        }
    }
}