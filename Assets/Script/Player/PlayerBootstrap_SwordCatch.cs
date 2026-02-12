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
        StateReadJudge_SwordCatch readJudge;    //  アクセスが適正かを判断する関数をReader層から呼ばれる。
        StateWriter_SwordCatch stateWriter;    //  下位クラスからStateを書き換えるためのFacade、judgeを通ったらState集約クラスの関数を使って書き換える
        StateWriteJudge_SwordCatch writeJudge;    //  下位クラスからの書き換えが適正かを判断する、Witerにインスタンスを渡してそこから判断関数を呼び出してもらう

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

            readJudge = new StateReadJudge_SwordCatch();
            stateReader = new StateReader_SwordCatch(stateHolder, readJudge);
            writeJudge = new StateWriteJudge_SwordCatch();
            stateWriter = new StateWriter_SwordCatch(stateHolder, writeJudge);

            playerController.Initialize(playerHitBoxData, playerHeadTF, stateReader, stateWriter);    //  Controllerの性質上Awakeで初期化
        }

        void Start()
        {
        }
    }
}