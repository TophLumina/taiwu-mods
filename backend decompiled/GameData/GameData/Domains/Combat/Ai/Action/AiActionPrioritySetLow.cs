using System.Collections.Generic;
using Config;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.PrioritySetLow)]
public class AiActionPrioritySetLow : AiActionCombatBase
{
	private readonly string _key;

	public AiActionPrioritySetLow(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (memory.Ints.TryGetValue(_key, out var skillId) && skillId >= 0 && skillId < Config.CombatSkill.Instance.Count)
		{
			memory.SetPriority((short)skillId, EAiPriority.Low);
		}
	}
}
