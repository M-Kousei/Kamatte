using UnityEngine;
using UnityEngine.UIElements;

namespace Kamatte.Core
{
    public static class EffectAPIWindow    //  エフェクトAPI窓口
    {
        public static void Play(EffectKey key, Vector3 pos)    //  エフェクト再生
        {
            Debug.Log("Untitile");
            ServiceLocator.Resolve<IEffectSystem>().Play(key, pos);
        }
        public static void Stop(EffectKey key)
        {
            ServiceLocator.Resolve<IEffectSystem>().Stop(key);
        }
    }
}