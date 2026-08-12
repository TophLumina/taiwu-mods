namespace GameData.Domains.Combat.Ai;

public interface IAiAction
{
	int GroupId { get; }

	int RuntimeId { get; set; }

	void Execute(AiMemoryNew memory, IAiParticipant participant);
}
