using System;
using System.Reflection;
using HarmonyLib;
using TaiwuDiagnostics.Patches;
using TaiwuDiagnostics.Runtime;
using TaiwuModdingLib.Core.Plugin;

namespace TaiwuDiagnostics;

[PluginConfig("TaiwuDiagnostics", "local", "0.1.0")]
public sealed class TaiwuDiagnosticsPlugin : TaiwuRemakePlugin
{
    private const string HarmonyId = "TaiwuDiagnostics.LocalDashboard";
    private Harmony? _harmony;

    public override void Initialize()
    {
        TaiwuDiagnosticsSettings.Load(ModIdStr);
        StartDiagnosticsServer();
        PatchDiagnostics();
    }

    public override void Dispose()
    {
        _harmony?.UnpatchSelf();
        _harmony = null;
        TaiwuDiagnosticsExporter.Dispose();
    }

    public override void OnModSettingUpdate()
    {
        TaiwuDiagnosticsSettings.Load(ModIdStr);
        StartDiagnosticsServer();
    }

    private static void StartDiagnosticsServer()
    {
        TaiwuDiagnosticsExporter.Initialize(
            "TaiwuDiagnostics",
            TaiwuDiagnosticsSettings.EnableTaiwuDiagnosticsServer,
            TaiwuDiagnosticsSettings.AutoOpenTaiwuDiagnosticsDashboard,
            TaiwuDiagnosticsSettings.TaiwuDiagnosticsPort);
        TaiwuDiagnosticsExporter.Publish(
            "diagnostics.server_ready",
            new
            {
                port = TaiwuDiagnosticsSettings.TaiwuDiagnosticsPort,
                dashboardUrl = "http://127.0.0.1:" + TaiwuDiagnosticsSettings.TaiwuDiagnosticsPort + "/",
                serverAvailable = TaiwuDiagnosticsExporter.IsAvailable,
            });
    }

    private void PatchDiagnostics()
    {
        if (_harmony != null)
        {
            return;
        }

        _harmony = new Harmony(HarmonyId);

        bool advanceMonthPatched = TryPatch(typeof(TaiwuDiagnosticsAdvanceMonthPatch), "advance_month");
        bool updateInformationPatched = TryPatch(typeof(TaiwuDiagnosticsUpdateInformationPatch), "update_information");
        bool saveWorldPatched = TryPatchGroup(
            "save_world",
            typeof(TaiwuDiagnosticsArchiveSavePatch),
            typeof(TaiwuDiagnosticsWriteHeaderPatch),
            typeof(TaiwuDiagnosticsWriteContentPatch),
            typeof(TaiwuDiagnosticsDomainSavePatch),
            typeof(TaiwuDiagnosticsDatabaseDisconnectPatch),
            typeof(TaiwuDiagnosticsDatabaseConnectPatch),
            typeof(TaiwuDiagnosticsCopyFromPatch),
            typeof(TaiwuDiagnosticsEndCompressionPatch),
            typeof(TaiwuDiagnosticsWriteCrcToEndPatch));
        bool characterPlanningPatched = TryPatchByPrefix(
            "character_action_planning",
            "TaiwuDiagnostics.Patches.CharacterActionPlanningDiagnostics");

        TaiwuDiagnosticsExporter.Publish(
            "diagnostics.patch_ready",
            new
            {
                harmonyId = HarmonyId,
                targets = new[]
                {
                    new { name = "advance_month", patched = advanceMonthPatched },
                    new { name = "update_information", patched = updateInformationPatched },
                    new { name = "save_world", patched = saveWorldPatched },
                    new { name = "character_action_planning", patched = characterPlanningPatched },
                },
            });
    }

    private bool TryPatch(Type patchType, string targetName)
    {
        try
        {
            _harmony!.CreateClassProcessor(patchType).Patch();
            return true;
        }
        catch (Exception exception)
        {
            TaiwuDiagnosticsExporter.Publish(
                "diagnostics.patch_error",
                new
                {
                    harmonyId = HarmonyId,
                    target = targetName,
                    patchType = patchType.FullName,
                    exception = exception.GetType().FullName,
                    message = exception.Message,
                });
            return false;
        }
    }

    private bool TryPatchGroup(string targetName, params Type[] patchTypes)
    {
        bool allPatched = true;
        foreach (Type patchType in patchTypes)
        {
            allPatched &= TryPatch(patchType, targetName);
        }

        return allPatched;
    }

    private bool TryPatchByPrefix(string targetName, string fullNamePrefix)
    {
        bool found = false;
        bool allPatched = true;
        foreach (Type type in typeof(TaiwuDiagnosticsPlugin).Assembly.GetTypes())
        {
            if (type.FullName == null ||
                !type.FullName.StartsWith(fullNamePrefix, StringComparison.Ordinal) ||
                type.GetCustomAttribute<HarmonyPatch>() == null)
            {
                continue;
            }

            found = true;
            allPatched &= TryPatch(type, targetName);
        }

        return found && allPatched;
    }
}
