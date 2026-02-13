using UnityEngine;

namespace Kamatte.Core
{
    public abstract class AnimParamCollectionBase    //  
    {
        protected Animator animator;
        protected AnimParamRead paramRead;
        protected AnimParamSet paramSet;

        protected AnimParamCollectionBase(Animator animator, AnimParamRead paramRead, AnimParamSet paramSet)
        {
            this.animator = animator;
            this.paramRead = paramRead;
            this.paramSet = paramSet;
        }
       
    }
}