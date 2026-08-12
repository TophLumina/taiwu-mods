using System.Collections.Generic;
using GameData.Common;
using GameData.Domains;
using GameData.Utilities;

namespace GameData.GameDataBridge;

public class DataMonitorManager
{
	private readonly HashSet<DataUid> _monitoredData = new HashSet<DataUid>();

	private readonly HashSet<DataUid> _initialMonitoring = new HashSet<DataUid>();

	private readonly HashSet<DataUid> _dataWithPostModificationHandlers = new HashSet<DataUid>();

	private readonly List<DataUid> _handledData = new List<DataUid>();

	private readonly HashSet<DataUid> _dataWithAllHandlersRemoved = new HashSet<DataUid>();

	private readonly HashSet<DataUid> _dataWithInitialHandler = new HashSet<DataUid>();

	public void MonitorData(DataUid uid)
	{
		_monitoredData.Add(uid);
		_initialMonitoring.Add(uid);
		BaseGameDataDomain domain = DomainManager.Domains[uid.DomainId];
		domain.OnMonitorData(uid.DataId, uid.SubId0, uid.SubId1, monitoring: true);
	}

	public void UnMonitorData(DataUid uid)
	{
		_monitoredData.Remove(uid);
		_initialMonitoring.Remove(uid);
		BaseGameDataDomain domain = DomainManager.Domains[uid.DomainId];
		domain.OnMonitorData(uid.DataId, uid.SubId0, uid.SubId1, monitoring: false);
	}

	public void AddPostModificationHandler(DataUid uid, string handlerKey, DataModificationHandler handler)
	{
		if (!_dataWithPostModificationHandlers.Contains(uid))
		{
			_dataWithInitialHandler.Add(uid);
		}
		_dataWithAllHandlersRemoved.Remove(uid);
		BaseGameDataDomain domain = DomainManager.Domains[uid.DomainId];
		domain.AddPostModificationHandler(uid, handlerKey, handler);
	}

	public void RemovePostModificationHandler(DataUid uid, string handlerKey)
	{
		BaseGameDataDomain domain = DomainManager.Domains[uid.DomainId];
		if (domain.RemovePostModificationHandler(uid, handlerKey))
		{
			_dataWithAllHandlersRemoved.Add(uid);
			_dataWithInitialHandler.Remove(uid);
		}
	}

	public void Clear()
	{
		foreach (DataUid uid in _monitoredData)
		{
			BaseGameDataDomain domain = DomainManager.Domains[uid.DomainId];
			domain.OnMonitorData(uid.DataId, uid.SubId0, uid.SubId1, monitoring: false);
		}
		foreach (DataUid uid2 in _dataWithPostModificationHandlers)
		{
			BaseGameDataDomain domain2 = DomainManager.Domains[uid2.DomainId];
			domain2.RemovePostModificationHandlers(uid2);
		}
		foreach (DataUid uid3 in _dataWithInitialHandler)
		{
			BaseGameDataDomain domain3 = DomainManager.Domains[uid3.DomainId];
			domain3.RemovePostModificationHandlers(uid3);
		}
		_monitoredData.Clear();
		_initialMonitoring.Clear();
		_dataWithPostModificationHandlers.Clear();
		_dataWithInitialHandler.Clear();
		_dataWithAllHandlersRemoved.Clear();
	}

	public void CheckMonitoredData()
	{
		NotificationCollection pendingNotifications = GameDataBridge.GetPendingNotifications();
		RawDataPool dataPool = pendingNotifications.DataPool;
		List<Notification> notifications = pendingNotifications.Notifications;
		DataContext context = DataContextManager.GetCurrentThreadDataContext();
		_handledData.Clear();
		if (_dataWithAllHandlersRemoved.Count > 0)
		{
			foreach (DataUid uid in _dataWithAllHandlersRemoved)
			{
				_dataWithPostModificationHandlers.Remove(uid);
			}
			_dataWithAllHandlersRemoved.Clear();
		}
		if (_dataWithInitialHandler.Count > 0)
		{
			foreach (DataUid uid2 in _dataWithInitialHandler)
			{
				_dataWithPostModificationHandlers.Add(uid2);
			}
			_dataWithInitialHandler.Clear();
		}
		foreach (DataUid uid3 in _dataWithPostModificationHandlers)
		{
			BaseGameDataDomain domain = DomainManager.Domains[uid3.DomainId];
			if (domain.IsModifiedWrapper(uid3.DataId, uid3.SubId0, uid3.SubId1))
			{
				_handledData.Add(uid3);
			}
		}
		if (_initialMonitoring.Count <= 0)
		{
			foreach (DataUid uid4 in _monitoredData)
			{
				BaseGameDataDomain domain2 = DomainManager.Domains[uid4.DomainId];
				int offset = domain2.CheckModified(uid4.DataId, uid4.SubId0, uid4.SubId1, dataPool);
				if (offset >= 0)
				{
					notifications.Add(Notification.CreateDataModification(uid4, offset));
				}
			}
		}
		else
		{
			foreach (DataUid uid5 in _initialMonitoring)
			{
				BaseGameDataDomain domain3 = DomainManager.Domains[uid5.DomainId];
				int offset2 = domain3.GetData(uid5.DataId, uid5.SubId0, uid5.SubId1, dataPool, resetModified: true);
				if (offset2 < 0)
				{
					AdaptableLog.TagWarning("CheckMonitoredData", $"Failed to get initial monitoring data {uid5}.");
				}
				else
				{
					notifications.Add(Notification.CreateDataModification(uid5, offset2));
				}
			}
			foreach (DataUid uid6 in _monitoredData)
			{
				if (!_initialMonitoring.Contains(uid6))
				{
					BaseGameDataDomain domain4 = DomainManager.Domains[uid6.DomainId];
					int offset3 = domain4.CheckModified(uid6.DataId, uid6.SubId0, uid6.SubId1, dataPool);
					if (offset3 >= 0)
					{
						notifications.Add(Notification.CreateDataModification(uid6, offset3));
					}
				}
			}
			_initialMonitoring.Clear();
		}
		foreach (DataUid uid7 in _handledData)
		{
			BaseGameDataDomain domain5 = DomainManager.Domains[uid7.DomainId];
			domain5.ResetModifiedWrapper(uid7.DataId, uid7.SubId0, uid7.SubId1);
			domain5.ExecutePostModificationHandlers(context, uid7);
		}
	}
}
