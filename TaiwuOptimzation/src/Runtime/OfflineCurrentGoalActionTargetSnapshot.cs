using System;
using System.Collections.Generic;
using GameData.Domains;
using GameData.Domains.Map;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal sealed class OfflineCurrentGoalActionTargetSnapshot
{
    private const int AreaCount = 141;

    private readonly Dictionary<int, int[]> _blockCharacterIds;
    private readonly Dictionary<int, int[]> _settlementCharacterIds;

    public int LocationEpoch { get; }
    public int[][] AreaCharacterIds { get; }
    public Dictionary<sbyte, int[]> StateCharacterIds { get; }
    public int[] AllCharacterIds { get; }
    public OfflineCurrentGoalActionTargetRecord[] CharacterRecords { get; }

    private OfflineCurrentGoalActionTargetSnapshot(
        int locationEpoch,
        int[][] areaCharacterIds,
        Dictionary<sbyte, int[]> stateCharacterIds,
        Dictionary<int, int[]> blockCharacterIds,
        Dictionary<int, int[]> settlementCharacterIds,
        int[] allCharacterIds,
        OfflineCurrentGoalActionTargetRecord[] characterRecords)
    {
        LocationEpoch = locationEpoch;
        AreaCharacterIds = areaCharacterIds;
        StateCharacterIds = stateCharacterIds;
        _blockCharacterIds = blockCharacterIds;
        _settlementCharacterIds = settlementCharacterIds;
        AllCharacterIds = allCharacterIds;
        CharacterRecords = characterRecords;
    }

    /// <summary>在 NPC 规划屏障前一次性扫描角色位置，并产出后续子缓存共享的快照根。</summary>
    public static OfflineCurrentGoalActionTargetSnapshot Build(int locationEpoch)
    {
        List<int>?[] areaBuilders = new List<int>?[AreaCount];
        Dictionary<int, int[]> blockCharacterIds = new(32768);
        HashSet<int> allCharacterIds = new(8192);
        Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
        HashSet<int>? taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
        int totalCharacterIds = 0;

        for (short areaId = 0; areaId < AreaCount; areaId++)
        {
            Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
            foreach (MapBlockData block in blocks)
            {
                int[] blockIds = CollectBlockCharacters(block, taiwuLocation, taiwuGroup);
                totalCharacterIds += blockIds.Length;
                blockCharacterIds[MakeBlockKey(block.AreaId, block.BlockId)] = blockIds;
                List<int> areaBuilder = areaBuilders[block.AreaId] ??= new List<int>(128);
                areaBuilder.AddRange(blockIds);
                foreach (int characterId in blockIds)
                {
                    allCharacterIds.Add(characterId);
                }
            }
        }

        int[][] areaCharacterIds = new int[AreaCount][];
        for (int areaId = 0; areaId < AreaCount; areaId++)
        {
            areaCharacterIds[areaId] = areaBuilders[areaId]?.ToArray() ?? Array.Empty<int>();
        }

        Dictionary<sbyte, int[]> stateCharacterIds = BuildAllStateCharacterIds(areaCharacterIds);
        Dictionary<int, int[]> settlementCharacterIds = BuildSettlementCharacterIds(blockCharacterIds);
        int[] allCharacterIdArray = new int[allCharacterIds.Count];
        allCharacterIds.CopyTo(allCharacterIdArray);
        OfflineCurrentGoalActionTargetRecord[] characterRecords = BuildCharacterRecords(allCharacterIdArray);

        CharacterActionPlanningDiagnostics.RecordTargetLookupSnapshotSize(
            blockCharacterIds.Count,
            areaCharacterIds.Length,
            stateCharacterIds.Count,
            totalCharacterIds);
        return new OfflineCurrentGoalActionTargetSnapshot(
            locationEpoch,
            areaCharacterIds,
            stateCharacterIds,
            blockCharacterIds,
            settlementCharacterIds,
            allCharacterIdArray,
            characterRecords);
    }

    /// <summary>根据 primary ApplyAll 产生的位置变更，只重建受影响的 block/area/state/settlement 索引。</summary>
    /// <param name="deltas">串行 ApplyAll 中记录的角色位置变更。</param>
    /// <param name="affectedBlockLimit">超过此 block 数量时回退全量重建。</param>
    /// <param name="affectedAreaLimit">超过此 area 数量时回退全量重建。</param>
    public OfflineCurrentGoalActionTargetSnapshot ApplyLocationDeltas(
        IReadOnlyList<OfflineCurrentGoalActionLocationDelta> deltas,
        int affectedBlockLimit,
        int affectedAreaLimit,
        out OfflineCurrentGoalActionTargetDeltaApplyStats stats)
    {
        if (deltas.Count == 0)
        {
            stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Success(0, 0, 0, 0, 0);
            return this;
        }

        HashSet<int> affectedBlockKeys = new(deltas.Count * 2);
        HashSet<short> affectedAreaIds = new();
        HashSet<sbyte> affectedStateIds = new();
        HashSet<int> affectedSettlementKeys = new();
        bool rebuildCharacterRecords = false;
        foreach (OfflineCurrentGoalActionLocationDelta delta in deltas)
        {
            bool oldLocationValid = delta.OldLocation.IsValid();
            bool newLocationValid = delta.NewLocation.IsValid();
            rebuildCharacterRecords |= oldLocationValid != newLocationValid;
            if (!TryAddAffectedLocation(
                    delta.OldLocation,
                    affectedBlockKeys,
                    affectedAreaIds,
                    affectedStateIds,
                    affectedSettlementKeys) ||
                !TryAddAffectedLocation(
                    delta.NewLocation,
                    affectedBlockKeys,
                    affectedAreaIds,
                    affectedStateIds,
                    affectedSettlementKeys))
            {
                stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Fallback(
                    deltas.Count,
                    affectedBlockKeys.Count,
                    affectedAreaIds.Count,
                    affectedStateIds.Count,
                    affectedSettlementKeys.Count,
                    OfflineCurrentGoalActionTargetDeltaFallbackReason.InvalidLocation);
                return Build(LocationEpoch);
            }

            if (affectedBlockKeys.Count > affectedBlockLimit || affectedAreaIds.Count > affectedAreaLimit)
            {
                stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Fallback(
                    deltas.Count,
                    affectedBlockKeys.Count,
                    affectedAreaIds.Count,
                    affectedStateIds.Count,
                    affectedSettlementKeys.Count,
                    OfflineCurrentGoalActionTargetDeltaFallbackReason.AffectedLimit);
                return Build(LocationEpoch);
            }
        }

        Dictionary<int, int[]> blockCharacterIds = new(_blockCharacterIds);
        foreach (int blockKey in affectedBlockKeys)
        {
            short areaId = GetAreaId(blockKey);
            short blockId = GetBlockId(blockKey);
            if (DomainManager.Map.TryGetBlock(new Location(areaId, blockId), out MapBlockData block))
            {
                Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
                HashSet<int>? taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
                blockCharacterIds[blockKey] = CollectBlockCharacters(block, taiwuLocation, taiwuGroup);
            }
            else
            {
                stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Fallback(
                    deltas.Count,
                    affectedBlockKeys.Count,
                    affectedAreaIds.Count,
                    affectedStateIds.Count,
                    affectedSettlementKeys.Count,
                    OfflineCurrentGoalActionTargetDeltaFallbackReason.InvalidBlock);
                return Build(LocationEpoch);
            }
        }

        int[][] areaCharacterIds = (int[][])AreaCharacterIds.Clone();
        foreach (short areaId in affectedAreaIds)
        {
            if (areaId < 0 || areaId >= AreaCount)
            {
                stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Fallback(
                    deltas.Count,
                    affectedBlockKeys.Count,
                    affectedAreaIds.Count,
                    affectedStateIds.Count,
                    affectedSettlementKeys.Count,
                    OfflineCurrentGoalActionTargetDeltaFallbackReason.InvalidArea);
                return Build(LocationEpoch);
            }

            areaCharacterIds[areaId] = BuildAreaCharacterIds(blockCharacterIds, areaId);
        }

        Dictionary<sbyte, int[]> stateCharacterIds = new(StateCharacterIds);
        foreach (sbyte stateId in affectedStateIds)
        {
            stateCharacterIds[stateId] = BuildStateCharacterIds(areaCharacterIds, stateId);
        }

        Dictionary<int, int[]> settlementCharacterIds = new(_settlementCharacterIds);
        foreach (int settlementKey in affectedSettlementKeys)
        {
            if (DomainManager.Map.TryGetBlock(
                    new Location(GetAreaId(settlementKey), GetBlockId(settlementKey)),
                    out MapBlockData rootBlock))
            {
                settlementCharacterIds[settlementKey] =
                    BuildSettlementCharacterIdsForRootBlock(blockCharacterIds, rootBlock.GetRootBlock());
            }
            else
            {
                stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Fallback(
                    deltas.Count,
                    affectedBlockKeys.Count,
                    affectedAreaIds.Count,
                    affectedStateIds.Count,
                    affectedSettlementKeys.Count,
                    OfflineCurrentGoalActionTargetDeltaFallbackReason.InvalidSettlementRoot);
                return Build(LocationEpoch);
            }
        }

        stats = OfflineCurrentGoalActionTargetDeltaApplyStats.Success(
            deltas.Count,
            affectedBlockKeys.Count,
            affectedAreaIds.Count,
            affectedStateIds.Count,
            affectedSettlementKeys.Count);
        int[] allCharacterIds = AllCharacterIds;
        OfflineCurrentGoalActionTargetRecord[] characterRecords = CharacterRecords;
        if (rebuildCharacterRecords)
        {
            allCharacterIds = BuildAllCharacterIds(areaCharacterIds);
            characterRecords = BuildCharacterRecords(allCharacterIds);
        }

        return new OfflineCurrentGoalActionTargetSnapshot(
            LocationEpoch,
            areaCharacterIds,
            stateCharacterIds,
            blockCharacterIds,
            settlementCharacterIds,
            allCharacterIds,
            characterRecords);
    }

    public int[] GetBlockCharacterIds(short areaId, short blockId) =>
        _blockCharacterIds.TryGetValue(MakeBlockKey(areaId, blockId), out int[]? characterIds)
            ? characterIds
            : Array.Empty<int>();

    public int[] GetSettlementCharacterIds(Location settlementLocation) =>
        _settlementCharacterIds.TryGetValue(
            MakeBlockKey(settlementLocation.AreaId, settlementLocation.BlockId),
            out int[]? characterIds)
            ? characterIds
            : Array.Empty<int>();

    private static OfflineCurrentGoalActionTargetRecord[] BuildCharacterRecords(int[] characterIds)
    {
        List<OfflineCurrentGoalActionTargetRecord> records = new(characterIds.Length);
        foreach (int characterId in characterIds)
        {
            if (DomainManager.Character.TryGetElement_Objects(characterId, out Character character))
            {
                records.Add(new OfflineCurrentGoalActionTargetRecord(characterId, character));
            }
        }

        return records.ToArray();
    }

    private static Dictionary<sbyte, int[]> BuildAllStateCharacterIds(int[][] areaCharacterIds)
    {
        List<sbyte> stateIds = CreateAllStateIds();
        Dictionary<sbyte, int[]> stateCharacterIds = new(stateIds.Count);
        foreach (sbyte stateId in stateIds)
        {
            stateCharacterIds[stateId] = BuildStateCharacterIds(areaCharacterIds, stateId);
        }

        return stateCharacterIds;
    }

    private static Dictionary<int, int[]> BuildSettlementCharacterIds(Dictionary<int, int[]> blockCharacterIds)
    {
        Dictionary<int, int[]> settlementCharacterIds = new(blockCharacterIds.Count);
        for (short areaId = 0; areaId < AreaCount; areaId++)
        {
            Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
            foreach (MapBlockData block in blocks)
            {
                int key = MakeBlockKey(block.AreaId, block.BlockId);
                List<MapBlockData>? groupBlocks = block.GroupBlockList;
                if (groupBlocks == null || groupBlocks.Count == 0)
                {
                    settlementCharacterIds[key] = blockCharacterIds.TryGetValue(key, out int[]? ownCharacters)
                        ? ownCharacters
                        : Array.Empty<int>();
                    continue;
                }

                int totalCount = blockCharacterIds.TryGetValue(key, out int[]? rootCharacters)
                    ? rootCharacters.Length
                    : 0;
                foreach (MapBlockData groupBlock in groupBlocks)
                {
                    if (blockCharacterIds.TryGetValue(
                            MakeBlockKey(groupBlock.AreaId, groupBlock.BlockId),
                            out int[]? groupCharacters))
                    {
                        totalCount += groupCharacters.Length;
                    }
                }

                if (totalCount == 0)
                {
                    settlementCharacterIds[key] = Array.Empty<int>();
                    continue;
                }

                int[] settlementCharacters = new int[totalCount];
                int index = 0;
                if (rootCharacters != null)
                {
                    Array.Copy(rootCharacters, 0, settlementCharacters, index, rootCharacters.Length);
                    index += rootCharacters.Length;
                }

                foreach (MapBlockData groupBlock in groupBlocks)
                {
                    if (blockCharacterIds.TryGetValue(
                            MakeBlockKey(groupBlock.AreaId, groupBlock.BlockId),
                            out int[]? groupCharacters))
                    {
                        Array.Copy(groupCharacters, 0, settlementCharacters, index, groupCharacters.Length);
                        index += groupCharacters.Length;
                    }
                }

                settlementCharacterIds[key] = settlementCharacters;
            }
        }

        return settlementCharacterIds;
    }

    private static int[] BuildSettlementCharacterIdsForRootBlock(
        Dictionary<int, int[]> blockCharacterIds,
        MapBlockData rootBlock)
    {
        int rootKey = MakeBlockKey(rootBlock.AreaId, rootBlock.BlockId);
        List<MapBlockData>? groupBlocks = rootBlock.GroupBlockList;
        if (groupBlocks == null || groupBlocks.Count == 0)
        {
            return blockCharacterIds.TryGetValue(rootKey, out int[]? ownCharacters)
                ? ownCharacters
                : Array.Empty<int>();
        }

        int totalCount = blockCharacterIds.TryGetValue(rootKey, out int[]? rootCharacters)
            ? rootCharacters.Length
            : 0;
        foreach (MapBlockData groupBlock in groupBlocks)
        {
            if (blockCharacterIds.TryGetValue(
                    MakeBlockKey(groupBlock.AreaId, groupBlock.BlockId),
                    out int[]? groupCharacters))
            {
                totalCount += groupCharacters.Length;
            }
        }

        if (totalCount == 0)
        {
            return Array.Empty<int>();
        }

        int[] settlementCharacters = new int[totalCount];
        int index = 0;
        if (rootCharacters != null)
        {
            Array.Copy(rootCharacters, 0, settlementCharacters, index, rootCharacters.Length);
            index += rootCharacters.Length;
        }

        foreach (MapBlockData groupBlock in groupBlocks)
        {
            if (blockCharacterIds.TryGetValue(
                    MakeBlockKey(groupBlock.AreaId, groupBlock.BlockId),
                    out int[]? groupCharacters))
            {
                Array.Copy(groupCharacters, 0, settlementCharacters, index, groupCharacters.Length);
                index += groupCharacters.Length;
            }
        }

        return settlementCharacters;
    }

    private static List<sbyte> CreateAllStateIds()
    {
        List<sbyte> stateIds = new(16);
        for (short areaId = 0; areaId < AreaCount; areaId++)
        {
            sbyte stateId = DomainManager.Map.GetStateIdByAreaId(areaId);
            if (!stateIds.Contains(stateId))
            {
                stateIds.Add(stateId);
            }
        }

        return stateIds;
    }

    private static int[] CollectBlockCharacters(
        MapBlockData block,
        Location taiwuLocation,
        HashSet<int>? taiwuGroup)
    {
        bool includeTaiwuGroup = taiwuGroup != null &&
            taiwuLocation.AreaId == block.AreaId &&
            taiwuLocation.BlockId == block.BlockId;
        int groupCount = includeTaiwuGroup ? taiwuGroup!.Count : 0;
        int blockCharacterCount = block.CharacterSet?.Count ?? 0;
        int totalCount = groupCount + blockCharacterCount;
        if (totalCount == 0)
        {
            return Array.Empty<int>();
        }

        int[] characterIds = new int[totalCount];
        int index = 0;
        if (includeTaiwuGroup)
        {
            foreach (int groupMemberId in taiwuGroup!)
            {
                characterIds[index++] = groupMemberId;
            }
        }

        if (block.CharacterSet != null)
        {
            foreach (int characterId in block.CharacterSet)
            {
                characterIds[index++] = characterId;
            }
        }

        return characterIds;
    }

    private static int[] BuildStateCharacterIds(int[][] areaCharacterIds, sbyte stateId)
    {
        List<int> stateCharacters = new(1024);
        for (short areaId = 0; areaId < areaCharacterIds.Length; areaId++)
        {
            if (DomainManager.Map.GetStateIdByAreaId(areaId) == stateId)
            {
                stateCharacters.AddRange(areaCharacterIds[areaId]);
            }
        }

        return stateCharacters.ToArray();
    }

    private static int[] BuildAreaCharacterIds(Dictionary<int, int[]> blockCharacterIds, short areaId)
    {
        Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
        int totalCount = 0;
        foreach (MapBlockData block in blocks)
        {
            if (blockCharacterIds.TryGetValue(MakeBlockKey(block.AreaId, block.BlockId), out int[]? blockCharacters))
            {
                totalCount += blockCharacters.Length;
            }
        }

        if (totalCount == 0)
        {
            return Array.Empty<int>();
        }

        int[] areaCharacters = new int[totalCount];
        int index = 0;
        foreach (MapBlockData block in blocks)
        {
            if (blockCharacterIds.TryGetValue(MakeBlockKey(block.AreaId, block.BlockId), out int[]? blockCharacters))
            {
                Array.Copy(blockCharacters, 0, areaCharacters, index, blockCharacters.Length);
                index += blockCharacters.Length;
            }
        }

        return areaCharacters;
    }

    private static bool TryAddAffectedLocation(
        Location location,
        HashSet<int> blockKeys,
        HashSet<short> areaIds,
        HashSet<sbyte> stateIds,
        HashSet<int> settlementKeys)
    {
        if (!location.IsValid())
        {
            return true;
        }

        if (!DomainManager.Map.TryGetBlock(location, out MapBlockData block))
        {
            return false;
        }

        blockKeys.Add(MakeBlockKey(block.AreaId, block.BlockId));
        areaIds.Add(block.AreaId);
        stateIds.Add(DomainManager.Map.GetStateIdByAreaId(block.AreaId));
        MapBlockData rootBlock = block.GetRootBlock();
        settlementKeys.Add(MakeBlockKey(rootBlock.AreaId, rootBlock.BlockId));
        return true;
    }

    private static int[] BuildAllCharacterIds(int[][] areaCharacterIds)
    {
        HashSet<int> allCharacterIds = new(8192);
        foreach (int[] areaCharacterIdArray in areaCharacterIds)
        {
            foreach (int characterId in areaCharacterIdArray)
            {
                allCharacterIds.Add(characterId);
            }
        }

        int[] characterIds = new int[allCharacterIds.Count];
        allCharacterIds.CopyTo(characterIds);
        return characterIds;
    }

    private static short GetAreaId(int blockKey) =>
        (short)(blockKey >> 16);

    private static short GetBlockId(int blockKey) =>
        (short)(blockKey & 0xffff);

    private static int MakeBlockKey(short areaId, short blockId) =>
        (areaId << 16) ^ (ushort)blockId;
}

