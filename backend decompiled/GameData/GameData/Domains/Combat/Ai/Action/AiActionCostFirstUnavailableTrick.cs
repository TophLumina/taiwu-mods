using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CostFirstUnavailableTrick)]
public class AiActionCostFirstUnavailableTrick : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		IReadOnlyDictionary<int, sbyte> tricks = combatChar.GetTricks().Tricks;
		foreach (KeyValuePair<int, sbyte> trick in tricks)
		{
			if (!combatChar.IsTrickUsable(trick.Value))
			{
				DomainManager.SpecialEffect.CostTrickDuringPreparingSkill(context, combatChar.GetId(), trick.Key);
				break;
			}
		}
	}
}
