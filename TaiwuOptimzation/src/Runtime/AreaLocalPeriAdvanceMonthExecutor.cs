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

    private delegate bool TryGetRandomBlockForGeneratingAnimalDelegate(
        ExtraDomain domain,
        DataContext context,
        short areaId,
        bool isTaiwuSkill,
        out short blockId);

    private delegate short GetRandomAnimalForGeneratingAnimalDelegate(ExtraDomain domain, DataContext context);

    private static TryGetRandomBlockForGeneratingAnimalDelegate? _tryGetRandomBlockForGeneratingAnimal;
    private static GetRandomAnimalForGeneratingAnimalDelegate? _getRandomAnimalForGeneratingAnimal;

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

    public static void ExecuteCharacterParallelActionChunk(
        DataContext context,
        ICharacterParallelAction action,
        IReadOnlyList<int>? characterIds)
    {
        if (characterIds == null)
        {
            return;
        }

        foreach (int characterId in characterIds)
        {
            if (DomainManager.Character.TryGetElement_Objects(characterId, out var character))
            {
                action.Execute(context, character);
            }
        }
    }

    public static void ExecuteMapBrokenBlockUpdate(
        DataContext context,
        int areaId,
        int blockStart,
        int blockCount)
    {
        if (areaId < 0 || blockCount <= 0)
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

    public static void ExecuteSkeletonGeneration(DataContext context, int areaId) =>
        ExecuteSkeletonGeneration(context, areaId, 0, int.MaxValue);

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
                var grave = DomainManager.Character.GetElement_Graves(graveId);
                if (grave.GetSkeletonCharId() < 0 &&
                    context.Random.CheckPercentProb(50))
                {
                    DomainManager.Character.CreateSkeletonCharacter(context, grave);
                }
            }
        }
    }

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

    private static void ExecuteMapPickupCleanupByLocations(
        DataContext context,
        int areaId,
        IReadOnlyList<Location> locations)
    {
        foreach (Location location in locations)
        {
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

    private static bool TryGetRandomBlockForGeneratingAnimal(DataContext context, short areaId, out short blockId)
    {
        if (_tryGetRandomBlockForGeneratingAnimal == null)
        {
            throw new InvalidOperationException("Animal block generation method was not resolved.");
        }

        return _tryGetRandomBlockForGeneratingAnimal(DomainManager.Extra, context, areaId, false, out blockId);
    }

    private static short GetRandomAnimalForGeneratingAnimal(DataContext context)
    {
        if (_getRandomAnimalForGeneratingAnimal == null)
        {
            throw new InvalidOperationException("Animal template generation method was not resolved.");
        }

        return _getRandomAnimalForGeneratingAnimal(DomainManager.Extra, context);
    }

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
