using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Domains;
using GameData.Domains.Map;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class OfflineUpdateCurrentGoalActionsTargetLookupCache
{
    private const int IncrementalLocationDeltaLimit = short.MaxValue;
    private const int IncrementalAffectedBlockLimit = short.MaxValue;
    private const int IncrementalAffectedAreaLimit = 128;

    private static readonly object SyncRoot = new();

    private static OfflineUpdateCurrentGoalActionsTargetSnapshot? _frozenSnapshot;
    private static int _locationEpoch;
    private static volatile bool _offlineUpdateCurrentGoalActionsStageActive;
    private static bool _collectSerialApplyAllLocationDeltas;
    private static bool _serialApplyAllStageActive;
    private static bool _forceRebuildAfterSerialApplyAll;
    private static OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason _forceRebuildAfterSerialApplyAllReason =
        OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.SerialApplyAllForced;
    private static readonly List<OfflineUpdateCurrentGoalActionsLocationDelta> SerialApplyAllLocationDeltas = new(128);
    private static readonly HashSet<int> SerialApplyAllAffectedBlockKeys = new();
    private static readonly HashSet<short> SerialApplyAllAffectedAreaIds = new();
    private static int _serialApplyAllRecordedDeltaCount;
    private static int _serialApplyAllSavedDeltaCount;
    private static int _serialApplyAllOverflowCount;

    [ThreadStatic]
    private static int _offlineUpdateCurrentGoalActionsScopeDepth;

    [ThreadStatic]
    private static OfflineUpdateCurrentGoalActionsTargetSnapshot? _offlineTargetLookupSnapshot;

    [ThreadStatic]
    private static List<MapBlockData>? _blockRangeScratch;

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions` 阶段；主/副目标阶段共用同一份冻结索引。</summary>
    /// <param name="goalType">原版当前处理的目标类型。</param>
    public static void EnterOfflineUpdateCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsEnabled())
        {
            _offlineTargetLookupSnapshot = null;
            return;
        }

        _offlineUpdateCurrentGoalActionsScopeDepth++;
        _offlineTargetLookupSnapshot = Volatile.Read(ref _frozenSnapshot);
    }

    /// <summary>离开原版 `OfflineUpdateCurrentGoalActions` 阶段。</summary>
    public static void LeaveOfflineUpdateCurrentGoalActions()
    {
        if (_offlineUpdateCurrentGoalActionsScopeDepth > 0)
        {
            _offlineUpdateCurrentGoalActionsScopeDepth--;
            if (_offlineUpdateCurrentGoalActionsScopeDepth == 0)
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
    public static void EnsureFrozenBeforeUpdateCurrentGoalActions()
    {
        if (!IsEnabled())
        {
            _offlineUpdateCurrentGoalActionsStageActive = false;
            UnfreezeAndInvalidate();
            return;
        }

        _offlineUpdateCurrentGoalActionsStageActive = true;
        int locationEpoch = Volatile.Read(ref _locationEpoch);
        OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot = Volatile.Read(ref _frozenSnapshot);
        if (snapshot != null && snapshot.LocationEpoch == locationEpoch)
        {
            PublishSerialApplyAllLocationDeltas(snapshot);
            return;
        }

        lock (SyncRoot)
        {
            locationEpoch = Volatile.Read(ref _locationEpoch);
            snapshot = Volatile.Read(ref _frozenSnapshot);
            if (snapshot == null || snapshot.LocationEpoch != locationEpoch)
            {
                Volatile.Write(
                    ref _frozenSnapshot,
                    BuildSnapshot(
                        locationEpoch,
                        snapshot == null
                            ? OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.InitialSnapshot
                            : OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.EpochMismatch));
                SerialApplyAllLocationDeltas.Clear();
                ResetSerialApplyAllDeltaStats();
                _forceRebuildAfterSerialApplyAll = false;
                _forceRebuildAfterSerialApplyAllReason =
                    OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.SerialApplyAllForced;
            }
            else
            {
                PublishSerialApplyAllLocationDeltas(snapshot);
            }
        }
    }

    /// <summary>角色位置变化只推进版本号；下一次规划阶段入口再决定是否重建索引。</summary>
    /// <summary>离开原版 `UpdatePrimary/SecondaryGoalAndActions` 屏障。</summary>
    public static void EndOfflineUpdateCurrentGoalActionsStage() =>
        _offlineUpdateCurrentGoalActionsStageActive = false;

    /// <summary>角色位置变化：planning 屏障内只记录警告，屏障外才推进下轮索引版本。</summary>
    public static void NotifyCharacterLocationChanged(int charId)
    {
        if (_offlineUpdateCurrentGoalActionsStageActive && Volatile.Read(ref _frozenSnapshot) != null)
        {
            if (CharacterActionPlanningDiagnostics.IsRecording)
            {
                CharacterActionPlanningDiagnostics.RecordFrozenTargetLookupLocationChange(charId);
            }

            return;
        }

        IncrementLocationEpoch(
            OfflineUpdateCurrentGoalActionsLocationEpochIncrementReason.LocationChangedWithoutLocation,
            charId,
            hasLocation: false,
            default,
            default);
    }

    /// <summary>返回当前 planning 阶段共享快照；关系和物品预过滤在同一构建屏障内复用它。</summary>
    /// <summary>进入串行 ApplyAll；primary 记录位置 delta，secondary 只关闭读取屏障。</summary>
    public static void BeginSerialApplyAllDeltaRecording(bool collectDeltas)
    {
        _serialApplyAllStageActive = true;
        _collectSerialApplyAllLocationDeltas = collectDeltas && Volatile.Read(ref _frozenSnapshot) != null;
        if (_collectSerialApplyAllLocationDeltas)
        {
            SerialApplyAllLocationDeltas.Clear();
            ResetSerialApplyAllDeltaStats();
            _forceRebuildAfterSerialApplyAll = false;
            _forceRebuildAfterSerialApplyAllReason =
                OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.SerialApplyAllForced;
        }
    }

    /// <summary>离开串行 ApplyAll；delta 会在下一次 planning 入口统一发布。</summary>
    public static void EndSerialApplyAllDeltaRecording()
    {
        if (_collectSerialApplyAllLocationDeltas)
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookupPrimaryApplyAllDeltas(
                _serialApplyAllRecordedDeltaCount,
                _serialApplyAllSavedDeltaCount,
                SerialApplyAllAffectedBlockKeys.Count,
                SerialApplyAllAffectedAreaIds.Count,
                _serialApplyAllOverflowCount);
        }

        _serialApplyAllStageActive = false;
        _collectSerialApplyAllLocationDeltas = false;
    }

    /// <summary>记录角色位置变更；primary ApplyAll 内尽量收集局部 delta，其他时机推进全量 epoch。</summary>
    public static void NotifyCharacterLocationChanged(int charId, Location oldLocation, Location newLocation)
    {
        if (oldLocation.AreaId == newLocation.AreaId && oldLocation.BlockId == newLocation.BlockId)
        {
            return;
        }

        if (_offlineUpdateCurrentGoalActionsStageActive && Volatile.Read(ref _frozenSnapshot) != null)
        {
            if (CharacterActionPlanningDiagnostics.IsRecording)
            {
                CharacterActionPlanningDiagnostics.RecordFrozenTargetLookupLocationChange(charId);
            }

            return;
        }

        if (_collectSerialApplyAllLocationDeltas)
        {
            _serialApplyAllRecordedDeltaCount++;

            if (!TryRecordSerialApplyAllAffectedLocation(oldLocation) ||
                !TryRecordSerialApplyAllAffectedLocation(newLocation))
            {
                ForceSerialApplyAllFullRebuild(
                    OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.DeltaInvalidLocation,
                    OfflineUpdateCurrentGoalActionsLocationEpochIncrementReason.DeltaInvalidLocation,
                    charId,
                    oldLocation,
                    newLocation);
                return;
            }

            if (_forceRebuildAfterSerialApplyAll)
            {
                return;
            }

            if (SerialApplyAllLocationDeltas.Count >= IncrementalLocationDeltaLimit)
            {
                _serialApplyAllOverflowCount++;
                ForceSerialApplyAllFullRebuild(
                    OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.DeltaAffectedLimit,
                    OfflineUpdateCurrentGoalActionsLocationEpochIncrementReason.DeltaLimit,
                    charId,
                    oldLocation,
                    newLocation);
                return;
            }

            SerialApplyAllLocationDeltas.Add(
                new OfflineUpdateCurrentGoalActionsLocationDelta(charId, oldLocation, newLocation));
            _serialApplyAllSavedDeltaCount++;
            return;
        }

        IncrementLocationEpoch(
            OfflineUpdateCurrentGoalActionsLocationEpochIncrementReason.LocationChangedOutsideDeltaRecording,
            charId,
            hasLocation: true,
            oldLocation,
            newLocation);
    }

    public static bool TryGetFrozenPlanningSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot snapshot)
    {
        snapshot = Volatile.Read(ref _frozenSnapshot)!;
        return snapshot != null;
    }

    /// <summary>过月结束后丢弃冻结快照；下一次过月前会重新全量生成。</summary>
    public static void UnfreezeAndInvalidate()
    {
        lock (SyncRoot)
        {
            _offlineUpdateCurrentGoalActionsStageActive = false;
            _collectSerialApplyAllLocationDeltas = false;
            _serialApplyAllStageActive = false;
            _forceRebuildAfterSerialApplyAll = false;
            _forceRebuildAfterSerialApplyAllReason =
                OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.SerialApplyAllForced;
            SerialApplyAllLocationDeltas.Clear();
            ResetSerialApplyAllDeltaStats();
            Volatile.Write(ref _frozenSnapshot, null);
        }
    }

    /// <summary>退出世界、切档或设置变化时清理全部运行时缓存。</summary>
    public static void Reset()
    {
        lock (SyncRoot)
        {
            _offlineUpdateCurrentGoalActionsStageActive = false;
            _collectSerialApplyAllLocationDeltas = false;
            _serialApplyAllStageActive = false;
            _forceRebuildAfterSerialApplyAll = false;
            _forceRebuildAfterSerialApplyAllReason =
                OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.SerialApplyAllForced;
            SerialApplyAllLocationDeltas.Clear();
            ResetSerialApplyAllDeltaStats();
            Volatile.Write(ref _frozenSnapshot, null);
        }

        _offlineUpdateCurrentGoalActionsScopeDepth = 0;
        _offlineTargetLookupSnapshot = null;
        Volatile.Write(ref _locationEpoch, 0);
    }

    /// <summary>尝试用冻结快照追加同一地块候选角色。</summary>
    public static bool TryAddCharactersInBlock(CharacterPlanningAgent agent, List<Character> characters, MapBlockData block)
    {
        if (!TryGetFrozenSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(OfflineUpdateCurrentGoalActionsTargetLookupKind.SameBlock, false, 0, 0);
            return false;
        }

        int[] characterIds = snapshot!.GetBlockCharacterIds(block.AreaId, block.BlockId);
        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            OfflineUpdateCurrentGoalActionsTargetLookupKind.SameBlock,
            true,
            characterIds.Length,
            added);
        return true;
    }

    /// <summary>尝试用冻结快照追加同一地区候选角色。</summary>
    public static bool TryAddCharactersInArea(CharacterPlanningAgent agent, List<Character> characters, short areaId)
    {
        if (!TryGetFrozenSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot) ||
            areaId < 0 ||
            areaId >= snapshot!.AreaCharacterIds.Length)
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(OfflineUpdateCurrentGoalActionsTargetLookupKind.SameArea, false, 0, 0);
            return false;
        }

        int[] characterIds = snapshot.AreaCharacterIds[areaId];
        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            OfflineUpdateCurrentGoalActionsTargetLookupKind.SameArea,
            true,
            characterIds.Length,
            added);
        return true;
    }

    /// <summary>尝试用冻结快照追加同一州域候选角色。</summary>
    public static bool TryAddCharactersInState(CharacterPlanningAgent agent, List<Character> characters, sbyte stateId)
    {
        if (!TryGetFrozenSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot) ||
            !snapshot!.StateCharacterIds.TryGetValue(stateId, out int[]? characterIds))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(OfflineUpdateCurrentGoalActionsTargetLookupKind.SameState, false, 0, 0);
            return false;
        }

        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            OfflineUpdateCurrentGoalActionsTargetLookupKind.SameState,
            true,
            characterIds.Length,
            added);
        return true;
    }

    /// <summary>尝试用冻结快照追加地块范围内候选角色。</summary>
    public static bool TryAddCharactersInBlockRange(
        CharacterPlanningAgent agent,
        List<Character> characters,
        Location location,
        int steps)
    {
        if (!TryGetFrozenSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(OfflineUpdateCurrentGoalActionsTargetLookupKind.BlockRange, false, 0, 0);
            return false;
        }

        List<MapBlockData> blocks = _blockRangeScratch ??= new List<MapBlockData>(64);
        blocks.Clear();
        DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, blocks, steps, includeCenter: true);
        int candidateIds = 0;
        int beforeCount = characters.Count;
        foreach (MapBlockData block in blocks)
        {
            int[] characterIds = snapshot!.GetBlockCharacterIds(block.AreaId, block.BlockId);
            candidateIds += characterIds.Length;
            AddIndexedCharacters(agent, characters, characterIds);
        }

        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            OfflineUpdateCurrentGoalActionsTargetLookupKind.BlockRange,
            true,
            candidateIds,
            characters.Count - beforeCount);
        blocks.Clear();
        return true;
    }

    /// <summary>尝试用冻结快照追加聚落范围内候选角色。</summary>
    public static bool TryAddCharactersInSettlementRange(
        CharacterPlanningAgent agent,
        List<Character> characters,
        Location settlementLocation)
    {
        if (!TryGetFrozenSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(OfflineUpdateCurrentGoalActionsTargetLookupKind.SettlementRange, false, 0, 0);
            return false;
        }

        int[] characterIds = snapshot!.GetSettlementCharacterIds(settlementLocation);
        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            OfflineUpdateCurrentGoalActionsTargetLookupKind.SettlementRange,
            true,
            characterIds.Length,
            added);
        return true;
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization;

    private static void ResetSerialApplyAllDeltaStats()
    {
        _serialApplyAllRecordedDeltaCount = 0;
        _serialApplyAllSavedDeltaCount = 0;
        _serialApplyAllOverflowCount = 0;
        SerialApplyAllAffectedBlockKeys.Clear();
        SerialApplyAllAffectedAreaIds.Clear();
    }

    private static void RecordSerialApplyAllAffectedBlock(MapBlockData block)
    {
        SerialApplyAllAffectedAreaIds.Add(block.AreaId);
        SerialApplyAllAffectedBlockKeys.Add(MakeBlockKey(block.AreaId, block.BlockId));
    }

    private static bool TryRecordSerialApplyAllAffectedLocation(Location location)
    {
        if (!location.IsValid())
        {
            return true;
        }

        if (!DomainManager.Map.TryGetBlock(location, out MapBlockData block))
        {
            return false;
        }

        RecordSerialApplyAllAffectedBlock(block);
        return true;
    }

    private static int MakeBlockKey(short areaId, short blockId) =>
        ((int)areaId << 16) | (ushort)blockId;

    private static void ForceSerialApplyAllFullRebuild(
        OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason fullBuildReason,
        OfflineUpdateCurrentGoalActionsLocationEpochIncrementReason epochReason,
        int charId,
        Location oldLocation,
        Location newLocation)
    {
        if (_forceRebuildAfterSerialApplyAll)
        {
            return;
        }

        SerialApplyAllLocationDeltas.Clear();
        _forceRebuildAfterSerialApplyAll = true;
        _forceRebuildAfterSerialApplyAllReason = fullBuildReason;
        IncrementLocationEpoch(
            epochReason,
            charId,
            hasLocation: true,
            oldLocation,
            newLocation);
    }

    private static void PublishSerialApplyAllLocationDeltas(OfflineUpdateCurrentGoalActionsTargetSnapshot snapshot)
    {
        if (!_forceRebuildAfterSerialApplyAll && SerialApplyAllLocationDeltas.Count == 0)
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookupDeltaPublishNoChange();
            ResetSerialApplyAllDeltaStats();
            return;
        }

        lock (SyncRoot)
        {
            snapshot = Volatile.Read(ref _frozenSnapshot) ?? snapshot;
            int locationEpoch = Volatile.Read(ref _locationEpoch);
            if (_forceRebuildAfterSerialApplyAll || snapshot.LocationEpoch != locationEpoch)
            {
                OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason reason = _forceRebuildAfterSerialApplyAll
                    ? _forceRebuildAfterSerialApplyAllReason
                    : OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.EpochMismatch;
                Volatile.Write(ref _frozenSnapshot, BuildSnapshot(locationEpoch, reason));
            }
            else if (SerialApplyAllLocationDeltas.Count > 0)
            {
                long deltaPublishStartTicks = CharacterActionPlanningDiagnostics.BeginTargetLookupDeltaPublish();
                Volatile.Write(
                    ref _frozenSnapshot,
                    snapshot.ApplyLocationDeltas(
                        SerialApplyAllLocationDeltas,
                        IncrementalAffectedBlockLimit,
                        IncrementalAffectedAreaLimit,
                        out OfflineUpdateCurrentGoalActionsTargetDeltaApplyStats stats));
                CharacterActionPlanningDiagnostics.EndTargetLookupDeltaPublish(deltaPublishStartTicks, stats);
            }

            SerialApplyAllLocationDeltas.Clear();
            ResetSerialApplyAllDeltaStats();
            _forceRebuildAfterSerialApplyAll = false;
            _forceRebuildAfterSerialApplyAllReason =
                OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason.SerialApplyAllForced;
        }
    }

    private static OfflineUpdateCurrentGoalActionsTargetSnapshot BuildSnapshot(
        int locationEpoch,
        OfflineUpdateCurrentGoalActionsTargetLookupFullBuildReason reason)
    {
        CharacterActionPlanningDiagnostics.RecordTargetLookupFullBuild(reason);
        return OfflineUpdateCurrentGoalActionsTargetSnapshot.Build(locationEpoch);
    }

    private static void IncrementLocationEpoch(
        OfflineUpdateCurrentGoalActionsLocationEpochIncrementReason reason,
        int charId,
        bool hasLocation,
        Location oldLocation,
        Location newLocation)
    {
        CharacterActionPlanningDiagnostics.RecordTargetLookupLocationEpochIncrement(
            reason,
            GetRuntimeStage(),
            charId,
            hasLocation,
            hasLocation ? oldLocation.AreaId : (short)0,
            hasLocation ? oldLocation.BlockId : (short)0,
            hasLocation ? newLocation.AreaId : (short)0,
            hasLocation ? newLocation.BlockId : (short)0);
        Interlocked.Increment(ref _locationEpoch);
    }

    private static OfflineUpdateCurrentGoalActionsTargetLookupRuntimeStage GetRuntimeStage()
    {
        if (_offlineUpdateCurrentGoalActionsStageActive)
        {
            return OfflineUpdateCurrentGoalActionsTargetLookupRuntimeStage.FrozenRead;
        }

        if (_serialApplyAllStageActive)
        {
            return _collectSerialApplyAllLocationDeltas
                ? OfflineUpdateCurrentGoalActionsTargetLookupRuntimeStage.PrimaryApplyAllDeltaRecording
                : OfflineUpdateCurrentGoalActionsTargetLookupRuntimeStage.SecondaryApplyAllNoDeltaRecording;
        }

        return Volatile.Read(ref _frozenSnapshot) != null
            ? OfflineUpdateCurrentGoalActionsTargetLookupRuntimeStage.FrozenSnapshotIdle
            : OfflineUpdateCurrentGoalActionsTargetLookupRuntimeStage.None;
    }

    private static bool TryGetFrozenSnapshot(out OfflineUpdateCurrentGoalActionsTargetSnapshot? snapshot)
    {
        snapshot = null;
        if (_offlineUpdateCurrentGoalActionsScopeDepth <= 0)
        {
            return false;
        }

        snapshot = _offlineTargetLookupSnapshot;
        return snapshot != null;
    }

    private static int AddIndexedCharacters(CharacterPlanningAgent agent, List<Character> characters, int[] characterIds)
    {
        int selfId = agent.Object.GetId();
        int beforeCount = characters.Count;
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

        return characters.Count - beforeCount;
    }
}
