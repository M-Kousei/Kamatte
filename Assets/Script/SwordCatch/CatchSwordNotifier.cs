using UnityEngine;
using Kamatte.Core;

namespace Kamatte.Player
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class CatchSwordNotifier : MonoBehaviour    //  îíênéÊÇË
    {
        private void OnEnable()
        {
            //SwordCatchEventBus.OnCatchPressed += ;
        }

        private void OnDisable()
        {
            //SwordCatchEventBus.OnCatchPressed -= HandleCatch;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword"))
            {
                LogUtility.Log(LogPrefix.CatchSwordNotifier, "îíênéÊÇËê¨å˜", LogLevel.Info);
                //SwordCatchEventBus.OnCatchSuccess();
            }
        }
    }
}
