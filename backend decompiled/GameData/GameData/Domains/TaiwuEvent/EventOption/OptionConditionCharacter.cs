using System;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCharacter : TaiwuEventOptionConditionBase
{
	public readonly Func<GameData.Domains.Character.Character, bool> ConditionChecker;

	public OptionConditionCharacter(short id, Func<GameData.Domains.Character.Character, bool> checker)
		: base(id)
	{
		ConditionChecker = checker;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		if (box == null)
		{
			return false;
		}
		return ConditionChecker(box.GetCharacter());
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int charId = box.GetInt(EventTriggerParameter.DefValue.CharacterId);
		(string, string) nameTuple = DomainManager.Character.GetNameRelatedData(charId).GetMonasticTitleOrDisplayName(charId == DomainManager.Taiwu.GetTaiwuCharId());
		return (Id, new string[1] { nameTuple.Item1 + nameTuple.Item2 });
	}
}
