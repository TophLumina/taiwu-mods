using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.GameDataBridge;

public struct NotificationCollection
{
	public readonly List<Notification> Notifications;

	public readonly RawDataPool DataPool;

	public NotificationCollection(int defaultCapacity)
	{
		Notifications = new List<Notification>();
		DataPool = new RawDataPool(defaultCapacity);
	}

	public NotificationCollection(List<Notification> notifications, RawDataPool dataPool)
	{
		Notifications = notifications;
		DataPool = dataPool;
	}
}
