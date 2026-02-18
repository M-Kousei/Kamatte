using Unity.VisualScripting;

namespace Kamatte.Core
{
    public sealed class GameModeChanger    //  ゲームモード変更クラス
    {
        private void Awake()
        {
        }

        public void Chagne(GameMode prev, GameMode next)    //  ゲームモード変更
        {
            GameModeChagneExecutor executor = new GameModeChagneExecutor();

            ScreenFader.Instance.Regist(executor);

            CoroutineRunner.instance.StartCoroutine(executor.Execute(prev, next));
        }
    }
}