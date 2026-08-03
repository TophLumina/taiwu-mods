using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Neigong;

public class JiaYiQuanPian : CombatSkillEffectBase
{
	private sbyte DirectReduceMaxAcupoint = -1;

	private sbyte ReverseReduceMaxAcupoint = -2;

	private sbyte ReverseReduceDamageAcupoint = 3;

	private sbyte ReverseReduceDamagePercent = -30;

	public JiaYiQuanPian()
	{
	}

	public JiaYiQuanPian(CombatSkillKey skillKey)
		: base(skillKey, 3002, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 130, -1), EDataModifyType.Add);
		if (!base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 130)
		{
			return base.IsDirect ? DirectReduceMaxAcupoint : ReverseReduceMaxAcupoint;
		}
		if (dataKey.FieldId == 69 && dataKey.CustomParam0 == 1 && base.CombatChar.GetDefeatMarkCollection().GetTotalAcupointCount() >= ReverseReduceDamageAcupoint)
		{
			return ReverseReduceDamagePercent;
		}
		return 0;
	}
}
