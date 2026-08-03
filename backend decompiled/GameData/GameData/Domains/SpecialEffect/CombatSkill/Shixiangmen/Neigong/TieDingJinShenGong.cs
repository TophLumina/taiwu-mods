using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Neigong;

public class TieDingJinShenGong : CombatSkillEffectBase
{
	private sbyte DirectReduceMaxFlaw = -1;

	private sbyte ReverseReduceMaxFlaw = -2;

	private sbyte ReverseReduceDamageFlaw = 3;

	private sbyte ReverseReduceDamagePercent = -30;

	public TieDingJinShenGong()
	{
	}

	public TieDingJinShenGong(CombatSkillKey skillKey)
		: base(skillKey, 6002, -1)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 125, -1), EDataModifyType.Add);
		if (!base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 125)
		{
			return base.IsDirect ? DirectReduceMaxFlaw : ReverseReduceMaxFlaw;
		}
		if (dataKey.FieldId == 69 && dataKey.CustomParam0 == 0 && base.CombatChar.GetDefeatMarkCollection().GetTotalFlawCount() >= ReverseReduceDamageFlaw)
		{
			return ReverseReduceDamagePercent;
		}
		return 0;
	}
}
