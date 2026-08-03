namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.InHazard)]
public class AiConditionInHazard : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return combatChar.AiController.IsHazard();
	}
}
