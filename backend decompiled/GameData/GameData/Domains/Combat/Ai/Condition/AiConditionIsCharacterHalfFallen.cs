using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.IsCharacterHalfFallen)]
public class AiConditionIsCharacterHalfFallen : AiConditionCombatBase
{
	private readonly bool _isAlly;

	public AiConditionIsCharacterHalfFallen(IReadOnlyList<int> ints)
	{
		_isAlly = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == _isAlly);
		return DomainManager.Combat.IsCharacterHalfFallen(checkChar);
	}
}
