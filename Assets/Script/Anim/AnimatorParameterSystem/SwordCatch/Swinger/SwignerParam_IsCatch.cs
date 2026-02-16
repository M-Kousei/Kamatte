using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwingerParam_IsCatch : AnimParamBase
    {
        public SwingerParam_IsCatch(Animator animator, string paramName) : base(animator, paramName) { }

        public void SetBool(bool isHited)
        {
            animator.SetBool(hash, isHited);
        }
    }
}