namespace GameData.Domains.Taiwu;

/// <summary>
/// 当前的传剑状态
/// </summary>
public static class LegacyPassingState
{
	/// <summary>
	/// 默认状态，不做任何操作
	/// </summary>
	public const sbyte DefaultState = 0;

	/// <summary>
	/// 选择继承人
	/// </summary>
	public const sbyte ChoosingHeir = 1;

	/// <summary>
	/// 选择随机继承人
	/// </summary>
	public const sbyte ChoosingRandomHeir = 2;

	/// <summary>
	/// 传承遗惠
	/// </summary>
	public const sbyte PassingLegacy = 3;

	/// <summary>
	/// 事件窗口
	/// </summary>
	public const sbyte DisplayingEvent = 4;
}
