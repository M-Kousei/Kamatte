using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class SwingedSword : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsSwingTime", false);
        }
    }
}