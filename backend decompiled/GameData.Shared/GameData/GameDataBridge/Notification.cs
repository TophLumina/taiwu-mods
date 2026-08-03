using System.Runtime.InteropServices;
using GameData.Common;

namespace GameData.GameDataBridge;

/// <summary>
/// 数据模块向表现模块发送的通知
///
/// 通知分类:
/// - 数据更改: Uid, ValueOffset.
/// - 方法调用返回: ListenerId, DomainId, MethodId, ValueOffset.
/// - 推送给表现模块的事件: DisplayEventType, ValueOffset.
///
/// 目前的内存布局兼容 32 位和 64 位系统.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Notification
{
	/// <summary>
	/// 通用字段 - 通知类型
	/// </summary>
	[FieldOffset(0)]
	public byte Type;

	/// <summary>
	/// 数据更改 - 数据唯一 ID
	/// </summary>
	[FieldOffset(4)]
	public DataUid Uid;

	/// <summary>
	/// 方法调用返回 - 监听者 ID
	/// </summary>
	[FieldOffset(4)]
	public int ListenerId;

	/// <summary>
	/// 方法调用返回 - 数据域 ID
	/// </summary>
	[FieldOffset(8)]
	public ushort DomainId;

	/// <summary>
	/// 方法调用返回 - 方法 ID
	/// </summary>
	[FieldOffset(10)]
	public ushort MethodId;

	/// <summary>
	/// 推送给表现模块的事件 - 事件类型.
	/// <see cref="T:GameData.GameDataBridge.DisplayEventType" />
	/// </summary>
	[FieldOffset(4)]
	public ushort DisplayEventType;

	/// <summary>
	/// 通用字段 - 值在数据池中的偏移
	/// </summary>
	[FieldOffset(20)]
	public int ValueOffset;

	/// <summary>
	/// 数据模块向表现模块发送的通知 - 数据更改
	/// </summary>
	public static Notification CreateDataModification(DataUid uid, int valueOffset)
	{
		Notification notification = default(Notification);
		notification.Type = 0;
		notification.ListenerId = 0;
		notification.DomainId = 0;
		notification.MethodId = 0;
		notification.DisplayEventType = 0;
		notification.Uid = uid;
		notification.ValueOffset = valueOffset;
		return notification;
	}

	/// <summary>
	/// 数据模块向表现模块发送的通知 - 方法调用返回
	/// </summary>
	public static Notification CreateMethodReturn(int listenerId, ushort domainId, ushort methodId, int returnValueOffset)
	{
		Notification notification = default(Notification);
		notification.Type = 1;
		notification.Uid = default(DataUid);
		notification.DisplayEventType = 0;
		notification.ListenerId = listenerId;
		notification.DomainId = domainId;
		notification.MethodId = methodId;
		notification.ValueOffset = returnValueOffset;
		return notification;
	}

	/// <summary>
	/// 数据模块向表现模块发送的通知 - 表现模块事件
	/// </summary>
	public static Notification CreateDisplayEvent(DisplayEventType displayEventType, int valueOffset)
	{
		Notification notification = default(Notification);
		notification.Type = 2;
		notification.Uid = default(DataUid);
		notification.ListenerId = 0;
		notification.DomainId = 0;
		notification.MethodId = 0;
		notification.DisplayEventType = (ushort)displayEventType;
		notification.ValueOffset = valueOffset;
		return notification;
	}
}
