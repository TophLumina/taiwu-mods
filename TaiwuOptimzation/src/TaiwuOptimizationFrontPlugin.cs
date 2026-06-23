using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;

namespace TaiwuOptimization.Frontend;

[PluginConfig("TaiwuOptimizationFront", "local", "0.1.0")]
public sealed class TaiwuOptimizationFrontPlugin : TaiwuRemakePlugin
{
    private Harmony? _harmony;

    public override void Initialize()
    {
        _harmony = new Harmony("TaiwuOptimization.Frontend");
        _harmony.PatchAll(typeof(TaiwuOptimizationFrontPlugin).Assembly);
    }

    public override void Dispose()
    {
        _harmony?.UnpatchSelf();
        _harmony = null;
    }
}
