using UnityEngine;

namespace Kamatte.SwordCatch
{
    [RequireComponent(typeof(StateRunner_SwordCatch))]
    [DisallowMultipleComponent]
    public class StateBootstrap_SwordCatch : MonoBehaviour
    {
        [SerializeField] StateRunner_SwordCatch stateRunner;    //  Bootstrapでの初期化対象

        ISwordCatchState swordCatchState;    //  ソードキャッチゲームの状態を集約してるクラス、ランナーに渡される。
        CatchState catchState;    //    キャッチの状況を持つクラス

        void Awake()
        {
            if(stateRunner == null)
            {
                stateRunner =  GetComponent<StateRunner_SwordCatch>();
                Debug.LogWarning("SwordCatchStateRunner isn't assigned");
            }

            catchState = new CatchState();
            
            swordCatchState = new SwordCatchState(catchState);
        }

        void Start()
        {
            stateRunner.Initialize(swordCatchState);
        }
    }
}