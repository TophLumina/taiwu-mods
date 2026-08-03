namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.TargetDistanceIsNotFarthest)]
public class AiConditionTargetDistanceIsNotFarthest : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		return combatChar.AiTargetDistance != DomainManager.Combat.GetDistanceRange().max;
	}
}
