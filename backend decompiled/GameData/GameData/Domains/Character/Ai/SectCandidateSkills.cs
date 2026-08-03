namespace GameData.Domains.Character.Ai;

public class SectCandidateSkills
{
	public sbyte OrgTemplateId;

	public sbyte CombatSkillsCount;

	public sbyte MaxGrade;

	public short[] SkillTemplateIds;

	public SectCandidateSkills()
	{
		Initialize(-1);
	}

	public SectCandidateSkills(sbyte orgTemplateId)
	{
		Initialize(orgTemplateId);
	}

	public void Initialize(sbyte orgTemplateId)
	{
		OrgTemplateId = orgTemplateId;
		CombatSkillsCount = 0;
		MaxGrade = -1;
		SkillTemplateIds = new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
	}

	public void Add(short skillTemplateId, sbyte grade)
	{
		CombatSkillsCount++;
		if (MaxGrade < grade)
		{
			MaxGrade = grade;
		}
		SkillTemplateIds[grade] = skillTemplateId;
	}
}
