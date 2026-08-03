namespace GameData.Domains.Character.Display;

public static class HunterState
{
	/// <summary>
	/// 待追捕
	/// </summary>
	public const sbyte NotInProgress = 0;

	/// <summary>
	/// 追捕中
	/// </summary>
	public const sbyte Hunting = 1;

	/// <summary>
	/// 追捕失败
	/// </summary>
	public const sbyte Failed = 2;

	/// <summary>
	/// 押送中
	/// </summary>
	public const sbyte Escorting = 3;
}
