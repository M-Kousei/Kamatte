using UnityEngine;

public class AnimatorBinding_SwordCatch
{
    enum AnimatorRole
    {
        Player,
        SwordSwinger
    }

    class AnimatorBinding    //  
    {
        public AnimatorRole role;
        public Animator animator;
    }

}
