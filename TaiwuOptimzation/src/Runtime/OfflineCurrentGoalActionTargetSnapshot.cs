using System;
using System.Collections.Generic;
using GameData.Domains;
using GameData.Domains.Map;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal sealed class OfflineCurrentGoalActionTargetSnapshot
{
    private const int AreaCount = 141;

    private readonly object _settlementSync = new();
    private readonly Dictionary<int, int[]> _blockCharacterIds;
    private readonly Dictionary<int, int[]> _settlementCharacterIds = new();

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
        int[] allCharacterIds,
        OfflineCurrentGoalActionTargetRecord[] characterRecords)
    {
        LocationEpoch = locationEpoch;
        AreaCharacterIds = areaCharacterIds;
        StateCharacterIds = stateCharacterIds;
        _blockCharacterIds = blockCharacterIds;
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
            allCharacterIdArray,
            characterRecords);
    }

    public int[] GetBlockCharacterIds(short areaId, short blockId) =>
        _blockCharacterIds.TryGetValue(MakeBlockKey(areaId, blockId), out int[]? characterIds)
            ? characterIds
            : Array.Empty<int>();

    public int[] GetSettlementCharacterIds(Location settlementLocation)
    {
        int key = MakeBlockKey(settlementLocation.AreaId, settlementLocation.BlockId);
        lock (_settlementSync)
        {
            if (_settlementCharacterIds.TryGetValue(key, out int[]? cached))
            {
                return cached;
            }

            List<short> blockIds = new(32);
            List<int> characters = new(128);
            DomainManager.Map.GetSettlementBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockIds);
            foreach (short blockId in blockIds)
            {
                characters.AddRange(GetBlockCharacterIds(settlementLocation.AreaId, blockId));
            }

            int[] result = characters.ToArray();
            _settlementCharacterIds[key] = result;
            return result;
        }
    }

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

    private static int MakeBlockKey(short areaId, short blockId) =>
        (areaId << 16) ^ (ushort)blockId;
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
