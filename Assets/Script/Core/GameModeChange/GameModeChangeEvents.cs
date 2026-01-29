using System;
using Kamatte.Core;

public static class GameModeChagneEvents    //  ゲームモード変更関数保持してるクラス
{
    public static event Action<GameMode, GameMode> OnChanged;    //  変更イベント登録変数

    public static void RaiseChanged(GameMode prev, GameMode next)    //  変更イベント発火
    {
        OnChanged?.Invoke(prev, next);
    }
}