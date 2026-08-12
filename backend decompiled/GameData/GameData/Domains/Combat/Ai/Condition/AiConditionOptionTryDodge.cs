namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionTryDodge)]
public class AiConditionOptionTryDodge : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoMove))
		{
			return false;
		}
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.TryDodge))
		{
			return false;
		}
		return true;
	}
}
