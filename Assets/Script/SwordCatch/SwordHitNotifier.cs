using UnityEngine;
using Kamatte.Player;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwordHitNotifier : MonoBehaviour    //  ìÅÇ™ìñÇΩÇ¡ÇΩÇÃÇí ím
    {
        [SerializeField] PlayerController playerController;
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword") && !playerController.isCatching)
            {
                GameModeChagneEvents.RaiseChanged(GameMode.SwordCatch, GameMode.SwordCatch);
                //SwordCatchEventBus.OnCatchSuccess();
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
            }
            //  Endèàóù
        }
    }
}