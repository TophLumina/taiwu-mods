using Config;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

public static class CastBoostKit
{
	private const int NeiliCostValuePerGrid = 5;

	private const int ClearDefendAddQiDisorderValuePerGrid = 500;

	public static CastBoostEffectDisplayData GetPureCostNeiliEffectData(this CombatSkillKey skillKey, byte type, short skillId, bool applyEffect)
	{
		CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(skillKey.CharId);
		sbyte gridCost = Config.CombatSkill.Instance[skillId].GridCost;
		int costValue = gridCost * -5;
		costValue = (applyEffect ? combatChar.ApplySpecialEffectToNeiliAllocation(type, costValue) : costValue);
		CombatSkillEffectDescriptionDisplayData effectDescription = DomainManager.CombatSkill.GetEffectDisplayData(skillKey);
		return CastBoostEffectDisplayData.GenerateNeiliAllocation(effectDescription, type, costValue);
	}

	public static CastBoostEffectDisplayData GetCostWugKingData(this CombatSkillKey skillKey, short wugTemplateId, int count)
	{
		CombatSkillEffectDescriptionDisplayData effectDescription = DomainManager.CombatSkill.GetEffectDisplayData(skillKey);
		return CastBoostEffectDisplayData.GenerateWugKing(effectDescription, wugTemplateId, count);
	}

	public static CastBoostEffectDisplayData GetCostClearDefendData(this CombatSkillKey skillKey, short skillId)
	{
		sbyte gridCost = Config.CombatSkill.Instance[skillId].GridCost;
		int costValue = gridCost * 500;
		CombatSkillEffectDescriptionDisplayData effectDescription = DomainManager.CombatSkill.GetEffectDisplayData(skillKey);
		return CastBoostEffectDisplayData.GenerateClearDefend(effectDescription, costValue);
	}
}
