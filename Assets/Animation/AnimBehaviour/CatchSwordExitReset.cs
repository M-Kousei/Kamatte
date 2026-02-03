using UnityEngine;

namespace Kamatte.Core
{
    public class CatchSwordExitReset : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsTryCatch", false);
        }
    }
}