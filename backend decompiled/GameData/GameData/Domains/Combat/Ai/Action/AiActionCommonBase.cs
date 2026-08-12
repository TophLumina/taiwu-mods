namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionCommonBase : IAiAction
{
	public int GroupId => 0;

	public int RuntimeId { get; set; }

	public abstract void Execute(AiMemoryNew memory, IAiParticipant participant);
}
