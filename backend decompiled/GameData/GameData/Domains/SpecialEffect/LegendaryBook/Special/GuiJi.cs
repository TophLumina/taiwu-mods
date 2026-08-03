using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Special;

public class GuiJi : EquipmentEffectBase
{
	private const int ExtraAttackBodyPartCount = 1;

	private sbyte _exceptBodyPart;

	private OuterAndInnerInts _damageValues;

	public GuiJi()
	{
	}

	public GuiJi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 41000, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
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
		if (attackerId == base.CharacterId && defenderId != base.CharacterId && combatSkillId < 0 && base.CombatChar.GetChangeTrickAttack() && IsCurrWeapon())
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
}
