using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongFireImplementBrokenHit : ISpecialEffectImplement, ISpecialEffectModifier
{
	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		EffectBase.CreateAffectedData(251, EDataModifyType.Custom, -1);
	}

	public void OnDisable(DataContext context)
	{
	}

	public bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != EffectBase.CharacterId || dataKey.FieldId != 251 || !dataKey.IsNormalAttack)
		{
			return dataValue;
		}
		CombatCharacter enemyChar = EffectBase.CurrEnemyChar;
		sbyte bodyPartType = EffectBase.CombatChar.NormalAttackBodyPart;
		if (!enemyChar.HasBreakInjury(bodyPartType))
		{
			return dataValue;
		}
		EffectBase.ShowSpecialEffectTips(1);
		return true;
	}
}
