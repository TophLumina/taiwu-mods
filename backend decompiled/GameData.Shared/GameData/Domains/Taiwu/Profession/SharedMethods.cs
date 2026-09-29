using Config;

namespace GameData.Domains.Taiwu.Profession;

public static class SharedMethods
{
	public static int GetSkillId(int professionSkillId, int skillIndex)
	{
		ProfessionItem professionCfg = Config.Profession.Instance[professionSkillId];
		if (skillIndex != 3)
		{
			return professionCfg.ProfessionSkills[skillIndex];
		}
		return professionCfg.ExtraProfessionSkill;
	}

	public static int GetSkillUnlockSeniority(int professionSkillId)
	{
		return ProfessionSkill.Instance[professionSkillId].UnlockSeniority * 3000000 / 100;
	}
}
