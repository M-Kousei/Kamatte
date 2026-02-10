namespace Kamatte.SwordCatch
{
    public class SwordCatchState : SwordCatchStateBase   //  白刃取りゲームのフラグデータを持つクラス
    {
        public override CatchState CatchState { get; }    //  キャッチの状態を表すFlagがあるクラス
        public SwordCatchState(CatchState catchState)    //  Bootstrapで使われてSwordCatchStateRunnerに渡される
        {
            CatchState = catchState;
        }
    }
}