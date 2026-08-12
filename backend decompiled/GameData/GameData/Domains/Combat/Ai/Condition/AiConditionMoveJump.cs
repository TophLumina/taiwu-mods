using System.Linq;
using Config;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MoveJump)]
public class AiConditionMoveJump : AiConditionCombatBase
{
	private static bool IsValid(short skillId)
	{
		return skillId >= 0;
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		int charId = combatChar.GetId();
		Config.CombatSkill configInstance = Config.CombatSkill.Instance;
		return combatChar.GetAgileSkillList().Where(delegate(short skillId)
		{
			if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: charId, skillId: skillId), out var element))
			{
				return false;
			}
			CombatSkillItem combatSkillItem = configInstance[skillId];
			return combatSkillItem.JumpPrepareFrame > 0 && CombatSkillStateHelper.IsBrokenOut(element.GetActivationState());
		}).Where(IsValid)
			.Where(combatChar.AiCanCast)
			.Any();
	}
}
