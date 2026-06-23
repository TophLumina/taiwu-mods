using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization;

[PluginConfig("TaiwuOptimization", "local", "0.1.0")]
public sealed class TaiwuOptimizationPlugin : TaiwuRemakePlugin
{
    private Harmony? _harmony;

    public override void Initialize()
    {
        DelayMonthSettings.Load(ModIdStr);
        DelayMonthRuntime.Initialize();

        _harmony = new Harmony("TaiwuOptimization.DelayMonth");
        _harmony.PatchAll(typeof(TaiwuOptimizationPlugin).Assembly);
    }

    public override void Dispose()
    {
        _harmony?.UnpatchSelf();
        _harmony = null;
        DelayMonthRuntime.Dispose();
    }

    public override void OnModSettingUpdate()
    {
        DelayMonthSettings.Load(ModIdStr);
    }
}
