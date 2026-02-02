using Unity.VisualScripting;
using UnityEngine;

namespace Kamatte.Core
{
    public sealed class GameModeChanger    //  ゲームモード変更クラス
    {
        private void Awake()
        {
        }

        public void Chagne(GameMode prev, GameMode next)    //  ゲームモード変更
        {
            Debug.Log("来てる彼女のパジャマ");
            GameModeChagneExecutor executor = new GameModeChagneExecutor();

            ScreenFader.Instance.Regist(executor);

            CoroutineRunner.instance.StartCoroutine(executor.Execute(prev, next));
        }
    }
}