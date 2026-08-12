using System;
using System.Reflection;
using GameData.Domains.TaiwuEvent;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

/// <summary>
/// Supplies an already loaded Assembly to the original event-package loop. Only
/// the LoadBuffer enum value (2 in the current game assembly) is eligible.
/// </summary>
[HarmonyPatch(typeof(TaiwuEventDomain), "LoadEventPackageAssembly", new[] { typeof(string) })]
internal static class EventAssemblyPreloadTakePatch
{
    private const int LoadBufferMethodValue = 2;
    private static readonly FieldInfo? LoadMethodField =
        AccessTools.Field(typeof(TaiwuEventDomain), "_loadMethod");

    private static bool Prefix(string path, ref Assembly __result)
    {
        if (!IsUsingLoadBuffer() || !EventAssemblyPreloader.TryTake(path, out Assembly assembly))
        {
            return true;
        }

        __result = assembly;
        return false;
    }

    private static bool IsUsingLoadBuffer()
    {
        try
        {
            object? loadMethod = LoadMethodField?.GetValue(null);
            return loadMethod != null && Convert.ToInt32(loadMethod) == LoadBufferMethodValue;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

/// <summary>
/// Releases any unused cold-start buffers after the built-in, DLC, and mod event
/// packages have passed through the original initialization method.
/// </summary>
[HarmonyPatch(typeof(TaiwuEventDomain), nameof(TaiwuEventDomain.InitConchShipEvents))]
internal static class EventAssemblyPreloadCompletionPatch
{
    private static Exception? Finalizer(Exception? __exception)
    {
        EventAssemblyPreloader.CompleteInitialLoad();
        return __exception;
    }
}
