namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MoveToFarthest)]
public class AiActionMoveToFarthest : AiActionCombatBase
{
	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		combatChar.AiTargetDistance = DomainManager.Combat.GetDistanceRange().max;
	}
}
