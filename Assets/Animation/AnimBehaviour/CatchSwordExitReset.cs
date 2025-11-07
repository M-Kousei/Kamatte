using UnityEngine;

namespace Kamatte.Animation
{
    public class CatchSwordExitReset : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsTryCatch", false);
            Debug.Log(3);
        }
    }
}