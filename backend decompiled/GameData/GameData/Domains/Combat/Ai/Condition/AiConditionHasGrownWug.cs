using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.HasGrownWug)]
public class AiConditionHasGrownWug : AiConditionCheckCharBase
{
	private readonly sbyte _wugType;

	public AiConditionHasGrownWug(IReadOnlyList<int> ints)
		: base(ints)
	{
		_wugType = (sbyte)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		short templateId = ItemDomain.GetWugTemplateId(_wugType, 4);
		return checkChar.GetCharacter().GetEatingItems().IndexOfWug(templateId) >= 0;
	}
}
