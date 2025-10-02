using UnityEngine;
using Kamatte.Customer;

namespace Kamatte.SwordCatch
{
    public class SwingTimeController : MonoBehaviour    //  刀を振るタイミングを決定するスクリプト
    {
        [SerializeField] CustomerStatus customerStatus;    //  お客さんのステータス
        CustomerStatusBlock customerStatusBlock;           //  お客さんのステータスブロック

        SwingerPersonal swingerPersonal;     //  刀振りの性格

        float swingTimer;     //  刀を振り下ろすまでのタイマー

        private void Awake()
        {
            customerStatusBlock = customerStatus.GetStats(CustomerID.Samurai);
            swingerPersonal = customerStatusBlock.swingerPersonal;

            swingTimer = customerStatusBlock.swingTimer;
        }
        void Initialize()    //  クラス変数初期化
        {
            customerStatusBlock = customerStatus.GetStats(CustomerID.Samurai);
            swingerPersonal = customerStatusBlock.swingerPersonal;

            swingTimer = customerStatusBlock.swingTimer;
        }
        void Start()
        {

        }

        void Update()
        {
            swingTimer -= Time.deltaTime;

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
        }
        void ChikenUpdate()    //  性格ChikenのUpdate
        {

        }
        void SwordMasterUpdate()    //  性格SwordMasterUpdate
        {

        }
        void SpeedStarUpdate()    //  性格SpeedStarのUpdate
        {

        }
    }
}