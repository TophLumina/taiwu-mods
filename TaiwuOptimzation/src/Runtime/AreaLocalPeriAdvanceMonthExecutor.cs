using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Extra;
using GameData.Domains.Map;
using GameData.Utilities;
using HarmonyLib;

namespace TaiwuOptimization.Runtime;

internal static class AreaLocalPeriAdvanceMonthExecutor
{
    private const int AreaCount = 141;
    private const int SkeletonAreaCount = 45;

    // 原版动物生成 helper 是非公开方法，初始化时用 Harmony 解析为委托。
    private delegate bool TryGetRandomBlockForGeneratingAnimalDelegate(
        ExtraDomain domain,
        DataContext context,
        short areaId,
        bool isTaiwuSkill,
        out short blockId);

    private delegate short GetRandomAnimalForGeneratingAnimalDelegate(ExtraDomain domain, DataContext context);

    private static TryGetRandomBlockForGeneratingAnimalDelegate? _tryGetRandomBlockForGeneratingAnimal;
    private static GetRandomAnimalForGeneratingAnimalDelegate? _getRandomAnimalForGeneratingAnimal;

    /// <summary>解析延迟回放时需要调用的原版非公开方法。</summary>
    public static void Initialize()
    {
        _tryGetRandomBlockForGeneratingAnimal = AccessTools
            .Method(
                typeof(ExtraDomain),
                "TryGetRandomBlockForGeneratingAnimal",
                new[] { typeof(DataContext), typeof(short), typeof(bool), typeof(short).MakeByRefType() })
            .CreateDelegate<TryGetRandomBlockForGeneratingAnimalDelegate>();

        _getRandomAnimalForGeneratingAnimal = AccessTools
            .Method(typeof(ExtraDomain), "GetRandomAnimalForGeneratingAnimal", new[] { typeof(DataContext) })
            .CreateDelegate<GetRandomAnimalForGeneratingAnimalDelegate>();
    }

    /// <summary>截取某个 area 当前地块上的角色列表，避免延迟回放时重新扫描变化后的角色集合。</summary>
    /// <param name="areaId">目标 area。</param>
    public static List<int> SnapshotAreaCharacterIdsForParallelAction(int areaId)
    {
        List<int> characterIds = new();
        if (areaId < 0 || areaId >= AreaCount)
        {
            return characterIds;
        }

        foreach (MapBlockData block in DomainManager.Map.GetAreaBlocks((short)areaId))
        {
            if (block.CharacterSet == null)
            {
                continue;
            }

            foreach (int characterId in block.CharacterSet)
            {
                characterIds.Add(characterId);
            }
        }

        return characterIds;
    }

    /// <summary>回放一组 NPC 月结行动前并行任务。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="action">原版 ICharacterParallelAction 实例。</param>
    /// <param name="characterIds">本次回放处理的角色 id 快照。</param>
    public static void ExecuteCharacterParallelActionChunk(
        DataContext context,
        ICharacterParallelAction action,
        IReadOnlyList<int>? characterIds)
    {
        if (characterIds == null)
        {
            return;
        }

        for (int i = 0; i < characterIds.Count; i++)
        {
            int characterId = characterIds[i];
            if (DomainManager.Character.TryGetElement_Objects(characterId, out var character) &&
                DomainManager.Character.IsCharacterAlive(characterId))
            {
                action.Execute(context, character);
            }
        }
    }

    /// <summary>回放破损地块倒计时更新，并将需要写回的 block 记录到 ParallelModificationsRecorder。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    /// <param name="blockStart">本 job 的 block 起点。</param>
    /// <param name="blockCount">本 job 的 block 数量。</param>
    public static void ExecuteMapBrokenBlockUpdate(
        DataContext context,
        int areaId,
        int blockStart,
        int blockCount)
    {
        if (areaId < 0 || areaId >= AreaCount || blockCount <= 0)
        {
            return;
        }

        Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks((short)areaId);
        int end = Math.Min(areaBlocks.Length, blockStart + blockCount);
        for (int i = Math.Max(0, blockStart); i < end; i++)
        {
            MapBlockData block = areaBlocks[i];
            if (block.CountDown())
            {
                context.ParallelModificationsRecorder.RecordType(ParallelModificationType.UpdateBrokenArea);
                context.ParallelModificationsRecorder.RecordParameterClass(block);
            }
        }
    }

    /// <summary>回放原版野生动物生态更新，一个 job 对应一个 area。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    public static void ExecuteAnimalAreaData(DataContext context, int areaId)
    {
        if (areaId < 0 || areaId >= AreaCount)
        {
            return;
        }

        short area = (short)areaId;
        if (DomainManager.Map.IsAreaBroken(area))
        {
            return;
        }

        List<int> attackableAnimals = ObjectPool<List<int>>.Instance.Get();
        try
        {
            attackableAnimals.Clear();
            if (DomainManager.Extra.TryGetAnimalAreaDataByAreaId(area, out Dictionary<short, List<int>>? animalAreaData))
            {
                foreach (List<int> animals in animalAreaData.Values)
                {
                    foreach (int animalId in animals)
                    {
                        if (DomainManager.Extra.TryGetAnimal(animalId, out GameData.Domains.Character.Animal animal) &&
                            DomainManager.Extra.IsAnimalAbleToAttack(animal, isTaiwuVictim: false))
                        {
                            attackableAnimals.Add(animalId);
                        }
                    }
                }
            }

            if (attackableAnimals.Count >= 12)
            {
                DomainManager.Extra.ApplyAnimalDeadByAccident(context, attackableAnimals.GetRandom(context.Random));
            }
            else if (TryGetRandomBlockForGeneratingAnimal(context, area, out short blockId))
            {
                short templateId = GetRandomAnimalForGeneratingAnimal(context);
                DomainManager.Extra.CreateAnimalByCharacterTemplateId(context, templateId, new Location(area, blockId));
            }
        }
        finally
        {
            ObjectPool<List<int>>.Instance.Return(attackableAnimals);
        }
    }

