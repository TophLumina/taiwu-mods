using System;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionCharacterShave : TaiwuEventOptionConditionBase
{
	public readonly Func<GameData.Domains.Character.Character, bool> ConditionChecker;

	public OptionConditionCharacterShave(short id, Func<GameData.Domains.Character.Character, bool> checker)
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
		GameData.Domains.Character.Character character = box.GetCharacter();
		int appraisalRequirement = (character.GetOrganizationInfo().InteractionGrade + 1) * 50 + 50;
		return (Id, new string[1] { appraisalRequirement.ToString() });
	}
}
