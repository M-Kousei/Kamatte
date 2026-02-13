using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class NormalSwingAnimExit : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsSwingTime", false);
            animator.SetBool("IsNormalSwing", false);
        }
    }
}