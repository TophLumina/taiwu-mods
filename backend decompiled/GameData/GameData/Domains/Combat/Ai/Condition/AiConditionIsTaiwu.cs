namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.IsTaiwu)]
public class AiConditionIsTaiwu : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return combatChar.IsTaiwu;
	}
}
