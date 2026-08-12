using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.GameDataBridge;

/// <summary>
/// 数据模块向表现模块发送的通知集合
/// </summary>
public struct NotificationCollection
{
	/// <summary>
	/// 通知集合
	/// </summary>
	public readonly List<Notification> Notifications;

	/// <summary>
	/// 数据池
	/// </summary>
	public readonly RawDataPool DataPool;

	/// <summary>
	/// 数据模块向表现模块发送的通知集合
	/// </summary>
	/// <param name="defaultCapacity"></param>
	public NotificationCollection(int defaultCapacity)
	{
		Notifications = new List<Notification>();
		DataPool = new RawDataPool(defaultCapacity);
	}

	/// <summary>
	/// 数据模块向表现模块发送的通知集合
	/// </summary>
	/// <param name="notifications"></param>
	/// <param name="dataPool"></param>
	public NotificationCollection(List<Notification> notifications, RawDataPool dataPool)
	{
		Notifications = notifications;
		DataPool = dataPool;
	}
}
