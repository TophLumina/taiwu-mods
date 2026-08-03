namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionAttack)]
public class AiConditionOptionAttack : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoAttack))
		{
			return false;
		}
		return DomainManager.Combat.CanNormalAttack(combatChar.IsAlly) && combatChar.CanNormalAttackImmediate;
	}
}
