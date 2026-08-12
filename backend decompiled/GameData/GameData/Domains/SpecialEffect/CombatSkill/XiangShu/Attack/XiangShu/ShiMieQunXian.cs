using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class ShiMieQunXian : SkillCostNeiliAllocation
{
	public ShiMieQunXian()
	{
	}

	public ShiMieQunXian(CombatSkillKey skillKey)
		: base(skillKey, -1)
	{
		CostNeiliAllocationPerGrade = 6;
	}

	protected override void AppendAffect(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 344, EDataModifyType.Custom, -1);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 344)
		{
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
