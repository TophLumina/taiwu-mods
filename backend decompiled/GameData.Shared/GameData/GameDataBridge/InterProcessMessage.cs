namespace GameData.GameDataBridge;

/// <summary>
/// 进程间通信相关常量
/// </summary>
public static class InterProcessMessage
{
	/// <summary>
	/// 消息头长度 (字节)
	/// </summary>
	public const int HeaderSize = 5;

	/// <summary>
	/// 错误消息最大长度 (字节)
	/// </summary>
	public const int ErrorMessageMaxSize = 65000;

	/// <summary>
	/// 警告消息最大长度（字节）
	/// </summary>
	public const int WarningMessageMaxSize = 65000;

	/// <summary>
	/// 连接超时时长
	/// </summary>
	public const int ConnectionTimeout = 300000;

	/// <summary>
	/// Socket 端口号
	/// </summary>
	public const int SocketPort = 51827;
}
