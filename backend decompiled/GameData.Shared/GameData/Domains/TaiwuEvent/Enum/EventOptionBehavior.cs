namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 选项立场枚举
/// </summary>
public static class EventOptionBehavior
{
	/// <summary>
	/// 无立场
	/// </summary>
	public const sbyte None = 0;

	/// <summary>
	/// 刚正
	/// </summary>
	public const sbyte BehaviorJust = 1;

	/// <summary>
	/// 仁善
	/// </summary>
	public const sbyte BehaviorKind = 2;

	/// <summary>
	/// 中庸
	/// </summary>
	public const sbyte BehaviorEven = 3;

	/// <summary>
	/// 叛逆
	/// </summary>
	public const sbyte BehaviorRebel = 4;

	/// <summary>
	/// 唯我
	/// </summary>
	public const sbyte BehaviorEgoistic = 5;

	/// <summary>
	/// 转换成 <see cref="T:GameData.Domains.Character.BehaviorType" />
	/// </summary>
	public static readonly sbyte[] ToBehaviorType = new sbyte[6] { -1, 0, 1, 2, 3, 4 };
}
