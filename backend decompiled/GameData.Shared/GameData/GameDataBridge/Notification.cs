using System.Runtime.InteropServices;
using GameData.Common;

namespace GameData.GameDataBridge;

[StructLayout(LayoutKind.Explicit)]
public struct Notification
{
	[FieldOffset(0)]
	public byte Type;

	[FieldOffset(4)]
	public DataUid Uid;

	[FieldOffset(4)]
	public int ListenerId;

	[FieldOffset(8)]
	public ushort DomainId;

	[FieldOffset(10)]
	public ushort MethodId;

	[FieldOffset(4)]
	public ushort DisplayEventType;

	[FieldOffset(20)]
	public int ValueOffset;

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
