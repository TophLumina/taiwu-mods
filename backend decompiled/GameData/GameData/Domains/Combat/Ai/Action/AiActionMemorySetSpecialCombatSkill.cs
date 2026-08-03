using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetSpecialCombatSkill)]
public class AiActionMemorySetSpecialCombatSkill : AiActionCombatBase
{
	private readonly string _key;

	private readonly short _skillId;

	public AiActionMemorySetSpecialCombatSkill(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
	{
		_key = strings[0];
		_skillId = (short)ints[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		memory.Ints[_key] = _skillId;
	}
}
