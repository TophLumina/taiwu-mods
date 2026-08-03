using GameData.Common;
using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionCastSkillBase : AiActionCombatBase
{
	protected abstract CombatSkillSelector Selector { get; }

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		short skillId = Selector.Select(memory, combatChar);
		if (skillId > 0)
		{
			DomainManager.Combat.StartPrepareSkill(context, skillId, combatChar.IsAlly);
		}
	}
}
