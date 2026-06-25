using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization;

[PluginConfig("TaiwuOptimization", "local", "0.1.0")]
public sealed class TaiwuOptimizationPlugin : TaiwuRemakePlugin
{
    // 后端所有 patch 共用一个 Harmony 实例，便于卸载时整体回滚。
    private Harmony? _harmony;

    public override void Initialize()
    {
        // 先读取设置，再初始化需要依赖设置的 runtime/cache。
        TaiwuOptimizationSettings.Load(ModIdStr);
        AdvanceMonthOptimizationRuntime.Initialize();

        _harmony = new Harmony("TaiwuOptimization.AdvanceMonthOptimization");
        _harmony.PatchAll(typeof(TaiwuOptimizationPlugin).Assembly);
    }

    public override void Dispose()
    {
        // 卸载时先撤销 patch，再清理 pending/cache 状态。
        _harmony?.UnpatchSelf();
        _harmony = null;
        AdvanceMonthOptimizationRuntime.Dispose();
    }

    public override void OnModSettingUpdate()
    {
        TaiwuOptimizationSettings.Load(ModIdStr);

        // 设置可能改变保护范围或诊断行为，保守地重建保护快照。
        PeriAdvanceMonthProtectionCache.MarkAllDirty();
    }
}
