using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MoveToTargetDistance)]
public class AiActionMoveToTargetDistance : AiActionCombatBase
{
	private readonly short _target;

	public AiActionMoveToTargetDistance(IReadOnlyList<int> ints)
	{
		_target = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		combatChar.AiTargetDistance = DomainManager.Combat.GetMoveRangeDistance(_target);
	}
}
