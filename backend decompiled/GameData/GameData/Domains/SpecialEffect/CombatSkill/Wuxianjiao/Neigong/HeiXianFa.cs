using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class HeiXianFa : CombatSkillEffectBase
{
	private sbyte HealCountChangePercent = 50;

	public HeiXianFa()
	{
	}

	public HeiXianFa(CombatSkillKey skillKey)
		: base(skillKey, 12003, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			CreateAffectedData(122, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(123, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 122) > 1u)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		if (dataKey.CustomParam0 == 0)
		{
			ShowSpecialEffectTips(0);
		}
		return (dataKey.FieldId == 122) ? HealCountChangePercent : (-HealCountChangePercent);
	}
}
