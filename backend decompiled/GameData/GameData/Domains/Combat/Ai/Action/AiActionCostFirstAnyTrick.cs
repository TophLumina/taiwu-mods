using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CostFirstAnyTrick)]
public class AiActionCostFirstAnyTrick : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		IReadOnlyDictionary<int, sbyte> tricks = combatChar.GetTricks().Tricks;
		using IEnumerator<KeyValuePair<int, sbyte>> enumerator = tricks.GetEnumerator();
		if (enumerator.MoveNext())
		{
			KeyValuePair<int, sbyte> trick = enumerator.Current;
			DomainManager.SpecialEffect.CostTrickDuringPreparingSkill(context, combatChar.GetId(), trick.Key);
		}
	}
}
