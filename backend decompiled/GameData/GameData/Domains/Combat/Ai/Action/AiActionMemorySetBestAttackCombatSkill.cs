using System.Collections.Generic;
using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetBestAttackCombatSkill)]
public class AiActionMemorySetBestAttackCombatSkill : AiActionCombatBase
{
	private readonly CombatSkillSelector _selector = new CombatSkillSelector(1);

	private readonly string _key;

	public AiActionMemorySetBestAttackCombatSkill(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		memory.Ints[_key] = _selector.Select(memory, combatChar);
	}
}
