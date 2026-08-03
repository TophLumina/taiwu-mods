using GameData.Common;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.NormalAttack)]
public class AiActionNormalAttack : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		DomainManager.Combat.NormalAttackImmediate(context, combatChar.IsAlly);
	}
}
