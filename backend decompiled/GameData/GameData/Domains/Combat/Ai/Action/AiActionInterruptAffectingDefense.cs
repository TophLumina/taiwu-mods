using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.InterruptAffectingDefense)]
public class AiActionInterruptAffectingDefense : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.ClearAffectingDefenseSkillManual(context, combatChar.IsAlly);
	}
}
