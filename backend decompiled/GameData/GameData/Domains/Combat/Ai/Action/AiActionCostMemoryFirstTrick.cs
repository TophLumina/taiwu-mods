using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CostMemoryFirstTrick)]
public class AiActionCostMemoryFirstTrick : AiActionCombatBase
{
	private readonly string _key;

	public AiActionCostMemoryFirstTrick(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!memory.Ints.TryGetValue(_key, out var skillId) || skillId < 0)
		{
			return;
		}
		DataContext context = DomainManager.Combat.Context;
		IReadOnlyDictionary<int, sbyte> tricks = combatChar.GetTricks().Tricks;
		List<NeedTrick> trickCost = Config.CombatSkill.Instance[skillId].TrickCost;
		List<sbyte> trickTypeList = trickCost.Select((NeedTrick needTrick) => needTrick.TrickType).ToList();
		foreach (KeyValuePair<int, sbyte> trick in tricks)
		{
			if (!trickTypeList.Contains(trick.Value))
			{
				DomainManager.SpecialEffect.CostTrickDuringPreparingSkill(context, combatChar.GetId(), trick.Key);
				break;
			}
		}
	}
}
