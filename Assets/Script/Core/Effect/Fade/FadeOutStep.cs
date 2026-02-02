using System.Collections;

namespace Kamatte.Core
{
    public class FadeOutStep : IGameModeChangeStep
    {
        public int Order => 20;    //  Às‡(¬‚³‚¢•û‚ªæ)
        public IEnumerator Execute(GameMode prev, GameMode next)    //  Step‚Ìˆ—ŠÖ”‚Ìƒ‰ƒbƒvŠÖ”
        {
            yield return ScreenFader.Instance.FadeOut(1f);
        }
    }
}