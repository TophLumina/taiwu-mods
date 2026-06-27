using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.Domains.Item;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class OfflineCurrentGoalActionItemHolderPrefilter
{
    private static Snapshot? _frozenSnapshot;
    private static volatile bool _isFrozen;
    private static int _inventoryEpoch;
    private static bool _collectSerialApplyAllInventoryDeltas;
    private static readonly List<ItemHolderDelta> SerialApplyAllInventoryDeltas = new(128);

    /// <summary>在 NPC 主/副目标行动阶段开始前冻结“可能持有者”索引。</summary>
    public static void FreezeBeforeUpdateCurrentGoalActions()
    {
        if (!IsEnabled())
        {
            Unfreeze();
            return;
        }

        try
        {
            if (!OfflineCurrentGoalActionTargetLookupCache.TryGetFrozenPlanningSnapshot(
                    out OfflineCurrentGoalActionTargetSnapshot planningSnapshot) ||
                planningSnapshot.CharacterRecords.Length == 0)
            {
                Unfreeze();
                return;
            }

            int inventoryEpoch = Volatile.Read(ref _inventoryEpoch);
            Snapshot? currentSnapshot = Volatile.Read(ref _frozenSnapshot);
            if (currentSnapshot == null ||
                currentSnapshot.InventoryEpoch != inventoryEpoch ||
                currentSnapshot.SourceLocationEpoch != planningSnapshot.LocationEpoch)
            {
                currentSnapshot = BuildSnapshot(
                    planningSnapshot.CharacterRecords,
                    inventoryEpoch,
                    planningSnapshot.LocationEpoch);
                Volatile.Write(ref _frozenSnapshot, currentSnapshot);
                SerialApplyAllInventoryDeltas.Clear();
            }
            else if (SerialApplyAllInventoryDeltas.Count > 0)
            {
                currentSnapshot.ApplyHolderDeltas(SerialApplyAllInventoryDeltas);
                SerialApplyAllInventoryDeltas.Clear();
            }

            _isFrozen = true;
        }
        catch (Exception exception)
        {
            OfflineCurrentGoalActionTargetPrefilter.RecordException(exception);
            Unfreeze();
        }
    }

    /// <summary>离开 NPC 行动阶段后释放冻结索引，避免旧世界状态被复用。</summary>
    public static void Unfreeze()
    {
        _isFrozen = false;
        _frozenSnapshot = null;
        Volatile.Write(ref _inventoryEpoch, 0);
        _collectSerialApplyAllInventoryDeltas = false;
        SerialApplyAllInventoryDeltas.Clear();
    }

    public static void EndFrozenReadStage() =>
        _isFrozen = false;

    /// <summary>进入串行 ApplyAll；primary 记录新增持有人，secondary 只关闭读取屏障。</summary>
    public static void BeginSerialApplyAllDeltaRecording(bool collectDeltas)
    {
        _collectSerialApplyAllInventoryDeltas = collectDeltas && _frozenSnapshot != null;
        if (_collectSerialApplyAllInventoryDeltas)
        {
            SerialApplyAllInventoryDeltas.Clear();
        }
    }

    /// <summary>离开串行 ApplyAll；delta 会在下一次 planning 入口统一发布。</summary>
    public static void EndSerialApplyAllDeltaRecording() =>
        _collectSerialApplyAllInventoryDeltas = false;

    /// <summary>世界切换或插件卸载时清理运行时状态。</summary>
    public static void Reset() =>
        Unfreeze();

    /// <summary>记录新增持有者；删除和转移源角色不从索引移除，以保证预过滤集合只会扩大。</summary>
    public static void AddPossibleHolder(int charId, ItemKey itemKey)
    {
        RecordPossibleHolder(charId, itemKey.ItemType, itemKey.TemplateId);
    }

    /// <summary>角色背包发生难以定位的新增时，保守把当前背包全部并入“可能持有者”集合。</summary>
    public static void AddCurrentInventory(Character character)
    {
        int charId = character.GetId();
        if (_collectSerialApplyAllInventoryDeltas)
        {
            foreach (ItemKey itemKey in character.GetInventory().Items.Keys)
            {
                RecordPossibleHolder(charId, itemKey.ItemType, itemKey.TemplateId);
            }

            return;
        }

        RecordFrozenInventoryMutation();
    }

    /// <summary>记录离线创建出的新物品持有者。</summary>
    public static void AddPossibleHolder(int charId, sbyte itemType, short itemTemplateId)
    {
        RecordPossibleHolder(charId, itemType, itemTemplateId);
    }

    /// <summary>尝试为指定财富类道具行动创建持有者过滤器。</summary>
    public static bool TryCreateHolderFilter(
        PlanningActionNode? action,
        ContextArgGroupHandle args,
        out HolderFilter filter)
    {
        filter = default;
        Snapshot? snapshot = _frozenSnapshot;
        if (snapshot == null || action == null)
        {
            return false;
        }

        PlanningActionItem template = action.Template;
        if (IsSupportedItemDemandAction(template))
        {
            sbyte itemType = args.ItemType;
            short itemTemplateId = args.ItemTemplateId;
            if (itemType < 0 || itemTemplateId < 0 || itemType == 3)
            {
                return false;
            }

            filter = HolderFilter.ForItemTemplate(snapshot, MakeItemTemplateKey(itemType, itemTemplateId));
            return true;
        }

        if (IsSupportedDetoxMedicineDemandAction(template) && args.PoisonType >= 0)
        {
            filter = HolderFilter.ForDetoxPoison(snapshot, args.PoisonType);
            return true;
        }

        return false;
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization;

    private static bool IsSupportedItemDemandAction(PlanningActionItem template) =>
        template.TemplateId is 36 or 37 or 38 or 39 &&
        template.CharacterSelector is
            EPlanningActionCharacterSelector.RequestTarget or
            EPlanningActionCharacterSelector.StealTarget or
            EPlanningActionCharacterSelector.ScamTarget or
            EPlanningActionCharacterSelector.RobTarget;

    private static bool IsSupportedDetoxMedicineDemandAction(PlanningActionItem template) =>
        template.TemplateId == 27 &&
        template.CharacterSelector == EPlanningActionCharacterSelector.RequestTarget;

    private static Snapshot BuildSnapshot(
        OfflineCurrentGoalActionTargetRecord[] characterRecords,
        int inventoryEpoch,
        int sourceLocationEpoch)
    {
        var holdersByItemTemplate = new Dictionary<int, HashSet<int>>();
        var detoxMedicineHoldersByPoisonType = new Dictionary<sbyte, HashSet<int>>();
        foreach (OfflineCurrentGoalActionTargetRecord record in characterRecords)
        {
            foreach (ItemKey itemKey in record.Character.GetInventory().Items.Keys)
            {
                AddPossibleHolder(
                    holdersByItemTemplate,
                    detoxMedicineHoldersByPoisonType,
                    record.CharId,
                    itemKey.ItemType,
                    itemKey.TemplateId);
            }
        }

        return new Snapshot(
            inventoryEpoch,
            sourceLocationEpoch,
            holdersByItemTemplate,
            detoxMedicineHoldersByPoisonType);
    }

    private static void AddPossibleHolder(
        Dictionary<int, HashSet<int>> holdersByItemTemplate,
        Dictionary<sbyte, HashSet<int>> detoxMedicineHoldersByPoisonType,
        int charId,
        sbyte itemType,
        short itemTemplateId)
    {
        if (itemType < 0 || itemTemplateId < 0)
        {
            return;
        }

        int key = MakeItemTemplateKey(itemType, itemTemplateId);
        AddToSet(holdersByItemTemplate, key, charId);
        AddDetoxMedicineHolder(detoxMedicineHoldersByPoisonType, charId, itemType, itemTemplateId);
    }

    private static void AddDetoxMedicineHolder(
        Dictionary<sbyte, HashSet<int>> detoxMedicineHoldersByPoisonType,
        int charId,
        sbyte itemType,
        short itemTemplateId)
    {
        if (itemType != 8 || itemTemplateId < 0)
        {
            return;
        }

        MedicineItem medicineItem = Config.Medicine.Instance[itemTemplateId];
        if (medicineItem.EffectType != EMedicineEffectType.DetoxPoison)
        {
            return;
        }

        sbyte poisonType = medicineItem.EffectSubType.PoisonType();
        if (poisonType < 0)
        {
            return;
        }

        AddToSet(detoxMedicineHoldersByPoisonType, poisonType, charId);
    }

    private static void AddToSet<TKey>(Dictionary<TKey, HashSet<int>> map, TKey key, int charId)
        where TKey : notnull
    {
        if (!map.TryGetValue(key, out HashSet<int>? holders))
        {
            holders = new HashSet<int>();
            map[key] = holders;
        }

        holders.Add(charId);
    }

    private static int MakeItemTemplateKey(sbyte itemType, short itemTemplateId) =>
        ((itemType & 0xff) << 16) | (ushort)itemTemplateId;

    private static void RecordPossibleHolder(int charId, sbyte itemType, short itemTemplateId)
    {
        if (itemType < 0 || itemTemplateId < 0)
        {
            return;
        }

        if (_collectSerialApplyAllInventoryDeltas)
        {
            SerialApplyAllInventoryDeltas.Add(new ItemHolderDelta(charId, itemType, itemTemplateId));
            return;
        }

        RecordFrozenInventoryMutation();
    }

    private static void RecordFrozenInventoryMutation()
    {
        if (_collectSerialApplyAllInventoryDeltas)
        {
            return;
        }

        if (_isFrozen)
        {
            if (CharacterActionPlanningDiagnostics.IsRecording)
            {
                CharacterActionPlanningDiagnostics.RecordFrozenItemHolderPrefilterInventoryMutation();
            }

            return;
        }

        Interlocked.Increment(ref _inventoryEpoch);
    }

    internal readonly struct ItemHolderDelta
    {
        public readonly int CharId;
        public readonly sbyte ItemType;
        public readonly short ItemTemplateId;

        public ItemHolderDelta(int charId, sbyte itemType, short itemTemplateId)
        {
            CharId = charId;
            ItemType = itemType;
            ItemTemplateId = itemTemplateId;
        }
    }

    internal readonly struct HolderFilter
    {
        private readonly Snapshot? _snapshot;
        private readonly HolderFilterKind _kind;
        private readonly int _key;

        private HolderFilter(Snapshot snapshot, HolderFilterKind kind, int key)
        {
            _snapshot = snapshot;
            _kind = kind;
            _key = key;
        }

        public static HolderFilter ForItemTemplate(Snapshot snapshot, int itemTemplateKey) =>
            new(snapshot, HolderFilterKind.ItemTemplate, itemTemplateKey);

        public static HolderFilter ForDetoxPoison(Snapshot snapshot, sbyte poisonType) =>
            new(snapshot, HolderFilterKind.DetoxPoison, poisonType);

        /// <summary>查询角色是否可能持有目标物品；返回 true 不代表真实持有，仍需原版最终确认。</summary>
        public bool MayHold(int charId) =>
            _snapshot == null ||
            (_kind == HolderFilterKind.ItemTemplate
                ? _snapshot.MayHoldItemTemplate(_key, charId)
                : _snapshot.MayHoldDetoxMedicine((sbyte)_key, charId));
    }

    private enum HolderFilterKind : byte
    {
        ItemTemplate,
        DetoxPoison,
    }

    internal sealed class Snapshot
    {
        private readonly Dictionary<int, HashSet<int>> _holdersByItemTemplate;
        private readonly Dictionary<sbyte, HashSet<int>> _detoxMedicineHoldersByPoisonType;

        public int InventoryEpoch { get; }
        public int SourceLocationEpoch { get; }

        public Snapshot(
            int inventoryEpoch,
            int sourceLocationEpoch,
            Dictionary<int, HashSet<int>> holdersByItemTemplate,
            Dictionary<sbyte, HashSet<int>> detoxMedicineHoldersByPoisonType)
        {
            InventoryEpoch = inventoryEpoch;
            SourceLocationEpoch = sourceLocationEpoch;
            _holdersByItemTemplate = holdersByItemTemplate;
            _detoxMedicineHoldersByPoisonType = detoxMedicineHoldersByPoisonType;
        }

        public void ApplyHolderDeltas(IReadOnlyList<ItemHolderDelta> deltas)
        {
            foreach (ItemHolderDelta delta in deltas)
            {
                AddPossibleHolder(
                    _holdersByItemTemplate,
                    _detoxMedicineHoldersByPoisonType,
                    delta.CharId,
                    delta.ItemType,
                    delta.ItemTemplateId);
            }
        }

        public bool MayHoldItemTemplate(int itemTemplateKey, int charId) =>
            _holdersByItemTemplate.TryGetValue(itemTemplateKey, out HashSet<int>? holders) &&
            holders.Contains(charId);

        public bool MayHoldDetoxMedicine(sbyte poisonType, int charId) =>
            _detoxMedicineHoldersByPoisonType.TryGetValue(poisonType, out HashSet<int>? holders) &&
            holders.Contains(charId);
    }
}
