using System.Collections.Generic;
using Config;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.PrioritySetHigh)]
public class AiActionPrioritySetHigh : AiActionCombatBase
{
	private readonly string _key;

	public AiActionPrioritySetHigh(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (memory.Ints.TryGetValue(_key, out var skillId) && skillId >= 0 && skillId < Config.CombatSkill.Instance.Count)
		{
			memory.SetPriority((short)skillId, EAiPriority.High);
		}
	}
}
