namespace GameData.Domains.Combat.Ai;

public class AiTree
{
	private readonly IAiParticipant _participant;

	private readonly AiMemoryNew _aiMemory = new AiMemoryNew();

	private readonly AiData _aiData;

	public AiTree(IAiParticipant participant, AiData template)
	{
		_participant = participant;
		_aiData = template;
	}

	public void Update()
	{
		if (!_participant.DisableAi)
		{
			_aiData.Update(_aiMemory, _participant);
		}
	}

	public void ClearMemories()
	{
		_aiData.Reset();
		_aiMemory.Clear();
	}
}
