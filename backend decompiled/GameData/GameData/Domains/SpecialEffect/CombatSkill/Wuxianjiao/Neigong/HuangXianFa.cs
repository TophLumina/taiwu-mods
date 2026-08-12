using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class HuangXianFa : CombatSkillEffectBase
{
	private sbyte SpeedChangePercent = 50;

	public HuangXianFa()
	{
	}

	public HuangXianFa(CombatSkillKey skillKey)
		: base(skillKey, 12001, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			CreateAffectedData(121, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(121, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId != 121)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		ShowSpecialEffectTips(0);
		return base.IsDirect ? SpeedChangePercent : (-SpeedChangePercent);
	}
}
