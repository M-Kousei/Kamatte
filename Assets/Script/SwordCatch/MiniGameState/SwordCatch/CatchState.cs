namespace Kamatte.SwordCatch
{
    public class CatchState    //  白刃取りが失敗したか、成功したかのFlagを持ってる
    {
        bool isCatchSword = false;    //  刀をキャッチした後に、顔に当たって失敗判定になる可能性を消すのに使う

        public bool IsCatchSword
        { get { return isCatchSword; } set { isCatchSword = value; } }
    }
}