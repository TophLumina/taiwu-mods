using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class HuaShengLian : RanChenZiAssistSkillBase
{
	private const sbyte MaxInjuryMark = 3;

	public HuaShengLian()
	{
	}

	public HuaShengLian(CombatSkillKey skillKey)
		: base(skillKey, 16411)
	{
		RequireBossPhase = 1;
	}

	protected override void ActivateEffect(DataContext context)
	{
		AppendAffectedData(context, 159, EDataModifyType.Custom, -1);
		AppendAffectedData(context, 114, EDataModifyType.Custom, -1);
	}

	protected override void DeactivateEffect(DataContext context)
	{
		ClearAffectedData(context);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		if (dataKey.FieldId == 159)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 114)
		{
			bool inner = dataKey.CustomParam1 == 1;
			sbyte bodyPart = (sbyte)dataKey.CustomParam2;
			return Math.Min(dataValue, base.CombatChar.MarkCountChangeToDamageValue(bodyPart, inner, 3));
		}
		return dataValue;
	}
}
