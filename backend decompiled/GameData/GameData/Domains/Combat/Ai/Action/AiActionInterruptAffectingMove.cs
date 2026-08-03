using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.InterruptAffectingMove)]
public class AiActionInterruptAffectingMove : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.ClearAffectingMoveSkillManual(context, combatChar.IsAlly);
	}
}
