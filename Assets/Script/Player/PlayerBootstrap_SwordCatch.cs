using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    [RequireComponent(typeof(PlayerController))]
    [DisallowMultipleComponent]
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] PlayerController playerController; 
        [SerializeField] PlayerHitBoxData playerHitBoxData;
        [SerializeField] Transform playerHeadTF;

        [SerializeField] StateHolder_SwordCatch stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader_SwordCatch stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。
        StateAccessJudge_SwordCatch accessJudge;    //  アクセスが適正かを判断する関数をReader層から呼ばれる。

        void Awake()
        {
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
                Debug.LogWarning("playerController isn't assigned in the Inspector");
            }
            if(playerHitBoxData == null)
            {
                Debug.LogError("playerHitBoxData isn't assigned in the Inspector");
            }
            if (playerHeadTF == null)
            {
                Debug.LogError("playerHeadTF isn't assigned in the Inspector");
            }
            if(stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }

            accessJudge = new StateAccessJudge_SwordCatch();
            stateReader = new StateReader_SwordCatch(stateHolder, accessJudge);

            playerController.Initialize(playerHitBoxData, playerHeadTF, stateReader);    //  Controllerの性質上Awakeで初期化
        }

        void Start()
        {
        }
    }
}