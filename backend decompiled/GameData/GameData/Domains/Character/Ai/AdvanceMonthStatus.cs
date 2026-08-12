namespace GameData.Domains.Character.Ai;

public static class AdvanceMonthStatus
{
	public const byte ForbiddenToExecuteGeneralAction = 1;

	public const byte ForbiddenToExecutePrioritizedAction = 2;

	public const byte ForbiddenToExecuteFixedAction = 4;

	public const byte CannotBeCalledByAdventure = 16;

	public const byte ForbiddenToExecuteAction = 7;
}
