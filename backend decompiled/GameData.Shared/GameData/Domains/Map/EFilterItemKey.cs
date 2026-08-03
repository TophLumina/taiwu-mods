using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 筛选项标识枚举 - 每个枚举对应一个控件
/// </summary>
[SerializeAs(typeof(byte))]
public enum EFilterItemKey : byte
{
	CharacterRelation,
	CharacterIdentity,
	CharacterRank,
	CharacterFollow,
	CharacterAge,
	CharacterGender,
	CharacterSpouse,
	CharacterReincarnation,
	CharacterFavorability,
	CharacterMood,
	CharacterHealth,
	CharacterBreath,
	CharacterInjury,
	CharacterPoison,
	CharacterTrait,
	CharacterAttributeType,
	CharacterCombatSkillType,
	CharacterLifeSkillType,
	CharacterAptitude,
	CharacterAchievement,
	CharacterGrowth,
	CharacterStrength,
	CharacterDexterity,
	CharacterConcentration,
	CharacterVitality,
	CharacterEnergy,
	CharacterIntelligence,
	MerchantType,
	MerchantGuildType,
	MerchantGuildRank,
	MerchantCaravanStatus,
	GraveRank,
	GraveInteraction,
	GraveDurability,
	GraveHasRelation,
	GraveRelation,
	BeastType,
	BeastRank,
	BeastStatus,
	TerrainResourceType,
	TerrainResourceAmount,
	TerrainMigration,
	TerrainStatus,
	TerrainExcavation
}
