using GameData.Domains;

namespace TaiwuRemoveAILimitation.Runtime;

internal static class TaiwuRemoveAILimitationSettings
{
    public static bool EnableNpcActionLimitationRemoval = true;
    public static bool EnableNpcActionLimitationRemovalLog = false;
    public static bool EnableNpcActionReachabilityDiagnostics = false;

    public static void Load(string modId)
    {
        TryGet(modId, "EnableNpcActionLimitationRemoval", ref EnableNpcActionLimitationRemoval);
        TryGet(modId, "EnableNpcActionLimitationRemovalLog", ref EnableNpcActionLimitationRemovalLog);
        TryGet(modId, "EnableNpcActionReachabilityDiagnostics", ref EnableNpcActionReachabilityDiagnostics);
    }

    private static void TryGet(string modId, string key, ref bool value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // 设置尚未加载时保留默认值。
        }
    }
}
