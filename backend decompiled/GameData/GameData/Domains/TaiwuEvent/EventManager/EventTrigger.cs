using System.Collections.Generic;
using GameData.Domains.TaiwuEvent.Enum;

namespace GameData.Domains.TaiwuEvent.EventManager;

public class EventTrigger
{
	private readonly List<TaiwuEvent> _headEventList = new List<TaiwuEvent>();

	public readonly EventArgBox ArgBox = new EventArgBox();

	public void RegisterEvent(TaiwuEvent taiwuEvent)
	{
		_headEventList.Add(taiwuEvent);
	}

	public void UnregisterEvent(TaiwuEvent taiwuEvent)
	{
		_headEventList.Remove(taiwuEvent);
	}

	public void Clear()
	{
		_headEventList.Clear();
	}

	public void OnEvent(EventArgBox argBox)
	{
		EventArgBox tmpArgBox = null;
		foreach (TaiwuEvent taiwuEvent in _headEventList)
		{
			if (CanTriggerEventType(taiwuEvent.EventConfig.EventType))
			{
				if (tmpArgBox == null)
				{
					tmpArgBox = DomainManager.TaiwuEvent.GetEventArgBox();
				}
				tmpArgBox.Clear();
				argBox.CloneTo(tmpArgBox);
				taiwuEvent.ArgBox = tmpArgBox;
				if (taiwuEvent.EventConfig.CheckCondition())
				{
					DomainManager.TaiwuEvent.AddTriggeredEvent(taiwuEvent);
					tmpArgBox = null;
				}
				else
				{
					taiwuEvent.ArgBox = null;
				}
			}
		}
	}

	private bool CanTriggerEventType(EEventType eventType)
	{
		return DomainManager.TutorialChapter.InGuiding == (eventType == EEventType.TutorialEvent);
	}
}
