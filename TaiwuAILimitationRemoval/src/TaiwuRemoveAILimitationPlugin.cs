using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;
using TaiwuRemoveAILimitation.Runtime;

namespace TaiwuRemoveAILimitation;

[PluginConfig("TaiwuRemoveAILimitation", "local", "0.1.0")]
public sealed class TaiwuRemoveAILimitationPlugin : TaiwuRemakePlugin
{
    private Harmony? _harmony;

    public override void Initialize()
    {
        TaiwuRemoveAILimitationSettings.Load(ModIdStr);
        TaiwuDiagnosticsExporter.Initialize(
            "TaiwuRemoveAILimitation",
            TaiwuRemoveAILimitationSettings.EnableTaiwuDiagnosticsServer,
            TaiwuRemoveAILimitationSettings.AutoOpenTaiwuDiagnosticsDashboard,
            TaiwuRemoveAILimitationSettings.TaiwuDiagnosticsPort);
        TaiwuDiagnosticsExporter.Publish(
            "mod.loaded",
            new
            {
                mod = "TaiwuRemoveAILimitation",
                diagnosticsCollectionEnabled = TaiwuRemoveAILimitationSettings.DiagnosticsCollectionEnabled,
                diagnosticsLogToGameLog = TaiwuRemoveAILimitationSettings.DiagnosticsLogToGameLog,
            });

        _harmony = new Harmony("TaiwuRemoveAILimitation.NpcActionBypass");
        _harmony.PatchAll(typeof(TaiwuRemoveAILimitationPlugin).Assembly);
    }

    public override void Dispose()
    {
        _harmony?.UnpatchSelf();
        _harmony = null;
        TaiwuDiagnosticsExporter.Dispose();
    }

    public override void OnModSettingUpdate()
    {
        TaiwuRemoveAILimitationSettings.Load(ModIdStr);
        TaiwuDiagnosticsExporter.Initialize(
            "TaiwuRemoveAILimitation",
            TaiwuRemoveAILimitationSettings.EnableTaiwuDiagnosticsServer,
            TaiwuRemoveAILimitationSettings.AutoOpenTaiwuDiagnosticsDashboard,
            TaiwuRemoveAILimitationSettings.TaiwuDiagnosticsPort);
    }
}
