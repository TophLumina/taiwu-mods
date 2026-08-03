namespace GameData.Domains.Combat.Ai;

public struct AiContext
{
	public AiMemoryNew Memory;

	public IAiParticipant Participant;

	public static implicit operator AiContext((AiMemoryNew memory, IAiParticipant participant) tup)
	{
		AiContext result = default(AiContext);
		(result.Memory, result.Participant) = tup;
		return result;
	}

	public void Deconstruct(out AiMemoryNew memory, out IAiParticipant participant)
	{
		memory = Memory;
		participant = Participant;
	}
}
