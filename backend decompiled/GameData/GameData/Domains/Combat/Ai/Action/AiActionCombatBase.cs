namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionCombatBase : IAiAction
{
	public int GroupId => 1;

	public int RuntimeId { get; set; }

	public void Execute(AiMemoryNew memory, IAiParticipant participant)
	{
		CombatCharacter combatChar = (CombatCharacter)participant;
		Execute(memory, combatChar);
	}

	public abstract void Execute(AiMemoryNew memory, CombatCharacter combatChar);
}
