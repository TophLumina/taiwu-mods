using GameData.Domains.Character;

namespace GameData.Domains.Taiwu;

public static class CombatSkillPlanHelper
{
	public static void Record(this CombatSkillPlan plan, GameData.Domains.Character.Character character)
	{
		CombatSkillEquipment combatSkillEquipment = character.GetCombatSkillEquipment();
		CombatSkillPlan srcPlan = combatSkillEquipment.GetSourceObject<CombatSkillPlan>();
		if (srcPlan != null)
		{
			plan.CopyFrom(srcPlan);
			return;
		}
		short[] skillIdList = character.GetEquippedCombatSkills();
		plan.Record(skillIdList);
	}
}
