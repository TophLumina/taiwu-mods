using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.ConsummateLevelMoreOrEqual)]
public class AiConditionConsummateLevelMoreOrEqual : AiConditionCheckCharBase
{
	private readonly int _consummateLevel;

	public AiConditionConsummateLevelMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_consummateLevel = ints[0];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.IsAlly || checkChar.GetCharacter().GetConsummateLevel() >= _consummateLevel;
	}
}
