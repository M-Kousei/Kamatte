using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class DelaySword : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsSwingDelay", false);
            animator.SetBool("IsSwingTime", false);
        }
    }
}