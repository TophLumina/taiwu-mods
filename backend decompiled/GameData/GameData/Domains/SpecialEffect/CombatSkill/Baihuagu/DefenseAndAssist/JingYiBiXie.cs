using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class JingYiBiXie : AssistSkillBase
{
	private const sbyte ReducePercent = -50;

	private static readonly int[] PoisonAffectThresholdValues = new int[6] { 1, 15, 25, 25, 200, 200 };

	public JingYiBiXie()
	{
	}

	public JingYiBiXie(CombatSkillKey skillKey)
		: base(skillKey, 3601)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 106, -1), EDataModifyType.TotalPercent);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 243, -1), EDataModifyType.Add);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 106)
		{
			ShowSpecialEffectTipsOnceInFrame(0);
			return -50;
		}
		if (dataKey.FieldId == 243)
		{
			return PoisonAffectThresholdValues[dataKey.CustomParam0];
		}
		return 0;
	}
}
