using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkill)]
public class AiActionCastSkill : AiActionCombatBase
{
	private readonly short _skillId;

	public AiActionCastSkill(IReadOnlyList<int> ints)
	{
		_skillId = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.StartPrepareSkill(context, _skillId, combatChar.IsAlly);
	}
}
