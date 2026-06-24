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
        DeferredAdvanceMonthSettings.Load(ModIdStr);
        DeferredAdvanceMonthRuntime.Initialize();

        _harmony = new Harmony("TaiwuOptimization.DeferredAdvanceMonth");
        _harmony.PatchAll(typeof(TaiwuOptimizationPlugin).Assembly);
    }

    public override void Dispose()
    {
        _harmony?.UnpatchSelf();
        _harmony = null;
        DeferredAdvanceMonthRuntime.Dispose();
    }

    public override void OnModSettingUpdate()
    {
        DeferredAdvanceMonthSettings.Load(ModIdStr);
    }
}
