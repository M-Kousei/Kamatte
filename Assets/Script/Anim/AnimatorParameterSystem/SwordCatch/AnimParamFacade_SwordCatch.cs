using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public sealed class AnimParamFacade_SwordCatch : AnimParamFacadeBase
    {
        public override AnimParam_Player PlayerParam { get; }
        public override AnimParam_Swinger SwingerParam { get; }
        
        public AnimParamFacade_SwordCatch(AnimParam_Player playerPalam, AnimParam_Swinger swingerParam)
        {
            PlayerParam = playerPalam;
            SwingerParam = swingerParam;
        }
    }
}