namespace GameData.Domains.Combat.Ai.Condition;

public abstract class AiConditionCommonBase : IAiCondition
{
	private int _runtimeId;

	public int GroupId => 0;

	protected string RuntimeIdStr { get; private set; }

	public int RuntimeId
	{
		get
		{
			return _runtimeId;
		}
		set
		{
			_runtimeId = value;
			RuntimeIdStr = $"Conchship_Internal_{_runtimeId}";
		}
	}

	public abstract bool Check(AiMemoryNew memory, IAiParticipant participant);
}
