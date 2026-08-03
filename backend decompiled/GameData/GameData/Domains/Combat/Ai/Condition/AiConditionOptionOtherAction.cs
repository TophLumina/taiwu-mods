using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionOtherAction)]
public class AiConditionOptionOtherAction : AiConditionCombatBase
{
	private readonly sbyte _otherActionType;

	public AiConditionOptionOtherAction(IReadOnlyList<int> ints)
	{
		_otherActionType = (sbyte)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		sbyte otherActionType = _otherActionType;
		if (1 == 0)
		{
		}
		int num = otherActionType switch
		{
			0 => 0, 
			1 => 1, 
			2 => 2, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int index = num;
		if (index < 0 || !combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoUseOtherAction[index]))
		{
			return false;
		}
		return combatChar.GetOtherActionCanUse()[_otherActionType];
	}
}
