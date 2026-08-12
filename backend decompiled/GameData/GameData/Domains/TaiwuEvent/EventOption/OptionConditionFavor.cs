using System;
using Config;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionFavor : TaiwuEventOptionConditionBase
{
	public readonly sbyte FavorType;

	public readonly Func<int, int, sbyte, bool> ConditionChecker;

	private readonly string[] FavorTypeKeys = new string[13]
	{
		"LK_Favor_Type_0", "LK_Favor_Type_1", "LK_Favor_Type_2", "LK_Favor_Type_3", "LK_Favor_Type_4", "LK_Favor_Type_5", "LK_Favor_Type_6", "LK_Favor_Type_7", "LK_Favor_Type_8", "LK_Favor_Type_9",
		"LK_Favor_Type_10", "LK_Favor_Type_11", "LK_Favor_Type_12"
	};

	public OptionConditionFavor(short id, sbyte favorType, Func<int, int, sbyte, bool> checkFunc)
		: base(id)
	{
		FavorType = favorType;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		int charId = -1;
		if (box.Get(EventTriggerParameter.DefValue.CharacterId, ref charId))
		{
			return ConditionChecker(charId, DomainManager.Taiwu.GetTaiwuCharId(), FavorType);
		}
		return false;
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, new string[1] { "<Language Key=" + FavorTypeKeys[FavorType - -6] + "/>" });
	}
}
