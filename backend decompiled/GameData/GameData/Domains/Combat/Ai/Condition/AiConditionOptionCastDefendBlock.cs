using System.Linq;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionCastDefendBlock)]
public class AiConditionOptionCastDefendBlock : AiConditionCombatBase
{
	private static bool IsValid(short skillId)
	{
		return false;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoCastSkill[2]))
		{
			return false;
		}
		return combatChar.GetDefenceSkillList().Where(IsValid).Where(combatChar.AiCanCast)
			.Any();
	}
}
