using System;
using System.Collections.Generic;
using Config;
using Config.EventConfig;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.EventManager;

public class EventManager
{
	private readonly EventTrigger[] _headEventCollections;

	private readonly Dictionary<string, TaiwuEvent> _eventDictionary;

	public EventManager()
	{
		_eventDictionary = new Dictionary<string, TaiwuEvent>();
		_headEventCollections = new EventTrigger[EventTriggerType.Instance.Count];
		for (int i = 0; i < _headEventCollections.Length; i++)
		{
			_headEventCollections[i] = new EventTrigger();
		}
	}

	public EventTrigger GetTrigger(short triggerType)
	{
		if (!_headEventCollections.CheckIndex(triggerType))
		{
			throw new ArgumentOutOfRangeException("triggerType", triggerType, $"valid range is [0, {_headEventCollections.Length})");
		}
		return _headEventCollections[triggerType];
	}

	public TaiwuEvent GetEvent(string eventGuid)
	{
		return _eventDictionary.GetValueOrDefault(eventGuid);
	}

	public void HandleEventPackage(EventPackage package)
	{
		List<TaiwuEventItem> eventItems = package.GetAllEvents();
		for (int i = 0; i < eventItems.Count; i++)
		{
			TaiwuEventItem eventItem = eventItems[i];
			string guid = eventItem.Guid.ToString();
			TaiwuEvent taiwuEvent = new TaiwuEvent
			{
				EventGuid = guid,
				EventConfig = eventItem,
				ExtendEventOptions = new List<(string, string)>()
			};
			if (!eventItem.IsHeadEvent && eventItem.TriggerType >= 0)
			{
				AdaptableLog.Warning($"event {eventItem.Guid} selected a TriggerType but IsHeadEvent set as false,this means TriggerType will not take effect");
			}
			if (!_eventDictionary.TryAdd(guid, taiwuEvent))
			{
				AdaptableLog.Warning($"Duplicate event {eventItem.Guid} detected.");
			}
			else if (eventItem.IsHeadEvent)
			{
				try
				{
					EventTrigger trigger = GetTrigger(eventItem.TriggerType);
					trigger.RegisterEvent(taiwuEvent);
				}
				catch (Exception ex)
				{
					AdaptableLog.Warning($"Error loading event {eventItem.Guid}: {ex.Message}");
				}
			}
		}
		foreach (KeyValuePair<string, TaiwuEvent> pair in _eventDictionary)
		{
			pair.Value.EventConfig.TaiwuEvent = pair.Value;
		}
	}

	public void UnloadPackage(EventPackage package)
	{
		List<TaiwuEventItem> events = package.GetAllEvents();
		if (events == null || events.Count <= 0)
		{
			return;
		}
		foreach (TaiwuEventItem toRemoveEvent in events)
		{
			if (_eventDictionary.Remove(toRemoveEvent.Guid.ToString(), out var taiwuEvent) && taiwuEvent.EventConfig.TriggerType >= 0)
			{
				EventTrigger trigger = GetTrigger(taiwuEvent.EventConfig.TriggerType);
				trigger.UnregisterEvent(taiwuEvent);
			}
		}
	}

	public void ClearExtendOptions()
	{
		foreach (KeyValuePair<string, TaiwuEvent> item in _eventDictionary)
		{
			item.Value.ExtendEventOptions?.Clear();
		}
	}

	public void Reset()
	{
		_eventDictionary.Clear();
		EventTrigger[] headEventCollections = _headEventCollections;
		foreach (EventTrigger trigger in headEventCollections)
		{
			trigger.Clear();
		}
	}
}
