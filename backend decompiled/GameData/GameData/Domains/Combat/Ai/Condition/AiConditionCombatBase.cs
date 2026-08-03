namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionCombatBase : IAiCondition
{
	public int GroupId => 1;

	public int RuntimeId { get; set; }

	public bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		CombatCharacter combatChar = (CombatCharacter)participant;
		return Check(memory, combatChar);
	}

	public abstract bool Check(AiMemoryNew memory, CombatCharacter combatChar);
}