internal readonly struct OfflineCurrentGoalActionLocationDelta
{
    public readonly int CharId;
    public readonly Location OldLocation;
    public readonly Location NewLocation;

    public OfflineCurrentGoalActionLocationDelta(int charId, Location oldLocation, Location newLocation)
    {
        CharId = charId;
        OldLocation = oldLocation;
        NewLocation = newLocation;
    }
}

internal enum OfflineCurrentGoalActionTargetDeltaFallbackReason
{
    None,
    InvalidLocation,
    AffectedLimit,
    InvalidBlock,
    InvalidArea,
    InvalidSettlementRoot,
}

internal readonly struct OfflineCurrentGoalActionTargetDeltaApplyStats
{
    public readonly int DeltaCount;
    public readonly int AffectedBlockCount;
    public readonly int AffectedAreaCount;
    public readonly int AffectedStateCount;
    public readonly int AffectedSettlementCount;
    public readonly bool FullRebuild;
    public readonly OfflineCurrentGoalActionTargetDeltaFallbackReason FallbackReason;

    private OfflineCurrentGoalActionTargetDeltaApplyStats(
        int deltaCount,
        int affectedBlockCount,
        int affectedAreaCount,
        int affectedStateCount,
        int affectedSettlementCount,
        bool fullRebuild,
        OfflineCurrentGoalActionTargetDeltaFallbackReason fallbackReason)
    {
        DeltaCount = deltaCount;
        AffectedBlockCount = affectedBlockCount;
        AffectedAreaCount = affectedAreaCount;
        AffectedStateCount = affectedStateCount;
        AffectedSettlementCount = affectedSettlementCount;
        FullRebuild = fullRebuild;
        FallbackReason = fallbackReason;
    }

    public static OfflineCurrentGoalActionTargetDeltaApplyStats Success(
        int deltaCount,
        int affectedBlockCount,
        int affectedAreaCount,
        int affectedStateCount,
        int affectedSettlementCount) =>
        new(
            deltaCount,
            affectedBlockCount,
            affectedAreaCount,
            affectedStateCount,
            affectedSettlementCount,
            fullRebuild: false,
            OfflineCurrentGoalActionTargetDeltaFallbackReason.None);

    public static OfflineCurrentGoalActionTargetDeltaApplyStats Fallback(
        int deltaCount,
        int affectedBlockCount,
        int affectedAreaCount,
        int affectedStateCount,
        int affectedSettlementCount,
        OfflineCurrentGoalActionTargetDeltaFallbackReason reason) =>
        new(
            deltaCount,
            affectedBlockCount,
            affectedAreaCount,
            affectedStateCount,
            affectedSettlementCount,
            fullRebuild: true,
            reason);
}

internal readonly struct OfflineCurrentGoalActionTargetRecord
{
    public readonly int CharId;
    public readonly Character Character;

    public OfflineCurrentGoalActionTargetRecord(int charId, Character character)
    {
        CharId = charId;
        Character = character;
    }
}
