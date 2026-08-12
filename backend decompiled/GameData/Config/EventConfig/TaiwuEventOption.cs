using System;
using System.Collections.Generic;
using GameData.Domains;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventOption;

namespace Config.EventConfig;

public class TaiwuEventOption
{
	public EventArgBox ArgBox;

	public sbyte Behavior = 0;

	public Func<string> GetReplacedContent;

	public Func<bool> OnOptionAvailableCheck;

	public Func<string> OnOptionSelect;

	public Func<bool> OnOptionVisibleCheck;

	public Func<List<string>> GetExtraFormatLanguageKeys;

	public List<TaiwuEventOptionConditionBase> OptionAvailableConditions;

	public List<OptionConsumeInfo> OptionConsumeInfos;

	public Dictionary<int, string> OptionConsumeAmountExpressions;

	public string OptionKey;

	public string OptionGuid;

	public (string EventGuid, string OptionGuid) RedirectOption;

	public sbyte DefaultState = 0;

	public EventScript Script;

	public EventConditionList VisibleConditions;

	public EventConditionList AvailableConditions;

	public bool OneTimeOnly;

	public bool Important;

	public string OptionContent { get; private set; }

	public bool WasSelected
	{
		get
		{
			return DomainManager.TaiwuEvent.WasTemporaryOptionSelected(OptionGuid);
		}
		set
		{
			DomainManager.TaiwuEvent.SetTemporaryOptionSelected(OptionGuid, value);
		}
	}

	public bool HasRedirect => !string.IsNullOrEmpty(RedirectOption.EventGuid) && !string.IsNullOrEmpty(RedirectOption.OptionGuid);

	public bool IsVisible
	{
		get
		{
			if (OnOptionVisibleCheck != null && !OnOptionVisibleCheck())
			{
				return false;
			}
			EventScriptRuntime runtime = DomainManager.TaiwuEvent.ScriptRuntime;
			if (!runtime.CheckConditionList(VisibleConditions, ArgBox))
			{
				return false;
			}
			if (OneTimeOnly && WasSelected)
			{
				return false;
			}
			if (HasRedirect)
			{
				TaiwuEventOption redirectOption = GetRedirectOption();
				if (!redirectOption.IsVisible)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool IsAvailable => CheckAvailableConditionsFromCode() && CheckAvailableConditionsFromScript() && CheckAvailableConditionsFromCodeConfig() && CheckAvailableConditionsFromRedirect();

	public void SetContent(string content)
	{
		OptionContent = content;
	}

	public string Select(EventScriptRuntime scriptRuntime)
	{
		if (DefaultState == 1)
		{
			WasSelected = true;
		}
		string scriptRet = TryExecuteScript(scriptRuntime);
		string ret = OnOptionSelect?.Invoke();
		ret = (string.IsNullOrEmpty(ret) ? scriptRet : ret);
		if (HasRedirect)
		{
			TaiwuEventOption redirectOption = GetRedirectOption();
			string redirectRet = redirectOption.Select(scriptRuntime);
			ret = (string.IsNullOrEmpty(ret) ? redirectRet : ret);
		}
		return ret;
	}

	public string TryExecuteScript(EventScriptRuntime scriptRuntime)
	{
		if (Script == null)
		{
			return string.Empty;
		}
		return scriptRuntime.ExecuteScript(Script, ArgBox);
	}

	public bool CheckAvailableConditionsFromCode()
	{
		return OnOptionAvailableCheck == null || OnOptionAvailableCheck();
	}

	public bool CheckAvailableConditionsFromScript()
	{
		return DomainManager.TaiwuEvent.ScriptRuntime.CheckConditionList(AvailableConditions, ArgBox);
	}

	public bool CheckAvailableConditionsFromCodeConfig()
	{
		if (OptionAvailableConditions == null)
		{
			return true;
		}
		for (int i = 0; i < OptionAvailableConditions.Count; i++)
		{
			TaiwuEventOptionConditionBase condition = OptionAvailableConditions[i];
			if (condition.OrConditionCore != null && condition.OrConditionCore.Count > 0)
			{
				bool anyTrue = false;
				for (int j = 0; j < condition.OrConditionCore.Count; j++)
				{
					OptionAvailableInfoMinimumElement element = default(OptionAvailableInfoMinimumElement);
					OptionConditionModifier.ModifyCondition(ref element, condition.OrConditionCore[i], ArgBox);
					if (element.Pass)
					{
						anyTrue = true;
						break;
					}
				}
				if (!anyTrue)
				{
					return false;
				}
			}
			else
			{
				OptionAvailableInfoMinimumElement element2 = default(OptionAvailableInfoMinimumElement);
				OptionConditionModifier.ModifyCondition(ref element2, condition, ArgBox);
				if (!element2.Pass)
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool CheckAvailableConditionsFromRedirect()
	{
		if (!HasRedirect)
		{
			return true;
		}
		TaiwuEventOption redirectOption = GetRedirectOption();
		return redirectOption.IsAvailable;
	}

	public TaiwuEventOption GetRedirectOption()
	{
		TaiwuEvent redirectEvent = DomainManager.TaiwuEvent.GetEvent(RedirectOption.EventGuid);
		if (redirectEvent == null)
		{
			throw new Exception($"Unable to find redirect event {RedirectOption.EventGuid} for option {OptionContent}.");
		}
		redirectEvent.ArgBox = ArgBox;
		TaiwuEventOption option = redirectEvent.EventConfig.GetOptionByGuid(RedirectOption.OptionGuid);
		if (option == null)
		{
			throw new Exception($"Unable to find redirect event {RedirectOption.EventGuid} option {RedirectOption.OptionGuid} for option {OptionContent}.");
		}
		return option;
	}
}
