using UnityEngine;
using Kamatte.Customer;

namespace Kamatte.SwordCatch
{
    public class SwingTimeController : MonoBehaviour    //  刀を振るタイミングを決定するスクリプト
    {
        [SerializeField] CustomerStatus customerStatus;    //  お客さんのステータス
        CustomerStatusBlock customerStatusBlock;           //  お客さんのステータスブロック
        SwordSwingController _swordSwingController;             //  刀振りのコントローラー

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