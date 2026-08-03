using System;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Map;

namespace GameData.Domains.Character.Creation;

public struct IntelligentCharacterCreationInfo(Location location, OrganizationInfo orgInfo, short charTemplateId)
{
	public readonly Location Location = location;

	public readonly OrganizationInfo OrgInfo = orgInfo;

	public readonly short CharTemplateId = charTemplateId;

	public sbyte GrowingSectId = -1;

	public sbyte GrowingSectGrade = -1;

	public int MotherCharId = -1;

	public Character Mother = null;

	public PregnantState PregnantState = null;

	public int FatherCharId = -1;

	public Character Father = null;

	public DeadCharacter DeadFather = null;

	public int ActualFatherCharId = -1;

	public Character ActualFather = null;

	public DeadCharacter ActualDeadFather = null;

	public FullName ReferenceFullName = default(FullName);

	public sbyte MultipleBirthCount = 1;

	public short Age = -1;

	public sbyte BirthMonth = -1;

	public short BaseAttraction = -1;

	public AvatarData Avatar = null;

	public bool SpecifyGenome = false;

	public Genome Genome = default(Genome);

	public int ReincarnationCharId = -1;

	public int DestinyType = -1;

	public short[] LifeSkillsLowerBound = null;

	public short[] CombatSkillsLowerBound = null;

	public bool InitializeSectSkills = true;

	public MainAttributes ParentMainAttributeValues;

	public LifeSkillShorts ParentLifeSkillQualificationValues;

	public CombatSkillShorts ParentCombatSkillQualificationValues;

	public bool AllowRandomGrowingGradeAdjust = false;

	public sbyte CombatSkillQualificationGrowthType = -1;

	public sbyte LifeSkillQualificationGrowthType = -1;

	public sbyte Gender = -1;

	public bool Transgender = false;

	public sbyte Race = -1;

	[Obsolete]
	public short[] LifeSkillsAdjustBonus = null;

	[Obsolete]
	public short[] CombatSkillsAdjustBonus = null;

	public bool DisableBeReincarnatedBySavedSoul = false;
}
