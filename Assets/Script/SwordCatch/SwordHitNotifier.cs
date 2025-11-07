using UnityEngine;

namespace Kamatte.SwordCatch
{
    public class SwordHitNotifier : MonoBehaviour    //  “‚ª“–‚½‚Á‚½‚Ì‚ğ’Ê’m
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword"))
            {
                Debug.Log("End");
                //SwordCatchEventBus.OnCatchSuccess();
            }
            //  Endˆ—
        }
    }
}