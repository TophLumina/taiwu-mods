using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AttackRangeEdgeLess)]
public class AiConditionAttackRangeEdgeLess : AiConditionCheckCharBase
{
	private readonly bool _isForward;

	public AiConditionAttackRangeEdgeLess(IReadOnlyList<int> ints)
		: base(ints)
	{
		_isForward = ints[1] == 1;
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		CombatCharacter otherChar = DomainManager.Combat.GetCombatCharacter(!checkChar.IsAlly);
		short edgeL = (_isForward ? checkChar.GetAttackRange().Outer : checkChar.GetAttackRange().Inner);
		short edgeR = (_isForward ? otherChar.GetAttackRange().Outer : otherChar.GetAttackRange().Inner);
		return edgeL < edgeR;
	}
}
