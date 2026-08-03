using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;

public class RedEyeBase : WugEffectBase
{
	private const int LostItemCount = 3;

	private bool _affected;

	private readonly List<(ItemBase item, int amount)>[] _classifiedItems = new List<(ItemBase, int)>[3]
	{
		new List<(ItemBase, int)>(),
		new List<(ItemBase, int)>(),
		new List<(ItemBase, int)>()
	};

	private readonly List<(ItemBase item, int amount)> _lostItems = new List<(ItemBase, int)>();

	private int ChangeHitOdds => (!base.IsGrown && base.IsElite) ? 75 : 50;

	protected RedEyeBase()
	{
	}

	protected RedEyeBase(int charId, int type, short wugTemplateId, short effectId)
		: base(charId, type, wugTemplateId, effectId)
	{
		CostWugCount = 1;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (AffectDatas == null)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		}
		if (base.IsGrown)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 259, -1), EDataModifyType.Custom);
		}
		if (base.CanChangeToGrown)
		{
			Events.RegisterHandler_EatingItem(OnEatingItem);
		}
		if (base.IsGrown)
		{
			Events.RegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (base.CanChangeToGrown)
		{
			Events.UnRegisterHandler_EatingItem(OnEatingItem);
		}
		if (base.IsGrown)
		{
			Events.UnRegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		}
		base.OnDisable(context);
	}

	protected override void AddAffectDataAndEvent(DataContext context)
	{
		_affected = true;
		AppendAffectedData(context, base.CharacterId, 74, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		if (WugGrowthType.IsWugGrowthTypeCombatOnly(WugConfig.WugGrowthType))
		{
			Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		}
	}

	protected override void ClearAffectDataAndEvent(DataContext context)
	{
		RemoveAffectedData(context, base.CharacterId, 74);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		if (WugGrowthType.IsWugGrowthTypeCombatOnly(WugConfig.WugGrowthType))
		{
			Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		}
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (attacker == base.CombatChar && pursueIndex <= 0 && DomainManager.Combat.InAttackRange(base.CombatChar) && base.CanAffect)
		{
			ShowEffectTips(context, 1);
			if (base.IsElite)
			{
				ShowEffectTips(context, 2);
			}
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_affected && attacker == base.CombatChar && base.CanAffect)
		{
			_affected = false;
			CostWugInCombat(context);
		}
	}

	private void OnEatingItem(DataContext context, GameData.Domains.Character.Character character, ItemKey itemKey)
	{
		if (character.GetId() == base.CharacterId && itemKey.ItemType == 9 && base.CanAffect && Config.TeaWine.Instance[itemKey.TemplateId].ItemSubType == 901)
		{
			ChangeToGrown(context);
		}
	}

	private void OnAdvanceMonthFinish(DataContext context)
	{
		if (!base.IsGrown || !base.IsElite || !base.CanAffect)
		{
			return;
		}
		bool isTaiwu = base.CharacterId == DomainManager.Taiwu.GetTaiwuCharId();
		Inventory inventory = CharObj.GetInventory();
		CharacterDomain.ClassifyItemsToLose(_classifiedItems, inventory.Items, isTaiwu);
		CharacterDomain.GetLostItemsByAmount(context.Random, 3, _classifiedItems, _lostItems);
		Location location = CharObj.GetLocation();
		if (!location.IsValid())
		{
			location = CharObj.GetValidLocation();
		}
		LifeRecordCollection lifeRecord = DomainManager.LifeRecord.GetLifeRecordCollection();
		List<MapBlockData> nearbyBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, nearbyBlocks, 2, includeCenter: true);
		foreach (var lostItem in _lostItems)
		{
			ItemBase item = lostItem.item;
			int amount = lostItem.amount;
			ItemKey itemKey = item.GetItemKey();
			CharObj.RemoveInventoryItem(context, itemKey, amount, deleteItem: false);
			MapBlockData block = nearbyBlocks.GetRandom(context.Random);
			DomainManager.Map.AddBlockItem(context, block, itemKey, amount);
			AddLifeRecord(lifeRecord.AddWugKingRedEyeLoseItem, block.GetLocation(), itemKey.ItemType, itemKey.TemplateId);
		}
		_lostItems.Clear();
		ObjectPool<List<MapBlockData>>.Instance.Return(nearbyBlocks);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId >= 0 || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 74)
		{
			_affected = true;
			return base.IsGood ? ChangeHitOdds : (-ChangeHitOdds);
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 259 && base.CanAffect)
		{
			return false;
		}
		return dataValue;
	}
}
