using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.TrickCountMoreOrEqual)]
public class AiConditionTrickCountMoreOrEqual : AiConditionCheckCharBase
{
	private readonly sbyte _trickType;

	private readonly int _trickCount;

	public AiConditionTrickCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_trickType = (sbyte)ints[1];
		_trickCount = ints[2];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return checkChar.GetTrickCount(_trickType) >= _trickCount;
	}
}
