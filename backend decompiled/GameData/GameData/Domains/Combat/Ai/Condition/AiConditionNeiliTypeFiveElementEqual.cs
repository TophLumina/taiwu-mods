using System.Collections.Generic;
using Config;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.NeiliTypeFiveElementEqual)]
public class AiConditionNeiliTypeFiveElementEqual : AiConditionCheckCharBase
{
	private readonly sbyte _fiveElementsType;

	public AiConditionNeiliTypeFiveElementEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_fiveElementsType = (sbyte)ints[1];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		return NeiliType.Instance[checkChar.GetNeiliType()].FiveElements == _fiveElementsType;
	}
}
