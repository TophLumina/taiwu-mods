using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MoveToAttackRangeCenter)]
public class AiActionMoveToAttackRangeCenter : AiActionCombatBase
{
	private readonly int _offset;

	public AiActionMoveToAttackRangeCenter(IReadOnlyList<int> ints)
	{
		_offset = ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		OuterAndInnerShorts attackRange = combatChar.GetAttackRange();
		int center = (attackRange.Outer + attackRange.Inner) / 2;
		combatChar.AiTargetDistance = DomainManager.Combat.GetMoveRangeDistance(center + _offset);
	}
}
