using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    [RequireComponent(typeof(StateBootstrap_SwordCatch))]
    [DisallowMultipleComponent]
    public class StateRunner_SwordCatch : MonoBehaviour
    {
        public ISwordCatchState SwordCatchState { get; private set; }

        public void Initialize(ISwordCatchState swordCatchState)    //  BootStrap‚©‚çŒÄ‚Î‚ê‚é‰Šú‰»
        {
            SwordCatchState = swordCatchState;
        }
    }
}