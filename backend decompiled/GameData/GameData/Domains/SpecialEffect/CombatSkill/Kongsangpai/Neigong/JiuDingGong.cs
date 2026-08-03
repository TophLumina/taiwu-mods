using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Neigong;

public class JiuDingGong : CombatSkillEffectBase
{
	private const sbyte AddPowerRatio = 40;

	private const sbyte MaxAddPower = 20;

	public JiuDingGong()
	{
	}

	public JiuDingGong(CombatSkillKey skillKey)
		: base(skillKey, 10004, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 199)
		{
			return 0;
		}
		int healthPercent = CValuePercent.ParseInt(CharObj.GetHealth(), CharObj.GetMaxHealth());
		int addPower = (base.IsDirect ? (healthPercent * 40 / 100) : ((100 - healthPercent) * 40 / 100));
		return Math.Clamp(addPower, 0, 20);
	}
}
