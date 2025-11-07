using Kamatte.Player;

namespace Kamatte.Core
{
    public class PlayerTryCatchState : StateBase<PlayerSwordCatchStateID>    //  ”’næ‚èIdleó‘Ô
    {
        public PlayerTryCatchState(IStateMachine<PlayerSwordCatchStateID> machine) : base(machine) { }


        public override void OnUpdate()
        {

        }
    }
}