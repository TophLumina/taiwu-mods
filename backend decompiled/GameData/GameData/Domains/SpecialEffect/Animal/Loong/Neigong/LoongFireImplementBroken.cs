using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongFireImplementBroken : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const sbyte BreakNeedInjury = 4;

	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		EffectBase.CreateAffectedAllEnemyData(168, EDataModifyType.Custom, -1);
	}

	public void OnDisable(DataContext context)
	{
	}

	public int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId == EffectBase.CharacterId || dataKey.FieldId != 168)
		{
			return dataValue;
		}
		return Math.Min(dataValue, 4);
	}
}
