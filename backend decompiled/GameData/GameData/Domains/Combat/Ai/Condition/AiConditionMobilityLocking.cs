using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MobilityLocking)]
public class AiConditionMobilityLocking : AiConditionCheckCharBase
{
	public AiConditionMobilityLocking(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return false;
	}
}
