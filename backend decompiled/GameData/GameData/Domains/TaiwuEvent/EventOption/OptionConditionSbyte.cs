using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionSbyte : TaiwuEventOptionConditionBase
{
	public readonly sbyte Arg;

	public readonly Func<sbyte, bool> ConditionChecker;

	public OptionConditionSbyte(short id, sbyte arg, Func<sbyte, bool> checker)
		: base(id)
	{
		Arg = arg;
		ConditionChecker = checker;
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
