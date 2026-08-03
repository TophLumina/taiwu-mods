using System;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCharacterBehaviorType : TaiwuEventOptionConditionBase
{
	public readonly Func<GameData.Domains.Character.Character, sbyte, sbyte, bool> ConditionChecker;

	public sbyte BehaviorType1;

	public sbyte BehaviorType2;

	public OptionConditionCharacterBehaviorType(short id, sbyte type1, sbyte type2, Func<GameData.Domains.Character.Character, sbyte, sbyte, bool> checker)
		: base(id)
	{
		ConditionChecker = checker;
		BehaviorType1 = type1;
		BehaviorType2 = type2;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		if (box == null)
		{
			return false;
		}
		return ConditionChecker(box.GetCharacter(), BehaviorType1, BehaviorType2);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int charId = box.GetInt(EventTriggerParameter.DefValue.CharacterId);
		(string, string) nameTuple = DomainManager.Character.GetNameRelatedData(charId).GetDisplayName(charId == DomainManager.Taiwu.GetTaiwuCharId());
		return (Id, new string[3]
		{
			nameTuple.Item1 + nameTuple.Item2,
			$"<Language Key=LK_Goodness_{BehaviorType1}/>",
			$"<Language Key=LK_Goodness_{BehaviorType2}/>"
		});
	}
}
