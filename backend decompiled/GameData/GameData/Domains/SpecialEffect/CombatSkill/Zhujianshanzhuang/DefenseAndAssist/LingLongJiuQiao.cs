using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.DefenseAndAssist;

public class LingLongJiuQiao : DefenseSkillBase
{
	private const int AddOrReduceDurabilityValue = 3;

	private static readonly IReadOnlyList<sbyte> TargetEquipmentSlots = new sbyte[7] { 0, 1, 2, 3, 5, 6, 7 };

	public LingLongJiuQiao()
	{
	}

	public LingLongJiuQiao(CombatSkillKey skillKey)
		: base(skillKey, 9705)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!hit && pursueIndex <= 0 && defender == base.CombatChar && base.CanAffect)
		{
			DoEffect(context);
		}
	}

	private void DoEffect(DataContext context)
	{
		ItemKey[] equipments = CharObj.GetEquipment();
		List<ItemKey> pool = ObjectPool<List<ItemKey>>.Instance.Get();
		pool.Clear();
		for (int i = 8; i <= 10; i++)
		{
			ItemKey key = equipments[i];
			if (key.IsValid() && DomainManager.Item.GetElement_Accessories(key.Id).GetCurrDurability() > 0)
			{
				pool.Add(key);
			}
		}
		if (pool.Count > 0)
		{
			ItemKey key2 = pool.GetRandom(context.Random);
			bool affected = AddRandomUnlockValue(context, ItemTemplateHelper.GetGrade(key2.ItemType, key2.TemplateId));
			if (AddOrReduceDurability(context) || affected)
			{
				ChangeDurability(context, base.CombatChar, key2, -1);
			}
		}
		ObjectPool<List<ItemKey>>.Instance.Return(pool);
	}

	private bool AddOrReduceDurability(DataContext context)
	{
		CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
		ItemKey[] equipments = affectChar.GetCharacter().GetEquipment();
		List<ItemKey> pool = ObjectPool<List<ItemKey>>.Instance.Get();
		foreach (sbyte slot in TargetEquipmentSlots)
		{
			ItemKey key = equipments[slot];
			if (key.IsValid() && CombatDomain.IsWeaponCanBreak(key.GetConfig().ItemSubType))
			{
				ItemBase item = DomainManager.Item.GetBaseItem(key);
				if (base.IsDirect ? (item.GetCurrDurability() < item.GetMaxDurability()) : (item.GetCurrDurability() > 0))
				{
					pool.Add(key);
				}
			}
		}
		bool affected = pool.Count > 0;
		if (affected)
		{
			ItemKey key2 = pool.GetRandom(context.Random);
			int delta = 3 * (base.IsDirect ? 1 : (-1));
			ChangeDurability(context, affectChar, key2, delta);
			ShowSpecialEffectTips(1);
		}
		ObjectPool<List<ItemKey>>.Instance.Return(pool);
		return affected;
	}

	private bool AddRandomUnlockValue(DataContext context, sbyte grade)
	{
		int addValue = GlobalConfig.Instance.UnlockAttackUnit * (CValuePercent)(grade + 1);
		List<int> pool = ObjectPool<List<int>>.Instance.Get();
		pool.Clear();
		List<int> unlockValues = base.CombatChar.GetUnlockPrepareValue();
		for (int i = 0; i < 3; i++)
		{
			if (unlockValues[i] < GlobalConfig.Instance.UnlockAttackUnit && base.CombatChar.CanUnlockAttackByConfig(i))
			{
				pool.Add(i);
			}
		}
		bool affected = pool.Count > 0;
		if (affected)
		{
			int index = pool.GetRandom(context.Random);
			base.CombatChar.ChangeUnlockAttackValue(context, index, addValue);
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<int>>.Instance.Return(pool);
		return affected;
	}
}
