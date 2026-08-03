using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.NeiliAllocationPercentMoreOrEqual)]
public class AiConditionNeiliAllocationPercentMoreOrEqual : AiConditionCheckCharBase
{
	private readonly sbyte _neiliAllocationType;

	private readonly int _percent;

	public AiConditionNeiliAllocationPercentMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		_neiliAllocationType = (sbyte)ints[1];
		_percent = ints[2];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		short neiliAllocation = checkChar.GetNeiliAllocation()[_neiliAllocationType];
		short maxNeiliAllocation = checkChar.GetOriginNeiliAllocation()[_neiliAllocationType];
		return CValuePercent.ParseInt(neiliAllocation, maxNeiliAllocation) >= _percent;
	}
}
