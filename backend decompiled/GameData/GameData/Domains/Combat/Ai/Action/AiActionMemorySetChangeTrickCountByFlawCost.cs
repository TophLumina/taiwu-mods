using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySetChangeTrickCountByFlawCost)]
public class AiActionMemorySetChangeTrickCountByFlawCost : AiActionMemorySetCharValueBase
{
	public AiActionMemorySetChangeTrickCountByFlawCost(IReadOnlyList<string> strings, IReadOnlyList<int> ints)
		: base(strings, ints)
	{
	}

	protected override int GetCharValue(CombatCharacter checkChar)
	{
		return checkChar.GetChangeTrickCount() / CFormulaHelper.CalcCostChangeTrickCount(checkChar, EFlawOrAcupointType.Flaw);
	}
}
