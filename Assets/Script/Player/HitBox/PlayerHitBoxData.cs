using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    [System.Serializable]
    public class PlayerHitBoxData    //  ヒットボックスのデータ一覧
    {
        [Header("ヒットボックスリスト")]
        public List<HitBoxData> playerHitBoxes = new();
    }
}