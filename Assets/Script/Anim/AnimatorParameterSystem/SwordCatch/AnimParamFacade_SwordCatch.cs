using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public sealed class AnimParamFacade_SwordCatch : AnimParamFacadeBase
    {
        public override AnimParam_Player PlayerParam { get; }
        
        public AnimParamFacade_SwordCatch(AnimParam_Player playerPalam)
        {
            PlayerParam = playerPalam;
        }
    }
}