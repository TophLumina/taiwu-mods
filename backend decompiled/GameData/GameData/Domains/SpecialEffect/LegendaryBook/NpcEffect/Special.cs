using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Special : FeatureEffectBase
{
	private const int ExtraAttackBodyPartCount = 1;

	private sbyte _exceptBodyPart;

	private OuterAndInnerInts _damageValues;

	private const short MaxAddDamage = 180;

	public Special()
	{
	}

	public Special(int charId, short featureId)
		: base(charId, featureId, 41410)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId != base.CharacterId || defenderId == base.CharacterId || combatSkillId >= 0 || !base.CombatChar.GetChangeTrickAttack())
		{
			return;
		}
		GameData.Domains.Item.Weapon usingWeapon = DomainManager.Combat.GetUsingWeapon(base.CombatChar);
		short subType = usingWeapon.GetItemSubType();
		if (CombatSkillType.Instance[(sbyte)10].LegendaryBookWeaponSlotItemSubTypes.Contains(subType))
		{
			_exceptBodyPart = bodyPart;
			if (isInner)
			{
				_damageValues.Inner += damageValue;
			}
			else
			{
				_damageValues.Outer += damageValue;
			}
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightback)
	{
		if (attacker.GetId() != base.CharacterId || !_damageValues.IsNonZero)
		{
			return;
		}
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		pool.Clear();
		pool.AddRange(defender.GetAvailableBodyParts());
		pool.Remove(_exceptBodyPart);
		foreach (sbyte otherSidePart in RandomUtils.GetRandomUnrepeated(context.Random, 1, pool))
		{
			DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, defender, otherSidePart, _damageValues.Outer, _damageValues.Inner, -1);
			base.CombatChar.ApplyChangeTrickFlawOrAcupoint(context, defender, otherSidePart);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		_damageValues = (outer: 0, inner: 0);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			if (base.CombatChar.GetAutoCastingSkill() || dataKey.CombatSkillId < 0 || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 10)
			{
				return 0;
			}
			int addDamage = 180 * (4000 - base.CurrEnemyChar.GetStanceValue()) / 4000;
			return Math.Min(addDamage, 180);
		}
		return 0;
	}
}
