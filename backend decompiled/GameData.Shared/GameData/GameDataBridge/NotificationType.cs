namespace GameData.GameDataBridge;

/// <summary>
/// 数据模块向表现模块发送的通知的类型
/// </summary>
public static class NotificationType
{
	/// <summary>
	/// 数据更改
	/// </summary>
	public const byte DataModification = 0;

	/// <summary>
	/// 方法调用返回
	/// </summary>
	public const byte MethodReturn = 1;

	/// <summary>
	/// 数据模块推送给表现模块的事件
	/// </summary>
	public const byte DisplayEvent = 2;
}
