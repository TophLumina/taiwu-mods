using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Map;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterActionTargetLookupCache
{
    private const int AreaCount = 141;

    private static readonly object SyncRoot = new();

    private static Snapshot? _frozenSnapshot;

    [ThreadStatic]
    private static int _offlineCurrentGoalActionScopeDepth;

    [ThreadStatic]
    private static ActionPlanningData.ECurrentGoalType _offlineGoalType;

    [ThreadStatic]
    private static Snapshot? _offlineTargetLookupSnapshot;

    [ThreadStatic]
    private static List<MapBlockData>? _blockRangeScratch;

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions` 阶段；目前只在主目标阶段使用缓存。</summary>
    /// <param name="goalType">原版当前处理的目标类型。</param>
    public static void EnterOfflineCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsEnabled())
        {
            _offlineTargetLookupSnapshot = null;
            return;
        }

        _offlineGoalType = goalType;
        _offlineCurrentGoalActionScopeDepth++;
        _offlineTargetLookupSnapshot = goalType == ActionPlanningData.ECurrentGoalType.Primary
            ? Volatile.Read(ref _frozenSnapshot)
            : null;
    }

    /// <summary>离开原版 `OfflineUpdateCurrentGoalActions` 阶段。</summary>
    public static void LeaveOfflineCurrentGoalActions()
    {
        if (_offlineCurrentGoalActionScopeDepth > 0)
        {
            _offlineCurrentGoalActionScopeDepth--;
            if (_offlineCurrentGoalActionScopeDepth == 0)
            {
                _offlineTargetLookupSnapshot = null;
            }
        }
        else
        {
            _offlineTargetLookupSnapshot = null;
        }
    }

    /// <summary>在 NPC 行动规划前同步全量生成并冻结目标索引。</summary>
    public static void RebuildAndFreezeBeforeAdvanceMonth()
    {
        if (!IsEnabled())
        {
            return;
        }

        lock (SyncRoot)
        {
            Volatile.Write(ref _frozenSnapshot, BuildFullSnapshot());
        }
    }

    /// <summary>过月结束后丢弃冻结快照；下一次过月前会重新全量生成。</summary>
    public static void UnfreezeAndInvalidate()
    {
        lock (SyncRoot)
        {
            Volatile.Write(ref _frozenSnapshot, null);
        }
    }

    /// <summary>退出世界、切档或设置变化时清理全部运行时缓存。</summary>
    public static void Reset()
    {
        lock (SyncRoot)
        {
            Volatile.Write(ref _frozenSnapshot, null);
        }

        _offlineCurrentGoalActionScopeDepth = 0;
        _offlineTargetLookupSnapshot = null;
    }

    /// <summary>尝试用冻结快照追加同一地块候选角色。</summary>
    public static bool TryAddCharactersInBlock(CharacterPlanningAgent agent, List<Character> characters, MapBlockData block)
    {
        if (!TryGetFrozenSnapshot(out Snapshot? snapshot))
        {
            return false;
        }

        return AddIndexedCharacters(agent, characters, snapshot!.GetBlockCharacterIds(block.AreaId, block.BlockId));
    }

    /// <summary>尝试用冻结快照追加同一地区候选角色。</summary>
    public static bool TryAddCharactersInArea(CharacterPlanningAgent agent, List<Character> characters, short areaId)
    {
        if (!TryGetFrozenSnapshot(out Snapshot? snapshot) || areaId < 0 || areaId >= snapshot!.AreaCharacterIds.Length)
        {
            return false;
        }

        return AddIndexedCharacters(agent, characters, snapshot.AreaCharacterIds[areaId]);
    }

    /// <summary>尝试用冻结快照追加同一州域候选角色。</summary>
    public static bool TryAddCharactersInState(CharacterPlanningAgent agent, List<Character> characters, sbyte stateId)
    {
        if (!TryGetFrozenSnapshot(out Snapshot? snapshot) ||
            !snapshot!.StateCharacterIds.TryGetValue(stateId, out int[]? characterIds))
        {
            return false;
        }

        return AddIndexedCharacters(agent, characters, characterIds);
    }

    /// <summary>尝试用冻结快照追加地块范围内候选角色。</summary>
    public static bool TryAddCharactersInBlockRange(
        CharacterPlanningAgent agent,
        List<Character> characters,
        Location location,
        int steps)
    {
        if (!TryGetFrozenSnapshot(out Snapshot? snapshot))
        {
            return false;
        }

        List<MapBlockData> blocks = _blockRangeScratch ??= new List<MapBlockData>(64);
        blocks.Clear();
        DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, blocks, steps, includeCenter: true);
        foreach (MapBlockData block in blocks)
        {
            AddIndexedCharacters(agent, characters, snapshot!.GetBlockCharacterIds(block.AreaId, block.BlockId));
        }

        blocks.Clear();
        return true;
    }

    /// <summary>尝试用冻结快照追加聚落范围内候选角色。</summary>
    public static bool TryAddCharactersInSettlementRange(
        CharacterPlanningAgent agent,
        List<Character> characters,
        Location settlementLocation)
    {
        if (!TryGetFrozenSnapshot(out Snapshot? snapshot))
        {
            return false;
        }

        int[] characterIds = snapshot!.GetSettlementCharacterIds(settlementLocation);
        return AddIndexedCharacters(agent, characters, characterIds);
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionTargetLookupCache;

    private static bool TryGetFrozenSnapshot(out Snapshot? snapshot)
    {
        snapshot = null;
        if (_offlineCurrentGoalActionScopeDepth <= 0 ||
            _offlineGoalType != ActionPlanningData.ECurrentGoalType.Primary)
        {
            return false;
        }

        snapshot = _offlineTargetLookupSnapshot;
        return snapshot != null;
    }

    private static Snapshot BuildFullSnapshot()
    {
        List<int>?[] areaBuilders = new List<int>?[AreaCount];
        Dictionary<int, int[]> blockCharacterIds = new(32768);
        Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
        HashSet<int>? taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();

        for (short areaId = 0; areaId < AreaCount; areaId++)
        {
            Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(areaId);
            foreach (MapBlockData block in blocks)
            {
                int[] blockIds = CollectBlockCharacters(block, taiwuLocation, taiwuGroup);
                blockCharacterIds[MakeBlockKey(block.AreaId, block.BlockId)] = blockIds;
                List<int> areaBuilder = areaBuilders[block.AreaId] ??= new List<int>(128);
                areaBuilder.AddRange(blockIds);
            }
        }

        int[][] areaCharacterIds = new int[AreaCount][];
        for (int areaId = 0; areaId < AreaCount; areaId++)
        {
            areaCharacterIds[areaId] = areaBuilders[areaId]?.ToArray() ?? Array.Empty<int>();
        }

        return new Snapshot(areaCharacterIds, BuildAllStateCharacterIds(areaCharacterIds), blockCharacterIds);
    }

    private static bool AddIndexedCharacters(CharacterPlanningAgent agent, List<Character> characters, int[] characterIds)
    {
        int selfId = agent.Object.GetId();
        characters.EnsureCapacity(characters.Count + characterIds.Length);
        foreach (int characterId in characterIds)
        {
            if (characterId == selfId)
            {
                continue;
            }

            if (DomainManager.Character.TryGetElement_Objects(characterId, out Character character))
            {
                characters.Add(character);
            }
        }

        return true;
    }

    private sealed class Snapshot
    {
        private readonly object _settlementSync = new();
        private readonly Dictionary<int, int[]> _blockCharacterIds;
        private readonly Dictionary<int, int[]> _settlementCharacterIds = new();

        public int[][] AreaCharacterIds { get; }
        public Dictionary<sbyte, int[]> StateCharacterIds { get; }

        public Snapshot(
            int[][] areaCharacterIds,
            Dictionary<sbyte, int[]> stateCharacterIds,
            Dictionary<int, int[]> blockCharacterIds)
        {
            AreaCharacterIds = areaCharacterIds;
            StateCharacterIds = stateCharacterIds;
            _blockCharacterIds = blockCharacterIds;
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
