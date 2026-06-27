using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.Domains;
using GameData.Domains.Item;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterInventoryTargetPrefilter
{
    private static Snapshot? _frozenSnapshot;

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
            int[] characterIds = CharacterActionTargetLookupCache.GetFrozenCharacterIdsForRelationTargetCache();
            if (characterIds.Length == 0)
            {
                Unfreeze();
                return;
            }

            _frozenSnapshot = BuildSnapshot(characterIds);
        }
        catch (Exception exception)
        {
            CharacterGoalTargetConditionPrefilter.RecordException(exception);
            Unfreeze();
        }
    }

    /// <summary>离开 NPC 行动阶段后释放冻结索引，避免旧世界状态被复用。</summary>
    public static void Unfreeze() =>
        _frozenSnapshot = null;

    /// <summary>世界切换或插件卸载时清理运行时状态。</summary>
    public static void Reset() =>
        _frozenSnapshot = null;

    /// <summary>记录新增持有者；删除和转移源角色不从索引移除，以保证预过滤集合只会扩大。</summary>
    public static void AddPossibleHolder(int charId, ItemKey itemKey)
    {
        if (charId < 0 || !itemKey.IsValid())
        {
            return;
        }

        _frozenSnapshot?.AddPossibleHolder(charId, itemKey.ItemType, itemKey.TemplateId);
    }

    /// <summary>角色背包发生难以定位的新增时，保守把当前背包全部并入“可能持有者”集合。</summary>
    public static void AddCurrentInventory(Character character)
    {
        Snapshot? snapshot = _frozenSnapshot;
        if (snapshot == null)
        {
            return;
        }

        int charId = character.GetId();
        if (charId < 0)
        {
            return;
        }

        foreach (ItemKey itemKey in character.GetInventory().Items.Keys)
        {
            snapshot.AddPossibleHolder(charId, itemKey.ItemType, itemKey.TemplateId);
        }
    }

    /// <summary>记录离线创建出的新物品持有者。</summary>
    public static void AddPossibleHolder(int charId, sbyte itemType, short itemTemplateId)
    {
        if (charId < 0 || itemType < 0 || itemTemplateId < 0)
        {
            return;
        }

        _frozenSnapshot?.AddPossibleHolder(charId, itemType, itemTemplateId);
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
        if (!IsSupportedItemDemandAction(template))
        {
            return false;
        }

        sbyte itemType = args.ItemType;
        short itemTemplateId = args.ItemTemplateId;
        if (itemType < 0 || itemTemplateId < 0 || itemType == 3)
        {
            return false;
        }

        filter = new HolderFilter(snapshot, MakeItemTemplateKey(itemType, itemTemplateId));
        return true;
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionTargetLookupCache;

    private static bool IsSupportedItemDemandAction(PlanningActionItem template) =>
        template.TemplateId is 36 or 37 or 38 or 39 &&
        template.CharacterSelector is
            EPlanningActionCharacterSelector.RequestTarget or
            EPlanningActionCharacterSelector.StealTarget or
            EPlanningActionCharacterSelector.ScamTarget or
            EPlanningActionCharacterSelector.RobTarget;

    private static Snapshot BuildSnapshot(int[] characterIds)
    {
        var holdersByItemTemplate = new ConcurrentDictionary<int, ConcurrentDictionary<int, byte>>();
        foreach (int charId in characterIds)
        {
            if (!DomainManager.Character.TryGetElement_Objects(charId, out Character character))
            {
                continue;
            }

            foreach (ItemKey itemKey in character.GetInventory().Items.Keys)
            {
                AddPossibleHolder(holdersByItemTemplate, charId, itemKey.ItemType, itemKey.TemplateId);
            }
        }

        return new Snapshot(holdersByItemTemplate);
    }

    private static void AddPossibleHolder(
        ConcurrentDictionary<int, ConcurrentDictionary<int, byte>> holdersByItemTemplate,
        int charId,
        sbyte itemType,
        short itemTemplateId)
    {
        if (itemType < 0 || itemTemplateId < 0)
        {
            return;
        }

        int key = MakeItemTemplateKey(itemType, itemTemplateId);
        ConcurrentDictionary<int, byte> holders = holdersByItemTemplate.GetOrAdd(
            key,
            static _ => new ConcurrentDictionary<int, byte>());
        holders.TryAdd(charId, 0);
    }

    private static int MakeItemTemplateKey(sbyte itemType, short itemTemplateId) =>
        ((itemType & 0xff) << 16) | (ushort)itemTemplateId;

    internal readonly struct HolderFilter
    {
        private readonly Snapshot? _snapshot;
        private readonly int _itemTemplateKey;

        internal HolderFilter(Snapshot snapshot, int itemTemplateKey)
        {
            _snapshot = snapshot;
            _itemTemplateKey = itemTemplateKey;
        }

        /// <summary>查询角色是否可能持有目标物品；返回 true 不代表真实持有，仍需原版最终确认。</summary>
        public bool MayHold(int charId) =>
            _snapshot == null || _snapshot.MayHold(_itemTemplateKey, charId);
    }

    internal sealed class Snapshot
    {
        private readonly ConcurrentDictionary<int, ConcurrentDictionary<int, byte>> _holdersByItemTemplate;

        public Snapshot(ConcurrentDictionary<int, ConcurrentDictionary<int, byte>> holdersByItemTemplate)
        {
            _holdersByItemTemplate = holdersByItemTemplate;
        }

        public void AddPossibleHolder(int charId, sbyte itemType, short itemTemplateId) =>
            CharacterInventoryTargetPrefilter.AddPossibleHolder(
                _holdersByItemTemplate,
                charId,
                itemType,
                itemTemplateId);

        public bool MayHold(int itemTemplateKey, int charId) =>
            _holdersByItemTemplate.TryGetValue(itemTemplateKey, out ConcurrentDictionary<int, byte>? holders) &&
            holders.ContainsKey(charId);
    }
}
