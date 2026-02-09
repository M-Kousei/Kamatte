namespace Kamatte.SwordCatch
{
    public class SwordCatchState : ISwordCatchState   //  白刃取りゲームのフラグデータを持つクラス
    {
        CatchState CatchState { get; }    //  キャッチの状態を表すFlagがあるクラス
        public SwordCatchState(CatchState catchState)    //  Bootstrapで使われてSwordCatchStateRunnerに渡される
        {
            CatchState = catchState;
        }
    }
}