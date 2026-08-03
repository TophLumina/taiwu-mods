using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Neigong;

public class JiuZhenShiErYuan : CombatSkillEffectBase
{
	private const sbyte SpeedChangePercent = 50;

	public JiuZhenShiErYuan()
	{
	}

	public JiuZhenShiErYuan(CombatSkillKey skillKey)
		: base(skillKey, 3001, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			CreateAffectedData(118, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(118, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId != 118)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		ShowSpecialEffectTips(0);
		return (dataKey.CharId == base.CharacterId) ? 50 : (-50);
	}
}
