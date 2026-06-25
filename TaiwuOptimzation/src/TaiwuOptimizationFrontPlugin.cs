using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;

namespace TaiwuOptimization.Frontend;

[PluginConfig("TaiwuOptimizationFront", "local", "0.1.0")]
public sealed class TaiwuOptimizationFrontPlugin : TaiwuRemakePlugin
{
    // 当前前端插件暂不提供 UI patch，仅保留独立 dll 结构。
    private Harmony? _harmony;

    public override void Initialize()
    {
        // 预留前端 patch 入口，保持前后端 dll 分离。
        _harmony = new Harmony("TaiwuOptimization.Frontend");
        _harmony.PatchAll(typeof(TaiwuOptimizationFrontPlugin).Assembly);
    }

    public override void Dispose()
    {
        // 前端卸载时只撤销本插件 patch。
        _harmony?.UnpatchSelf();
        _harmony = null;
    }
}
