using System.Linq;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionCastAgileBuff)]
public class AiConditionOptionCastAgileBuff : AiConditionCombatBase
{
	private static bool IsValid(short skillId)
	{
		return skillId >= 0;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoCastSkill[1]))
		{
			return false;
		}
		return combatChar.GetAgileSkillList().Where(IsValid).Where(combatChar.AiCanCast)
			.Any();
	}
}
