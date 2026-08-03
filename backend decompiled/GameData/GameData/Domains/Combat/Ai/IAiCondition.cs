namespace GameData.Domains.Combat.Ai;

public interface IAiCondition
{
	int GroupId { get; }

	int RuntimeId { get; set; }

	bool Check(AiMemoryNew memory, IAiParticipant participant);
}
