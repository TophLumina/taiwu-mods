namespace GameData.GameDataBridge;

/// <summary>
/// 表现模块传给数据模块的消息类型
/// </summary>
public static class ClientMessageType
{
	/// <summary>
	/// 初始化数据模块 (同时传入模板数据)
	/// </summary>
	public const byte Initialize = 0;

	/// <summary>
	/// 操作集合
	/// </summary>
	public const byte Operations = 1;

	/// <summary>
	/// 断开连接
	/// </summary>
	public const byte Disconnect = 2;
}
