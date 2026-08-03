using System;
using System.Collections.Generic;
using System.IO;
using GameData.Domains.TaiwuEvent.Enum;
using GameData.Utilities;

namespace Config.EventConfig;

public abstract class EventPackage
{
	protected List<TaiwuEventItem> EventList;

	public string NameSpace { get; protected set; }

	public string Author { get; protected set; }

	public string Group { get; protected set; }

	public string ModIdString { get; protected set; }

	public string Key => $"{NameSpace}_{Author}_{Group}";

	public List<TaiwuEventItem> GetEventsByType(EEventType eventType)
	{
		List<TaiwuEventItem> list = new List<TaiwuEventItem>();
		for (int i = 0; i < EventList.Count; i++)
		{
			EventList[i].Package = this;
			if (EventList[i].EventType == eventType)
			{
				list.Add(EventList[i]);
			}
		}
		return list;
	}

	public List<TaiwuEventItem> GetAllEvents()
	{
		return EventList;
	}

	public void SetModIdString(string modId)
	{
		ModIdString = modId;
	}

	public void InitLanguage(string languageFilePath)
	{
		if (!File.Exists(languageFilePath))
		{
			return;
		}
		Dictionary<string, List<string>> contentMap = new Dictionary<string, List<string>>();
		string guidLineStart = "- EventGuid : ";
		string contentLineStart = "-- EventContent :";
		string optionLineStart = "-- Option_";
		string[] lines = File.ReadAllLines(languageFilePath);
		string eventGuid = string.Empty;
		List<string> list = null;
		bool contentHandlingFlag = false;
		for (int i = 0; i < lines.Length; i++)
		{
			string line = lines[i].Trim();
			if (line.StartsWith(guidLineStart))
			{
				if (list != null && !string.IsNullOrEmpty(eventGuid) && !contentMap.TryAdd(eventGuid, list))
				{
					AdaptableLog.TagWarning("EventLanguage", $"Duplicate event guid {eventGuid} at {languageFilePath} line {i}.\n{line}");
				}
				else
				{
					eventGuid = line.Replace(guidLineStart, string.Empty);
					list = new List<string>();
				}
			}
			else
			{
				if (string.IsNullOrEmpty(eventGuid) || list == null)
				{
					continue;
				}
				if (!line.StartsWith("-") && list.Count > 0)
				{
					string lineData = line.Trim();
					if (contentHandlingFlag && string.IsNullOrEmpty(lineData))
					{
						lineData = "\n";
					}
					List<string> list2 = list;
					list2[list2.Count - 1] += lineData;
				}
				else if (line.StartsWith(contentLineStart))
				{
					contentHandlingFlag = true;
					list.Add(line.Replace(contentLineStart, string.Empty).Trim());
				}
				else if (line.StartsWith(optionLineStart))
				{
					contentHandlingFlag = false;
					list.Add(line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 1));
				}
			}
		}
		if (!string.IsNullOrEmpty(eventGuid) && list != null && !contentMap.TryAdd(eventGuid, list))
		{
			AdaptableLog.TagWarning("EventLanguage", $"Duplicate event guid {eventGuid} at {languageFilePath}.");
		}
		foreach (TaiwuEventItem eventItem in EventList)
		{
			if (contentMap.TryGetValue(eventItem.Guid.ToString(), out var contentList) && contentList.Count > 0)
			{
				eventItem.SetLanguage(contentList.ToArray());
				eventItem.Package = this;
			}
		}
	}
}
