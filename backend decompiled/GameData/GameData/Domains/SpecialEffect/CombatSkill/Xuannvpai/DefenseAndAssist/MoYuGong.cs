using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class MoYuGong : AssistSkillBase
{
	private const sbyte ChangeTimePercent = 33;

	public MoYuGong()
	{
	}

	public MoYuGong(CombatSkillKey skillKey)
		: base(skillKey, 8602)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(178, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(178, EDataModifyType.AddPercent, -1);
		}
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
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
		if (dataKey.FieldId == 178)
		{
			return base.IsDirect ? (-33) : 33;
		}
		return 0;
	}
}
