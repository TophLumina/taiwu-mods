using System;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCharacterValue : TaiwuEventOptionConditionBase
{
	public readonly Func<GameData.Domains.Character.Character, int, bool> ConditionChecker;

	public int Value;

	public OptionConditionCharacterValue(short id, int value, Func<GameData.Domains.Character.Character, int, bool> checker)
		: base(id)
	{
		ConditionChecker = checker;
		Value = value;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		if (box == null)
		{
			return false;
		}
		return ConditionChecker(box.GetCharacter(), Value);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int charId = box.GetInt(EventTriggerParameter.DefValue.CharacterId);
		(string, string) nameTuple = DomainManager.Character.GetNameRelatedData(charId).GetDisplayName(charId == DomainManager.Taiwu.GetTaiwuCharId());
		return (Id, new string[2]
		{
			nameTuple.Item1 + nameTuple.Item2,
			Value.ToString()
		});
	}
}
