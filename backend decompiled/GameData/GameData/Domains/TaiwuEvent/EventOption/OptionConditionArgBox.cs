using System;
using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionArgBox : TaiwuEventOptionConditionBase
{
	public readonly List<string> _argBoxKeys;

	public readonly Func<EventArgBox, bool> ConditionChecker;

	public OptionConditionArgBox(short id, List<string> argBoxKeys, Func<EventArgBox, bool> checker)
		: base(id)
	{
		_argBoxKeys = argBoxKeys;
		ConditionChecker = checker;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		if (box == null)
		{
			return false;
		}
		return ConditionChecker(box);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		List<string> res = new List<string>();
		foreach (string key in _argBoxKeys)
		{
			string s = "";
			box.Get(key, ref s);
			res.Add(s);
		}
		return (Id, res.ToArray());
	}
}
