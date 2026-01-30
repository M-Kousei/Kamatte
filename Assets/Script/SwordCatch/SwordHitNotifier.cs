using UnityEngine;
using Kamatte.Player;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwordHitNotifier : MonoBehaviour    //  ìÅÇ™ìñÇΩÇ¡ÇΩÇÃÇí ím
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] SwingTimeController _swingTimeController;
        [SerializeField] Animator _swingerAnimator;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword") && !_playerController.isCatching)
            {
                //GameModeChagneEvents.RaiseChanged(GameMode.SwordCatch, GameMode.SwordCatch);
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
                _swingTimeController.IsTimerStop = true;
                _swingerAnimator.SetTrigger(SwordSwingerAnimHash.GetAnimation(SwordCatchAnimID_Swinger.Sheath));
            }
            //  Endèàóù
        }
    }
}