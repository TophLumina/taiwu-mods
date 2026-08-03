namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeTrick)]
public class AiConditionOptionChangeTrick : AiConditionCombatBase
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
		return DomainManager.Combat.CanNormalAttack(combatChar.IsAlly) && combatChar.GetCanChangeTrick();
	}
}
