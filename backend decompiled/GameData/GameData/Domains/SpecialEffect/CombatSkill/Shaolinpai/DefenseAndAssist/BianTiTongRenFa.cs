using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class BianTiTongRenFa : AssistSkillBase
{
	public BianTiTongRenFa()
	{
	}

	public BianTiTongRenFa(CombatSkillKey skillKey)
		: base(skillKey, 1603)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(114, EDataModifyType.Custom, -1);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || dataKey.FieldId != 114)
		{
			return dataValue;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		bool inner = dataKey.CustomParam1 == 1;
		if (inner == base.IsDirect)
		{
			return dataValue;
		}
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		sbyte existInjury = base.CombatChar.GetInjuries().Get(bodyPart, inner);
		if (existInjury > 0)
		{
			return dataValue;
		}
		DamageStepCollection stepCollection = base.CombatChar.GetDamageStepCollection();
		int damageStep = (inner ? stepCollection.InnerDamageSteps : stepCollection.OuterDamageSteps)[bodyPart];
		int existDamageValue = base.CombatChar.GetDamageValue(bodyPart, inner);
		if (existDamageValue + dataValue <= damageStep)
		{
			return dataValue;
		}
		ShowSpecialEffectTips(0);
		return damageStep - existDamageValue;
	}
}
