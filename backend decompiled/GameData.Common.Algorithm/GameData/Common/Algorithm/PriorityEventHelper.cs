namespace GameData.Common.Algorithm;

internal static class PriorityEventHelper
{
	public static long NextId;

	public const int StateActive = 0;

	public const int StateRemoved = 1;

	public static bool Contains(this EPriorityEventStatus status, EPriorityEventStatus target)
	{
		return (status & target) == target;
	}
}
