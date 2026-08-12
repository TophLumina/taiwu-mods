namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionInterruptAffectingDefense)]
public class AiConditionOptionInterruptAffectingDefense : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoClearDefense))
		{
			return false;
		}
		return combatChar.GetAffectingDefendSkillId() >= 0;
	}
}
