using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.HasKingWug)]
public class AiConditionHasKingWug : AiConditionCheckCharBase
{
	private readonly sbyte _wugType;

	public AiConditionHasKingWug(IReadOnlyList<int> ints)
		: base(ints)
	{
		_wugType = (sbyte)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		short templateId = ItemDomain.GetWugTemplateId(_wugType, 5);
		return checkChar.GetCharacter().GetEatingItems().IndexOfWug(templateId) >= 0;
	}
}
