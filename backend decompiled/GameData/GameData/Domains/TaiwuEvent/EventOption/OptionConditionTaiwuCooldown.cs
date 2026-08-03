using System;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionTaiwuCooldown : TaiwuEventOptionConditionBase
{
	public readonly string BoxKeyPrefix;

	public readonly sbyte CoolDownMonthCount;

	public readonly Func<string, int, sbyte, bool> ConditionChecker;

	public OptionConditionTaiwuCooldown(short id, string coolDownBoxKey, sbyte coolDownArg, Func<string, int, sbyte, bool> checkFunc)
		: base(id)
	{
		BoxKeyPrefix = coolDownBoxKey;
		CoolDownMonthCount = coolDownArg;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		return ConditionChecker(BoxKeyPrefix, taiwu.GetId(), CoolDownMonthCount);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, new string[1] { CoolDownMonthCount.ToString() });
	}
}
