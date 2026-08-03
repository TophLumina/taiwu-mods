using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Pulao : CombatStateEffectBase
{
	protected override short CombatStateId => 202;

	public Pulao(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(102, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 102)
		{
			return 0;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		sbyte innerRatio = (dataKey.IsNormalAttack ? DomainManager.Combat.GetUsingWeaponData(enemyChar).GetInnerRatio() : DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(enemyChar.GetId(), dataKey.CombatSkillId)).GetCurrInnerRatio());
		int outerRatio = 100 - innerRatio;
		return -Math.Min(outerRatio, innerRatio) / 2;
	}
}
