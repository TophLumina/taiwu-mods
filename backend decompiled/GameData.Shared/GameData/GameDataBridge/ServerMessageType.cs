namespace GameData.GameDataBridge;

/// <summary>
/// 数据模块传给表现模块的消息类型
/// </summary>
public static class ServerMessageType
{
	/// <summary>
	/// 数据模块初始化完毕
	/// </summary>
	public const byte GameModuleInitialized = 0;

	/// <summary>
	/// 通知集合
	/// </summary>
	public const byte Notifications = 1;

	/// <summary>
	/// 错误消息集合
	/// </summary>
	public const byte ErrorMessages = 2;

	/// <summary>
	/// 警告消息集合
	/// </summary>
	public const byte WarningMessages = 3;

	/// <summary>
	/// 断开连接
	/// </summary>
	public const byte Disconnect = 4;
}
