namespace GameData.GameDataBridge;

/// <summary>
/// 表现模块向数据模块发送的数据操作的类型
/// </summary>
public static class OperationType
{
	/// <summary>
	/// 数据监听
	/// </summary>
	public const byte DataMonitor = 0;

	/// <summary>
	/// 移除数据监听
	/// </summary>
	public const byte DataUnMonitor = 1;

	/// <summary>
	/// 数据修改
	/// </summary>
	public const byte DataModification = 2;

	/// <summary>
	/// 方法调用
	/// </summary>
	public const byte MethodCall = 3;
}
