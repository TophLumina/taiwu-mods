namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionAutoCostTrick)]
public class AiConditionOptionAutoCostTrick : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoCostTrick))
		{
			return false;
		}
		return DomainManager.SpecialEffect.CanCostTrickDuringPreparingSkill(combatChar.GetId(), combatChar.GetPreparingSkillId());
	}
}
