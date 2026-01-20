using UnityEngine;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    public class SwordHitNotifier : MonoBehaviour    //  “‚ª“–‚½‚Á‚½‚Ì‚ğ’Ê’m
    {
        [SerializeField] PlayerController playerController;
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword") && !playerController.isCatching)
            {
                Debug.Log("End", this.gameObject);
                //SwordCatchEventBus.OnCatchSuccess();
            }
            //  Endˆ—
        }
    }
}