using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AnyReserve)]
public class AiConditionAnyReserve : AiConditionCheckCharBase
{
	public AiConditionAnyReserve(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.GetCombatReserveData().AnyReserve;
	}
}
