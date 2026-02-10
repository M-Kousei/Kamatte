using UnityEngine;

namespace Kamatte.SwordCatch
{
    [RequireComponent(typeof(StateHolderBootstrap_SwordCatch))]
    [DisallowMultipleComponent]
    public class StateHolder_SwordCatch : MonoBehaviour
    {
        public SwordCatchStateBase SwordCatchState { get; private set; }

        public void Initialize(SwordCatchStateBase swordCatchState)    //  BootStrap‚©‚çŒÄ‚Î‚ê‚é‰Šú‰»
        {
            SwordCatchState = swordCatchState;
        }
    }
}