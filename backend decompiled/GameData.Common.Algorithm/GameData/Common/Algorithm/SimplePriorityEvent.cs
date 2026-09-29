namespace GameData.Common.Algorithm;

public class SimplePriorityEvent : PriorityEvent<ESimplePriority, object>
{
	public SimplePriorityEvent()
		: base(ESimplePriority.Medium)
	{
	}
}
