using System.Collections.Generic;
using System.Linq;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionProactiveSkillType)]
public class AiConditionOptionProactiveSkillType : AiConditionCombatBase
{
	private readonly sbyte _equipType;

	private static bool IsValid(short skillId)
	{
		return skillId >= 0;
	}

	public AiConditionOptionProactiveSkillType(IReadOnlyList<int> ints)
	{
		_equipType = (sbyte)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		sbyte equipType = _equipType;
		if (1 == 0)
		{
		}
		int num = equipType switch
		{
			1 => 0, 
			2 => 1, 
			3 => 2, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int index = num;
		if (index < 0 || !combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoCastSkill[index]))
		{
			return false;
		}
		return combatChar.GetCombatSkillList(_equipType).Where(IsValid).Where(combatChar.AiCanCast)
			.Any();
	}
}
