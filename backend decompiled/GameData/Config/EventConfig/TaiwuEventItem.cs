using System;
using System.Collections.Generic;
using GameData.Domains;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.Enum;
using GameData.Domains.TaiwuEvent.EventOption;
using GameData.Utilities;

namespace Config.EventConfig;

public abstract class TaiwuEventItem
{
	public TaiwuEvent TaiwuEvent;

	public EventArgBox ArgBox;

	public string EventAudio;

	public string EventBackground;

	public string EventGroup;

	public TaiwuEventOption[] EventOptions;

	public short EventSortingOrder;

	public EEventType EventType;

	public bool ForceSingle;

	public Guid Guid;

	public bool IsHeadEvent;

	public string MainRoleKey;

	public sbyte MaskControl;

	public float MaskTweenTime;

	public EventPackage Package;

	public string TargetRoleKey;

	public short TriggerType;

	public EventScript Script;

	public EventConditionList Conditions;

	public Dictionary<short, EventBoolStateInfo> BoolStateDict;

	public string EscOptionKey;

	public string EventContent { get; private set; } = string.Empty;

	public TaiwuEventOption this[string key] => GetOptionByKey(key);

	public bool CheckCondition()
	{
		EventScriptRuntime runtime = DomainManager.TaiwuEvent.ScriptRuntime;
		if (!runtime.CheckConditionList(Conditions, ArgBox))
		{
			return false;
		}
		return OnCheckEventCondition();
	}

	public abstract bool OnCheckEventCondition();

	public abstract void OnEventEnter();

	public abstract void OnEventExit();

	public abstract string GetReplacedContentString();

	public virtual List<string> GetExtraFormatLanguageKeys()
	{
		return null;
	}

	public void ClearLanguage()
	{
		EventContent = string.Empty;
		if (EventOptions != null)
		{
			for (int i = 0; i < EventOptions.Length; i++)
			{
				EventOptions[i]?.ClearLanguage();
			}
		}
	}

	public void SetLanguage(string[] languageArray)
	{
		EventContent = languageArray[0].Replace("<NL>", "\n");
		for (int i = 1; i < languageArray.Length; i++)
		{
			string language = languageArray[i];
			if (!string.IsNullOrEmpty(language))
			{
				TaiwuEventOption option = EventOptions.GetOrDefault(i - 1);
				if (option == null)
				{
					AdaptableLog.TagWarning("EventLanguage", $"Unable to set language for null option: {Guid} option {i - 1} \n{language}.");
				}
				else
				{
					option.SetContent(language);
					EventOptions[i - 1].SetContent(languageArray[i].Replace("<NL>", "\n"));
				}
			}
		}
	}

	[Obsolete("应使用指令+公式消耗")]
	public void SetOptionConsume(string optionKeyOrGuid, sbyte consumeType, int consumeCount)
	{
		if (EventOptions == null)
		{
			return;
		}
		TaiwuEventOption[] eventOptions = EventOptions;
		foreach (TaiwuEventOption opt in eventOptions)
		{
			if ((!(optionKeyOrGuid == opt.OptionKey) && !(optionKeyOrGuid == opt.OptionGuid)) || opt.OptionConsumeInfos == null)
			{
				continue;
			}
			int i2 = opt.OptionConsumeInfos.Count;
			while (i2-- > 0)
			{
				if (opt.OptionConsumeInfos[i2].ConsumeType == consumeType)
				{
					OptionConsumeInfo item = opt.OptionConsumeInfos[i2];
					item.ConsumeCount = consumeCount;
					opt.OptionConsumeInfos[i2] = item;
					break;
				}
			}
			break;
		}
	}

	[Obsolete]
	public void SetOptionRead(string optionKey)
	{
		if (ArgBox == null)
		{
			throw new Exception("can not set option read when event is not showing!");
		}
		TaiwuEventOption option = this[optionKey];
		if (option == null)
		{
			throw new Exception($"{optionKey} is not an option of event {Guid}!");
		}
		string optionArgBoxKey = $"{Guid}_{optionKey}";
		ArgBox.Set(optionArgBoxKey, arg: true);
	}

	[Obsolete]
	public bool GetOptionRead(string optionKey)
	{
		if (ArgBox == null)
		{
			throw new Exception("can not get option read when event is not showing!");
		}
		TaiwuEventOption option = this[optionKey];
		if (option == null)
		{
			throw new Exception($"{optionKey} is not an option of event {Guid}!");
		}
		string optionArgBoxKey = $"{Guid}_{optionKey}";
		bool readState = false;
		ArgBox.Get(optionArgBoxKey, ref readState);
		return readState;
	}

	public TaiwuEventOption GetOptionByKey(string key)
	{
		TaiwuEventOption option = Array.Find(EventOptions, (TaiwuEventOption cell) => cell.OptionKey == key);
		if (option == null && TaiwuEvent != null && TaiwuEvent.ExtendEventOptions != null)
		{
			for (int i = 0; i < TaiwuEvent.ExtendEventOptions.Count; i++)
			{
				(string, string) tuple = TaiwuEvent.ExtendEventOptions[i];
				if (tuple.Item2 == key)
				{
					TaiwuEvent srcEvent = DomainManager.TaiwuEvent.GetEvent(tuple.Item1);
					srcEvent.ArgBox = ArgBox;
					option = srcEvent.EventConfig.GetOptionByKey(tuple.Item2);
					if (option != null)
					{
						break;
					}
				}
			}
		}
		return option;
	}

	public TaiwuEventOption GetOptionByGuid(string guid)
	{
		TaiwuEventOption option = Array.Find(EventOptions, (TaiwuEventOption cell) => cell.OptionGuid == guid);
		if (option != null)
		{
			return option;
		}
		if (TaiwuEvent == null || TaiwuEvent.ExtendEventOptions == null)
		{
			return null;
		}
		for (int i = 0; i < TaiwuEvent.ExtendEventOptions.Count; i++)
		{
			(string, string) tuple = TaiwuEvent.ExtendEventOptions[i];
			TaiwuEvent srcEvent = DomainManager.TaiwuEvent.GetEvent(tuple.Item1);
			option = srcEvent.EventConfig.GetOptionByGuid(guid);
			if (option != null)
			{
				srcEvent.ArgBox = ArgBox;
				break;
			}
		}
		return option;
	}
}
