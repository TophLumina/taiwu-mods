using HarmonyLib;
using TaiwuModdingLib.Core.Plugin;

namespace TaiwuZstdSave;

[PluginConfig("TaiwuZstdSave", "Local", "0.2.0")]
public sealed class ModEntry : TaiwuRemakePlugin
{
    private Harmony? _harmony;

    public override void Initialize()
    {
        //IL_001d: Unknown result type (might be due to invalid IL or missing references)
        //IL_0027: Expected O, but got Unknown
        NativeZstd.Initialize(((TaiwuRemakePlugin)this).ModIdStr);
        NativeZlibNg.Initialize(((TaiwuRemakePlugin)this).ModIdStr);
        _harmony = new Harmony(((TaiwuRemakePlugin)this).GetGuid());
        _harmony.PatchAll(typeof(ModEntry).Assembly);
        ModLog.Info($"Backend Mod 已初始化。Zstd 存档算法值为 {254}。");
    }

    public override void Dispose()
    {
        Harmony? harmony = _harmony;
        if (harmony != null)
        {
            harmony.UnpatchSelf();
        }
        _harmony = null;
        ModLog.Info("Backend Mod 已卸载。");
    }

    public override void OnModSettingUpdate()
    {
        ModSettings.Update(((TaiwuRemakePlugin)this).ModIdStr);
        if (ModSettings.UseZstd)
        {
            CompatibilityBackup.EnsureForCurrentArchive();
        }
    }
}