    /// <summary>同步执行整个 area 的坟墓骷髅生成。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    public static void ExecuteSkeletonGeneration(DataContext context, int areaId) =>
        ExecuteSkeletonGeneration(context, areaId, 0, int.MaxValue);

    /// <summary>回放坟墓骷髅生成任务块。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    /// <param name="blockStart">本 job 的 block 起点。</param>
    /// <param name="blockCount">本 job 的 block 数量。</param>
    public static void ExecuteSkeletonGeneration(DataContext context, int areaId, int blockStart, int blockCount)
    {
        if (areaId < 0 || areaId >= SkeletonAreaCount || blockCount <= 0)
        {
            return;
        }

        Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks((short)areaId);
        int end = Math.Min(areaBlocks.Length, blockStart + blockCount);
        for (int i = Math.Max(0, blockStart); i < end; i++)
        {
            MapBlockData block = areaBlocks[i];
            if (block.GetConfig().SubType != EMapBlockSubType.Ruin || block.GraveSet == null)
            {
                continue;
            }

            foreach (int graveId in block.GraveSet)
            {
                if (!DomainManager.Character.TryGetElement_Graves(graveId, out var grave))
                {
                    continue;
                }

                if (grave.GetSkeletonCharId() < 0 &&
                    context.Random.CheckPercentProb(50))
                {
                    DomainManager.Character.CreateSkeletonCharacter(context, grave);
                }
            }
        }
    }

    /// <summary>回放地图拾取物可见性刷新和状态清理。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    /// <param name="locations">可选的位置快照；为 null 时扫描整个 area。</param>
    public static void ExecuteMapPickupCleanup(
        DataContext context,
        int areaId,
        IReadOnlyList<Location>? locations = null)
    {
        if (areaId < 0)
        {
            return;
        }

        if (locations != null)
        {
            ExecuteMapPickupCleanupByLocations(context, areaId, locations);
            return;
        }

        List<(Location location, MapPickupCollection pickupCollection)> updates = new();
        foreach ((Location location, MapPickupCollection pickupCollection) in DomainManager.Extra.PickupDict)
        {
            if (location.AreaId != areaId)
            {
                continue;
            }

            RefreshPickupVisibleByResource(location, pickupCollection);
            pickupCollection.ClearIgnoredAndTriggered();
            updates.Add((location, pickupCollection));
        }

        foreach ((Location location, MapPickupCollection pickupCollection) in updates)
        {
            DomainManager.Extra.SetMapPickupCollection(context, location, pickupCollection);
        }
    }

    /// <summary>按月结时截取的位置列表回放拾取物清理。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    /// <param name="locations">月结时截取的拾取物位置。</param>
    private static void ExecuteMapPickupCleanupByLocations(
        DataContext context,
        int areaId,
        IReadOnlyList<Location> locations)
    {
        for (int i = 0; i < locations.Count; i++)
        {
            Location location = locations[i];
            if (location.AreaId != areaId ||
                !DomainManager.Extra.TryGetElement_PickupDict(location, out MapPickupCollection? pickupCollection))
            {
                continue;
            }

            RefreshPickupVisibleByResource(location, pickupCollection);
            pickupCollection.ClearIgnoredAndTriggered();
            DomainManager.Extra.SetMapPickupCollection(context, location, pickupCollection);
        }
    }

    /// <summary>调用原版非公开方法，取得可生成动物的随机 block。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    /// <param name="areaId">目标 area。</param>
    /// <param name="blockId">输出 block id。</param>
    private static bool TryGetRandomBlockForGeneratingAnimal(DataContext context, short areaId, out short blockId)
    {
        if (_tryGetRandomBlockForGeneratingAnimal == null)
        {
            throw new InvalidOperationException("Animal block generation method was not resolved.");
        }

        return _tryGetRandomBlockForGeneratingAnimal(DomainManager.Extra, context, areaId, false, out blockId);
    }

    /// <summary>调用原版非公开方法，取得随机动物 template id。</summary>
    /// <param name="context">当前游戏数据上下文。</param>
    private static short GetRandomAnimalForGeneratingAnimal(DataContext context)
    {
        if (_getRandomAnimalForGeneratingAnimal == null)
        {
            throw new InvalidOperationException("Animal template generation method was not resolved.");
        }

        return _getRandomAnimalForGeneratingAnimal(DomainManager.Extra, context);
    }

    /// <summary>按当前地块资源刷新拾取物可见性。</summary>
    /// <param name="location">拾取物位置。</param>
    /// <param name="pickupCollection">该位置的拾取物集合。</param>
    private static void RefreshPickupVisibleByResource(Location location, MapPickupCollection pickupCollection)
    {
        MapBlockData block = DomainManager.Map.GetBlock(location);
        var currResources = block.CurrResources;
        foreach (MapPickup pickup in pickupCollection.PickupList)
        {
            pickup.VisibleByResource = true;
            MapPickupsItem config = MapPickups.Instance[pickup.TemplateId];
            for (sbyte resourceType = 0; resourceType <= 5; resourceType++)
            {
                if (currResources.Get(resourceType) < config.Resources[resourceType])
                {
                    pickup.VisibleByResource = false;
                    break;
                }
            }
        }
    }
}
