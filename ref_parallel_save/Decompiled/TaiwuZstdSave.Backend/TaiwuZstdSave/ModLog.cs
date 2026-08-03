using GameData.Utilities;

namespace TaiwuZstdSave;

internal static class ModLog
{
    private const string Prefix = "[TaiwuZstdSave] ";

    public static void Info(string message)
    {
        AdaptableLog.Info("[TaiwuZstdSave] " + message);
    }

    public static void Warning(string message)
    {
        AdaptableLog.Warning("[TaiwuZstdSave] " + message, false);
    }
}
