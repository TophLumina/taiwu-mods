using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MoveToAttackRangeEdge)]
public class AiActionMoveToAttackRangeEdge : AiActionCombatBase
{
	private readonly bool _isForward;

	private readonly int _offset;

	public AiActionMoveToAttackRangeEdge(IReadOnlyList<int> ints)
	{
		_isForward = ints[0] == 1;
		_offset = ints[1];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		OuterAndInnerShorts attackRange = combatChar.GetAttackRange();
		short edge = (_isForward ? attackRange.Outer : attackRange.Inner);
		combatChar.AiTargetDistance = DomainManager.Combat.GetMoveRangeDistance(edge + _offset);
	}
}
