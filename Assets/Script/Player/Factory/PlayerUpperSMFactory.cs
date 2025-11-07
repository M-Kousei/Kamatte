using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerUpperSMFactory : SMFactoryBase<PlayerStateMachineID>    //  プレイヤー上位ステートマシーン生成
    {
        public PlayerUpperSMFactory()    //  コンストラクタ
        {
            Register(PlayerStateMachineID.SwordCatchSM, () => CreateSwordCatchSM());    //  ステートマシーン登録
        }

        private IState<PlayerStateMachineID> CreateSwordCatchSM()    //  白刃取りステートマシーン生成
        {
            var swordCatchSMFactory = new PlayerStateFacotry_SwordCatch(null);
            var swordCatchSM = new PlayerSwordCatchSM(this);

            swordCatchSM.Initialize(swordCatchSMFactory);    //  ステートマシーン初期化
            
            return swordCatchSM as IState<PlayerStateMachineID>;
        }
    }
}