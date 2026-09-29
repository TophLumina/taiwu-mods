using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SortItem : ConfigData<SortItemItem, short>
{
	public static class DefKey
	{
		public const short Name = 0;

		public const short Grade = 1;

		public const short CombatSkillPower = 2;

		public const short CombatSkillBonus = 3;

		public const short ReadCount = 4;

		public const short ItemValue = 5;

		public const short ExchangeValue = 267;

		public const short ItemWeight = 6;

		public const short InformationLeftTime = 7;

		public const short CharacterAge = 8;

		public const short CharacterCharm = 9;

		public const short CharacterHealth = 10;

		public const short CharacterFavorabilityToTaiwu = 11;

		public const short CharacterHappiness = 12;

		public const short VillagerLeftPotentialCount = 13;

		public const short PrisonerDuration = 14;

		public const short PunishmentSeverity = 15;

		public const short BountyAmount = 16;

		public const short ItemAmount = 17;

		public const short CurrentDurability = 18;

		public const short Power = 19;

		public const short ArmorBreak = 20;

		public const short EquipmentDefense = 21;

		public const short PenetrateOuter = 22;

		public const short PenetrateInner = 23;

		public const short HitRateStrength = 24;

		public const short HitRateTechnique = 25;

		public const short HitRateSpeed = 26;

		public const short HitRateMind = 27;

		public const short WeaponBreak = 28;

		public const short PenetrateResistOuter = 29;

		public const short PenetrateResistInner = 30;

		public const short InnerWoundReduce = 31;

		public const short OutterWoundReduce = 32;

		public const short AvoidRateStrength = 33;

		public const short AvoidRateTechnique = 34;

		public const short AvoidRateSpeed = 35;

		public const short AvoidRateMind = 36;

		public const short Carriage = 37;

		public const short Energy = 38;

		public const short Loot = 39;

		public const short SubdueRate = 40;

		public const short TameRate = 41;

		public const short CricketDurability = 42;

		public const short CricketAge = 43;

		public const short CricketWin = 44;

		public const short CricketLose = 45;

		public const short CricketVitality = 46;

		public const short CricketSpirit = 47;

		public const short CricketVigor = 48;

		public const short CricketStrength = 49;

		public const short CricketTeeth = 50;

		public const short MedicineAttainment = 51;

		public const short ToxicologyAttainment = 52;

		public const short TotalInjuries = 53;

		public const short TotalPoisons = 54;

		public const short QiDisorder = 55;

		public const short Type = 56;

		public const short BehaviourType = 57;

		public const short Samsara = 58;

		public const short Fame = 59;

		public const short MainAttribute0 = 60;

		public const short MainAttribute1 = 61;

		public const short MainAttribute2 = 62;

		public const short MainAttribute3 = 63;

		public const short MainAttribute4 = 64;

		public const short MainAttribute5 = 65;

		public const short LKLifeSkillType0 = 66;

		public const short LKLifeSkillType1 = 67;

		public const short LKLifeSkillType2 = 68;

		public const short LKLifeSkillType3 = 69;

		public const short LKLifeSkillType4 = 70;

		public const short LKLifeSkillType5 = 71;

		public const short LKLifeSkillType6 = 72;

		public const short LKLifeSkillType7 = 73;

		public const short LKLifeSkillType8 = 74;

		public const short LKLifeSkillType9 = 75;

		public const short LKLifeSkillType10 = 76;

		public const short LKLifeSkillType11 = 77;

		public const short LKLifeSkillType12 = 78;

		public const short LKLifeSkillType13 = 79;

		public const short LKLifeSkillType14 = 80;

		public const short LKLifeSkillType15 = 81;

		public const short LKCombatSkillType0 = 82;

		public const short LKCombatSkillType1 = 83;

		public const short LKCombatSkillType2 = 84;

		public const short LKCombatSkillType3 = 85;

		public const short LKCombatSkillType4 = 86;

		public const short LKCombatSkillType5 = 87;

		public const short LKCombatSkillType6 = 88;

		public const short LKCombatSkillType7 = 89;

		public const short LKCombatSkillType8 = 90;

		public const short LKCombatSkillType9 = 91;

		public const short LKCombatSkillType10 = 92;

		public const short LKCombatSkillType11 = 93;

		public const short LKCombatSkillType12 = 94;

		public const short LKCombatSkillType13 = 95;

		public const short Personality0 = 96;

		public const short Personality1 = 97;

		public const short Personality2 = 98;

		public const short Personality3 = 99;

		public const short Personality4 = 100;

		public const short Personality5 = 101;

		public const short Personality6 = 102;

		public const short ResourceType0 = 103;

		public const short ResourceType1 = 104;

		public const short ResourceType2 = 105;

		public const short ResourceType3 = 106;

		public const short ResourceType4 = 107;

		public const short ResourceType5 = 108;

		public const short ResourceType6 = 109;

		public const short ResourceType7 = 110;

		public const short KidnapCount = 111;

		public const short AttackMedal = 112;

		public const short DefenceMedal = 113;

		public const short WisdomMedal = 114;

		public const short ConsumedFeatureMedals = 266;

		public const short Command0 = 115;

		public const short Command1 = 116;

		public const short Command2 = 117;

		public const short LifeSkillGrowth = 118;

		public const short CombatSkillGrowth = 119;

		public const short Resistance = 120;

		public const short CombatSKillAttainment = 121;

		public const short Gender = 122;

		public const short Infection = 123;

		public const short CombatSkillType = 124;

		public const short Location = 125;

		public const short WorkingLocation = 126;

		public const short WorkingRole = 127;

		public const short Potential = 128;

		public const short WorkingStatus = 129;

		public const short Alertness = 130;

		public const short SpecialBreakBonusProgress = 131;

		public const short RequireCharacterAmount = 133;

		public const short TakeAfterMonth = 134;

		public const short TakeAmount = 135;

		public const short Relationship = 136;

		public const short Contribution = 137;

		public const short ApprovingRate = 178;

		public const short SupplyRate = 132;

		public const short PunishmentType = 138;

		public const short CharacterIdentity = 139;

		public const short CombatSkillQualificationSum = 140;

		public const short LifeSkillQualificationSum = 141;

		public const short MainAttributeSum = 142;

		public const short ConsummateLevel = 143;

		public const short LoopingObtainedNeili = 144;

		public const short LoopingFiveElementTranferAmound = 145;

		public const short LoopingNeili = 146;

		public const short LoopingNeiliAllocation = 147;

		public const short LoopingEvent = 148;

		public const short LoopingStrategy = 149;

		public const short Personality = 150;

		public const short OriginalGrade = 151;

		public const short ProfessionName = 152;

		public const short ProfessionSeniority = 153;

		public const short InformationLevel = 154;

		public const short InformationCanUseCount = 155;

		public const short SecretOccurenceDate = 159;

		public const short SecretLevel = 160;

		public const short SecretLifeTime = 161;

		public const short SecretKnownCount = 162;

		public const short SecretCanUseCount = 163;

		public const short SecretDisseminationRate = 164;

		public const short MakeNeedAttainment = 156;

		public const short MakeAvailableToolCount = 157;

		public const short MakeAvailableMaterialCount = 158;

		public const short PoisonInfo = 165;

		public const short BookInfo = 166;

		public const short RefineEffect = 167;

		public const short RefineAttribute = 168;

		public const short ProductRate = 169;

		public const short ModStatus = 170;

		public const short ModOrder = 171;

		public const short ModName = 172;

		public const short ModRate = 173;

		public const short ModUploadTime = 174;

		public const short ModUpdateTime = 175;

		public const short ModSize = 176;

		public const short ModVersion = 177;

		public const short FarmerAutoCollectActionCount = 179;

		public const short FarmerMigrateResourceSuccessRate = 180;

		public const short FarmerMigrateResourceExtraSuccessRate = 181;

		public const short FarmerChickenUpgradeBuildingCoreRate = 182;

		public const short DoctorInteractTargetGrade = 183;

		public const short DoctorChickenUpgradeInfectionChangeAmount = 184;

		public const short MerchantInteractTargetGrade = 185;

		public const short MerchantBuyItemPriceRate = 186;

		public const short MerchantSellItemPriceRate = 187;

		public const short MerchantChickenIncreaseHeadMerchantFavor = 188;

		public const short MerchantChickenIncreaseBranchMerchantFavor = 189;

		public const short LiteratiWorkUsableCount = 190;

		public const short LiteratiWorkEffectiveValue = 191;

		public const short LiteratiChickenInfluenceCount = 192;

		public const short LiteratiChickenRelationChange = 193;

		public const short SwordTombKeeperWorkCollectOdd = 194;

		public const short SwordTombKeeperWorkHurtOdd = 195;

		public const short SwordTombKeeperWorkFeatureOddWhenInformationCollect = 196;

		public const short SwordTombKeeperWorkFeatureOddWhenBeAttacked = 197;

		public const short SwordTombKeeperChickenDecreaseFactor = 198;

		public const short VillageHeadWorkSpecialRuleCount = 199;

		public const short VillageHeadWorkMonthlyAuthorityCost = 200;

		public const short DarkAsh = 201;

		public const short TripodVesselProtect = 202;

		public const short Organization = 203;

		public const short FoodRemainDurability = 204;

		public const short DoctorLifeSkill = 205;

		public const short LiteratiLifeSkill = 206;

		public const short TombKeeperLifeSkill = 207;

		public const short HighestCombatSkill = 208;

		public const short WeavedClothingTemplateId = 209;

		public const short WeavedCount = 210;

		public const short ToolAttainment = 211;

		public const short ShopItemValue = 212;

		public const short ShopItemPrice = 213;

		public const short BookEfficiency = 214;

		public const short BookInspiration = 215;

		public const short CombatSkillProficiency = 216;

		public const short PoisonsCount = 217;

		public const short NeiliTypeMetal = 218;

		public const short NeiliTypeWood = 219;

		public const short NeiliTypeWater = 220;

		public const short NeiliTypeFire = 221;

		public const short NeiliTypeEarth = 222;

		public const short BookReadingProgress = 223;

		public const short CricketPolymorphSpirit = 224;

		public const short LKLifeSkillAttainmentType0 = 225;

		public const short LKLifeSkillAttainmentType1 = 226;

		public const short LKLifeSkillAttainmentType2 = 227;

		public const short LKLifeSkillAttainmentType3 = 228;

		public const short LKLifeSkillAttainmentType4 = 229;

		public const short LKLifeSkillAttainmentType5 = 230;

		public const short LKLifeSkillAttainmentType6 = 231;

		public const short LKLifeSkillAttainmentType7 = 232;

		public const short LKLifeSkillAttainmentType8 = 253;

		public const short LKLifeSkillAttainmentType9 = 254;

		public const short LKLifeSkillAttainmentType10 = 233;

		public const short LKLifeSkillAttainmentType11 = 234;

		public const short LKLifeSkillAttainmentType12 = 235;

		public const short LKLifeSkillAttainmentType13 = 236;

		public const short LKLifeSkillAttainmentType14 = 237;

		public const short LKLifeSkillAttainmentType15 = 238;

		public const short LKCombatSkillAttainmentType0 = 239;

		public const short LKCombatSkillAttainmentType1 = 240;

		public const short LKCombatSkillAttainmentType2 = 241;

		public const short LKCombatSkillAttainmentType3 = 242;

		public const short LKCombatSkillAttainmentType4 = 243;

		public const short LKCombatSkillAttainmentType5 = 244;

		public const short LKCombatSkillAttainmentType6 = 245;

		public const short LKCombatSkillAttainmentType7 = 246;

		public const short LKCombatSkillAttainmentType8 = 247;

		public const short LKCombatSkillAttainmentType9 = 248;

		public const short LKCombatSkillAttainmentType10 = 249;

		public const short LKCombatSkillAttainmentType11 = 250;

		public const short LKCombatSkillAttainmentType12 = 251;

		public const short LKCombatSkillAttainmentType13 = 252;

		public const short GraveDurability = 255;

		public const short CharacterBirthDate = 256;

		public const short CharacterDeathDate = 257;

		public const short NormalWugCount = 258;

		public const short ExtraNeiliAllocationAttack = 259;

		public const short ExtraNeiliAllocationAgility = 260;

		public const short ExtraNeiliAllocationDefense = 261;

		public const short ExtraNeiliAllocationAssistance = 262;

		public const short LegendaryBookType = 263;

		public const short LegendaryBookFeature = 264;

		public const short ChickenPoint = 265;
	}

	public static class DefValue
	{
		public static SortItemItem Name => Instance[(short)0];

		public static SortItemItem Grade => Instance[(short)1];

		public static SortItemItem CombatSkillPower => Instance[(short)2];

		public static SortItemItem CombatSkillBonus => Instance[(short)3];

		public static SortItemItem ReadCount => Instance[(short)4];

		public static SortItemItem ItemValue => Instance[(short)5];

		public static SortItemItem ExchangeValue => Instance[(short)267];

		public static SortItemItem ItemWeight => Instance[(short)6];

		public static SortItemItem InformationLeftTime => Instance[(short)7];

		public static SortItemItem CharacterAge => Instance[(short)8];

		public static SortItemItem CharacterCharm => Instance[(short)9];

		public static SortItemItem CharacterHealth => Instance[(short)10];

		public static SortItemItem CharacterFavorabilityToTaiwu => Instance[(short)11];

		public static SortItemItem CharacterHappiness => Instance[(short)12];

		public static SortItemItem VillagerLeftPotentialCount => Instance[(short)13];

		public static SortItemItem PrisonerDuration => Instance[(short)14];

		public static SortItemItem PunishmentSeverity => Instance[(short)15];

		public static SortItemItem BountyAmount => Instance[(short)16];

		public static SortItemItem ItemAmount => Instance[(short)17];

		public static SortItemItem CurrentDurability => Instance[(short)18];

		public static SortItemItem Power => Instance[(short)19];

		public static SortItemItem ArmorBreak => Instance[(short)20];

		public static SortItemItem EquipmentDefense => Instance[(short)21];

		public static SortItemItem PenetrateOuter => Instance[(short)22];

		public static SortItemItem PenetrateInner => Instance[(short)23];

		public static SortItemItem HitRateStrength => Instance[(short)24];

		public static SortItemItem HitRateTechnique => Instance[(short)25];

		public static SortItemItem HitRateSpeed => Instance[(short)26];

		public static SortItemItem HitRateMind => Instance[(short)27];

		public static SortItemItem WeaponBreak => Instance[(short)28];

		public static SortItemItem PenetrateResistOuter => Instance[(short)29];

		public static SortItemItem PenetrateResistInner => Instance[(short)30];

		public static SortItemItem InnerWoundReduce => Instance[(short)31];

		public static SortItemItem OutterWoundReduce => Instance[(short)32];

		public static SortItemItem AvoidRateStrength => Instance[(short)33];

		public static SortItemItem AvoidRateTechnique => Instance[(short)34];

		public static SortItemItem AvoidRateSpeed => Instance[(short)35];

		public static SortItemItem AvoidRateMind => Instance[(short)36];

		public static SortItemItem Carriage => Instance[(short)37];

		public static SortItemItem Energy => Instance[(short)38];

		public static SortItemItem Loot => Instance[(short)39];

		public static SortItemItem SubdueRate => Instance[(short)40];

		public static SortItemItem TameRate => Instance[(short)41];

		public static SortItemItem CricketDurability => Instance[(short)42];

		public static SortItemItem CricketAge => Instance[(short)43];

		public static SortItemItem CricketWin => Instance[(short)44];

		public static SortItemItem CricketLose => Instance[(short)45];

		public static SortItemItem CricketVitality => Instance[(short)46];

		public static SortItemItem CricketSpirit => Instance[(short)47];

		public static SortItemItem CricketVigor => Instance[(short)48];

		public static SortItemItem CricketStrength => Instance[(short)49];

		public static SortItemItem CricketTeeth => Instance[(short)50];

		public static SortItemItem MedicineAttainment => Instance[(short)51];

		public static SortItemItem ToxicologyAttainment => Instance[(short)52];

		public static SortItemItem TotalInjuries => Instance[(short)53];

		public static SortItemItem TotalPoisons => Instance[(short)54];

		public static SortItemItem QiDisorder => Instance[(short)55];

		public static SortItemItem Type => Instance[(short)56];

		public static SortItemItem BehaviourType => Instance[(short)57];

		public static SortItemItem Samsara => Instance[(short)58];

		public static SortItemItem Fame => Instance[(short)59];

		public static SortItemItem MainAttribute0 => Instance[(short)60];

		public static SortItemItem MainAttribute1 => Instance[(short)61];

		public static SortItemItem MainAttribute2 => Instance[(short)62];

		public static SortItemItem MainAttribute3 => Instance[(short)63];

		public static SortItemItem MainAttribute4 => Instance[(short)64];

		public static SortItemItem MainAttribute5 => Instance[(short)65];

		public static SortItemItem LKLifeSkillType0 => Instance[(short)66];

		public static SortItemItem LKLifeSkillType1 => Instance[(short)67];

		public static SortItemItem LKLifeSkillType2 => Instance[(short)68];

		public static SortItemItem LKLifeSkillType3 => Instance[(short)69];

		public static SortItemItem LKLifeSkillType4 => Instance[(short)70];

		public static SortItemItem LKLifeSkillType5 => Instance[(short)71];

		public static SortItemItem LKLifeSkillType6 => Instance[(short)72];

		public static SortItemItem LKLifeSkillType7 => Instance[(short)73];

		public static SortItemItem LKLifeSkillType8 => Instance[(short)74];

		public static SortItemItem LKLifeSkillType9 => Instance[(short)75];

		public static SortItemItem LKLifeSkillType10 => Instance[(short)76];

		public static SortItemItem LKLifeSkillType11 => Instance[(short)77];

		public static SortItemItem LKLifeSkillType12 => Instance[(short)78];

		public static SortItemItem LKLifeSkillType13 => Instance[(short)79];

		public static SortItemItem LKLifeSkillType14 => Instance[(short)80];

		public static SortItemItem LKLifeSkillType15 => Instance[(short)81];

		public static SortItemItem LKCombatSkillType0 => Instance[(short)82];

		public static SortItemItem LKCombatSkillType1 => Instance[(short)83];

		public static SortItemItem LKCombatSkillType2 => Instance[(short)84];

		public static SortItemItem LKCombatSkillType3 => Instance[(short)85];

		public static SortItemItem LKCombatSkillType4 => Instance[(short)86];

		public static SortItemItem LKCombatSkillType5 => Instance[(short)87];

		public static SortItemItem LKCombatSkillType6 => Instance[(short)88];

		public static SortItemItem LKCombatSkillType7 => Instance[(short)89];

		public static SortItemItem LKCombatSkillType8 => Instance[(short)90];

		public static SortItemItem LKCombatSkillType9 => Instance[(short)91];

		public static SortItemItem LKCombatSkillType10 => Instance[(short)92];

		public static SortItemItem LKCombatSkillType11 => Instance[(short)93];

		public static SortItemItem LKCombatSkillType12 => Instance[(short)94];

		public static SortItemItem LKCombatSkillType13 => Instance[(short)95];

		public static SortItemItem Personality0 => Instance[(short)96];

		public static SortItemItem Personality1 => Instance[(short)97];

		public static SortItemItem Personality2 => Instance[(short)98];

		public static SortItemItem Personality3 => Instance[(short)99];

		public static SortItemItem Personality4 => Instance[(short)100];

		public static SortItemItem Personality5 => Instance[(short)101];

		public static SortItemItem Personality6 => Instance[(short)102];

		public static SortItemItem ResourceType0 => Instance[(short)103];

		public static SortItemItem ResourceType1 => Instance[(short)104];

		public static SortItemItem ResourceType2 => Instance[(short)105];

		public static SortItemItem ResourceType3 => Instance[(short)106];

		public static SortItemItem ResourceType4 => Instance[(short)107];

		public static SortItemItem ResourceType5 => Instance[(short)108];

		public static SortItemItem ResourceType6 => Instance[(short)109];

		public static SortItemItem ResourceType7 => Instance[(short)110];

		public static SortItemItem KidnapCount => Instance[(short)111];

		public static SortItemItem AttackMedal => Instance[(short)112];

		public static SortItemItem DefenceMedal => Instance[(short)113];

		public static SortItemItem WisdomMedal => Instance[(short)114];

		public static SortItemItem ConsumedFeatureMedals => Instance[(short)266];

		public static SortItemItem Command0 => Instance[(short)115];

		public static SortItemItem Command1 => Instance[(short)116];

		public static SortItemItem Command2 => Instance[(short)117];

		public static SortItemItem LifeSkillGrowth => Instance[(short)118];

		public static SortItemItem CombatSkillGrowth => Instance[(short)119];

		public static SortItemItem Resistance => Instance[(short)120];

		public static SortItemItem CombatSKillAttainment => Instance[(short)121];

		public static SortItemItem Gender => Instance[(short)122];

		public static SortItemItem Infection => Instance[(short)123];

		public static SortItemItem CombatSkillType => Instance[(short)124];

		public static SortItemItem Location => Instance[(short)125];

		public static SortItemItem WorkingLocation => Instance[(short)126];

		public static SortItemItem WorkingRole => Instance[(short)127];

		public static SortItemItem Potential => Instance[(short)128];

		public static SortItemItem WorkingStatus => Instance[(short)129];

		public static SortItemItem Alertness => Instance[(short)130];

		public static SortItemItem SpecialBreakBonusProgress => Instance[(short)131];

		public static SortItemItem RequireCharacterAmount => Instance[(short)133];

		public static SortItemItem TakeAfterMonth => Instance[(short)134];

		public static SortItemItem TakeAmount => Instance[(short)135];

		public static SortItemItem Relationship => Instance[(short)136];

		public static SortItemItem Contribution => Instance[(short)137];

		public static SortItemItem ApprovingRate => Instance[(short)178];

		public static SortItemItem SupplyRate => Instance[(short)132];

		public static SortItemItem PunishmentType => Instance[(short)138];

		public static SortItemItem CharacterIdentity => Instance[(short)139];

		public static SortItemItem CombatSkillQualificationSum => Instance[(short)140];

		public static SortItemItem LifeSkillQualificationSum => Instance[(short)141];

		public static SortItemItem MainAttributeSum => Instance[(short)142];

		public static SortItemItem ConsummateLevel => Instance[(short)143];

		public static SortItemItem LoopingObtainedNeili => Instance[(short)144];

		public static SortItemItem LoopingFiveElementTranferAmound => Instance[(short)145];

		public static SortItemItem LoopingNeili => Instance[(short)146];

		public static SortItemItem LoopingNeiliAllocation => Instance[(short)147];

		public static SortItemItem LoopingEvent => Instance[(short)148];

		public static SortItemItem LoopingStrategy => Instance[(short)149];

		public static SortItemItem Personality => Instance[(short)150];

		public static SortItemItem OriginalGrade => Instance[(short)151];

		public static SortItemItem ProfessionName => Instance[(short)152];

		public static SortItemItem ProfessionSeniority => Instance[(short)153];

		public static SortItemItem InformationLevel => Instance[(short)154];

		public static SortItemItem InformationCanUseCount => Instance[(short)155];

		public static SortItemItem SecretOccurenceDate => Instance[(short)159];

		public static SortItemItem SecretLevel => Instance[(short)160];

		public static SortItemItem SecretLifeTime => Instance[(short)161];

		public static SortItemItem SecretKnownCount => Instance[(short)162];

		public static SortItemItem SecretCanUseCount => Instance[(short)163];

		public static SortItemItem SecretDisseminationRate => Instance[(short)164];

		public static SortItemItem MakeNeedAttainment => Instance[(short)156];

		public static SortItemItem MakeAvailableToolCount => Instance[(short)157];

		public static SortItemItem MakeAvailableMaterialCount => Instance[(short)158];

		public static SortItemItem PoisonInfo => Instance[(short)165];

		public static SortItemItem BookInfo => Instance[(short)166];

		public static SortItemItem RefineEffect => Instance[(short)167];

		public static SortItemItem RefineAttribute => Instance[(short)168];

		public static SortItemItem ProductRate => Instance[(short)169];

		public static SortItemItem ModStatus => Instance[(short)170];

		public static SortItemItem ModOrder => Instance[(short)171];

		public static SortItemItem ModName => Instance[(short)172];

		public static SortItemItem ModRate => Instance[(short)173];

		public static SortItemItem ModUploadTime => Instance[(short)174];

		public static SortItemItem ModUpdateTime => Instance[(short)175];

		public static SortItemItem ModSize => Instance[(short)176];

		public static SortItemItem ModVersion => Instance[(short)177];

		public static SortItemItem FarmerAutoCollectActionCount => Instance[(short)179];

		public static SortItemItem FarmerMigrateResourceSuccessRate => Instance[(short)180];

		public static SortItemItem FarmerMigrateResourceExtraSuccessRate => Instance[(short)181];

		public static SortItemItem FarmerChickenUpgradeBuildingCoreRate => Instance[(short)182];

		public static SortItemItem DoctorInteractTargetGrade => Instance[(short)183];

		public static SortItemItem DoctorChickenUpgradeInfectionChangeAmount => Instance[(short)184];

		public static SortItemItem MerchantInteractTargetGrade => Instance[(short)185];

		public static SortItemItem MerchantBuyItemPriceRate => Instance[(short)186];

		public static SortItemItem MerchantSellItemPriceRate => Instance[(short)187];

		public static SortItemItem MerchantChickenIncreaseHeadMerchantFavor => Instance[(short)188];

		public static SortItemItem MerchantChickenIncreaseBranchMerchantFavor => Instance[(short)189];

		public static SortItemItem LiteratiWorkUsableCount => Instance[(short)190];

		public static SortItemItem LiteratiWorkEffectiveValue => Instance[(short)191];

		public static SortItemItem LiteratiChickenInfluenceCount => Instance[(short)192];

		public static SortItemItem LiteratiChickenRelationChange => Instance[(short)193];

		public static SortItemItem SwordTombKeeperWorkCollectOdd => Instance[(short)194];

		public static SortItemItem SwordTombKeeperWorkHurtOdd => Instance[(short)195];

		public static SortItemItem SwordTombKeeperWorkFeatureOddWhenInformationCollect => Instance[(short)196];

		public static SortItemItem SwordTombKeeperWorkFeatureOddWhenBeAttacked => Instance[(short)197];

		public static SortItemItem SwordTombKeeperChickenDecreaseFactor => Instance[(short)198];

		public static SortItemItem VillageHeadWorkSpecialRuleCount => Instance[(short)199];

		public static SortItemItem VillageHeadWorkMonthlyAuthorityCost => Instance[(short)200];

		public static SortItemItem DarkAsh => Instance[(short)201];

		public static SortItemItem TripodVesselProtect => Instance[(short)202];

		public static SortItemItem Organization => Instance[(short)203];

		public static SortItemItem FoodRemainDurability => Instance[(short)204];

		public static SortItemItem DoctorLifeSkill => Instance[(short)205];

		public static SortItemItem LiteratiLifeSkill => Instance[(short)206];

		public static SortItemItem TombKeeperLifeSkill => Instance[(short)207];

		public static SortItemItem HighestCombatSkill => Instance[(short)208];

		public static SortItemItem WeavedClothingTemplateId => Instance[(short)209];

		public static SortItemItem WeavedCount => Instance[(short)210];

		public static SortItemItem ToolAttainment => Instance[(short)211];

		public static SortItemItem ShopItemValue => Instance[(short)212];

		public static SortItemItem ShopItemPrice => Instance[(short)213];

		public static SortItemItem BookEfficiency => Instance[(short)214];

		public static SortItemItem BookInspiration => Instance[(short)215];

		public static SortItemItem CombatSkillProficiency => Instance[(short)216];

		public static SortItemItem PoisonsCount => Instance[(short)217];

		public static SortItemItem NeiliTypeMetal => Instance[(short)218];

		public static SortItemItem NeiliTypeWood => Instance[(short)219];

		public static SortItemItem NeiliTypeWater => Instance[(short)220];

		public static SortItemItem NeiliTypeFire => Instance[(short)221];

		public static SortItemItem NeiliTypeEarth => Instance[(short)222];

		public static SortItemItem BookReadingProgress => Instance[(short)223];

		public static SortItemItem CricketPolymorphSpirit => Instance[(short)224];

		public static SortItemItem LKLifeSkillAttainmentType0 => Instance[(short)225];

		public static SortItemItem LKLifeSkillAttainmentType1 => Instance[(short)226];

		public static SortItemItem LKLifeSkillAttainmentType2 => Instance[(short)227];

		public static SortItemItem LKLifeSkillAttainmentType3 => Instance[(short)228];

		public static SortItemItem LKLifeSkillAttainmentType4 => Instance[(short)229];

		public static SortItemItem LKLifeSkillAttainmentType5 => Instance[(short)230];

		public static SortItemItem LKLifeSkillAttainmentType6 => Instance[(short)231];

		public static SortItemItem LKLifeSkillAttainmentType7 => Instance[(short)232];

		public static SortItemItem LKLifeSkillAttainmentType8 => Instance[(short)253];

		public static SortItemItem LKLifeSkillAttainmentType9 => Instance[(short)254];

		public static SortItemItem LKLifeSkillAttainmentType10 => Instance[(short)233];

		public static SortItemItem LKLifeSkillAttainmentType11 => Instance[(short)234];

		public static SortItemItem LKLifeSkillAttainmentType12 => Instance[(short)235];

		public static SortItemItem LKLifeSkillAttainmentType13 => Instance[(short)236];

		public static SortItemItem LKLifeSkillAttainmentType14 => Instance[(short)237];

		public static SortItemItem LKLifeSkillAttainmentType15 => Instance[(short)238];

		public static SortItemItem LKCombatSkillAttainmentType0 => Instance[(short)239];

		public static SortItemItem LKCombatSkillAttainmentType1 => Instance[(short)240];

		public static SortItemItem LKCombatSkillAttainmentType2 => Instance[(short)241];

		public static SortItemItem LKCombatSkillAttainmentType3 => Instance[(short)242];

		public static SortItemItem LKCombatSkillAttainmentType4 => Instance[(short)243];

		public static SortItemItem LKCombatSkillAttainmentType5 => Instance[(short)244];

		public static SortItemItem LKCombatSkillAttainmentType6 => Instance[(short)245];

		public static SortItemItem LKCombatSkillAttainmentType7 => Instance[(short)246];

		public static SortItemItem LKCombatSkillAttainmentType8 => Instance[(short)247];

		public static SortItemItem LKCombatSkillAttainmentType9 => Instance[(short)248];

		public static SortItemItem LKCombatSkillAttainmentType10 => Instance[(short)249];

		public static SortItemItem LKCombatSkillAttainmentType11 => Instance[(short)250];

		public static SortItemItem LKCombatSkillAttainmentType12 => Instance[(short)251];

		public static SortItemItem LKCombatSkillAttainmentType13 => Instance[(short)252];

		public static SortItemItem GraveDurability => Instance[(short)255];

		public static SortItemItem CharacterBirthDate => Instance[(short)256];

		public static SortItemItem CharacterDeathDate => Instance[(short)257];

		public static SortItemItem NormalWugCount => Instance[(short)258];

		public static SortItemItem ExtraNeiliAllocationAttack => Instance[(short)259];

		public static SortItemItem ExtraNeiliAllocationAgility => Instance[(short)260];

		public static SortItemItem ExtraNeiliAllocationDefense => Instance[(short)261];

		public static SortItemItem ExtraNeiliAllocationAssistance => Instance[(short)262];

		public static SortItemItem LegendaryBookType => Instance[(short)263];

		public static SortItemItem LegendaryBookFeature => Instance[(short)264];

		public static SortItemItem ChickenPoint => Instance[(short)265];
	}

	public static SortItem Instance = new SortItem();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Names", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SortItemItem(0, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_0_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_0_1")
		}));
		_dataArray.Add(new SortItemItem(1, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_1_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_1_1")
		}));
		_dataArray.Add(new SortItemItem(2, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_2_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_2_1")
		}));
		_dataArray.Add(new SortItemItem(3, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_3_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_3_1")
		}));
		_dataArray.Add(new SortItemItem(4, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_4_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_4_1")
		}));
		_dataArray.Add(new SortItemItem(5, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_5_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_5_1")
		}));
		_dataArray.Add(new SortItemItem(6, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_6_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_6_1")
		}));
		_dataArray.Add(new SortItemItem(7, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_7_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_7_1")
		}));
		_dataArray.Add(new SortItemItem(8, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_8_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_8_1")
		}));
		_dataArray.Add(new SortItemItem(9, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_9_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_9_1")
		}));
		_dataArray.Add(new SortItemItem(10, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_10_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_10_1")
		}));
		_dataArray.Add(new SortItemItem(11, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_11_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_11_1")
		}));
		_dataArray.Add(new SortItemItem(12, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_12_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_12_1")
		}));
		_dataArray.Add(new SortItemItem(13, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_13_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_13_1")
		}));
		_dataArray.Add(new SortItemItem(14, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_14_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_14_1")
		}));
		_dataArray.Add(new SortItemItem(15, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_15_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_15_1")
		}));
		_dataArray.Add(new SortItemItem(16, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_16_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_16_1")
		}));
		_dataArray.Add(new SortItemItem(17, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_17_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_17_1")
		}));
		_dataArray.Add(new SortItemItem(18, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_18_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_18_1")
		}));
		_dataArray.Add(new SortItemItem(19, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_19_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_19_1")
		}));
		_dataArray.Add(new SortItemItem(20, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_20_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_20_1")
		}));
		_dataArray.Add(new SortItemItem(21, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_21_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_21_1")
		}));
		_dataArray.Add(new SortItemItem(22, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_22_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_22_1")
		}));
		_dataArray.Add(new SortItemItem(23, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_23_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_23_1")
		}));
		_dataArray.Add(new SortItemItem(24, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_24_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_24_1")
		}));
		_dataArray.Add(new SortItemItem(25, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_25_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_25_1")
		}));
		_dataArray.Add(new SortItemItem(26, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_26_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_26_1")
		}));
		_dataArray.Add(new SortItemItem(27, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_27_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_27_1")
		}));
		_dataArray.Add(new SortItemItem(28, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_28_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_28_1")
		}));
		_dataArray.Add(new SortItemItem(29, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_29_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_29_1")
		}));
		_dataArray.Add(new SortItemItem(30, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_30_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_30_1")
		}));
		_dataArray.Add(new SortItemItem(31, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_31_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_31_1")
		}));
		_dataArray.Add(new SortItemItem(32, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_32_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_32_1")
		}));
		_dataArray.Add(new SortItemItem(33, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_33_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_33_1")
		}));
		_dataArray.Add(new SortItemItem(34, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_34_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_34_1")
		}));
		_dataArray.Add(new SortItemItem(35, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_35_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_35_1")
		}));
		_dataArray.Add(new SortItemItem(36, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_36_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_36_1")
		}));
		_dataArray.Add(new SortItemItem(37, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_37_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_37_1")
		}));
		_dataArray.Add(new SortItemItem(38, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_38_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_38_1")
		}));
		_dataArray.Add(new SortItemItem(39, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_39_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_39_1")
		}));
		_dataArray.Add(new SortItemItem(40, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_40_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_40_1")
		}));
		_dataArray.Add(new SortItemItem(41, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_41_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_41_1")
		}));
		_dataArray.Add(new SortItemItem(42, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_42_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_42_1")
		}));
		_dataArray.Add(new SortItemItem(43, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_43_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_43_1")
		}));
		_dataArray.Add(new SortItemItem(44, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_44_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_44_1")
		}));
		_dataArray.Add(new SortItemItem(45, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_45_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_45_1")
		}));
		_dataArray.Add(new SortItemItem(46, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_46_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_46_1")
		}));
		_dataArray.Add(new SortItemItem(47, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_47_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_47_1")
		}));
		_dataArray.Add(new SortItemItem(48, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_48_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_48_1")
		}));
		_dataArray.Add(new SortItemItem(49, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_49_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_49_1")
		}));
		_dataArray.Add(new SortItemItem(50, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_50_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_50_1")
		}));
		_dataArray.Add(new SortItemItem(51, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_51_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_51_1")
		}));
		_dataArray.Add(new SortItemItem(52, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_52_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_52_1")
		}));
		_dataArray.Add(new SortItemItem(53, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_53_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_53_1")
		}));
		_dataArray.Add(new SortItemItem(54, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_54_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_54_1")
		}));
		_dataArray.Add(new SortItemItem(55, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_55_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_55_1")
		}));
		_dataArray.Add(new SortItemItem(56, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_56_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_56_1")
		}));
		_dataArray.Add(new SortItemItem(57, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_57_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_57_1")
		}));
		_dataArray.Add(new SortItemItem(58, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_58_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_58_1")
		}));
		_dataArray.Add(new SortItemItem(59, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_59_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_59_1")
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SortItemItem(60, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_60_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_60_1")
		}));
		_dataArray.Add(new SortItemItem(61, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_61_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_61_1")
		}));
		_dataArray.Add(new SortItemItem(62, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_62_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_62_1")
		}));
		_dataArray.Add(new SortItemItem(63, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_63_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_63_1")
		}));
		_dataArray.Add(new SortItemItem(64, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_64_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_64_1")
		}));
		_dataArray.Add(new SortItemItem(65, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_65_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_65_1")
		}));
		_dataArray.Add(new SortItemItem(66, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_66_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_66_1")
		}));
		_dataArray.Add(new SortItemItem(67, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_67_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_67_1")
		}));
		_dataArray.Add(new SortItemItem(68, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_68_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_68_1")
		}));
		_dataArray.Add(new SortItemItem(69, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_69_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_69_1")
		}));
		_dataArray.Add(new SortItemItem(70, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_70_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_70_1")
		}));
		_dataArray.Add(new SortItemItem(71, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_71_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_71_1")
		}));
		_dataArray.Add(new SortItemItem(72, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_72_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_72_1")
		}));
		_dataArray.Add(new SortItemItem(73, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_73_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_73_1")
		}));
		_dataArray.Add(new SortItemItem(74, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_74_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_74_1")
		}));
		_dataArray.Add(new SortItemItem(75, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_75_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_75_1")
		}));
		_dataArray.Add(new SortItemItem(76, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_76_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_76_1")
		}));
		_dataArray.Add(new SortItemItem(77, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_77_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_77_1")
		}));
		_dataArray.Add(new SortItemItem(78, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_78_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_78_1")
		}));
		_dataArray.Add(new SortItemItem(79, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_79_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_79_1")
		}));
		_dataArray.Add(new SortItemItem(80, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_80_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_80_1")
		}));
		_dataArray.Add(new SortItemItem(81, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_81_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_81_1")
		}));
		_dataArray.Add(new SortItemItem(82, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_82_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_82_1")
		}));
		_dataArray.Add(new SortItemItem(83, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_83_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_83_1")
		}));
		_dataArray.Add(new SortItemItem(84, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_84_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_84_1")
		}));
		_dataArray.Add(new SortItemItem(85, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_85_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_85_1")
		}));
		_dataArray.Add(new SortItemItem(86, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_86_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_86_1")
		}));
		_dataArray.Add(new SortItemItem(87, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_87_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_87_1")
		}));
		_dataArray.Add(new SortItemItem(88, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_88_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_88_1")
		}));
		_dataArray.Add(new SortItemItem(89, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_89_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_89_1")
		}));
		_dataArray.Add(new SortItemItem(90, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_90_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_90_1")
		}));
		_dataArray.Add(new SortItemItem(91, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_91_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_91_1")
		}));
		_dataArray.Add(new SortItemItem(92, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_92_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_92_1")
		}));
		_dataArray.Add(new SortItemItem(93, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_93_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_93_1")
		}));
		_dataArray.Add(new SortItemItem(94, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_94_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_94_1")
		}));
		_dataArray.Add(new SortItemItem(95, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_95_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_95_1")
		}));
		_dataArray.Add(new SortItemItem(96, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_96_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_96_1")
		}));
		_dataArray.Add(new SortItemItem(97, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_97_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_97_1")
		}));
		_dataArray.Add(new SortItemItem(98, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_98_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_98_1")
		}));
		_dataArray.Add(new SortItemItem(99, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_99_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_99_1")
		}));
		_dataArray.Add(new SortItemItem(100, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_100_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_100_1")
		}));
		_dataArray.Add(new SortItemItem(101, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_101_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_101_1")
		}));
		_dataArray.Add(new SortItemItem(102, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_102_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_102_1")
		}));
		_dataArray.Add(new SortItemItem(103, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_103_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_103_1")
		}));
		_dataArray.Add(new SortItemItem(104, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_104_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_104_1")
		}));
		_dataArray.Add(new SortItemItem(105, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_105_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_105_1")
		}));
		_dataArray.Add(new SortItemItem(106, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_106_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_106_1")
		}));
		_dataArray.Add(new SortItemItem(107, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_107_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_107_1")
		}));
		_dataArray.Add(new SortItemItem(108, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_108_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_108_1")
		}));
		_dataArray.Add(new SortItemItem(109, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_109_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_109_1")
		}));
		_dataArray.Add(new SortItemItem(110, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_110_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_110_1")
		}));
		_dataArray.Add(new SortItemItem(111, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_111_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_111_1")
		}));
		_dataArray.Add(new SortItemItem(112, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_112_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_112_1")
		}));
		_dataArray.Add(new SortItemItem(113, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_113_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_113_1")
		}));
		_dataArray.Add(new SortItemItem(114, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_114_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_114_1")
		}));
		_dataArray.Add(new SortItemItem(115, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_115_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_115_1")
		}));
		_dataArray.Add(new SortItemItem(116, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_116_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_116_1")
		}));
		_dataArray.Add(new SortItemItem(117, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_117_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_117_1")
		}));
		_dataArray.Add(new SortItemItem(118, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_118_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_118_1")
		}));
		_dataArray.Add(new SortItemItem(119, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_119_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_119_1")
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SortItemItem(120, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_120_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_120_1")
		}));
		_dataArray.Add(new SortItemItem(121, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_121_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_121_1")
		}));
		_dataArray.Add(new SortItemItem(122, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_122_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_122_1")
		}));
		_dataArray.Add(new SortItemItem(123, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_123_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_123_1")
		}));
		_dataArray.Add(new SortItemItem(124, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_124_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_124_1")
		}));
		_dataArray.Add(new SortItemItem(125, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_125_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_125_1")
		}));
		_dataArray.Add(new SortItemItem(126, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_126_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_126_1")
		}));
		_dataArray.Add(new SortItemItem(127, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_127_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_127_1")
		}));
		_dataArray.Add(new SortItemItem(128, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_128_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_128_1")
		}));
		_dataArray.Add(new SortItemItem(129, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_129_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_129_1")
		}));
		_dataArray.Add(new SortItemItem(130, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_130_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_130_1")
		}));
		_dataArray.Add(new SortItemItem(131, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_131_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_131_1")
		}));
		_dataArray.Add(new SortItemItem(132, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_132_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_132_1")
		}));
		_dataArray.Add(new SortItemItem(133, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_133_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_133_1")
		}));
		_dataArray.Add(new SortItemItem(134, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_134_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_134_1")
		}));
		_dataArray.Add(new SortItemItem(135, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_135_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_135_1")
		}));
		_dataArray.Add(new SortItemItem(136, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_136_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_136_1")
		}));
		_dataArray.Add(new SortItemItem(137, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_137_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_137_1")
		}));
		_dataArray.Add(new SortItemItem(138, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_138_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_138_1")
		}));
		_dataArray.Add(new SortItemItem(139, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_139_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_139_1")
		}));
		_dataArray.Add(new SortItemItem(140, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_140_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_140_1")
		}));
		_dataArray.Add(new SortItemItem(141, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_141_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_141_1")
		}));
		_dataArray.Add(new SortItemItem(142, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_142_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_142_1")
		}));
		_dataArray.Add(new SortItemItem(143, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_143_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_143_1")
		}));
		_dataArray.Add(new SortItemItem(144, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_144_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_144_1")
		}));
		_dataArray.Add(new SortItemItem(145, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_145_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_145_1")
		}));
		_dataArray.Add(new SortItemItem(146, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_146_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_146_1")
		}));
		_dataArray.Add(new SortItemItem(147, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_147_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_147_1")
		}));
		_dataArray.Add(new SortItemItem(148, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_148_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_148_1")
		}));
		_dataArray.Add(new SortItemItem(149, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_149_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_149_1")
		}));
		_dataArray.Add(new SortItemItem(150, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_150_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_150_1")
		}));
		_dataArray.Add(new SortItemItem(151, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_151_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_151_1")
		}));
		_dataArray.Add(new SortItemItem(152, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_152_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_152_1")
		}));
		_dataArray.Add(new SortItemItem(153, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_153_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_153_1")
		}));
		_dataArray.Add(new SortItemItem(154, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_154_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_154_1")
		}));
		_dataArray.Add(new SortItemItem(155, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_155_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_155_1")
		}));
		_dataArray.Add(new SortItemItem(156, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_156_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_156_1")
		}));
		_dataArray.Add(new SortItemItem(157, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_157_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_157_1")
		}));
		_dataArray.Add(new SortItemItem(158, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_158_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_158_1")
		}));
		_dataArray.Add(new SortItemItem(159, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_159_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_159_1")
		}));
		_dataArray.Add(new SortItemItem(160, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_160_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_160_1")
		}));
		_dataArray.Add(new SortItemItem(161, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_161_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_161_1")
		}));
		_dataArray.Add(new SortItemItem(162, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_162_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_162_1")
		}));
		_dataArray.Add(new SortItemItem(163, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_163_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_163_1")
		}));
		_dataArray.Add(new SortItemItem(164, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_164_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_164_1")
		}));
		_dataArray.Add(new SortItemItem(165, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_165_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_165_1")
		}));
		_dataArray.Add(new SortItemItem(166, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_166_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_166_1")
		}));
		_dataArray.Add(new SortItemItem(167, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_167_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_167_1")
		}));
		_dataArray.Add(new SortItemItem(168, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_168_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_168_1")
		}));
		_dataArray.Add(new SortItemItem(169, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_169_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_169_1")
		}));
		_dataArray.Add(new SortItemItem(170, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_170_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_170_1")
		}));
		_dataArray.Add(new SortItemItem(171, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_171_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_171_1")
		}));
		_dataArray.Add(new SortItemItem(172, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_172_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_172_1")
		}));
		_dataArray.Add(new SortItemItem(173, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_173_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_173_1")
		}));
		_dataArray.Add(new SortItemItem(174, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_174_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_174_1")
		}));
		_dataArray.Add(new SortItemItem(175, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_175_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_175_1")
		}));
		_dataArray.Add(new SortItemItem(176, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_176_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_176_1")
		}));
		_dataArray.Add(new SortItemItem(177, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_177_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_177_1")
		}));
		_dataArray.Add(new SortItemItem(178, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_178_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_178_1")
		}));
		_dataArray.Add(new SortItemItem(179, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_179_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_179_1")
		}));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new SortItemItem(180, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_180_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_180_1")
		}));
		_dataArray.Add(new SortItemItem(181, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_181_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_181_1")
		}));
		_dataArray.Add(new SortItemItem(182, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_182_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_182_1")
		}));
		_dataArray.Add(new SortItemItem(183, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_183_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_183_1")
		}));
		_dataArray.Add(new SortItemItem(184, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_184_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_184_1")
		}));
		_dataArray.Add(new SortItemItem(185, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_185_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_185_1")
		}));
		_dataArray.Add(new SortItemItem(186, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_186_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_186_1")
		}));
		_dataArray.Add(new SortItemItem(187, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_187_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_187_1")
		}));
		_dataArray.Add(new SortItemItem(188, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_188_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_188_1")
		}));
		_dataArray.Add(new SortItemItem(189, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_189_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_189_1")
		}));
		_dataArray.Add(new SortItemItem(190, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_190_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_190_1")
		}));
		_dataArray.Add(new SortItemItem(191, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_191_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_191_1")
		}));
		_dataArray.Add(new SortItemItem(192, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_192_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_192_1")
		}));
		_dataArray.Add(new SortItemItem(193, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_193_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_193_1")
		}));
		_dataArray.Add(new SortItemItem(194, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_194_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_194_1")
		}));
		_dataArray.Add(new SortItemItem(195, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_195_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_195_1")
		}));
		_dataArray.Add(new SortItemItem(196, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_196_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_196_1")
		}));
		_dataArray.Add(new SortItemItem(197, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_197_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_197_1")
		}));
		_dataArray.Add(new SortItemItem(198, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_198_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_198_1")
		}));
		_dataArray.Add(new SortItemItem(199, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_199_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_199_1")
		}));
		_dataArray.Add(new SortItemItem(200, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_200_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_200_1")
		}));
		_dataArray.Add(new SortItemItem(201, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_201_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_201_1")
		}));
		_dataArray.Add(new SortItemItem(202, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_202_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_202_1")
		}));
		_dataArray.Add(new SortItemItem(203, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_203_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_203_1")
		}));
		_dataArray.Add(new SortItemItem(204, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_204_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_204_1")
		}));
		_dataArray.Add(new SortItemItem(205, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_205_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_205_1")
		}));
		_dataArray.Add(new SortItemItem(206, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_206_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_206_1")
		}));
		_dataArray.Add(new SortItemItem(207, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_207_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_207_1")
		}));
		_dataArray.Add(new SortItemItem(208, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_208_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_208_1")
		}));
		_dataArray.Add(new SortItemItem(209, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_209_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_209_1")
		}));
		_dataArray.Add(new SortItemItem(210, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_210_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_210_1")
		}));
		_dataArray.Add(new SortItemItem(211, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_211_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_211_1")
		}));
		_dataArray.Add(new SortItemItem(212, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_212_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_212_1")
		}));
		_dataArray.Add(new SortItemItem(213, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_213_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_213_1")
		}));
		_dataArray.Add(new SortItemItem(214, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_214_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_214_1")
		}));
		_dataArray.Add(new SortItemItem(215, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_215_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_215_1")
		}));
		_dataArray.Add(new SortItemItem(216, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_216_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_216_1")
		}));
		_dataArray.Add(new SortItemItem(217, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_217_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_217_1")
		}));
		_dataArray.Add(new SortItemItem(218, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_218_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_218_1")
		}));
		_dataArray.Add(new SortItemItem(219, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_219_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_219_1")
		}));
		_dataArray.Add(new SortItemItem(220, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_220_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_220_1")
		}));
		_dataArray.Add(new SortItemItem(221, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_221_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_221_1")
		}));
		_dataArray.Add(new SortItemItem(222, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_222_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_222_1")
		}));
		_dataArray.Add(new SortItemItem(223, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_223_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_223_1")
		}));
		_dataArray.Add(new SortItemItem(224, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_224_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_224_1")
		}));
		_dataArray.Add(new SortItemItem(225, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_225_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_225_1")
		}));
		_dataArray.Add(new SortItemItem(226, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_226_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_226_1")
		}));
		_dataArray.Add(new SortItemItem(227, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_227_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_227_1")
		}));
		_dataArray.Add(new SortItemItem(228, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_228_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_228_1")
		}));
		_dataArray.Add(new SortItemItem(229, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_229_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_229_1")
		}));
		_dataArray.Add(new SortItemItem(230, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_230_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_230_1")
		}));
		_dataArray.Add(new SortItemItem(231, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_231_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_231_1")
		}));
		_dataArray.Add(new SortItemItem(232, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_232_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_232_1")
		}));
		_dataArray.Add(new SortItemItem(233, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_233_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_233_1")
		}));
		_dataArray.Add(new SortItemItem(234, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_234_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_234_1")
		}));
		_dataArray.Add(new SortItemItem(235, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_235_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_235_1")
		}));
		_dataArray.Add(new SortItemItem(236, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_236_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_236_1")
		}));
		_dataArray.Add(new SortItemItem(237, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_237_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_237_1")
		}));
		_dataArray.Add(new SortItemItem(238, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_238_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_238_1")
		}));
		_dataArray.Add(new SortItemItem(239, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_239_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_239_1")
		}));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new SortItemItem(240, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_240_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_240_1")
		}));
		_dataArray.Add(new SortItemItem(241, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_241_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_241_1")
		}));
		_dataArray.Add(new SortItemItem(242, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_242_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_242_1")
		}));
		_dataArray.Add(new SortItemItem(243, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_243_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_243_1")
		}));
		_dataArray.Add(new SortItemItem(244, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_244_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_244_1")
		}));
		_dataArray.Add(new SortItemItem(245, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_245_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_245_1")
		}));
		_dataArray.Add(new SortItemItem(246, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_246_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_246_1")
		}));
		_dataArray.Add(new SortItemItem(247, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_247_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_247_1")
		}));
		_dataArray.Add(new SortItemItem(248, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_248_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_248_1")
		}));
		_dataArray.Add(new SortItemItem(249, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_249_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_249_1")
		}));
		_dataArray.Add(new SortItemItem(250, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_250_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_250_1")
		}));
		_dataArray.Add(new SortItemItem(251, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_251_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_251_1")
		}));
		_dataArray.Add(new SortItemItem(252, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_252_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_252_1")
		}));
		_dataArray.Add(new SortItemItem(253, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_253_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_253_1")
		}));
		_dataArray.Add(new SortItemItem(254, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_254_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_254_1")
		}));
		_dataArray.Add(new SortItemItem(255, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_255_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_255_1")
		}));
		_dataArray.Add(new SortItemItem(256, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_256_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_256_1")
		}));
		_dataArray.Add(new SortItemItem(257, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_257_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_257_1")
		}));
		_dataArray.Add(new SortItemItem(258, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_258_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_258_1")
		}));
		_dataArray.Add(new SortItemItem(259, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_259_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_259_1")
		}));
		_dataArray.Add(new SortItemItem(260, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_260_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_260_1")
		}));
		_dataArray.Add(new SortItemItem(261, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_261_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_261_1")
		}));
		_dataArray.Add(new SortItemItem(262, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_262_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_262_1")
		}));
		_dataArray.Add(new SortItemItem(263, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_263_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_263_1")
		}));
		_dataArray.Add(new SortItemItem(264, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_264_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_264_1")
		}));
		_dataArray.Add(new SortItemItem(265, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_265_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_265_1")
		}));
		_dataArray.Add(new SortItemItem(266, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_266_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_266_1")
		}));
		_dataArray.Add(new SortItemItem(267, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_267_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_267_1")
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SortItemItem>(268);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
