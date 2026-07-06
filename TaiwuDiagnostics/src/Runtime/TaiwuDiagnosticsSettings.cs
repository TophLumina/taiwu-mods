using System;
using GameData.Domains;

namespace TaiwuDiagnostics.Runtime;

internal static class TaiwuDiagnosticsSettings
{
    public static bool EnableTaiwuDiagnosticsServer = true;
    public static bool AutoOpenTaiwuDiagnosticsDashboard = false;
    public static int TaiwuDiagnosticsPort = 18580;
    public static bool CaptureSaveWorldDiagnostics = true;
    public static bool CopySaveArchiveSnapshot = true;
    public static int SaveArchiveSnapshotMaxCount = 5;
    public static bool CaptureAdvanceMonthPlanningDiagnostics = true;

    public static void Load(string modId)
    {
        TryGet(modId, "EnableTaiwuDiagnosticsServer", ref EnableTaiwuDiagnosticsServer);
        TryGet(modId, "AutoOpenTaiwuDiagnosticsDashboard", ref AutoOpenTaiwuDiagnosticsDashboard);
        TryGet(modId, "TaiwuDiagnosticsPort", ref TaiwuDiagnosticsPort);
        TryGet(modId, "CaptureSaveWorldDiagnostics", ref CaptureSaveWorldDiagnostics);
        TryGet(modId, "CopySaveArchiveSnapshot", ref CopySaveArchiveSnapshot);
        TryGet(modId, "SaveArchiveSnapshotMaxCount", ref SaveArchiveSnapshotMaxCount);
        TryGet(modId, "CaptureAdvanceMonthPlanningDiagnostics", ref CaptureAdvanceMonthPlanningDiagnostics);

        TaiwuDiagnosticsPort = Math.Clamp(TaiwuDiagnosticsPort, 18580, 18595);
        SaveArchiveSnapshotMaxCount = Math.Clamp(SaveArchiveSnapshotMaxCount, 1, 20);
    }

    private static void TryGet(string modId, string key, ref bool value)
    {
        try
        {
            DomainManager.Mod.GetSetting(modId, key, ref value);
        }
        catch
        {
            // Keep defaults while settings are unavailable.
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
            // Keep defaults while settings are unavailable.
        }
    }
}
