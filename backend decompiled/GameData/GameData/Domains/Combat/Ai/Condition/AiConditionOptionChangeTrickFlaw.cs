namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeTrickFlaw)]
public class AiConditionOptionChangeTrickFlaw : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoAttack))
		{
			return false;
		}
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoChangeTrick))
		{
			return false;
		}
		if (!DomainManager.Combat.CanNormalAttack(combatChar.IsAlly) || !combatChar.GetCanChangeTrick())
		{
			return false;
		}
		int costChangeTrickCount = CFormulaHelper.CalcCostChangeTrickCount(combatChar, EFlawOrAcupointType.Flaw);
		return combatChar.GetChangeTrickCount() >= costChangeTrickCount;
	}
}
