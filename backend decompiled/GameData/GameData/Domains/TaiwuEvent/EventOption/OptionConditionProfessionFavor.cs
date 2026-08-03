using System;
using Config;
using GameData.Domains.Character;
using GameData.Domains.TaiwuEvent.EventHelper;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionProfessionFavor : TaiwuEventOptionConditionBase
{
	public readonly Func<int, int, bool> ConditionChecker;

	private readonly string[] FavorTypeKeys = new string[13]
	{
		"LK_Favor_Type_0", "LK_Favor_Type_1", "LK_Favor_Type_2", "LK_Favor_Type_3", "LK_Favor_Type_4", "LK_Favor_Type_5", "LK_Favor_Type_6", "LK_Favor_Type_7", "LK_Favor_Type_8", "LK_Favor_Type_9",
		"LK_Favor_Type_10", "LK_Favor_Type_11", "LK_Favor_Type_12"
	};

	public OptionConditionProfessionFavor(short id, Func<int, int, bool> checkFunc)
		: base(id)
	{
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		int charId = -1;
		if (box.Get(EventTriggerParameter.DefValue.CharacterId, ref charId))
		{
			return ConditionChecker(charId, DomainManager.Taiwu.GetTaiwuCharId());
		}
		return false;
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int charId = -1;
		if (box.Get(EventTriggerParameter.DefValue.CharacterId, ref charId))
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			sbyte behaviorType = character.GetBehaviorType();
			sbyte favorType = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetProfessionFavorabilityType(behaviorType);
			return (Id, new string[1] { "<Language Key=" + FavorTypeKeys[favorType - -6] + "/>" });
		}
		return (Id, new string[1] { $"<Language Key={6}/>" });
	}
}
