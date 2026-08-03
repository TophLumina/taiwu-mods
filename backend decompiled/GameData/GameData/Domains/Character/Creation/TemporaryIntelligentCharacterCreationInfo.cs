using GameData.Domains.Map;

namespace GameData.Domains.Character.Creation;

public struct TemporaryIntelligentCharacterCreationInfo
{
	public Location Location;

	public OrganizationInfo OrgInfo;

	public short CharTemplateId;

	public short? ActualAge;

	public sbyte? Happiness;

	public short? Morality;

	public short? BaseAttraction;

	public byte? MonkType;

	public bool? IsCompletelyInfected;

	public sbyte? ConsummateLevel;

	public ResourceInts Resources;

	public sbyte? GoodAtCombatSkillType;

	public sbyte? GoodAtLifeSkillType;

	public sbyte HaveHair;

	public short? LovingItemSubType;

	public short? HatingItemSubType;

	public sbyte? BountySeverity;

	public short[] CombatSkillQualifications;
}
