using GameData.Domains;

namespace TaiwuRemoveAILimitation.Runtime;

internal static class TaiwuRemoveAILimitationSettings
{
    public static bool EnableNpcActionLimitationRemoval = true;
    public static bool EnableHostileActionRangeExpansion = true;
    public static bool EnableNpcActionLimitationRemovalLog = false;
    public static bool EnableNpcActionReachabilityDiagnostics = false;
    public static bool EnableTaiwuDiagnosticsServer = true;
    public static bool AutoOpenTaiwuDiagnosticsDashboard = false;
    public static int TaiwuDiagnosticsPort = 18580;
    public static bool DiagnosticsLogToGameLog = false;

    public static bool DiagnosticsCollectionEnabled =>
        EnableNpcActionLimitationRemovalLog || TaiwuDiagnosticsExporter.IsAvailable;

    public static bool ReachabilityDiagnosticsCollectionEnabled =>
        EnableNpcActionReachabilityDiagnostics || TaiwuDiagnosticsExporter.IsAvailable;

    public static void Load(string modId)
    {
        TryGet(modId, "EnableNpcActionLimitationRemoval", ref EnableNpcActionLimitationRemoval);
        TryGet(modId, "EnableHostileActionRangeExpansion", ref EnableHostileActionRangeExpansion);
        TryGet(modId, "EnableNpcActionLimitationRemovalLog", ref EnableNpcActionLimitationRemovalLog);
        TryGet(modId, "EnableNpcActionReachabilityDiagnostics", ref EnableNpcActionReachabilityDiagnostics);
        TryGet(modId, "EnableTaiwuDiagnosticsServer", ref EnableTaiwuDiagnosticsServer);
        TryGet(modId, "AutoOpenTaiwuDiagnosticsDashboard", ref AutoOpenTaiwuDiagnosticsDashboard);
        TryGet(modId, "TaiwuDiagnosticsPort", ref TaiwuDiagnosticsPort);
        TryGet(modId, "DiagnosticsLogToGameLog", ref DiagnosticsLogToGameLog);
        TaiwuDiagnosticsPort = System.Math.Clamp(TaiwuDiagnosticsPort, 18580, 18595);
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

    private static void TryGet(string modId, string key, ref int value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // Keep default value when settings are unavailable.
        }
    }
}
