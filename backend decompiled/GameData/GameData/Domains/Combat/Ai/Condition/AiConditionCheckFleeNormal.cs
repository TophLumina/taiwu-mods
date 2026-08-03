namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CheckFleeNormal)]
public class AiConditionCheckFleeNormal : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!DomainManager.Combat.IsCharacterHalfFallen(combatChar))
		{
			return false;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!combatChar.IsAlly);
		return combatChar.GetDefeatMarkCollection().GetTotalCount() > enemyChar.GetDefeatMarkCollection().GetTotalCount();
	}
}
