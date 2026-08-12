using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class FangTianChiLing : BossNeigongBase
{
	private sbyte AddBouncePowerUnit = 10;

	public FangTianChiLing()
	{
	}

	public FangTianChiLing(CombatSkillKey skillKey)
		: base(skillKey, 16108)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 111, EDataModifyType.Add, -1);
		AppendAffectedData(context, base.CharacterId, 177, EDataModifyType.Custom, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 111)
		{
			return AddBouncePowerUnit * Math.Abs(dataKey.CustomParam1 - 50) * 2;
		}
		return 0;
	}

	public override OuterAndInnerInts GetModifiedValue(AffectedDataKey dataKey, OuterAndInnerInts dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 177)
		{
			dataValue.Outer = DomainManager.Combat.CombatConfig.MinDistance;
			dataValue.Inner = DomainManager.Combat.CombatConfig.MaxDistance;
		}
		return dataValue;
	}
}
