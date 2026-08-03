namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 事件对背景遮罩的控制代码
/// </summary>
public class EventMaskControl
{
	/// <summary>
	/// 无控制
	/// </summary>
	public const sbyte NoChange = 0;

	/// <summary>
	/// 事件显示时渐变到全黑
	/// </summary>
	public const sbyte ShowToMask = 1;

	/// <summary>
	/// 事件退出时从全黑恢复
	/// </summary>
	public const sbyte HideToRevert = 2;

	/// <summary>
	/// 显示时渐变到全黑，并且退出时从全黑恢复
	/// </summary>
	public const sbyte ShowToMaskAndHideToRevert = 3;

	/// <summary>
	/// 事件显示时渐变到全黑再到恢复
	/// </summary>
	public const sbyte ShowToMaskToHide = 4;

	/// <summary>
	/// 事件显示时从全黑恢复
	/// </summary>
	public const sbyte ShowToMaskToRevert = 5;

	/// <summary>
	/// 事件退出时渐变到全黑
	/// </summary>
	public const sbyte HideToMask = 6;
}
