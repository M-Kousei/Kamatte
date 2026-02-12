using UnityEngine;
using Kamatte.Customer;

namespace Kamatte.SwordCatch
{
    public class SwingTimeController : MonoBehaviour    //  刀を振るタイミングを決定するスクリプト
    {
        [SerializeField] CustomerStatus customerStatus;    //  お客さんのステータス
        CustomerStatusBlock customerStatusBlock;           //  お客さんのステータスブロック
        SwordSwingController _swordSwingController;             //  刀振りのコントローラー

        [SerializeField] StateHolder_SwordCatch stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader_SwordCatch stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。
        StateReadJudge_SwordCatch readJudge;    //  アクセスが適正かを判断する関数をReader層から呼ばれる。
        StateWriter_SwordCatch stateWriter;    //  下位クラスからStateを書き換えるためのFacade、judgeを通ったらState集約クラスの関数を使って書き換える
        StateWriteJudge_SwordCatch writeJudge;    //  下位クラスからの書き換えが適正かを判断する、Witerにインスタンスを渡してそこから判断関数を呼び出してもらう
        
        SwingerPersonal swingerPersonal;     //  刀振りの性格

        float swingTimer;     //  刀を振り下ろすまでのタイマー
        bool isTimerStop = false;

        public bool IsTimerStop { 
            get{ return isTimerStop; }
            set { isTimerStop = value; }
        }

        private void Awake()
        {
            customerStatusBlock = customerStatus.GetStats(CustomerID.Samurai);
            swingerPersonal = customerStatusBlock.swingerPersonal;

            swingTimer = customerStatusBlock.swingTimer;
        }
        public void Initialize(SwordSwingController swingController)    //  クラス変数初期化
        {
            customerStatusBlock = customerStatus.GetStats(CustomerID.Samurai);
            _swordSwingController = swingController;

            swingerPersonal = customerStatusBlock.swingerPersonal;

            swingTimer = customerStatusBlock.swingTimer;
            readJudge = new StateReadJudge_SwordCatch();
            stateReader = new StateReader_SwordCatch(stateHolder, readJudge);
            writeJudge = new StateWriteJudge_SwordCatch();
            stateWriter = new StateWriter_SwordCatch(stateHolder, writeJudge);
        }
        void Update()
        {
            if (!IsTimerStop)
            {
                swingTimer -= Time.deltaTime;
            }
            switch (swingerPersonal)
            {
                case SwingerPersonal.Chiken:
                    ChikenUpdate();
                    break;
                case SwingerPersonal.SwordMaster:
                    SwordMasterUpdate();
                    break;
                case SwingerPersonal.SpeedStar:
                    SpeedStarUpdate();
                    break;
            }
            if (swingTimer < 0)
            {
                stateWriter.ChangeIsCatchState(false);
                _swordSwingController.SwingSword();
                swingTimer = 10;
            }
        }
        void ChikenUpdate()    //  性格ChikenのUpdate
        {

        }
        void SwordMasterUpdate()    //  性格SwordMasterUpdate
        {
            if (swingTimer < 0)
            {
                //  Swing
            }
        }
        void SpeedStarUpdate()    //  性格SpeedStarのUpdate
        {
            if (swingTimer < 0)
            {
                //  Swing
            }
        }
    }
}