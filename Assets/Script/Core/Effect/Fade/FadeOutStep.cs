using System.Collections;
namespace Kamatte.Core
{
    public class FadeOutStep : IGameModeChangeStep    //  GameMode変更時のフェード処理
    {
        public int Order => 20;    //  実行順(小さい方が先)
        public IEnumerator Execute(GameMode prev, GameMode next)    //  Stepの処理関数のラップ関数
        {
            yield return ScreenFader.Instance.FadeOut(1f);
        }
    }
}