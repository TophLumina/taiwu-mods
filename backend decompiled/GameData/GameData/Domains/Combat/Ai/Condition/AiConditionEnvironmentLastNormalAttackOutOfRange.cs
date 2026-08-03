namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.EnvironmentLastNormalAttackOutOfRange)]
public class AiConditionEnvironmentLastNormalAttackOutOfRange : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		(int, AiEnvironment.ENormalAttackType) lastNormalAttack = combatChar.AiController.Environment.LastNormalAttack;
		return combatChar.GetUsingWeaponIndex() == lastNormalAttack.Item1 && lastNormalAttack.Item2 == AiEnvironment.ENormalAttackType.OutOfRange;
	}
}
