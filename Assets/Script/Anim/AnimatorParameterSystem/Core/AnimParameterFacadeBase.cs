using Kamatte.SwordCatch;

namespace Kamatte.Core
{
    public abstract class AnimParamFacadeBase    //  イベントなどの際に差し替えできるようにFacade集約クラスに入れる
    {
        public virtual AnimParam_Player PlayerParam { get;}
    }
}