namespace Kamatte.Core
{
    public enum GameStateID
    {
        Title,
        Shop,
        SwordCatch,
    }
    //public readonly struct GameStateID
    //{
    //    // 事前定義タグ
    //    public static readonly GameStateID Title = new ("[AutoAssign]");
    //    public static readonly GameStateID Shop = new("[ScreenFader]");
    //    public static readonly GameStateID SwordCatch = new("[FadeImageSetter]");

    //    public string Value { get; }

    //    private GameStateID(string value)
    //    {
    //        Value = value;
    //    }

    //    public override string ToString() => Value;

    //    // 等価比較（==, !=）できるように
    //    public override bool Equals(object obj)
    //    {
    //        return obj is GameStateID other && Value == other.Value;
    //    }

    //    //  ハッシュコードゲット
    //    public override int GetHashCode() => Value.GetHashCode();

    //    public static bool operator ==(GameStateID a, GameStateID b) => a.Equals(b);
    //    public static bool operator !=(GameStateID a, GameStateID b) => !a.Equals(b);

    //    // 動的に作成も可能
    //    public static GameStateID Custom(string value) => new(value);
    //}
}