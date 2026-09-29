using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongBaseImplementInvincible : ISpecialEffectImplement, ISpecialEffectModifier
{
	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		EffectBase.CreateAffectedData(281, EDataModifyType.Custom, -1);
	}

	public void OnDisable(DataContext context)
	{
	}

	public bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != EffectBase.CharacterId || dataKey.FieldId != 281)
		{
			return dataValue;
		}
		if (EffectBase.CombatChar.AnimalConfig == null)
		{
			return dataValue;
		}
		return true;
	}
}
