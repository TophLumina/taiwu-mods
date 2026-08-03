using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetNeedUseSkill)]
public class AiActionMemorySetNeedUseSkill : AiActionCombatBase
{
	private readonly string _key;

	public AiActionMemorySetNeedUseSkill(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		memory.Ints[_key] = combatChar.GetCombatReserveData().NeedUseSkillId;
	}
}
