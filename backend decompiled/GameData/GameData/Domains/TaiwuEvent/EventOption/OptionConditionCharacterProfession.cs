using System;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCharacterProfession : TaiwuEventOptionConditionBase
{
	public readonly Func<GameData.Domains.Character.Character, int, bool> ConditionChecker;

	public int ProfessionId;

	public OptionConditionCharacterProfession(short id, int professionId, Func<GameData.Domains.Character.Character, int, bool> checker)
		: base(id)
	{
		ConditionChecker = checker;
		ProfessionId = professionId;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		if (box == null)
		{
			return false;
		}
		return ConditionChecker(box.GetCharacter(), ProfessionId);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int charId = box.GetInt(EventTriggerParameter.DefValue.CharacterId);
		(string, string) nameTuple = DomainManager.Character.GetNameRelatedData(charId).GetDisplayName(charId == DomainManager.Taiwu.GetTaiwuCharId());
		return (Id, new string[2]
		{
			nameTuple.Item1 + nameTuple.Item2,
			Profession.Instance[ProfessionId].Name
		});
	}
}
