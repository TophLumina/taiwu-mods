using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization;

[PluginConfig("TaiwuOptimization", "local", "0.1.0")]
public sealed class TaiwuOptimizationPlugin : TaiwuRemakePlugin
{
    // 后端所有 patch 共用同一个 Harmony 实例，卸载时整体撤销。
    private Harmony? _harmony;

    public override void Initialize()
    {
        TaiwuOptimizationSettings.Load(ModIdStr);
        AdvanceMonthOptimizationRuntime.Initialize();

        _harmony = new Harmony("TaiwuOptimization.AdvanceMonthOptimization");
        _harmony.PatchAll(typeof(TaiwuOptimizationPlugin).Assembly);
    }

    public override void Dispose()
    {
        _harmony?.UnpatchSelf();
        _harmony = null;
        AdvanceMonthOptimizationRuntime.Dispose();
    }

    public override void OnModSettingUpdate()
    {
        TaiwuOptimizationSettings.Load(ModIdStr);
        PeriAdvanceMonthProtectionCache.MarkAllDirty();
    }
}
