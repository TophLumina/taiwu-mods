namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionInterruptAffectingMove)]
public class AiConditionOptionInterruptAffectingMove : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoClearAgile))
		{
			return false;
		}
		return combatChar.GetAffectingMoveSkillId() >= 0;
	}
}
