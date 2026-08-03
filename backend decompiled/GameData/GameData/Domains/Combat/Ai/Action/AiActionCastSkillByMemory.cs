using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillByMemory)]
public class AiActionCastSkillByMemory : AiActionCombatBase
{
	private readonly string _key;

	public AiActionCastSkillByMemory(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (memory.Ints.TryGetValue(_key, out var skillId) && skillId >= 0)
		{
			DataContext context = DomainManager.Combat.Context;
			DomainManager.Combat.StartPrepareSkill(context, (short)skillId, combatChar.IsAlly);
		}
	}
}
