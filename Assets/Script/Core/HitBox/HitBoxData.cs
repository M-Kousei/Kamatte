using UnityEngine;

namespace Kamatte.Core
{
    public class HitBoxData    //  当たり判定基礎データ
    {
        [Header("識別情報")]
        public HitBoxID id;   // ← 識別子（例："LeftHand", "RightHand", "Kick"など）

        [Header("判定位置とサイズ")]
        public Vector3 offset;    //  生成位置オフセット
        public Vector3 size;      //  当たり判定の大きさ

        [Header("フレーム")]
        public int startFrame;    //  当たり判定出現フレーム
        public int endFrame;      //  当たり判定削除フレーム
    }
}