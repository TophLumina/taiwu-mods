using System.Runtime.InteropServices;

namespace GameData.GameDataBridge;

/// <summary>
/// 表现模块向数据模块发送的数据操作.
///
/// 操作分类:
/// - 数据监听: domainId, dataId, subId0, subId1.
/// - 移除数据监听: domainId, dataId, subId0, subId1.
/// - 数据修改: domainId, dataId, subId0, subId1, valueOffset.
/// - 方法调用: domainId, methodId, argsCount, argsOffset, listenerId.
///
/// 目前的内存布局兼容 32 位和 64 位系统.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Operation
{
	/// <summary>
	/// 通用字段 - 操作类型
	/// </summary>
	[FieldOffset(0)]
	public byte Type;

	/// <summary>
	/// 通用字段 - 数据域 ID
	/// </summary>
	[FieldOffset(4)]
	public ushort DomainId;

	/// <summary>
	/// 数据监听 / 移除数据监听 / 数据修改 - 数据 ID
	/// </summary>
	[FieldOffset(6)]
	public ushort DataId;

	/// <summary>
	/// 数据监听 / 移除数据监听 / 数据修改 - 第一级数据子 ID
	/// </summary>
	[FieldOffset(8)]
	public ulong SubId0;

	/// <summary>
	/// 数据监听 / 移除数据监听 / 数据修改 - 第二级数据子 ID
	/// </summary>
	[FieldOffset(16)]
	public uint SubId1;

	/// <summary>
	/// 数据修改 - 值在数据池中的偏移
	/// </summary>
	[FieldOffset(20)]
	public int ValueOffset;

	/// <summary>
	/// 方法调用 - 方法 ID
	/// </summary>
	[FieldOffset(6)]
	public ushort MethodId;

	/// <summary>
	/// 方法调用 - 参数个数
	/// </summary>
	[FieldOffset(8)]
	public int ArgsCount;

	/// <summary>
	/// 方法调用 - 参数在数据池中的偏移
	/// </summary>
	[FieldOffset(12)]
	public int ArgsOffset;

	/// <summary>
	/// 方法调用 - 监听者 ID
	/// </summary>
	[FieldOffset(16)]
	public int ListenerId;

	/// <summary>
	/// 表现模块向数据模块发送的数据操作 - 数据监听
	/// </summary>
	public static Operation CreateDataMonitor(ushort domainId, ushort dataId, ulong subId0, uint subId1)
	{
		Operation operation = default(Operation);
		operation.Type = 0;
		operation.DomainId = domainId;
		operation.MethodId = 0;
		operation.DataId = dataId;
		operation.ArgsCount = 0;
		operation.ArgsOffset = 0;
		operation.SubId0 = subId0;
		operation.ListenerId = 0;
		operation.SubId1 = subId1;
		operation.ValueOffset = 0;
		return operation;
	}

	/// <summary>
	/// 表现模块向数据模块发送的数据操作 - 移除数据监听
	/// </summary>
	public static Operation CreateDataUnMonitor(ushort domainId, ushort dataId, ulong subId0, uint subId1)
	{
		Operation operation = default(Operation);
		operation.Type = 1;
		operation.DomainId = domainId;
		operation.MethodId = 0;
		operation.DataId = dataId;
		operation.ArgsCount = 0;
		operation.ArgsOffset = 0;
		operation.SubId0 = subId0;
		operation.ListenerId = 0;
		operation.SubId1 = subId1;
		operation.ValueOffset = 0;
		return operation;
	}

	/// <summary>
	/// 表现模块向数据模块发送的数据操作 - 数据修改
	/// </summary>
	public static Operation CreateDataModification(ushort domainId, ushort dataId, ulong subId0, uint subId1, int valueOffset)
	{
		Operation operation = default(Operation);
		operation.Type = 2;
		operation.DomainId = domainId;
		operation.MethodId = 0;
		operation.DataId = dataId;
		operation.ArgsCount = 0;
		operation.ArgsOffset = 0;
		operation.SubId0 = subId0;
		operation.ListenerId = 0;
		operation.SubId1 = subId1;
		operation.ValueOffset = valueOffset;
		return operation;
	}

	/// <summary>
	/// 表现模块向数据模块发送的数据操作 - 方法调用
	/// </summary>
	public static Operation CreateMethodCall(int listenerId, ushort domainId, ushort methodId, int argsCount, int argsOffset)
	{
		Operation operation = default(Operation);
		operation.Type = 3;
		operation.DomainId = domainId;
		operation.DataId = 0;
		operation.MethodId = methodId;
		operation.SubId0 = 0uL;
		operation.ArgsCount = argsCount;
		operation.ArgsOffset = argsOffset;
		operation.SubId1 = 0u;
		operation.ListenerId = listenerId;
		operation.ValueOffset = 0;
		return operation;
	}
}
