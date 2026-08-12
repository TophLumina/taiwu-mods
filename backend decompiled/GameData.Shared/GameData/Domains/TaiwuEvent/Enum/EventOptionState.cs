namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 事件选项状态
/// </summary>
public class EventOptionState
{
	/// <summary>
	/// 可见不可点击状态
	/// </summary>
	public const sbyte Disable = -1;

	/// <summary>
	/// 可见可点击状态
	/// </summary>
	public const sbyte Normal = 0;

	/// <summary>
	/// 蓝色可点击的未读状态
	/// </summary>
	public const sbyte UnRead = 1;

	/// <summary>
	/// 暗灰色可点击的已读状态
	/// </summary>
	public const sbyte Read = 2;
}
