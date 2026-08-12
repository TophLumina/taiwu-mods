using System;
using Config;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCooldown : TaiwuEventOptionConditionBase
{
	public readonly string BoxKeyPrefix;

	public readonly sbyte CoolDownMonthCount;

	public readonly Func<string, int, sbyte, bool> ConditionChecker;

	public OptionConditionCooldown(short id, string coolDownBoxKey, sbyte coolDownArg, Func<string, int, sbyte, bool> checkFunc)
		: base(id)
	{
		BoxKeyPrefix = coolDownBoxKey;
		CoolDownMonthCount = coolDownArg;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		int charId = -1;
		if (box.Get(EventTriggerParameter.DefValue.CharacterId, ref charId))
		{
			return ConditionChecker(BoxKeyPrefix, charId, CoolDownMonthCount);
		}
		return false;
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, new string[1] { CoolDownMonthCount.ToString() });
	}
}
