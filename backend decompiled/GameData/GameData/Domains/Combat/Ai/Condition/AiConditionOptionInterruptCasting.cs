namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionInterruptCasting)]
public class AiConditionOptionInterruptCasting : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoInterrupt))
		{
			return false;
		}
		return combatChar.GetPreparingSkillId() >= 0;
	}
}
