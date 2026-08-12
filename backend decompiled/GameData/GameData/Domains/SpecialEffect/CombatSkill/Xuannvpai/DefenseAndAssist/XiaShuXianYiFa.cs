using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class XiaShuXianYiFa : AssistSkillBase
{
	private const sbyte ChangeSpeedPercent = 25;

	public XiaShuXianYiFa()
	{
	}

	public XiaShuXianYiFa(CombatSkillKey skillKey)
		: base(skillKey, 8604)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(179, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(179, EDataModifyType.AddPercent, -1);
		}
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
		if (base.CanAffect)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		if (dataKey.FieldId == 179)
		{
			return base.IsDirect ? (-25) : 25;
		}
		return 0;
	}
}
