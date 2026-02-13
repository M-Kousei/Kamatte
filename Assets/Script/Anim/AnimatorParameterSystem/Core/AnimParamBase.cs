using UnityEngine;

namespace Kamatte.Core
{
    public abstract class AnimParamBase
    {
        protected Animator animator;
        protected int hash;

        protected AnimParamBase(Animator animator, string paramName)
        {
            this.animator = animator;
            hash = Animator.StringToHash(paramName);
        }
    }
}