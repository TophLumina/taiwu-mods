using Config;

namespace GameData.Domains.Taiwu.Profession;

public static class SharedMethods
{
	/// <summary>
	/// 从志向id和技能序号获取技能id
	/// </summary>
	/// <param name="professionSkillId"></param>
	/// <param name="skillIndex"></param>
	/// <returns></returns>
	public static int GetSkillId(int professionSkillId, int skillIndex)
	{
		ProfessionItem professionCfg = Config.Profession.Instance[professionSkillId];
		if (skillIndex != 3)
		{
			return professionCfg.ProfessionSkills[skillIndex];
		}
		return professionCfg.ExtraProfessionSkill;
	}

	/// <summary>
	/// 获取特定技能解锁需要的资历
	/// </summary>
	/// <param name="professionSkillId">技能id</param>
	/// <returns></returns>
	public static int GetSkillUnlockSeniority(int professionSkillId)
	{
		return ProfessionSkill.Instance[professionSkillId].UnlockSeniority * 3000000 / 100;
	}
}
