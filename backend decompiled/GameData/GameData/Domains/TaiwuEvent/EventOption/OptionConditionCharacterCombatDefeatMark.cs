using System;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCharacterCombatDefeatMark : TaiwuEventOptionConditionBase
{
	public readonly Func<GameData.Domains.Character.Character, sbyte, bool> ConditionChecker;

	public sbyte CombatType;

	public OptionConditionCharacterCombatDefeatMark(short id, sbyte combatType, Func<GameData.Domains.Character.Character, sbyte, bool> checker)
		: base(id)
	{
		ConditionChecker = checker;
		CombatType = combatType;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		if (box == null)
		{
			return false;
		}
		return ConditionChecker(box.GetCharacter(), CombatType);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int charId = box.GetInt(EventTriggerParameter.DefValue.CharacterId);
		(string, string) nameTuple = DomainManager.Character.GetNameRelatedData(charId).GetDisplayName(charId == DomainManager.Taiwu.GetTaiwuCharId());
		byte relatedDefeatMarkCount = GlobalConfig.NeedDefeatMarkCount[CombatType];
		return (Id, new string[2]
		{
			nameTuple.Item1 + nameTuple.Item2,
			relatedDefeatMarkCount.ToString()
		});
	}
}
