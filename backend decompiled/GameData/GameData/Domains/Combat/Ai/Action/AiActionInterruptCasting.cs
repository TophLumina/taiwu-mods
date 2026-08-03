using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.InterruptCasting)]
public class AiActionInterruptCasting : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.InterruptSkillManual(context, combatChar.IsAlly);
	}
}
