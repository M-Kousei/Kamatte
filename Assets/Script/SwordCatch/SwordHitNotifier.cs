using UnityEngine;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    public class SwordHitNotifier : MonoBehaviour    //  ìÅÇ™ìñÇΩÇ¡ÇΩéûÇ…èàóùÇìÆÇ©Ç∑
    {
        [SerializeField] PlayerController _playerController;
        [SerializeField] SwingTimeController _swingTimeController;
        [SerializeField] StateHolder_SwordCatch stateHolder;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sword") && !stateHolder.SwordCatchState.CatchState.IsCatchSword)/* && !_playerController.isCatching*/
            {
                _playerController.EraseHitBox();
                stateHolder.SwordCatchState.HitSwingState.ChagneHitSwordState(true);
                _playerController.isHited = true;
                //GameModeChagneEvents.RaiseChanged(GameMode.SwordCatch, GameMode.SwordCatch);
                EffectActAPI.Action(new EffectActKey(EffectActor.Player, EffectActTrigger.Hit, EffectActType.Blow));
                _swingTimeController.IsTimerStop = true;
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.IsHited.SetBool(true);
                //ServiceLocator.Resolve<IGameModeService>().RequestChange(GameMode.SwordCatch);
            }
            //  Endèàóù
        }
    }
}