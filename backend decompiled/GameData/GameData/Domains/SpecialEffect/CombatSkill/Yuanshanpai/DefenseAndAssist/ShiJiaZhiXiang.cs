using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;

public class ShiJiaZhiXiang : AssistSkillBase
{
	private int _checkedIndex = -1;

	private int UsingWeaponWeight => DomainManager.Combat.GetUsingWeapon(base.CombatChar).GetWeight();

	private bool Affecting => base.CombatChar.GetUsingWeaponIndex() == _checkedIndex;

	private int AffectingWeaponWeight => Affecting ? UsingWeaponWeight : 0;

	private int AffectingMakeDamageTotalPercent => Math.Max(base.IsDirect ? (AffectingWeaponWeight / 5) : (300 - AffectingWeaponWeight / 5), 0);

	public ShiJiaZhiXiang()
	{
	}

	public ShiJiaZhiXiang(CombatSkillKey skillKey)
		: base(skillKey, 5604)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(69, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(274, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId == base.CharacterId)
		{
			_checkedIndex = -1;
			if (base.CanAffect && base.CombatChar.GetUsingWeaponIndex() < 3)
			{
				ShowSpecialEffectTips(0);
				_checkedIndex = base.CombatChar.GetUsingWeaponIndex();
			}
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId && !attacker.GetIsFightBack())
		{
			_checkedIndex = -1;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !dataKey.IsNormalAttack || !base.CanAffect || _checkedIndex < 0)
		{
			return 0;
		}
		if (base.CombatChar.IsAutoNormalAttackingSpecial)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = ((fieldId == 69 || fieldId == 274) ? AffectingMakeDamageTotalPercent : 0);
		if (1 == 0)
		{
		}
		return result;
	}
}
