using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionInt : TaiwuEventOptionConditionBase
{
	public readonly int Arg;

	public readonly Func<int, bool> ConditionChecker;

	public OptionConditionInt(short id, int arg, Func<int, bool> checkFunc)
		: base(id)
	{
		Arg = arg;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		return ConditionChecker(Arg);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, new string[1] { Arg.ToString() });
	}
}
