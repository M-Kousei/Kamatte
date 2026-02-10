namespace Kamatte.SwordCatch
{
    public interface ISwordCatchState    //  イベントなどでState集約クラス、差し替える用のInterface  
    {

    }
    public abstract class SwordCatchStateBase
    {
        public abstract CatchState CatchState { get; }
    }
}