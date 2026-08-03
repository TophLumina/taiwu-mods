using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class LuanQiSha : AssistSkillBase
{
	private const short RequireQiDisorderUnit = 400;

	public LuanQiSha()
	{
	}

	public LuanQiSha(CombatSkillKey skillKey)
		: base(skillKey, 15801)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0) || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return CharObj.GetDisorderOfQi() / 400;
		}
		return 0;
	}
}
