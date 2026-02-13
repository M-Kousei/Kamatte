using UnityEngine;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    public sealed class AnimParam_Player : AnimParamCollectionBase    //  AnimaParameterHubÇ…èWñÒÇ≥ÇÍÇÈ
    {
        public PlayerParam_Catch PlayerParam_Catch { get; }
        public AnimParam_Player
            (Animator animator, AnimParamRead animParamRead, AnimParamSet animParamSet, PlayerAnimParamContext ctx) :
            base(animator, animParamRead, animParamSet)
        {
            PlayerParam_Catch = ctx.PlayerParam_Catch;

        }
    }
}