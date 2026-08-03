using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class WeaponAddAttackPrepareValue : CombatSkillEffectBase
{
	private const int ChangeWeaponCdCount = 2;

	private const int FreeNormalAttackCount = 1;

	protected abstract int RequireWeaponSubType { get; }

	protected abstract int DirectSrcWeaponSubType { get; }

	private static short GetItemSubType(ItemKey itemKey)
	{
		return ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
	}

	protected WeaponAddAttackPrepareValue()
	{
	}

	protected WeaponAddAttackPrepareValue(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				DoChangeWeaponCd(context);
				DoChangeWeapon(context);
			}
			RemoveSelf(context);
		}
	}

	private void DoChangeWeaponCd(DataContext context)
	{
		CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		ItemKey[] weapons = affectChar.GetWeapons();
		int currWeaponIndex = affectChar.GetUsingWeaponIndex();
		List<int> pool = ObjectPool<List<int>>.Instance.Get();
		pool.Clear();
		for (int i = 0; i < 3; i++)
		{
			if (i == currWeaponIndex)
			{
				continue;
			}
			ItemKey weaponKey = weapons[i];
			if (weaponKey.IsValid())
			{
				CombatWeaponData weaponData = affectChar.GetWeaponData(i);
				if (weaponData.GetDurability() > 0 && (!base.IsDirect || weaponData.GetCdFrame() > 0))
				{
					pool.Add(i);
				}
			}
		}
		foreach (int weaponIndex in RandomUtils.GetRandomUnrepeated(context.Random, 2, pool))
		{
			DomainManager.Combat.ChangeWeaponCd(context, affectChar, weaponIndex, base.IsDirect ? (-50) : 50);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
		ObjectPool<List<int>>.Instance.Return(pool);
	}

	private void DoChangeWeapon(DataContext context)
	{
		int usingWeaponIndex = base.CombatChar.GetUsingWeaponIndex();
		ItemKey[] weapons = base.CombatChar.GetWeapons();
		ItemKey currWeaponKey = weapons[usingWeaponIndex];
		bool canAffect = currWeaponKey.IsValid() && GetItemSubType(currWeaponKey) == (base.IsDirect ? DirectSrcWeaponSubType : RequireWeaponSubType);
		List<int> pool = ObjectPool<List<int>>.Instance.Get();
		pool.Clear();
		if (canAffect && base.IsDirect)
		{
			bool canSwitchToRequireSubType = false;
			for (int i = 0; i < 3; i++)
			{
				if (i == usingWeaponIndex)
				{
					continue;
				}
				ItemKey weaponKey = weapons[i];
				if (weaponKey.IsValid() && GetItemSubType(weaponKey) == RequireWeaponSubType)
				{
					CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(weaponKey.Id);
					if (weaponData.GetDurability() > 0 && weaponData.NotInAnyCd)
					{
						canSwitchToRequireSubType = true;
						pool.Add(i);
					}
				}
			}
			canAffect = canSwitchToRequireSubType;
		}
		if (canAffect)
		{
			if (base.IsDirect && pool.Count > 0)
			{
				DomainManager.Combat.ChangeWeapon(context, pool[context.Random.Next(0, pool.Count)], base.CombatChar.IsAlly, forceChange: true);
			}
			if (!base.IsDirect && DomainManager.Combat.InAttackRange(base.CombatChar))
			{
				base.CombatChar.NeedNormalAttackSkipPrepare++;
				ShowSpecialEffectTips(1);
			}
		}
		ObjectPool<List<int>>.Instance.Return(pool);
	}
}
