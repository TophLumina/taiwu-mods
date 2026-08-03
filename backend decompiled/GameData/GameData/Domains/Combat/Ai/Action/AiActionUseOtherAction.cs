using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.UseOtherAction)]
public class AiActionUseOtherAction : AiActionCombatBase
{
	private readonly sbyte _otherActionType;

	public AiActionUseOtherAction(IReadOnlyList<int> ints)
	{
		_otherActionType = (sbyte)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.StartPrepareOtherAction(context, _otherActionType, combatChar.IsAlly);
	}
}
