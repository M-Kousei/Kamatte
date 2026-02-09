using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwordSwingController    //  刀の振り下ろしをコントロール
    {
        Animator _swingerAnimator;    //  アニメーター型の変数
        public SwordSwingController(Animator anim)    //  コンストラクタ
        {
            _swingerAnimator = anim;
        }

        public void SwingSword()    //  刀振り下ろし
        {
            LogUtility.Log(LogPrefix.SwingSwordController, "刀振り下ろしアニメーション開始", LogLevel.Debug);
            int r = Random.Range(0, 3);

            if(r == 0)
            {
                Debug.LogWarning("Normal");
                _swingerAnimator.SetTrigger(SwordSwingerAnimHash.GetAnimation(SwordCatchAnimID_Swinger.SwingSword));
            }
            else if( r == 1)
            {
                Debug.LogWarning("Fast");
                _swingerAnimator.SetTrigger(SwordSwingerAnimHash.GetAnimation(SwordCatchAnimID_Swinger.SwingFast));
            }
            else if (r == 2)
            {
                Debug.LogWarning("Delay");
                _swingerAnimator.SetTrigger(SwordSwingerAnimHash.GetAnimation(SwordCatchAnimID_Swinger.SwingDelay));
            }
        }
    }
}