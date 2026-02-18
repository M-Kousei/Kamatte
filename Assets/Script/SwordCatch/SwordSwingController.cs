using UnityEngine;
using Kamatte.Core;

namespace Kamatte.SwordCatch
{
    public class SwordSwingController    //  刀の振り下ろしをコントロール
    {
        public SwordSwingController()    //  コンストラクタ
        {
        }

        public void SwingSword()    //  刀振り下ろし
        {
            LogUtility.Log(LogPrefix.SwingSwordController, "刀振り下ろしアニメーション開始", LogLevel.Debug);
            int r = Random.Range(0, 2);

            if(r == 0)
            {
                Debug.LogWarning("Normal");
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.NormalSwing.SetTrigger();
            }
            else if( r == 1)
            {
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.NormalSwing.SetTrigger();
                //ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.FastSwing.SetTrigger();
                Debug.LogWarning("Fast");
            }
            else if (r == 2)
            {
                Debug.LogWarning("Delay");
                ServiceLocator.Resolve<AnimParamFacadeBase>().SwingerParam.DelaySwing.SetTrigger();
            }
        }
    }
}