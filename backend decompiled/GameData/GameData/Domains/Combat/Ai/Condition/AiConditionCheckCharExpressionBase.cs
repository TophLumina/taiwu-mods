using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionCheckCharExpressionBase : AiConditionCombatBase
{
	protected readonly CExpression Expression;

	protected readonly bool IsAlly;

	protected AiConditionCheckCharExpressionBase(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		Expression = CExpression.FromBase64(strings[0]);
		IsAlly = ints[0] == 1;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		CombatCharacter checkChar = DomainManager.Combat.GetCombatCharacter(combatChar.IsAlly == IsAlly);
		int expressionResult = Expression.Calc(combatChar);
		return Check(checkChar, expressionResult);
	}

	protected abstract bool Check(CombatCharacter checkChar, int expressionResult);
}
