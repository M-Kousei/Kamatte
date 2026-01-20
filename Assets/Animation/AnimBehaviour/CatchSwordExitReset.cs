using Kamatte.Player;
using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class CatchSwordExitReset : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsTryCatch", false);
            animator.GetComponent<PlayerController>().EraseHitBox();
            Debug.Log(2121);
        }
    }
}