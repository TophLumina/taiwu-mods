using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionCheckCharBase : AiConditionCombatBase
{
	protected readonly bool IsAlly;

	protected AiConditionCheckCharBase(IReadOnlyList<int> ints)
	{
		IsAlly = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == IsAlly);
		return Check(checkChar);
	}

	protected abstract bool Check(CombatCharacter checkChar);
}
