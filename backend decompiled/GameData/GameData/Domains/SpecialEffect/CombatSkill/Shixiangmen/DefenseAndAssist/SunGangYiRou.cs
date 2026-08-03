using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.DefenseAndAssist;

public class SunGangYiRou : DefenseSkillBase
{
	private const sbyte ReduceDamagePercent = -40;

	private const sbyte AddDamagePercent = 20;

	public SunGangYiRou()
	{
	}

	public SunGangYiRou(CombatSkillKey skillKey)
		: base(skillKey, 6502)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
		ShowSpecialEffectTips(0);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && base.CanAffect)
		{
			sbyte innerRatio = ((dataKey.CombatSkillId >= 0) ? DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(base.CurrEnemyChar.GetId(), dataKey.CombatSkillId)).GetCurrInnerRatio() : base.CurrEnemyChar.GetWeaponData().GetInnerRatio());
			if (innerRatio > 0 && innerRatio < 100 && (base.IsDirect ? (innerRatio > 50) : (innerRatio < 50)))
			{
				return (dataKey.CustomParam0 == (base.IsDirect ? 1 : 0)) ? (-40) : 20;
			}
		}
		return 0;
	}
}
