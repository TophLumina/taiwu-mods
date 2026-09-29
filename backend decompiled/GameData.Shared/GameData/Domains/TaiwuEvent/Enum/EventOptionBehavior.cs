namespace GameData.Domains.TaiwuEvent.Enum;

public static class EventOptionBehavior
{
	public const sbyte None = 0;

	public const sbyte BehaviorJust = 1;

	public const sbyte BehaviorKind = 2;

	public const sbyte BehaviorEven = 3;

	public const sbyte BehaviorRebel = 4;

	public const sbyte BehaviorEgoistic = 5;

	public static readonly sbyte[] ToBehaviorType = new sbyte[6] { -1, 0, 1, 2, 3, 4 };
}
