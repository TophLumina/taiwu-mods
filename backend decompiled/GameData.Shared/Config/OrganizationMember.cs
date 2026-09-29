using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class OrganizationMember : ConfigData<OrganizationMemberItem, short>
{
	public static class DefKey
	{
		public const short None = 0;

		public const short XiangshuInfected1 = 1;

		public const short XiangshuInfected2 = 2;

		public const short XiangshuInfected3 = 3;

		public const short XiangshuInfected4 = 4;

		public const short XiangshuInfected5 = 5;

		public const short XiangshuInfected6 = 6;

		public const short XiangshuInfected7 = 7;

		public const short XiangshuInfected8 = 8;

		public const short XiangshuInfected9 = 9;

		public const short Taiwu = 10;

		public const short TianyinPavilionDisciple = 114;

		public const short WuxianLeader = 145;

		public const short WuxianSaintness = 146;
	}

	public static class DefValue
	{
		public static OrganizationMemberItem None => Instance[(short)0];

		public static OrganizationMemberItem XiangshuInfected1 => Instance[(short)1];

		public static OrganizationMemberItem XiangshuInfected2 => Instance[(short)2];

		public static OrganizationMemberItem XiangshuInfected3 => Instance[(short)3];

		public static OrganizationMemberItem XiangshuInfected4 => Instance[(short)4];

		public static OrganizationMemberItem XiangshuInfected5 => Instance[(short)5];

		public static OrganizationMemberItem XiangshuInfected6 => Instance[(short)6];

		public static OrganizationMemberItem XiangshuInfected7 => Instance[(short)7];

		public static OrganizationMemberItem XiangshuInfected8 => Instance[(short)8];

		public static OrganizationMemberItem XiangshuInfected9 => Instance[(short)9];

		public static OrganizationMemberItem Taiwu => Instance[(short)10];

		public static OrganizationMemberItem TianyinPavilionDisciple => Instance[(short)114];

		public static OrganizationMemberItem WuxianLeader => Instance[(short)145];

		public static OrganizationMemberItem WuxianSaintness => Instance[(short)146];
	}

	public static OrganizationMember Instance = new OrganizationMember();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"GradeName", "Organization", "MonasticTitleSuffixes", "FavoriteClothingIds", "HatedClothingIds", "SpouseAnonymousTitles", "MinionGroupId", "Equipment", "Clothing", "Inventory",
		"CombatSkills", "PreferProfessions", "CraftTypes", "TemplateId", "Grade", "Amount", "UpAmount", "DownAmount", "ResourcesAdjust", "LifeSkillsAdjust",
		"LifeSkillGradeLimit", "CombatSkillsAdjust", "MainAttributesAdjust"
	};

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
		List<OrganizationMemberItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_0");
		sbyte[] potentialSuccessorGrades = new sbyte[0];
		sbyte[] childGrade = new sbyte[1];
		string[] monasticTitleSuffixes = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_0_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_0_1")
		};
		List<short> list = new List<short>();
		List<short> favoriteClothingIds = list;
		list = new List<short>();
		List<short> hatedClothingIds = list;
		string[] spouseAnonymousTitles = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_0_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_0_1")
		};
		short[] initialAges = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing = new PresetEquipmentItem("Clothing", -1);
		List<PresetInventoryItem> list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory = list2;
		List<PresetOrgMemberCombatSkill> list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills = list3;
		sbyte[] extraCombatSkillGrids = new sbyte[5];
		short[] resourcesAdjust = new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 };
		short[] lifeSkillsAdjust = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust = new short[6] { -1, -1, -1, -1, -1, -1 };
		List<sbyte> identityInteractConfig = new List<sbyte>();
		dataArray.Add(new OrganizationMemberItem(0, config, 0, 0, potentialSuccessorGrades, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade, 0, -1, -1, 0, 0, monasticTitleSuffixes, 0, 0, 0, 0, 0, favoriteClothingIds, hatedClothingIds, spouseAnonymousTitles, canStroll: false, -1, initialAges, equipment, clothing, inventory, combatSkills, extraCombatSkillGrids, resourcesAdjust, 5000, 1000, 0, 100, 300, lifeSkillsAdjust, 0, combatSkillsAdjust, mainAttributesAdjust, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray2 = _dataArray;
		string config2 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_1");
		sbyte[] potentialSuccessorGrades2 = new sbyte[0];
		sbyte[] childGrade2 = new sbyte[0];
		string[] monasticTitleSuffixes2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_1_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_1_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds2 = list;
		list = new List<short>();
		List<short> hatedClothingIds2 = list;
		string[] spouseAnonymousTitles2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_1_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_1_1")
		};
		short[] initialAges2 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment2 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing2 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory2 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills2 = list3;
		sbyte[] extraCombatSkillGrids2 = new sbyte[5] { 10, 10, 10, 10, 10 };
		short[] resourcesAdjust2 = new short[8];
		short[] lifeSkillsAdjust2 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust2 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust2 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray2.Add(new OrganizationMemberItem(1, config2, 20, 8, potentialSuccessorGrades2, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade2, 0, -1, -1, 0, 0, monasticTitleSuffixes2, 0, 0, 0, 0, 0, favoriteClothingIds2, hatedClothingIds2, spouseAnonymousTitles2, canStroll: false, 208, initialAges2, equipment2, clothing2, inventory2, combatSkills2, extraCombatSkillGrids2, resourcesAdjust2, 0, 0, 0, 100, 61500, lifeSkillsAdjust2, 0, combatSkillsAdjust2, mainAttributesAdjust2, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray3 = _dataArray;
		string config3 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_2");
		sbyte[] potentialSuccessorGrades3 = new sbyte[0];
		sbyte[] childGrade3 = new sbyte[0];
		string[] monasticTitleSuffixes3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_2_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_2_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds3 = list;
		list = new List<short>();
		List<short> hatedClothingIds3 = list;
		string[] spouseAnonymousTitles3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_2_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_2_1")
		};
		short[] initialAges3 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment3 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing3 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory3 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills3 = list3;
		sbyte[] extraCombatSkillGrids3 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust3 = new short[8];
		short[] lifeSkillsAdjust3 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust3 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust3 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray3.Add(new OrganizationMemberItem(2, config3, 20, 7, potentialSuccessorGrades3, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade3, 0, -1, -1, 0, 0, monasticTitleSuffixes3, 0, 0, 0, 0, 0, favoriteClothingIds3, hatedClothingIds3, spouseAnonymousTitles3, canStroll: false, 209, initialAges3, equipment3, clothing3, inventory3, combatSkills3, extraCombatSkillGrids3, resourcesAdjust3, 0, 0, 0, 100, 42300, lifeSkillsAdjust3, 0, combatSkillsAdjust3, mainAttributesAdjust3, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray4 = _dataArray;
		string config4 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_3");
		sbyte[] potentialSuccessorGrades4 = new sbyte[0];
		sbyte[] childGrade4 = new sbyte[0];
		string[] monasticTitleSuffixes4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_3_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_3_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds4 = list;
		list = new List<short>();
		List<short> hatedClothingIds4 = list;
		string[] spouseAnonymousTitles4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_3_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_3_1")
		};
		short[] initialAges4 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment4 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing4 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory4 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills4 = list3;
		sbyte[] extraCombatSkillGrids4 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust4 = new short[8];
		short[] lifeSkillsAdjust4 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust4 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust4 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray4.Add(new OrganizationMemberItem(3, config4, 20, 6, potentialSuccessorGrades4, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade4, 0, -1, -1, 0, 0, monasticTitleSuffixes4, 0, 0, 0, 0, 0, favoriteClothingIds4, hatedClothingIds4, spouseAnonymousTitles4, canStroll: false, 210, initialAges4, equipment4, clothing4, inventory4, combatSkills4, extraCombatSkillGrids4, resourcesAdjust4, 0, 0, 0, 100, 27600, lifeSkillsAdjust4, 0, combatSkillsAdjust4, mainAttributesAdjust4, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray5 = _dataArray;
		string config5 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_4");
		sbyte[] potentialSuccessorGrades5 = new sbyte[0];
		sbyte[] childGrade5 = new sbyte[0];
		string[] monasticTitleSuffixes5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_4_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_4_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds5 = list;
		list = new List<short>();
		List<short> hatedClothingIds5 = list;
		string[] spouseAnonymousTitles5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_4_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_4_1")
		};
		short[] initialAges5 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment5 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing5 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory5 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills5 = list3;
		sbyte[] extraCombatSkillGrids5 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust5 = new short[8];
		short[] lifeSkillsAdjust5 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust5 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust5 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray5.Add(new OrganizationMemberItem(4, config5, 20, 5, potentialSuccessorGrades5, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade5, 0, -1, -1, 0, 0, monasticTitleSuffixes5, 0, 0, 0, 0, 0, favoriteClothingIds5, hatedClothingIds5, spouseAnonymousTitles5, canStroll: false, 211, initialAges5, equipment5, clothing5, inventory5, combatSkills5, extraCombatSkillGrids5, resourcesAdjust5, 0, 0, 0, 100, 16800, lifeSkillsAdjust5, 0, combatSkillsAdjust5, mainAttributesAdjust5, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray6 = _dataArray;
		string config6 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_5");
		sbyte[] potentialSuccessorGrades6 = new sbyte[0];
		sbyte[] childGrade6 = new sbyte[0];
		string[] monasticTitleSuffixes6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_5_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_5_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds6 = list;
		list = new List<short>();
		List<short> hatedClothingIds6 = list;
		string[] spouseAnonymousTitles6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_5_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_5_1")
		};
		short[] initialAges6 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment6 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing6 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory6 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills6 = list3;
		sbyte[] extraCombatSkillGrids6 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust6 = new short[8];
		short[] lifeSkillsAdjust6 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust6 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust6 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray6.Add(new OrganizationMemberItem(5, config6, 20, 4, potentialSuccessorGrades6, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade6, 0, -1, -1, 0, 0, monasticTitleSuffixes6, 0, 0, 0, 0, 0, favoriteClothingIds6, hatedClothingIds6, spouseAnonymousTitles6, canStroll: false, 212, initialAges6, equipment6, clothing6, inventory6, combatSkills6, extraCombatSkillGrids6, resourcesAdjust6, 0, 0, 0, 100, 9300, lifeSkillsAdjust6, 0, combatSkillsAdjust6, mainAttributesAdjust6, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray7 = _dataArray;
		string config7 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_6");
		sbyte[] potentialSuccessorGrades7 = new sbyte[0];
		sbyte[] childGrade7 = new sbyte[0];
		string[] monasticTitleSuffixes7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_6_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_6_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds7 = list;
		list = new List<short>();
		List<short> hatedClothingIds7 = list;
		string[] spouseAnonymousTitles7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_6_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_6_1")
		};
		short[] initialAges7 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment7 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing7 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory7 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills7 = list3;
		sbyte[] extraCombatSkillGrids7 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust7 = new short[8];
		short[] lifeSkillsAdjust7 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust7 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust7 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray7.Add(new OrganizationMemberItem(6, config7, 20, 3, potentialSuccessorGrades7, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade7, 0, -1, -1, 0, 0, monasticTitleSuffixes7, 0, 0, 0, 0, 0, favoriteClothingIds7, hatedClothingIds7, spouseAnonymousTitles7, canStroll: false, 213, initialAges7, equipment7, clothing7, inventory7, combatSkills7, extraCombatSkillGrids7, resourcesAdjust7, 0, 0, 0, 100, 4500, lifeSkillsAdjust7, 0, combatSkillsAdjust7, mainAttributesAdjust7, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray8 = _dataArray;
		string config8 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_7");
		sbyte[] potentialSuccessorGrades8 = new sbyte[0];
		sbyte[] childGrade8 = new sbyte[0];
		string[] monasticTitleSuffixes8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_7_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_7_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds8 = list;
		list = new List<short>();
		List<short> hatedClothingIds8 = list;
		string[] spouseAnonymousTitles8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_7_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_7_1")
		};
		short[] initialAges8 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment8 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing8 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory8 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills8 = list3;
		sbyte[] extraCombatSkillGrids8 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust8 = new short[8];
		short[] lifeSkillsAdjust8 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust8 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust8 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray8.Add(new OrganizationMemberItem(7, config8, 20, 2, potentialSuccessorGrades8, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade8, 0, -1, -1, 0, 0, monasticTitleSuffixes8, 0, 0, 0, 0, 0, favoriteClothingIds8, hatedClothingIds8, spouseAnonymousTitles8, canStroll: false, 214, initialAges8, equipment8, clothing8, inventory8, combatSkills8, extraCombatSkillGrids8, resourcesAdjust8, 0, 0, 0, 100, 1800, lifeSkillsAdjust8, 0, combatSkillsAdjust8, mainAttributesAdjust8, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray9 = _dataArray;
		string config9 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_8");
		sbyte[] potentialSuccessorGrades9 = new sbyte[0];
		sbyte[] childGrade9 = new sbyte[0];
		string[] monasticTitleSuffixes9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_8_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_8_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds9 = list;
		list = new List<short>();
		List<short> hatedClothingIds9 = list;
		string[] spouseAnonymousTitles9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_8_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_8_1")
		};
		short[] initialAges9 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment9 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing9 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory9 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills9 = list3;
		sbyte[] extraCombatSkillGrids9 = new sbyte[5];
		short[] resourcesAdjust9 = new short[8];
		short[] lifeSkillsAdjust9 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust9 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust9 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray9.Add(new OrganizationMemberItem(8, config9, 20, 1, potentialSuccessorGrades9, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade9, 0, -1, -1, 0, 0, monasticTitleSuffixes9, 0, 0, 0, 0, 0, favoriteClothingIds9, hatedClothingIds9, spouseAnonymousTitles9, canStroll: false, 215, initialAges9, equipment9, clothing9, inventory9, combatSkills9, extraCombatSkillGrids9, resourcesAdjust9, 0, 0, 0, 100, 600, lifeSkillsAdjust9, 0, combatSkillsAdjust9, mainAttributesAdjust9, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray10 = _dataArray;
		string config10 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_9");
		sbyte[] potentialSuccessorGrades10 = new sbyte[0];
		sbyte[] childGrade10 = new sbyte[0];
		string[] monasticTitleSuffixes10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_9_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_9_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds10 = list;
		list = new List<short>();
		List<short> hatedClothingIds10 = list;
		string[] spouseAnonymousTitles10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_9_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_9_1")
		};
		short[] initialAges10 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment10 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing10 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory10 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills10 = list3;
		sbyte[] extraCombatSkillGrids10 = new sbyte[5];
		short[] resourcesAdjust10 = new short[8];
		short[] lifeSkillsAdjust10 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust10 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust10 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray10.Add(new OrganizationMemberItem(9, config10, 20, 0, potentialSuccessorGrades10, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade10, 0, -1, -1, 0, 0, monasticTitleSuffixes10, 0, 0, 0, 0, 0, favoriteClothingIds10, hatedClothingIds10, spouseAnonymousTitles10, canStroll: false, 216, initialAges10, equipment10, clothing10, inventory10, combatSkills10, extraCombatSkillGrids10, resourcesAdjust10, 0, 0, 0, 100, 300, lifeSkillsAdjust10, 0, combatSkillsAdjust10, mainAttributesAdjust10, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray11 = _dataArray;
		string config11 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_10");
		sbyte[] potentialSuccessorGrades11 = new sbyte[0];
		sbyte[] childGrade11 = new sbyte[1];
		string[] monasticTitleSuffixes11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_10_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_10_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds11 = list;
		list = new List<short>();
		List<short> hatedClothingIds11 = list;
		string[] spouseAnonymousTitles11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_10_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_10_1")
		};
		short[] initialAges11 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment11 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing11 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory11 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills11 = list3;
		sbyte[] extraCombatSkillGrids11 = new sbyte[5];
		short[] resourcesAdjust11 = new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 };
		short[] lifeSkillsAdjust11 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust11 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust11 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray11.Add(new OrganizationMemberItem(10, config11, 16, 8, potentialSuccessorGrades11, 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, -1, childGrade11, 0, -1, -1, 0, 0, monasticTitleSuffixes11, 0, 0, 0, 0, 0, favoriteClothingIds11, hatedClothingIds11, spouseAnonymousTitles11, canStroll: false, -1, initialAges11, equipment11, clothing11, inventory11, combatSkills11, extraCombatSkillGrids11, resourcesAdjust11, 160000, 576000, 100, 100, 61500, lifeSkillsAdjust11, 0, combatSkillsAdjust11, mainAttributesAdjust11, identityInteractConfig, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray12 = _dataArray;
		string config12 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_11");
		sbyte[] potentialSuccessorGrades12 = new sbyte[0];
		sbyte[] childGrade12 = new sbyte[1];
		string[] monasticTitleSuffixes12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_11_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_11_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds12 = list;
		list = new List<short>();
		List<short> hatedClothingIds12 = list;
		string[] spouseAnonymousTitles12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_11_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_11_1")
		};
		short[] initialAges12 = new short[4] { 42, 50, 58, 66 };
		PresetEquipmentItemWithProb[] equipment12 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing12 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory12 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray12.Add(new OrganizationMemberItem(11, config12, 16, 7, potentialSuccessorGrades12, 1, 1, 1, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade12, 0, -1, 0, 0, 0, monasticTitleSuffixes12, 0, 14, 10000, 0, -100, favoriteClothingIds12, hatedClothingIds12, spouseAnonymousTitles12, canStroll: false, -1, initialAges12, equipment12, clothing12, inventory12, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 100000, 288000, 35, 100, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 51 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 9),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 9),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 18),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 3),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray13 = _dataArray;
		string config13 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_12");
		sbyte[] potentialSuccessorGrades13 = new sbyte[0];
		sbyte[] childGrade13 = new sbyte[1];
		string[] monasticTitleSuffixes13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_12_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_12_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds13 = list;
		list = new List<short>();
		List<short> hatedClothingIds13 = list;
		string[] spouseAnonymousTitles13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_12_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_12_1")
		};
		short[] initialAges13 = new short[4] { 38, 45, 52, 59 };
		PresetEquipmentItemWithProb[] equipment13 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing13 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory13 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray13.Add(new OrganizationMemberItem(12, config13, 16, 6, potentialSuccessorGrades13, 1, 1, 1, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade13, 0, -1, 0, 0, 0, monasticTitleSuffixes13, 0, 12, 8000, 0, -100, favoriteClothingIds13, hatedClothingIds13, spouseAnonymousTitles13, canStroll: false, -1, initialAges13, equipment13, clothing13, inventory13, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 60000, 144000, 30, 100, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 50 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 3),
			new IntPair(6, 3),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 27),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 3),
			new IntPair(3, 30),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray14 = _dataArray;
		string config14 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_13");
		sbyte[] potentialSuccessorGrades14 = new sbyte[0];
		sbyte[] childGrade14 = new sbyte[1];
		string[] monasticTitleSuffixes14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_13_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_13_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds14 = list;
		list = new List<short>();
		List<short> hatedClothingIds14 = list;
		string[] spouseAnonymousTitles14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_13_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_13_1")
		};
		short[] initialAges14 = new short[4] { 28, 34, 40, 46 };
		PresetEquipmentItemWithProb[] equipment14 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing14 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory14 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray14.Add(new OrganizationMemberItem(13, config14, 16, 5, potentialSuccessorGrades14, 1, 1, 1, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade14, 0, -1, 0, 0, 0, monasticTitleSuffixes14, 0, 10, 6000, 0, -100, favoriteClothingIds14, hatedClothingIds14, spouseAnonymousTitles14, canStroll: true, -1, initialAges14, equipment14, clothing14, inventory14, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 40000, 48000, 25, 100, 16800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 49, 58, 3 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 6),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 30),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray15 = _dataArray;
		string config15 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_14");
		sbyte[] potentialSuccessorGrades15 = new sbyte[0];
		sbyte[] childGrade15 = new sbyte[1];
		string[] monasticTitleSuffixes15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_14_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_14_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds15 = list;
		list = new List<short>();
		List<short> hatedClothingIds15 = list;
		string[] spouseAnonymousTitles15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_14_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_14_1")
		};
		short[] initialAges15 = new short[4] { 25, 30, 35, 40 };
		PresetEquipmentItemWithProb[] equipment15 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing15 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory15 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray15.Add(new OrganizationMemberItem(14, config15, 16, 4, potentialSuccessorGrades15, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade15, 0, -1, 0, 0, 0, monasticTitleSuffixes15, 0, 8, 4500, 0, -100, favoriteClothingIds15, hatedClothingIds15, spouseAnonymousTitles15, canStroll: true, -1, initialAges15, equipment15, clothing15, inventory15, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 30000, 24000, 20, 100, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 4, 48, 53 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 30),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray16 = _dataArray;
		string config16 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_15");
		sbyte[] potentialSuccessorGrades16 = new sbyte[0];
		sbyte[] childGrade16 = new sbyte[1];
		string[] monasticTitleSuffixes16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_15_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_15_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds16 = list;
		list = new List<short>();
		List<short> hatedClothingIds16 = list;
		string[] spouseAnonymousTitles16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_15_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_15_1")
		};
		short[] initialAges16 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment16 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing16 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory16 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray16.Add(new OrganizationMemberItem(15, config16, 16, 3, potentialSuccessorGrades16, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade16, 0, -1, 0, 0, 0, monasticTitleSuffixes16, 0, 6, 3000, 0, -100, favoriteClothingIds16, hatedClothingIds16, spouseAnonymousTitles16, canStroll: true, -1, initialAges16, equipment16, clothing16, inventory16, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 20000, 12000, 15, 100, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 5, 47, 54 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 9),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray17 = _dataArray;
		string config17 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_16");
		sbyte[] potentialSuccessorGrades17 = new sbyte[0];
		sbyte[] childGrade17 = new sbyte[1];
		string[] monasticTitleSuffixes17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_16_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_16_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds17 = list;
		list = new List<short>();
		List<short> hatedClothingIds17 = list;
		string[] spouseAnonymousTitles17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_16_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_16_1")
		};
		short[] initialAges17 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment17 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing17 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory17 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray17.Add(new OrganizationMemberItem(16, config17, 16, 2, potentialSuccessorGrades17, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade17, 0, -1, 0, 0, 0, monasticTitleSuffixes17, 0, 4, 2000, 0, -100, favoriteClothingIds17, hatedClothingIds17, spouseAnonymousTitles17, canStroll: true, -1, initialAges17, equipment17, clothing17, inventory17, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 15000, 4000, 10, 100, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 6, 46, 61 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 18),
			new IntPair(2, 30),
			new IntPair(1, 9),
			new IntPair(11, 15),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray18 = _dataArray;
		string config18 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_17");
		sbyte[] potentialSuccessorGrades18 = new sbyte[0];
		sbyte[] childGrade18 = new sbyte[1];
		string[] monasticTitleSuffixes18 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_17_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_17_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds18 = list;
		list = new List<short>();
		List<short> hatedClothingIds18 = list;
		string[] spouseAnonymousTitles18 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_17_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_17_1")
		};
		short[] initialAges18 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment18 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing18 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory18 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		dataArray18.Add(new OrganizationMemberItem(17, config18, 16, 1, potentialSuccessorGrades18, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade18, 0, -1, 0, 0, 0, monasticTitleSuffixes18, 0, 2, 1000, 0, -100, favoriteClothingIds18, hatedClothingIds18, spouseAnonymousTitles18, canStroll: true, -1, initialAges18, equipment18, clothing18, inventory18, list3, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 }, 10000, 2000, 5, 100, 600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 3, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 45, 59, 62 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 18),
			new IntPair(2, 6),
			new IntPair(1, 15),
			new IntPair(11, 15),
			new IntPair(0, 30),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray19 = _dataArray;
		string config19 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_18");
		sbyte[] potentialSuccessorGrades19 = new sbyte[0];
		sbyte[] childGrade19 = new sbyte[1];
		string[] monasticTitleSuffixes19 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_18_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_18_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds19 = list;
		list = new List<short>();
		List<short> hatedClothingIds19 = list;
		string[] spouseAnonymousTitles19 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_18_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_18_1")
		};
		short[] initialAges19 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment19 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing19 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory19 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills12 = list3;
		sbyte[] extraCombatSkillGrids12 = new sbyte[5];
		short[] resourcesAdjust12 = new short[8] { -70, -70, -70, -70, -70, -70, -70, -70 };
		short[] lifeSkillsAdjust12 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust12 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust12 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray19.Add(new OrganizationMemberItem(18, config19, 16, 0, potentialSuccessorGrades19, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade19, 0, -1, 0, 0, 0, monasticTitleSuffixes19, 0, 0, 500, 0, -100, favoriteClothingIds19, hatedClothingIds19, spouseAnonymousTitles19, canStroll: true, -1, initialAges19, equipment19, clothing19, inventory19, combatSkills12, extraCombatSkillGrids12, resourcesAdjust12, 5000, 1000, 1, 100, 300, lifeSkillsAdjust12, 3, combatSkillsAdjust12, mainAttributesAdjust12, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 30),
			new IntPair(2, 9),
			new IntPair(1, 12),
			new IntPair(11, 9),
			new IntPair(0, 15),
			new IntPair(9, 15)
		}, null));
		List<OrganizationMemberItem> dataArray20 = _dataArray;
		string config20 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_19");
		sbyte[] potentialSuccessorGrades20 = new sbyte[0];
		sbyte[] childGrade20 = new sbyte[1];
		string[] monasticTitleSuffixes20 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_19_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_19_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds20 = list;
		list = new List<short>();
		List<short> hatedClothingIds20 = list;
		string[] spouseAnonymousTitles20 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_19_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_19_1")
		};
		short[] initialAges20 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment20 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing20 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory20 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills13 = list3;
		sbyte[] extraCombatSkillGrids13 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust13 = new short[8];
		short[] lifeSkillsAdjust13 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust13 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust13 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray20.Add(new OrganizationMemberItem(19, config20, 17, 8, potentialSuccessorGrades20, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade20, 0, -1, -1, 0, 0, monasticTitleSuffixes20, 0, 0, 0, 0, 0, favoriteClothingIds20, hatedClothingIds20, spouseAnonymousTitles20, canStroll: false, -1, initialAges20, equipment20, clothing20, inventory20, combatSkills13, extraCombatSkillGrids13, resourcesAdjust13, 0, 0, 0, 100, 61500, lifeSkillsAdjust13, 8, combatSkillsAdjust13, mainAttributesAdjust13, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray21 = _dataArray;
		string config21 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_20");
		sbyte[] potentialSuccessorGrades21 = new sbyte[0];
		sbyte[] childGrade21 = new sbyte[1];
		string[] monasticTitleSuffixes21 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_20_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_20_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds21 = list;
		list = new List<short>();
		List<short> hatedClothingIds21 = list;
		string[] spouseAnonymousTitles21 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_20_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_20_1")
		};
		short[] initialAges21 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment21 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing21 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory21 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills14 = list3;
		sbyte[] extraCombatSkillGrids14 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust14 = new short[8];
		short[] lifeSkillsAdjust14 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust14 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust14 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray21.Add(new OrganizationMemberItem(20, config21, 17, 7, potentialSuccessorGrades21, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade21, 0, -1, -1, 0, 0, monasticTitleSuffixes21, 0, 0, 0, 0, 0, favoriteClothingIds21, hatedClothingIds21, spouseAnonymousTitles21, canStroll: false, -1, initialAges21, equipment21, clothing21, inventory21, combatSkills14, extraCombatSkillGrids14, resourcesAdjust14, 0, 0, 0, 100, 42300, lifeSkillsAdjust14, 8, combatSkillsAdjust14, mainAttributesAdjust14, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray22 = _dataArray;
		string config22 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_21");
		sbyte[] potentialSuccessorGrades22 = new sbyte[0];
		sbyte[] childGrade22 = new sbyte[1];
		string[] monasticTitleSuffixes22 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_21_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_21_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds22 = list;
		list = new List<short>();
		List<short> hatedClothingIds22 = list;
		string[] spouseAnonymousTitles22 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_21_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_21_1")
		};
		short[] initialAges22 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment22 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing22 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory22 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills15 = list3;
		sbyte[] extraCombatSkillGrids15 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust15 = new short[8];
		short[] lifeSkillsAdjust15 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust15 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust15 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray22.Add(new OrganizationMemberItem(21, config22, 17, 6, potentialSuccessorGrades22, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade22, 0, -1, -1, 0, 0, monasticTitleSuffixes22, 0, 0, 0, 0, 0, favoriteClothingIds22, hatedClothingIds22, spouseAnonymousTitles22, canStroll: false, -1, initialAges22, equipment22, clothing22, inventory22, combatSkills15, extraCombatSkillGrids15, resourcesAdjust15, 0, 0, 0, 100, 27600, lifeSkillsAdjust15, 7, combatSkillsAdjust15, mainAttributesAdjust15, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray23 = _dataArray;
		string config23 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_22");
		sbyte[] potentialSuccessorGrades23 = new sbyte[0];
		sbyte[] childGrade23 = new sbyte[1];
		string[] monasticTitleSuffixes23 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_22_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_22_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds23 = list;
		list = new List<short>();
		List<short> hatedClothingIds23 = list;
		string[] spouseAnonymousTitles23 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_22_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_22_1")
		};
		short[] initialAges23 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment23 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing23 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory23 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills16 = list3;
		sbyte[] extraCombatSkillGrids16 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust16 = new short[8];
		short[] lifeSkillsAdjust16 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust16 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust16 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray23.Add(new OrganizationMemberItem(22, config23, 17, 5, potentialSuccessorGrades23, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade23, 0, -1, -1, 0, 0, monasticTitleSuffixes23, 0, 0, 0, 0, 0, favoriteClothingIds23, hatedClothingIds23, spouseAnonymousTitles23, canStroll: false, -1, initialAges23, equipment23, clothing23, inventory23, combatSkills16, extraCombatSkillGrids16, resourcesAdjust16, 0, 0, 0, 100, 16800, lifeSkillsAdjust16, 7, combatSkillsAdjust16, mainAttributesAdjust16, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray24 = _dataArray;
		string config24 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_23");
		sbyte[] potentialSuccessorGrades24 = new sbyte[0];
		sbyte[] childGrade24 = new sbyte[1];
		string[] monasticTitleSuffixes24 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_23_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_23_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds24 = list;
		list = new List<short>();
		List<short> hatedClothingIds24 = list;
		string[] spouseAnonymousTitles24 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_23_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_23_1")
		};
		short[] initialAges24 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment24 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing24 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory24 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills17 = list3;
		sbyte[] extraCombatSkillGrids17 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust17 = new short[8];
		short[] lifeSkillsAdjust17 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust17 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust17 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray24.Add(new OrganizationMemberItem(23, config24, 17, 4, potentialSuccessorGrades24, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade24, 0, -1, -1, 0, 0, monasticTitleSuffixes24, 0, 0, 0, 0, 0, favoriteClothingIds24, hatedClothingIds24, spouseAnonymousTitles24, canStroll: false, -1, initialAges24, equipment24, clothing24, inventory24, combatSkills17, extraCombatSkillGrids17, resourcesAdjust17, 0, 0, 0, 100, 9300, lifeSkillsAdjust17, 6, combatSkillsAdjust17, mainAttributesAdjust17, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray25 = _dataArray;
		string config25 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_24");
		sbyte[] potentialSuccessorGrades25 = new sbyte[0];
		sbyte[] childGrade25 = new sbyte[1];
		string[] monasticTitleSuffixes25 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_24_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_24_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds25 = list;
		list = new List<short>();
		List<short> hatedClothingIds25 = list;
		string[] spouseAnonymousTitles25 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_24_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_24_1")
		};
		short[] initialAges25 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment25 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing25 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory25 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills18 = list3;
		sbyte[] extraCombatSkillGrids18 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust18 = new short[8];
		short[] lifeSkillsAdjust18 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust18 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust18 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray25.Add(new OrganizationMemberItem(24, config25, 17, 3, potentialSuccessorGrades25, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade25, 0, -1, -1, 0, 0, monasticTitleSuffixes25, 0, 0, 0, 0, 0, favoriteClothingIds25, hatedClothingIds25, spouseAnonymousTitles25, canStroll: false, -1, initialAges25, equipment25, clothing25, inventory25, combatSkills18, extraCombatSkillGrids18, resourcesAdjust18, 0, 0, 0, 100, 4500, lifeSkillsAdjust18, 5, combatSkillsAdjust18, mainAttributesAdjust18, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray26 = _dataArray;
		string config26 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_25");
		sbyte[] potentialSuccessorGrades26 = new sbyte[0];
		sbyte[] childGrade26 = new sbyte[1];
		string[] monasticTitleSuffixes26 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_25_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_25_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds26 = list;
		list = new List<short>();
		List<short> hatedClothingIds26 = list;
		string[] spouseAnonymousTitles26 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_25_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_25_1")
		};
		short[] initialAges26 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment26 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing26 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory26 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills19 = list3;
		sbyte[] extraCombatSkillGrids19 = new sbyte[5];
		short[] resourcesAdjust19 = new short[8];
		short[] lifeSkillsAdjust19 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust19 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust19 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray26.Add(new OrganizationMemberItem(25, config26, 17, 2, potentialSuccessorGrades26, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade26, 0, -1, -1, 0, 0, monasticTitleSuffixes26, 0, 0, 0, 0, 0, favoriteClothingIds26, hatedClothingIds26, spouseAnonymousTitles26, canStroll: false, -1, initialAges26, equipment26, clothing26, inventory26, combatSkills19, extraCombatSkillGrids19, resourcesAdjust19, 0, 0, 0, 100, 1800, lifeSkillsAdjust19, 4, combatSkillsAdjust19, mainAttributesAdjust19, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray27 = _dataArray;
		string config27 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_26");
		sbyte[] potentialSuccessorGrades27 = new sbyte[0];
		sbyte[] childGrade27 = new sbyte[1];
		string[] monasticTitleSuffixes27 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_26_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_26_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds27 = list;
		list = new List<short>();
		List<short> hatedClothingIds27 = list;
		string[] spouseAnonymousTitles27 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_26_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_26_1")
		};
		short[] initialAges27 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment27 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing27 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory27 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills20 = list3;
		sbyte[] extraCombatSkillGrids20 = new sbyte[5];
		short[] resourcesAdjust20 = new short[8];
		short[] lifeSkillsAdjust20 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust20 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust20 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray27.Add(new OrganizationMemberItem(26, config27, 17, 1, potentialSuccessorGrades27, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade27, 0, -1, -1, 0, 0, monasticTitleSuffixes27, 0, 0, 0, 0, 0, favoriteClothingIds27, hatedClothingIds27, spouseAnonymousTitles27, canStroll: false, -1, initialAges27, equipment27, clothing27, inventory27, combatSkills20, extraCombatSkillGrids20, resourcesAdjust20, 0, 0, 0, 100, 600, lifeSkillsAdjust20, 3, combatSkillsAdjust20, mainAttributesAdjust20, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray28 = _dataArray;
		string config28 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_27");
		sbyte[] potentialSuccessorGrades28 = new sbyte[0];
		sbyte[] childGrade28 = new sbyte[1];
		string[] monasticTitleSuffixes28 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_27_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_27_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds28 = list;
		list = new List<short>();
		List<short> hatedClothingIds28 = list;
		string[] spouseAnonymousTitles28 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_27_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_27_1")
		};
		short[] initialAges28 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment28 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing28 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory28 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills21 = list3;
		sbyte[] extraCombatSkillGrids21 = new sbyte[5];
		short[] resourcesAdjust21 = new short[8];
		short[] lifeSkillsAdjust21 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust21 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust21 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray28.Add(new OrganizationMemberItem(27, config28, 17, 0, potentialSuccessorGrades28, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade28, 0, -1, -1, 0, 0, monasticTitleSuffixes28, 0, 0, 0, 0, 0, favoriteClothingIds28, hatedClothingIds28, spouseAnonymousTitles28, canStroll: false, -1, initialAges28, equipment28, clothing28, inventory28, combatSkills21, extraCombatSkillGrids21, resourcesAdjust21, 0, 0, 0, 100, 300, lifeSkillsAdjust21, 2, combatSkillsAdjust21, mainAttributesAdjust21, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray29 = _dataArray;
		string config29 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_28");
		sbyte[] potentialSuccessorGrades29 = new sbyte[0];
		sbyte[] childGrade29 = new sbyte[1];
		string[] monasticTitleSuffixes29 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_28_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_28_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds29 = list;
		list = new List<short>();
		List<short> hatedClothingIds29 = list;
		string[] spouseAnonymousTitles29 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_28_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_28_1")
		};
		short[] initialAges29 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment29 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing29 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory29 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills22 = list3;
		sbyte[] extraCombatSkillGrids22 = new sbyte[5] { 10, 10, 10, 10, 10 };
		short[] resourcesAdjust22 = new short[8];
		short[] lifeSkillsAdjust22 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust22 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust22 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray29.Add(new OrganizationMemberItem(28, config29, 18, 8, potentialSuccessorGrades29, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade29, 0, -1, -1, 0, 0, monasticTitleSuffixes29, 0, 0, 0, 0, 0, favoriteClothingIds29, hatedClothingIds29, spouseAnonymousTitles29, canStroll: false, -1, initialAges29, equipment29, clothing29, inventory29, combatSkills22, extraCombatSkillGrids22, resourcesAdjust22, 0, 0, 0, 100, 61500, lifeSkillsAdjust22, 8, combatSkillsAdjust22, mainAttributesAdjust22, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray30 = _dataArray;
		string config30 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_29");
		sbyte[] potentialSuccessorGrades30 = new sbyte[0];
		sbyte[] childGrade30 = new sbyte[1];
		string[] monasticTitleSuffixes30 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_29_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_29_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds30 = list;
		list = new List<short>();
		List<short> hatedClothingIds30 = list;
		string[] spouseAnonymousTitles30 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_29_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_29_1")
		};
		short[] initialAges30 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment30 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing30 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory30 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills23 = list3;
		sbyte[] extraCombatSkillGrids23 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust23 = new short[8];
		short[] lifeSkillsAdjust23 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust23 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust23 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray30.Add(new OrganizationMemberItem(29, config30, 18, 7, potentialSuccessorGrades30, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade30, 0, -1, -1, 0, 0, monasticTitleSuffixes30, 0, 0, 0, 0, 0, favoriteClothingIds30, hatedClothingIds30, spouseAnonymousTitles30, canStroll: false, -1, initialAges30, equipment30, clothing30, inventory30, combatSkills23, extraCombatSkillGrids23, resourcesAdjust23, 0, 0, 0, 100, 42300, lifeSkillsAdjust23, 8, combatSkillsAdjust23, mainAttributesAdjust23, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray31 = _dataArray;
		string config31 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_30");
		sbyte[] potentialSuccessorGrades31 = new sbyte[0];
		sbyte[] childGrade31 = new sbyte[1];
		string[] monasticTitleSuffixes31 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_30_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_30_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds31 = list;
		list = new List<short>();
		List<short> hatedClothingIds31 = list;
		string[] spouseAnonymousTitles31 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_30_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_30_1")
		};
		short[] initialAges31 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment31 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing31 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory31 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills24 = list3;
		sbyte[] extraCombatSkillGrids24 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust24 = new short[8];
		short[] lifeSkillsAdjust24 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust24 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust24 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray31.Add(new OrganizationMemberItem(30, config31, 18, 6, potentialSuccessorGrades31, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade31, 0, -1, -1, 0, 0, monasticTitleSuffixes31, 0, 0, 0, 0, 0, favoriteClothingIds31, hatedClothingIds31, spouseAnonymousTitles31, canStroll: false, -1, initialAges31, equipment31, clothing31, inventory31, combatSkills24, extraCombatSkillGrids24, resourcesAdjust24, 0, 0, 0, 100, 27600, lifeSkillsAdjust24, 7, combatSkillsAdjust24, mainAttributesAdjust24, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray32 = _dataArray;
		string config32 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_31");
		sbyte[] potentialSuccessorGrades32 = new sbyte[0];
		sbyte[] childGrade32 = new sbyte[1];
		string[] monasticTitleSuffixes32 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_31_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_31_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds32 = list;
		list = new List<short>();
		List<short> hatedClothingIds32 = list;
		string[] spouseAnonymousTitles32 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_31_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_31_1")
		};
		short[] initialAges32 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment32 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing32 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory32 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills25 = list3;
		sbyte[] extraCombatSkillGrids25 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust25 = new short[8];
		short[] lifeSkillsAdjust25 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust25 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust25 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray32.Add(new OrganizationMemberItem(31, config32, 18, 5, potentialSuccessorGrades32, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade32, 0, -1, -1, 0, 0, monasticTitleSuffixes32, 0, 0, 0, 0, 0, favoriteClothingIds32, hatedClothingIds32, spouseAnonymousTitles32, canStroll: false, -1, initialAges32, equipment32, clothing32, inventory32, combatSkills25, extraCombatSkillGrids25, resourcesAdjust25, 0, 0, 0, 100, 16800, lifeSkillsAdjust25, 7, combatSkillsAdjust25, mainAttributesAdjust25, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray33 = _dataArray;
		string config33 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_32");
		sbyte[] potentialSuccessorGrades33 = new sbyte[0];
		sbyte[] childGrade33 = new sbyte[1];
		string[] monasticTitleSuffixes33 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_32_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_32_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds33 = list;
		list = new List<short>();
		List<short> hatedClothingIds33 = list;
		string[] spouseAnonymousTitles33 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_32_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_32_1")
		};
		short[] initialAges33 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment33 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing33 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory33 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills26 = list3;
		sbyte[] extraCombatSkillGrids26 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust26 = new short[8];
		short[] lifeSkillsAdjust26 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust26 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust26 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray33.Add(new OrganizationMemberItem(32, config33, 18, 4, potentialSuccessorGrades33, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade33, 0, -1, -1, 0, 0, monasticTitleSuffixes33, 0, 0, 0, 0, 0, favoriteClothingIds33, hatedClothingIds33, spouseAnonymousTitles33, canStroll: false, -1, initialAges33, equipment33, clothing33, inventory33, combatSkills26, extraCombatSkillGrids26, resourcesAdjust26, 0, 0, 0, 100, 9300, lifeSkillsAdjust26, 6, combatSkillsAdjust26, mainAttributesAdjust26, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray34 = _dataArray;
		string config34 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_33");
		sbyte[] potentialSuccessorGrades34 = new sbyte[0];
		sbyte[] childGrade34 = new sbyte[1];
		string[] monasticTitleSuffixes34 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_33_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_33_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds34 = list;
		list = new List<short>();
		List<short> hatedClothingIds34 = list;
		string[] spouseAnonymousTitles34 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_33_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_33_1")
		};
		short[] initialAges34 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment34 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing34 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory34 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills27 = list3;
		sbyte[] extraCombatSkillGrids27 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust27 = new short[8];
		short[] lifeSkillsAdjust27 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust27 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust27 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray34.Add(new OrganizationMemberItem(33, config34, 18, 3, potentialSuccessorGrades34, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade34, 0, -1, -1, 0, 0, monasticTitleSuffixes34, 0, 0, 0, 0, 0, favoriteClothingIds34, hatedClothingIds34, spouseAnonymousTitles34, canStroll: false, -1, initialAges34, equipment34, clothing34, inventory34, combatSkills27, extraCombatSkillGrids27, resourcesAdjust27, 0, 0, 0, 100, 4500, lifeSkillsAdjust27, 5, combatSkillsAdjust27, mainAttributesAdjust27, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray35 = _dataArray;
		string config35 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_34");
		sbyte[] potentialSuccessorGrades35 = new sbyte[0];
		sbyte[] childGrade35 = new sbyte[1];
		string[] monasticTitleSuffixes35 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_34_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_34_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds35 = list;
		list = new List<short>();
		List<short> hatedClothingIds35 = list;
		string[] spouseAnonymousTitles35 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_34_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_34_1")
		};
		short[] initialAges35 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment35 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing35 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory35 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills28 = list3;
		sbyte[] extraCombatSkillGrids28 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust28 = new short[8];
		short[] lifeSkillsAdjust28 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust28 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust28 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray35.Add(new OrganizationMemberItem(34, config35, 18, 2, potentialSuccessorGrades35, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade35, 0, -1, -1, 0, 0, monasticTitleSuffixes35, 0, 0, 0, 0, 0, favoriteClothingIds35, hatedClothingIds35, spouseAnonymousTitles35, canStroll: false, -1, initialAges35, equipment35, clothing35, inventory35, combatSkills28, extraCombatSkillGrids28, resourcesAdjust28, 0, 0, 0, 100, 1800, lifeSkillsAdjust28, 4, combatSkillsAdjust28, mainAttributesAdjust28, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray36 = _dataArray;
		string config36 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_35");
		sbyte[] potentialSuccessorGrades36 = new sbyte[0];
		sbyte[] childGrade36 = new sbyte[1];
		string[] monasticTitleSuffixes36 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_35_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_35_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds36 = list;
		list = new List<short>();
		List<short> hatedClothingIds36 = list;
		string[] spouseAnonymousTitles36 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_35_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_35_1")
		};
		short[] initialAges36 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment36 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing36 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory36 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills29 = list3;
		sbyte[] extraCombatSkillGrids29 = new sbyte[5];
		short[] resourcesAdjust29 = new short[8];
		short[] lifeSkillsAdjust29 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust29 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust29 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray36.Add(new OrganizationMemberItem(35, config36, 18, 1, potentialSuccessorGrades36, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade36, 0, -1, -1, 0, 0, monasticTitleSuffixes36, 0, 0, 0, 0, 0, favoriteClothingIds36, hatedClothingIds36, spouseAnonymousTitles36, canStroll: false, -1, initialAges36, equipment36, clothing36, inventory36, combatSkills29, extraCombatSkillGrids29, resourcesAdjust29, 0, 0, 0, 100, 600, lifeSkillsAdjust29, 3, combatSkillsAdjust29, mainAttributesAdjust29, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray37 = _dataArray;
		string config37 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_36");
		sbyte[] potentialSuccessorGrades37 = new sbyte[0];
		sbyte[] childGrade37 = new sbyte[1];
		string[] monasticTitleSuffixes37 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_36_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_36_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds37 = list;
		list = new List<short>();
		List<short> hatedClothingIds37 = list;
		string[] spouseAnonymousTitles37 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_36_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_36_1")
		};
		short[] initialAges37 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment37 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing37 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory37 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills30 = list3;
		sbyte[] extraCombatSkillGrids30 = new sbyte[5];
		short[] resourcesAdjust30 = new short[8];
		short[] lifeSkillsAdjust30 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust30 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust30 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray37.Add(new OrganizationMemberItem(36, config37, 18, 0, potentialSuccessorGrades37, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade37, 0, -1, -1, 0, 0, monasticTitleSuffixes37, 0, 0, 0, 0, 0, favoriteClothingIds37, hatedClothingIds37, spouseAnonymousTitles37, canStroll: false, -1, initialAges37, equipment37, clothing37, inventory37, combatSkills30, extraCombatSkillGrids30, resourcesAdjust30, 0, 0, 0, 100, 300, lifeSkillsAdjust30, 2, combatSkillsAdjust30, mainAttributesAdjust30, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray38 = _dataArray;
		string config38 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_37");
		sbyte[] potentialSuccessorGrades38 = new sbyte[0];
		sbyte[] childGrade38 = new sbyte[1];
		string[] monasticTitleSuffixes38 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_37_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_37_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds38 = list;
		list = new List<short>();
		List<short> hatedClothingIds38 = list;
		string[] spouseAnonymousTitles38 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_37_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_37_1")
		};
		short[] initialAges38 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment38 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing38 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory38 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills31 = list3;
		sbyte[] extraCombatSkillGrids31 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust31 = new short[8];
		short[] lifeSkillsAdjust31 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust31 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust31 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray38.Add(new OrganizationMemberItem(37, config38, 19, 8, potentialSuccessorGrades38, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade38, 0, -1, -1, 0, 0, monasticTitleSuffixes38, 0, 0, 0, 0, 0, favoriteClothingIds38, hatedClothingIds38, spouseAnonymousTitles38, canStroll: false, -1, initialAges38, equipment38, clothing38, inventory38, combatSkills31, extraCombatSkillGrids31, resourcesAdjust31, 0, 0, 0, 100, 61500, lifeSkillsAdjust31, 8, combatSkillsAdjust31, mainAttributesAdjust31, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray39 = _dataArray;
		string config39 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_38");
		sbyte[] potentialSuccessorGrades39 = new sbyte[0];
		sbyte[] childGrade39 = new sbyte[1];
		string[] monasticTitleSuffixes39 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_38_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_38_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds39 = list;
		list = new List<short>();
		List<short> hatedClothingIds39 = list;
		string[] spouseAnonymousTitles39 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_38_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_38_1")
		};
		short[] initialAges39 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment39 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing39 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory39 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills32 = list3;
		sbyte[] extraCombatSkillGrids32 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust32 = new short[8];
		short[] lifeSkillsAdjust32 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust32 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust32 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray39.Add(new OrganizationMemberItem(38, config39, 19, 7, potentialSuccessorGrades39, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade39, 0, -1, -1, 0, 0, monasticTitleSuffixes39, 0, 0, 0, 0, 0, favoriteClothingIds39, hatedClothingIds39, spouseAnonymousTitles39, canStroll: false, -1, initialAges39, equipment39, clothing39, inventory39, combatSkills32, extraCombatSkillGrids32, resourcesAdjust32, 0, 0, 0, 100, 42300, lifeSkillsAdjust32, 8, combatSkillsAdjust32, mainAttributesAdjust32, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray40 = _dataArray;
		string config40 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_39");
		sbyte[] potentialSuccessorGrades40 = new sbyte[0];
		sbyte[] childGrade40 = new sbyte[1];
		string[] monasticTitleSuffixes40 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_39_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_39_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds40 = list;
		list = new List<short>();
		List<short> hatedClothingIds40 = list;
		string[] spouseAnonymousTitles40 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_39_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_39_1")
		};
		short[] initialAges40 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment40 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing40 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory40 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills33 = list3;
		sbyte[] extraCombatSkillGrids33 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust33 = new short[8];
		short[] lifeSkillsAdjust33 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust33 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust33 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray40.Add(new OrganizationMemberItem(39, config40, 19, 6, potentialSuccessorGrades40, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade40, 0, -1, -1, 0, 0, monasticTitleSuffixes40, 0, 0, 0, 0, 0, favoriteClothingIds40, hatedClothingIds40, spouseAnonymousTitles40, canStroll: false, -1, initialAges40, equipment40, clothing40, inventory40, combatSkills33, extraCombatSkillGrids33, resourcesAdjust33, 0, 0, 0, 100, 27600, lifeSkillsAdjust33, 7, combatSkillsAdjust33, mainAttributesAdjust33, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray41 = _dataArray;
		string config41 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_40");
		sbyte[] potentialSuccessorGrades41 = new sbyte[0];
		sbyte[] childGrade41 = new sbyte[1];
		string[] monasticTitleSuffixes41 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_40_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_40_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds41 = list;
		list = new List<short>();
		List<short> hatedClothingIds41 = list;
		string[] spouseAnonymousTitles41 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_40_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_40_1")
		};
		short[] initialAges41 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment41 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing41 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory41 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills34 = list3;
		sbyte[] extraCombatSkillGrids34 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust34 = new short[8];
		short[] lifeSkillsAdjust34 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust34 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust34 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray41.Add(new OrganizationMemberItem(40, config41, 19, 5, potentialSuccessorGrades41, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade41, 0, -1, -1, 0, 0, monasticTitleSuffixes41, 0, 0, 0, 0, 0, favoriteClothingIds41, hatedClothingIds41, spouseAnonymousTitles41, canStroll: false, -1, initialAges41, equipment41, clothing41, inventory41, combatSkills34, extraCombatSkillGrids34, resourcesAdjust34, 0, 0, 0, 100, 16800, lifeSkillsAdjust34, 7, combatSkillsAdjust34, mainAttributesAdjust34, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray42 = _dataArray;
		string config42 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_41");
		sbyte[] potentialSuccessorGrades42 = new sbyte[0];
		sbyte[] childGrade42 = new sbyte[1];
		string[] monasticTitleSuffixes42 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_41_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_41_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds42 = list;
		list = new List<short>();
		List<short> hatedClothingIds42 = list;
		string[] spouseAnonymousTitles42 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_41_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_41_1")
		};
		short[] initialAges42 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment42 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing42 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory42 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills35 = list3;
		sbyte[] extraCombatSkillGrids35 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust35 = new short[8];
		short[] lifeSkillsAdjust35 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust35 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust35 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray42.Add(new OrganizationMemberItem(41, config42, 19, 4, potentialSuccessorGrades42, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade42, 0, -1, -1, 0, 0, monasticTitleSuffixes42, 0, 0, 0, 0, 0, favoriteClothingIds42, hatedClothingIds42, spouseAnonymousTitles42, canStroll: false, -1, initialAges42, equipment42, clothing42, inventory42, combatSkills35, extraCombatSkillGrids35, resourcesAdjust35, 0, 0, 0, 100, 9300, lifeSkillsAdjust35, 6, combatSkillsAdjust35, mainAttributesAdjust35, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray43 = _dataArray;
		string config43 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_42");
		sbyte[] potentialSuccessorGrades43 = new sbyte[0];
		sbyte[] childGrade43 = new sbyte[1];
		string[] monasticTitleSuffixes43 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_42_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_42_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds43 = list;
		list = new List<short>();
		List<short> hatedClothingIds43 = list;
		string[] spouseAnonymousTitles43 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_42_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_42_1")
		};
		short[] initialAges43 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment43 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing43 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory43 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills36 = list3;
		sbyte[] extraCombatSkillGrids36 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust36 = new short[8];
		short[] lifeSkillsAdjust36 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust36 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust36 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray43.Add(new OrganizationMemberItem(42, config43, 19, 3, potentialSuccessorGrades43, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade43, 0, -1, -1, 0, 0, monasticTitleSuffixes43, 0, 0, 0, 0, 0, favoriteClothingIds43, hatedClothingIds43, spouseAnonymousTitles43, canStroll: false, -1, initialAges43, equipment43, clothing43, inventory43, combatSkills36, extraCombatSkillGrids36, resourcesAdjust36, 0, 0, 0, 100, 4500, lifeSkillsAdjust36, 5, combatSkillsAdjust36, mainAttributesAdjust36, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray44 = _dataArray;
		string config44 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_43");
		sbyte[] potentialSuccessorGrades44 = new sbyte[0];
		sbyte[] childGrade44 = new sbyte[1];
		string[] monasticTitleSuffixes44 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_43_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_43_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds44 = list;
		list = new List<short>();
		List<short> hatedClothingIds44 = list;
		string[] spouseAnonymousTitles44 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_43_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_43_1")
		};
		short[] initialAges44 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment44 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing44 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory44 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills37 = list3;
		sbyte[] extraCombatSkillGrids37 = new sbyte[5];
		short[] resourcesAdjust37 = new short[8];
		short[] lifeSkillsAdjust37 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust37 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust37 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray44.Add(new OrganizationMemberItem(43, config44, 19, 2, potentialSuccessorGrades44, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade44, 0, -1, -1, 0, 0, monasticTitleSuffixes44, 0, 0, 0, 0, 0, favoriteClothingIds44, hatedClothingIds44, spouseAnonymousTitles44, canStroll: false, -1, initialAges44, equipment44, clothing44, inventory44, combatSkills37, extraCombatSkillGrids37, resourcesAdjust37, 0, 0, 0, 100, 1800, lifeSkillsAdjust37, 4, combatSkillsAdjust37, mainAttributesAdjust37, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray45 = _dataArray;
		string config45 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_44");
		sbyte[] potentialSuccessorGrades45 = new sbyte[0];
		sbyte[] childGrade45 = new sbyte[1];
		string[] monasticTitleSuffixes45 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_44_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_44_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds45 = list;
		list = new List<short>();
		List<short> hatedClothingIds45 = list;
		string[] spouseAnonymousTitles45 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_44_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_44_1")
		};
		short[] initialAges45 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment45 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing45 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory45 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills38 = list3;
		sbyte[] extraCombatSkillGrids38 = new sbyte[5];
		short[] resourcesAdjust38 = new short[8];
		short[] lifeSkillsAdjust38 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust38 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust38 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray45.Add(new OrganizationMemberItem(44, config45, 19, 1, potentialSuccessorGrades45, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade45, 0, -1, -1, 0, 0, monasticTitleSuffixes45, 0, 0, 0, 0, 0, favoriteClothingIds45, hatedClothingIds45, spouseAnonymousTitles45, canStroll: false, -1, initialAges45, equipment45, clothing45, inventory45, combatSkills38, extraCombatSkillGrids38, resourcesAdjust38, 0, 0, 0, 100, 600, lifeSkillsAdjust38, 3, combatSkillsAdjust38, mainAttributesAdjust38, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray46 = _dataArray;
		string config46 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_45");
		sbyte[] potentialSuccessorGrades46 = new sbyte[0];
		sbyte[] childGrade46 = new sbyte[1];
		string[] monasticTitleSuffixes46 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_45_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_45_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds46 = list;
		list = new List<short>();
		List<short> hatedClothingIds46 = list;
		string[] spouseAnonymousTitles46 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_45_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_45_1")
		};
		short[] initialAges46 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment46 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing46 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory46 = list2;
		list3 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills39 = list3;
		sbyte[] extraCombatSkillGrids39 = new sbyte[5];
		short[] resourcesAdjust39 = new short[8];
		short[] lifeSkillsAdjust39 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust39 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust39 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray46.Add(new OrganizationMemberItem(45, config46, 19, 0, potentialSuccessorGrades46, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade46, 0, -1, -1, 0, 0, monasticTitleSuffixes46, 0, 0, 0, 0, 0, favoriteClothingIds46, hatedClothingIds46, spouseAnonymousTitles46, canStroll: false, -1, initialAges46, equipment46, clothing46, inventory46, combatSkills39, extraCombatSkillGrids39, resourcesAdjust39, 0, 0, 0, 100, 300, lifeSkillsAdjust39, 2, combatSkillsAdjust39, mainAttributesAdjust39, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		_dataArray.Add(new OrganizationMemberItem(46, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_46"), 1, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, 1, -1, 0, -1, new sbyte[0], 7, -1, 7, 100, 130, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_46_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_46_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 18, 19, 20, 6, 12 }, new List<short> { 58, 59, 60, 81, 82 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_46_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_46_1")
		}, canStroll: false, 217, new short[4] { 42, 50, 58, 66 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 20), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 40),
			new PresetInventoryItem("SkillBook", 9, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 8),
			new PresetOrgMemberCombatSkill(114, 5),
			new PresetOrgMemberCombatSkill(209, 8),
			new PresetOrgMemberCombatSkill(329, 7),
			new PresetOrgMemberCombatSkill(408, 5),
			new PresetOrgMemberCombatSkill(632, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 }, 80000, 288000, 20, 20, 61500, new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		}, 8, new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		}, new short[6] { 9, -1, 12, 9, -1, -1 }, new List<sbyte> { 9, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 42),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 42),
			new IntPair(4, 9),
			new IntPair(3, 3),
			new IntPair(13, 12),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(47, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_47"), 1, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 1, -1, 0, -1, new sbyte[0], 7, -1, 7, 100, 130, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_47_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_47_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 18, 19, 20, 6, 12 }, new List<short> { 58, 59, 60, 81, 82 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_47_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_47_1")
		}, canStroll: false, 218, new short[4] { 38, 45, 52, 59 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 20), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 40),
			new PresetInventoryItem("SkillBook", 9, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 7),
			new PresetOrgMemberCombatSkill(114, 5),
			new PresetOrgMemberCombatSkill(209, 7),
			new PresetOrgMemberCombatSkill(329, 6),
			new PresetOrgMemberCombatSkill(408, 5),
			new PresetOrgMemberCombatSkill(632, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 }, 50000, 144000, 15, 30, 42300, new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		}, 8, new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		}, new short[6] { 9, -1, 12, 9, -1, -1 }, new List<sbyte> { 9, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 42),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 42),
			new IntPair(4, 9),
			new IntPair(3, 3),
			new IntPair(13, 12),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(48, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_48"), 1, 6, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, 1, -1, 1, -1, new sbyte[0], 6, -1, 6, 100, 130, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_48_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_48_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 18, 19, 20, 6, 12 }, new List<short> { 58, 59, 60, 81, 82 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_48_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_48_1")
		}, canStroll: false, 219, new short[4] { 34, 40, 46, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 19), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 40),
			new PresetInventoryItem("SkillBook", 9, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 6),
			new PresetOrgMemberCombatSkill(114, 4),
			new PresetOrgMemberCombatSkill(209, 6),
			new PresetOrgMemberCombatSkill(329, 6),
			new PresetOrgMemberCombatSkill(408, 4),
			new PresetOrgMemberCombatSkill(632, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 }, 30000, 72000, 15, 40, 27600, new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		}, 7, new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		}, new short[6] { 9, -1, 12, 9, -1, -1 }, new List<sbyte> { 9, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 42),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 42),
			new IntPair(4, 9),
			new IntPair(3, 3),
			new IntPair(13, 12),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray47 = _dataArray;
		string config47 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_49");
		sbyte[] potentialSuccessorGrades47 = new sbyte[0];
		sbyte[] childGrade47 = new sbyte[0];
		string[] monasticTitleSuffixes47 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_49_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_49_1")
		};
		List<short> favoriteClothingIds47 = new List<short> { 18, 19, 20, 6, 12 };
		List<short> hatedClothingIds47 = new List<short> { 58, 59, 60, 81, 82 };
		string[] spouseAnonymousTitles47 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_49_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_49_1")
		};
		short[] initialAges47 = new short[4] { 30, 35, 40, 45 };
		PresetEquipmentItemWithProb[] equipment47 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing47 = new PresetEquipmentItem("Clothing", 19);
		List<PresetInventoryItem> inventory47 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 30),
			new PresetInventoryItem("SkillBook", 9, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills40 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 5),
			new PresetOrgMemberCombatSkill(114, 4),
			new PresetOrgMemberCombatSkill(209, 5),
			new PresetOrgMemberCombatSkill(329, 5),
			new PresetOrgMemberCombatSkill(408, 4),
			new PresetOrgMemberCombatSkill(632, 5)
		};
		sbyte[] extraCombatSkillGrids40 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust40 = new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 };
		short[] lifeSkillsAdjust40 = new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		};
		short[] combatSkillsAdjust40 = new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		};
		short[] mainAttributesAdjust40 = new short[6] { 9, -1, 12, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray47.Add(new OrganizationMemberItem(49, config47, 1, 5, potentialSuccessorGrades47, 18, 27, 9, restrictPrincipalAmount: false, 1, -1, 1, -1, childGrade47, 5, 8, 5, 100, 130, monasticTitleSuffixes47, 4200, 10, 6000, 8400, 0, favoriteClothingIds47, hatedClothingIds47, spouseAnonymousTitles47, canStroll: false, 220, initialAges47, equipment47, clothing47, inventory47, combatSkills40, extraCombatSkillGrids40, resourcesAdjust40, 20000, 24000, 10, 50, 16800, lifeSkillsAdjust40, 6, combatSkillsAdjust40, mainAttributesAdjust40, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 33),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 33),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 9),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 9)
		}, null));
		List<OrganizationMemberItem> dataArray48 = _dataArray;
		string config48 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_50");
		sbyte[] potentialSuccessorGrades48 = new sbyte[0];
		sbyte[] childGrade48 = new sbyte[0];
		string[] monasticTitleSuffixes48 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_50_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_50_1")
		};
		List<short> favoriteClothingIds48 = new List<short> { 18, 19, 20, 6, 12 };
		List<short> hatedClothingIds48 = new List<short> { 58, 59, 60, 81, 82 };
		string[] spouseAnonymousTitles48 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_50_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_50_1")
		};
		short[] initialAges48 = new short[4] { 26, 30, 34, 38 };
		PresetEquipmentItemWithProb[] equipment48 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing48 = new PresetEquipmentItem("Clothing", 19);
		List<PresetInventoryItem> inventory48 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 30),
			new PresetInventoryItem("SkillBook", 9, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills41 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 4),
			new PresetOrgMemberCombatSkill(114, 3),
			new PresetOrgMemberCombatSkill(209, 4),
			new PresetOrgMemberCombatSkill(329, 4),
			new PresetOrgMemberCombatSkill(408, 3),
			new PresetOrgMemberCombatSkill(632, 4)
		};
		sbyte[] extraCombatSkillGrids41 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust41 = new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 };
		short[] lifeSkillsAdjust41 = new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		};
		short[] combatSkillsAdjust41 = new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		};
		short[] mainAttributesAdjust41 = new short[6] { 9, -1, 12, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray48.Add(new OrganizationMemberItem(50, config48, 1, 4, potentialSuccessorGrades48, 4, 6, 2, restrictPrincipalAmount: false, 1, -1, 1, -1, childGrade48, 4, 7, 4, 100, 130, monasticTitleSuffixes48, 2800, 8, 4500, 4650, 0, favoriteClothingIds48, hatedClothingIds48, spouseAnonymousTitles48, canStroll: true, 221, initialAges48, equipment48, clothing48, inventory48, combatSkills41, extraCombatSkillGrids41, resourcesAdjust41, 15000, 12000, 10, 60, 9300, lifeSkillsAdjust41, 5, combatSkillsAdjust41, mainAttributesAdjust41, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 33),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 33),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 9),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 9)
		}, null));
		List<OrganizationMemberItem> dataArray49 = _dataArray;
		string config49 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_51");
		sbyte[] potentialSuccessorGrades49 = new sbyte[0];
		sbyte[] childGrade49 = new sbyte[0];
		string[] monasticTitleSuffixes49 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_51_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_51_1")
		};
		List<short> favoriteClothingIds49 = new List<short> { 18, 19, 20, 6, 12 };
		List<short> hatedClothingIds49 = new List<short> { 58, 59, 60, 81, 82 };
		string[] spouseAnonymousTitles49 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_51_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_51_1")
		};
		short[] initialAges49 = new short[4] { 22, 25, 28, 31 };
		PresetEquipmentItemWithProb[] equipment49 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing49 = new PresetEquipmentItem("Clothing", 18);
		List<PresetInventoryItem> inventory49 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 30),
			new PresetInventoryItem("SkillBook", 9, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills42 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 3),
			new PresetOrgMemberCombatSkill(114, 3),
			new PresetOrgMemberCombatSkill(209, 3),
			new PresetOrgMemberCombatSkill(329, 3),
			new PresetOrgMemberCombatSkill(408, 3),
			new PresetOrgMemberCombatSkill(632, 3)
		};
		sbyte[] extraCombatSkillGrids42 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust42 = new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 };
		short[] lifeSkillsAdjust42 = new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		};
		short[] combatSkillsAdjust42 = new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		};
		short[] mainAttributesAdjust42 = new short[6] { 9, -1, 12, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray49.Add(new OrganizationMemberItem(51, config49, 1, 3, potentialSuccessorGrades49, 6, 9, 3, restrictPrincipalAmount: false, 1, -1, 1, -1, childGrade49, 3, 6, 3, 100, 130, monasticTitleSuffixes49, 1800, 6, 3000, 2250, 0, favoriteClothingIds49, hatedClothingIds49, spouseAnonymousTitles49, canStroll: true, 222, initialAges49, equipment49, clothing49, inventory49, combatSkills42, extraCombatSkillGrids42, resourcesAdjust42, 10000, 6000, 10, 70, 4500, lifeSkillsAdjust42, 4, combatSkillsAdjust42, mainAttributesAdjust42, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 33),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 33),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 9),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 9)
		}, null));
		List<OrganizationMemberItem> dataArray50 = _dataArray;
		string config50 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_52");
		sbyte[] potentialSuccessorGrades50 = new sbyte[0];
		sbyte[] childGrade50 = new sbyte[0];
		string[] monasticTitleSuffixes50 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_52_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_52_1")
		};
		List<short> favoriteClothingIds50 = new List<short> { 18, 19, 20, 6, 12 };
		List<short> hatedClothingIds50 = new List<short> { 58, 59, 60, 81, 82 };
		string[] spouseAnonymousTitles50 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_52_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_52_1")
		};
		short[] initialAges50 = new short[4] { 18, 20, 22, 24 };
		PresetEquipmentItemWithProb[] equipment50 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing50 = new PresetEquipmentItem("Clothing", 18);
		List<PresetInventoryItem> inventory50 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 20),
			new PresetInventoryItem("SkillBook", 9, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills43 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 2),
			new PresetOrgMemberCombatSkill(114, 2),
			new PresetOrgMemberCombatSkill(209, 2),
			new PresetOrgMemberCombatSkill(329, 2),
			new PresetOrgMemberCombatSkill(632, 2)
		};
		sbyte[] extraCombatSkillGrids43 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust43 = new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 };
		short[] lifeSkillsAdjust43 = new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		};
		short[] combatSkillsAdjust43 = new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		};
		short[] mainAttributesAdjust43 = new short[6] { 9, -1, 12, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray50.Add(new OrganizationMemberItem(52, config50, 1, 2, potentialSuccessorGrades50, 6, 9, 3, restrictPrincipalAmount: false, 1, -1, 1, -1, childGrade50, 2, 6, 2, 100, 130, monasticTitleSuffixes50, 600, 4, 2000, 900, 0, favoriteClothingIds50, hatedClothingIds50, spouseAnonymousTitles50, canStroll: true, 223, initialAges50, equipment50, clothing50, inventory50, combatSkills43, extraCombatSkillGrids43, resourcesAdjust43, 7500, 2000, 5, 80, 1800, lifeSkillsAdjust43, 3, combatSkillsAdjust43, mainAttributesAdjust43, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 24),
			new IntPair(4, 3),
			new IntPair(3, 9),
			new IntPair(13, 6),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 12)
		}, null));
		List<OrganizationMemberItem> dataArray51 = _dataArray;
		string config51 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_53");
		sbyte[] potentialSuccessorGrades51 = new sbyte[0];
		sbyte[] childGrade51 = new sbyte[0];
		string[] monasticTitleSuffixes51 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_53_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_53_1")
		};
		List<short> favoriteClothingIds51 = new List<short> { 18, 19, 20, 6, 12 };
		List<short> hatedClothingIds51 = new List<short> { 58, 59, 60, 81, 82 };
		string[] spouseAnonymousTitles51 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_53_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_53_1")
		};
		short[] initialAges51 = new short[4] { 14, 15, 16, 17 };
		PresetEquipmentItemWithProb[] equipment51 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing51 = new PresetEquipmentItem("Clothing", 18);
		List<PresetInventoryItem> inventory51 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 20),
			new PresetInventoryItem("SkillBook", 9, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills44 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 1),
			new PresetOrgMemberCombatSkill(114, 1),
			new PresetOrgMemberCombatSkill(209, 1),
			new PresetOrgMemberCombatSkill(632, 1)
		};
		sbyte[] extraCombatSkillGrids44 = new sbyte[5];
		short[] resourcesAdjust44 = new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 };
		short[] lifeSkillsAdjust44 = new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		};
		short[] combatSkillsAdjust44 = new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		};
		short[] mainAttributesAdjust44 = new short[6] { 9, -1, 12, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray51.Add(new OrganizationMemberItem(53, config51, 1, 1, potentialSuccessorGrades51, 6, 9, 3, restrictPrincipalAmount: false, 1, -1, 1, -1, childGrade51, 1, 6, 1, 100, 130, monasticTitleSuffixes51, 300, 2, 1000, 300, 0, favoriteClothingIds51, hatedClothingIds51, spouseAnonymousTitles51, canStroll: true, 224, initialAges51, equipment51, clothing51, inventory51, combatSkills44, extraCombatSkillGrids44, resourcesAdjust44, 5000, 1000, 5, 90, 600, lifeSkillsAdjust44, 2, combatSkillsAdjust44, mainAttributesAdjust44, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 24),
			new IntPair(4, 3),
			new IntPair(3, 9),
			new IntPair(13, 6),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 12)
		}, null));
		List<OrganizationMemberItem> dataArray52 = _dataArray;
		string config52 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_54");
		sbyte[] potentialSuccessorGrades52 = new sbyte[0];
		sbyte[] childGrade52 = new sbyte[0];
		string[] monasticTitleSuffixes52 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_54_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_54_1")
		};
		List<short> favoriteClothingIds52 = new List<short> { 18, 19, 20, 6, 12 };
		List<short> hatedClothingIds52 = new List<short> { 58, 59, 60, 81, 82 };
		string[] spouseAnonymousTitles52 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_54_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_54_1")
		};
		short[] initialAges52 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment52 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 333, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 189, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing52 = new PresetEquipmentItem("Clothing", 18);
		List<PresetInventoryItem> inventory52 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 3, 20),
			new PresetInventoryItem("SkillBook", 9, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills45 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(4, 0),
			new PresetOrgMemberCombatSkill(114, 0),
			new PresetOrgMemberCombatSkill(632, 0)
		};
		sbyte[] extraCombatSkillGrids45 = new sbyte[5];
		short[] resourcesAdjust45 = new short[8] { -80, -70, -70, -70, -70, -70, -80, -80 };
		short[] lifeSkillsAdjust45 = new short[16]
		{
			-1, 9, -1, -1, -1, -1, -1, -1, 9, 2,
			-1, -1, 2, 12, -1, -1
		};
		short[] combatSkillsAdjust45 = new short[14]
		{
			12, 6, 12, 12, 6, -1, -1, -1, -1, 12,
			-1, -1, 2, -1
		};
		short[] mainAttributesAdjust45 = new short[6] { 9, -1, 12, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray52.Add(new OrganizationMemberItem(54, config52, 1, 0, potentialSuccessorGrades52, 4, 6, 2, restrictPrincipalAmount: false, 1, -1, 1, -1, childGrade52, 0, 6, 0, 100, 130, monasticTitleSuffixes52, 150, 0, 500, 150, 0, favoriteClothingIds52, hatedClothingIds52, spouseAnonymousTitles52, canStroll: true, 225, initialAges52, equipment52, clothing52, inventory52, combatSkills45, extraCombatSkillGrids45, resourcesAdjust45, 2500, 500, 1, 100, 300, lifeSkillsAdjust45, 1, combatSkillsAdjust45, mainAttributesAdjust45, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 0),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 0),
			new IntPair(12, 24),
			new IntPair(4, 3),
			new IntPair(3, 9),
			new IntPair(13, 6),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 12)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(55, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_55"), 2, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 4 }, 7, -1, 7, 50, 130, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_55_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_55_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 21, 22, 23, 6, 12, 5, 14 }, new List<short> { 49, 50, 51 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_55_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_55_1")
		}, canStroll: false, 226, new short[4] { 31, 38, 45, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 23), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("SkillBook", 108, 1, 40),
			new PresetInventoryItem("SkillBook", 126, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 7),
			new PresetOrgMemberCombatSkill(120, 6),
			new PresetOrgMemberCombatSkill(218, 8),
			new PresetOrgMemberCombatSkill(337, 6),
			new PresetOrgMemberCombatSkill(414, 8),
			new PresetOrgMemberCombatSkill(534, 6),
			new PresetOrgMemberCombatSkill(658, 7)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		}, 8, new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		}, new short[6] { -1, 12, 9, 2, 9, 9 }, new List<sbyte> { 10, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 24),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 24),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 9),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 9),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(56, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_56"), 2, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 3 }, 7, -1, 7, 50, 130, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_56_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_56_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 21, 22, 23, 6, 12, 5, 14 }, new List<short> { 49, 50, 51 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_56_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_56_1")
		}, canStroll: false, 227, new short[4] { 34, 42, 50, 58 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 22), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("SkillBook", 108, 1, 40),
			new PresetInventoryItem("SkillBook", 126, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 7),
			new PresetOrgMemberCombatSkill(120, 5),
			new PresetOrgMemberCombatSkill(218, 7),
			new PresetOrgMemberCombatSkill(337, 6),
			new PresetOrgMemberCombatSkill(414, 7),
			new PresetOrgMemberCombatSkill(534, 6),
			new PresetOrgMemberCombatSkill(658, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		}, 8, new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		}, new short[6] { -1, 12, 9, 2, 9, 9 }, new List<sbyte> { 10, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 24),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 24),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 9),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 9),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(57, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_57"), 2, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 5, 8, 6, 50, 130, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_57_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_57_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 21, 22, 23, 6, 12, 5, 14 }, new List<short> { 49, 50, 51 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_57_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_57_1")
		}, canStroll: false, 228, new short[4] { 28, 34, 40, 46 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 22), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("SkillBook", 108, 1, 40),
			new PresetInventoryItem("SkillBook", 126, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 6),
			new PresetOrgMemberCombatSkill(120, 5),
			new PresetOrgMemberCombatSkill(218, 6),
			new PresetOrgMemberCombatSkill(337, 5),
			new PresetOrgMemberCombatSkill(414, 6),
			new PresetOrgMemberCombatSkill(534, 5),
			new PresetOrgMemberCombatSkill(658, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		}, 7, new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		}, new short[6] { -1, 12, 9, 2, 9, 9 }, new List<sbyte> { 10, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 24),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 24),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 9),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 9),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray53 = _dataArray;
		string config53 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_58");
		sbyte[] potentialSuccessorGrades53 = new sbyte[0];
		sbyte[] childGrade53 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes53 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_58_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_58_1")
		};
		List<short> favoriteClothingIds53 = new List<short> { 21, 22, 23, 6, 12, 5, 14 };
		List<short> hatedClothingIds53 = new List<short> { 49, 50, 51 };
		string[] spouseAnonymousTitles53 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_58_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_58_1")
		};
		short[] initialAges53 = new short[4] { 25, 30, 35, 40 };
		PresetEquipmentItemWithProb[] equipment53 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing53 = new PresetEquipmentItem("Clothing", 22);
		List<PresetInventoryItem> inventory53 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("SkillBook", 108, 1, 30),
			new PresetInventoryItem("SkillBook", 126, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 20),
			new PresetInventoryItem("Medicine", 238, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 20),
			new PresetInventoryItem("Medicine", 322, 1, 20),
			new PresetInventoryItem("Medicine", 298, 1, 20),
			new PresetInventoryItem("Medicine", 274, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills46 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 5),
			new PresetOrgMemberCombatSkill(120, 4),
			new PresetOrgMemberCombatSkill(218, 5),
			new PresetOrgMemberCombatSkill(337, 5),
			new PresetOrgMemberCombatSkill(414, 5),
			new PresetOrgMemberCombatSkill(534, 5),
			new PresetOrgMemberCombatSkill(658, 5)
		};
		sbyte[] extraCombatSkillGrids46 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust46 = new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 };
		short[] lifeSkillsAdjust46 = new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		};
		short[] combatSkillsAdjust46 = new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust46 = new short[6] { -1, 12, 9, 2, 9, 9 };
		identityInteractConfig = new List<sbyte>();
		dataArray53.Add(new OrganizationMemberItem(58, config53, 2, 5, potentialSuccessorGrades53, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade53, 5, 8, 5, 50, 130, monasticTitleSuffixes53, 4200, 10, 6000, 8400, 0, favoriteClothingIds53, hatedClothingIds53, spouseAnonymousTitles53, canStroll: true, 229, initialAges53, equipment53, clothing53, inventory53, combatSkills46, extraCombatSkillGrids46, resourcesAdjust46, 40000, 48000, 10, 50, 16800, lifeSkillsAdjust46, 6, combatSkillsAdjust46, mainAttributesAdjust46, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 18),
			new IntPair(6, 18),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 18),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 6),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray54 = _dataArray;
		string config54 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_59");
		sbyte[] potentialSuccessorGrades54 = new sbyte[0];
		sbyte[] childGrade54 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes54 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_59_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_59_1")
		};
		List<short> favoriteClothingIds54 = new List<short> { 21, 22, 23, 6, 12, 5, 14 };
		List<short> hatedClothingIds54 = new List<short> { 49, 50, 51 };
		string[] spouseAnonymousTitles54 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_59_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_59_1")
		};
		short[] initialAges54 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment54 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing54 = new PresetEquipmentItem("Clothing", 21);
		List<PresetInventoryItem> inventory54 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("SkillBook", 108, 1, 30),
			new PresetInventoryItem("SkillBook", 126, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 20),
			new PresetInventoryItem("Medicine", 238, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 20),
			new PresetInventoryItem("Medicine", 322, 1, 20),
			new PresetInventoryItem("Medicine", 298, 1, 20),
			new PresetInventoryItem("Medicine", 274, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills47 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 4),
			new PresetOrgMemberCombatSkill(120, 4),
			new PresetOrgMemberCombatSkill(218, 4),
			new PresetOrgMemberCombatSkill(414, 4),
			new PresetOrgMemberCombatSkill(534, 4),
			new PresetOrgMemberCombatSkill(658, 4)
		};
		sbyte[] extraCombatSkillGrids47 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust47 = new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 };
		short[] lifeSkillsAdjust47 = new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		};
		short[] combatSkillsAdjust47 = new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust47 = new short[6] { -1, 12, 9, 2, 9, 9 };
		identityInteractConfig = new List<sbyte>();
		dataArray54.Add(new OrganizationMemberItem(59, config54, 2, 4, potentialSuccessorGrades54, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade54, 4, 7, 4, 50, 130, monasticTitleSuffixes54, 2800, 8, 4500, 4650, 0, favoriteClothingIds54, hatedClothingIds54, spouseAnonymousTitles54, canStroll: true, 230, initialAges54, equipment54, clothing54, inventory54, combatSkills47, extraCombatSkillGrids47, resourcesAdjust47, 30000, 24000, 10, 60, 9300, lifeSkillsAdjust47, 5, combatSkillsAdjust47, mainAttributesAdjust47, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 18),
			new IntPair(6, 18),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 18),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 6),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
	}

	private void CreateItems1()
	{
		List<OrganizationMemberItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_60");
		sbyte[] potentialSuccessorGrades = new sbyte[0];
		sbyte[] childGrade = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_60_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_60_1")
		};
		List<short> favoriteClothingIds = new List<short> { 21, 22, 23, 6, 12, 5, 14 };
		List<short> hatedClothingIds = new List<short> { 49, 50, 51 };
		string[] spouseAnonymousTitles = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_60_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_60_1")
		};
		short[] initialAges = new short[4] { 19, 22, 25, 28 };
		PresetEquipmentItemWithProb[] equipment = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing = new PresetEquipmentItem("Clothing", 21);
		List<PresetInventoryItem> inventory = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("SkillBook", 108, 1, 30),
			new PresetInventoryItem("SkillBook", 126, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 20),
			new PresetInventoryItem("Medicine", 238, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 20),
			new PresetInventoryItem("Medicine", 322, 1, 20),
			new PresetInventoryItem("Medicine", 298, 1, 20),
			new PresetInventoryItem("Medicine", 274, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 3),
			new PresetOrgMemberCombatSkill(120, 3),
			new PresetOrgMemberCombatSkill(218, 3),
			new PresetOrgMemberCombatSkill(337, 3),
			new PresetOrgMemberCombatSkill(534, 3),
			new PresetOrgMemberCombatSkill(658, 3)
		};
		sbyte[] extraCombatSkillGrids = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust = new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 };
		short[] lifeSkillsAdjust = new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		};
		short[] combatSkillsAdjust = new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust = new short[6] { -1, 12, 9, 2, 9, 9 };
		List<sbyte> identityInteractConfig = new List<sbyte>();
		dataArray.Add(new OrganizationMemberItem(60, config, 2, 3, potentialSuccessorGrades, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade, 3, 7, 3, 50, 130, monasticTitleSuffixes, 1800, 6, 3000, 2250, 0, favoriteClothingIds, hatedClothingIds, spouseAnonymousTitles, canStroll: true, 231, initialAges, equipment, clothing, inventory, combatSkills, extraCombatSkillGrids, resourcesAdjust, 20000, 12000, 10, 70, 4500, lifeSkillsAdjust, 4, combatSkillsAdjust, mainAttributesAdjust, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 18),
			new IntPair(6, 18),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 18),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 6),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray2 = _dataArray;
		string config2 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_61");
		sbyte[] potentialSuccessorGrades2 = new sbyte[0];
		sbyte[] childGrade2 = new sbyte[1];
		string[] monasticTitleSuffixes2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_61_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_61_1")
		};
		List<short> favoriteClothingIds2 = new List<short> { 21, 22, 23, 6, 12, 5, 14 };
		List<short> hatedClothingIds2 = new List<short> { 49, 50, 51 };
		string[] spouseAnonymousTitles2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_61_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_61_1")
		};
		short[] initialAges2 = new short[4] { 16, 18, 20, 22 };
		PresetEquipmentItemWithProb[] equipment2 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 99, 75),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", 495, 75),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 216, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing2 = new PresetEquipmentItem("Clothing", 21);
		List<PresetInventoryItem> inventory2 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("SkillBook", 108, 1, 20),
			new PresetInventoryItem("SkillBook", 126, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("TeaWine", 18, 1, 10),
			new PresetInventoryItem("TeaWine", 27, 1, 10)
		};
		List<PresetOrgMemberCombatSkill> combatSkills2 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 2),
			new PresetOrgMemberCombatSkill(120, 2),
			new PresetOrgMemberCombatSkill(218, 2),
			new PresetOrgMemberCombatSkill(414, 2),
			new PresetOrgMemberCombatSkill(534, 2),
			new PresetOrgMemberCombatSkill(658, 2)
		};
		sbyte[] extraCombatSkillGrids2 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust2 = new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 };
		short[] lifeSkillsAdjust2 = new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		};
		short[] combatSkillsAdjust2 = new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust2 = new short[6] { -1, 12, 9, 2, 9, 9 };
		identityInteractConfig = new List<sbyte>();
		dataArray2.Add(new OrganizationMemberItem(61, config2, 2, 2, potentialSuccessorGrades2, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade2, 2, 6, 2, 50, 130, monasticTitleSuffixes2, 600, 4, 2000, 900, 0, favoriteClothingIds2, hatedClothingIds2, spouseAnonymousTitles2, canStroll: true, 232, initialAges2, equipment2, clothing2, inventory2, combatSkills2, extraCombatSkillGrids2, resourcesAdjust2, 15000, 4000, 5, 80, 1800, lifeSkillsAdjust2, 3, combatSkillsAdjust2, mainAttributesAdjust2, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 12),
			new IntPair(6, 12),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 12),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 15),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray3 = _dataArray;
		string config3 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_62");
		sbyte[] potentialSuccessorGrades3 = new sbyte[0];
		sbyte[] childGrade3 = new sbyte[1];
		string[] monasticTitleSuffixes3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_62_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_62_1")
		};
		List<short> favoriteClothingIds3 = new List<short> { 21, 22, 23, 6, 12, 5, 14 };
		List<short> hatedClothingIds3 = new List<short> { 49, 50, 51 };
		string[] spouseAnonymousTitles3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_62_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_62_1")
		};
		short[] initialAges3 = new short[4] { 13, 14, 15, 16 };
		PresetEquipmentItemWithProb[] equipment3 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing3 = new PresetEquipmentItem("Clothing", 21);
		List<PresetInventoryItem> inventory3 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("SkillBook", 108, 1, 20),
			new PresetInventoryItem("SkillBook", 126, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("TeaWine", 18, 1, 10),
			new PresetInventoryItem("TeaWine", 27, 1, 10)
		};
		List<PresetOrgMemberCombatSkill> combatSkills3 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 1),
			new PresetOrgMemberCombatSkill(120, 1),
			new PresetOrgMemberCombatSkill(218, 1),
			new PresetOrgMemberCombatSkill(337, 1),
			new PresetOrgMemberCombatSkill(534, 1)
		};
		sbyte[] extraCombatSkillGrids3 = new sbyte[5];
		short[] resourcesAdjust3 = new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 };
		short[] lifeSkillsAdjust3 = new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		};
		short[] combatSkillsAdjust3 = new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust3 = new short[6] { -1, 12, 9, 2, 9, 9 };
		identityInteractConfig = new List<sbyte>();
		dataArray3.Add(new OrganizationMemberItem(62, config3, 2, 1, potentialSuccessorGrades3, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade3, 1, 5, 1, 50, 130, monasticTitleSuffixes3, 300, 2, 1000, 300, 0, favoriteClothingIds3, hatedClothingIds3, spouseAnonymousTitles3, canStroll: true, 233, initialAges3, equipment3, clothing3, inventory3, combatSkills3, extraCombatSkillGrids3, resourcesAdjust3, 10000, 2000, 5, 90, 600, lifeSkillsAdjust3, 2, combatSkillsAdjust3, mainAttributesAdjust3, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 12),
			new IntPair(6, 12),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 12),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 15),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray4 = _dataArray;
		string config4 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_63");
		sbyte[] potentialSuccessorGrades4 = new sbyte[0];
		sbyte[] childGrade4 = new sbyte[1];
		string[] monasticTitleSuffixes4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_63_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_63_1")
		};
		List<short> favoriteClothingIds4 = new List<short> { 21, 22, 23, 6, 12, 5, 14 };
		List<short> hatedClothingIds4 = new List<short> { 49, 50, 51 };
		string[] spouseAnonymousTitles4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_63_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_63_1")
		};
		short[] initialAges4 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment4 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 342, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 207, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing4 = new PresetEquipmentItem("Clothing", 21);
		List<PresetInventoryItem> inventory4 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("SkillBook", 108, 1, 20),
			new PresetInventoryItem("SkillBook", 126, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("TeaWine", 18, 1, 10),
			new PresetInventoryItem("TeaWine", 27, 1, 10)
		};
		List<PresetOrgMemberCombatSkill> combatSkills4 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(13, 0),
			new PresetOrgMemberCombatSkill(120, 0),
			new PresetOrgMemberCombatSkill(534, 0)
		};
		sbyte[] extraCombatSkillGrids4 = new sbyte[5];
		short[] resourcesAdjust4 = new short[8] { -60, -60, -70, -70, -70, -70, -70, -60 };
		short[] lifeSkillsAdjust4 = new short[16]
		{
			-1, -1, -1, -1, 2, -1, -1, -1, -1, -1,
			-1, -1, 9, 9, 9, -1
		};
		short[] combatSkillsAdjust4 = new short[14]
		{
			12, 9, 12, 9, 12, -1, -1, 9, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust4 = new short[6] { -1, 12, 9, 2, 9, 9 };
		identityInteractConfig = new List<sbyte>();
		dataArray4.Add(new OrganizationMemberItem(63, config4, 2, 0, potentialSuccessorGrades4, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade4, 0, 4, 0, 50, 130, monasticTitleSuffixes4, 150, 0, 500, 150, 0, favoriteClothingIds4, hatedClothingIds4, spouseAnonymousTitles4, canStroll: true, 234, initialAges4, equipment4, clothing4, inventory4, combatSkills4, extraCombatSkillGrids4, resourcesAdjust4, 5000, 1000, 1, 100, 300, lifeSkillsAdjust4, 1, combatSkillsAdjust4, mainAttributesAdjust4, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 12),
			new IntPair(6, 12),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 0),
			new IntPair(14, 1),
			new IntPair(12, 12),
			new IntPair(4, 15),
			new IntPair(3, 15),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 6),
			new IntPair(11, 6),
			new IntPair(0, 15),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(64, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_64"), 3, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 4 }, 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_64_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_64_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_64_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_64_1")
		}, canStroll: false, 235, new short[4] { 26, 34, 42, 50 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 26), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 40),
			new PresetInventoryItem("SkillBook", 27, 1, 30),
			new PresetInventoryItem("SkillBook", 0, 1, 30),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 4),
			new PresetOrgMemberCombatSkill(127, 7),
			new PresetOrgMemberCombatSkill(227, 8),
			new PresetOrgMemberCombatSkill(423, 8),
			new PresetOrgMemberCombatSkill(700, 8),
			new PresetOrgMemberCombatSkill(718, 6)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 120000, 432000, 20, 20, 61500, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 8, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 11, 24, 25, 55, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 15),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 27),
			new IntPair(3, 1),
			new IntPair(13, 54),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(65, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_65"), 3, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 3 }, 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_65_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_65_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_65_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_65_1")
		}, canStroll: false, 236, new short[4] { 24, 31, 38, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 25), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 40),
			new PresetInventoryItem("SkillBook", 27, 1, 30),
			new PresetInventoryItem("SkillBook", 0, 1, 30),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 4),
			new PresetOrgMemberCombatSkill(127, 6),
			new PresetOrgMemberCombatSkill(227, 7),
			new PresetOrgMemberCombatSkill(423, 7),
			new PresetOrgMemberCombatSkill(700, 7),
			new PresetOrgMemberCombatSkill(718, 5)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 75000, 216000, 15, 30, 42300, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 8, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 11, 24, 25, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 15),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 27),
			new IntPair(3, 1),
			new IntPair(13, 54),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(66, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_66"), 3, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 6, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_66_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_66_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_66_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_66_1")
		}, canStroll: true, 237, new short[4] { 22, 28, 34, 40 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 25), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 40),
			new PresetInventoryItem("SkillBook", 27, 1, 30),
			new PresetInventoryItem("SkillBook", 0, 1, 30),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 4),
			new PresetOrgMemberCombatSkill(127, 6),
			new PresetOrgMemberCombatSkill(227, 6),
			new PresetOrgMemberCombatSkill(423, 6),
			new PresetOrgMemberCombatSkill(700, 6),
			new PresetOrgMemberCombatSkill(718, 5)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 45000, 108000, 15, 40, 27600, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 7, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 11, 24, 25, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 15),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 27),
			new IntPair(3, 1),
			new IntPair(13, 54),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(67, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_67"), 3, 5, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 5, 8, 5, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_67_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_67_1")
		}, 4200, 10, 6000, 8400, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_67_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_67_1")
		}, canStroll: true, 238, new short[4] { 20, 25, 30, 35 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 25), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 20),
			new PresetInventoryItem("SkillBook", 27, 1, 20),
			new PresetInventoryItem("SkillBook", 0, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 3),
			new PresetOrgMemberCombatSkill(127, 5),
			new PresetOrgMemberCombatSkill(227, 5),
			new PresetOrgMemberCombatSkill(423, 5),
			new PresetOrgMemberCombatSkill(700, 5),
			new PresetOrgMemberCombatSkill(718, 4)
		}, new sbyte[5] { 6, 6, 6, 6, 6 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 30000, 36000, 10, 50, 16800, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 6, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 12),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 24),
			new IntPair(3, 1),
			new IntPair(13, 42),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(68, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_68"), 3, 4, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 4, 7, 4, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_68_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_68_1")
		}, 2800, 8, 4500, 4650, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_68_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_68_1")
		}, canStroll: true, 239, new short[4] { 18, 22, 26, 30 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 24), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 20),
			new PresetInventoryItem("SkillBook", 27, 1, 20),
			new PresetInventoryItem("SkillBook", 0, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 3),
			new PresetOrgMemberCombatSkill(127, 4),
			new PresetOrgMemberCombatSkill(227, 4),
			new PresetOrgMemberCombatSkill(423, 4),
			new PresetOrgMemberCombatSkill(700, 4)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 22500, 18000, 10, 60, 9300, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 5, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 12),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 24),
			new IntPair(3, 1),
			new IntPair(13, 42),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(69, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_69"), 3, 3, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 3, 7, 3, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_69_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_69_1")
		}, 1800, 6, 3000, 2250, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_69_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_69_1")
		}, canStroll: true, 240, new short[4] { 16, 19, 22, 25 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 24), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 20),
			new PresetInventoryItem("SkillBook", 27, 1, 20),
			new PresetInventoryItem("SkillBook", 0, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 2),
			new PresetOrgMemberCombatSkill(127, 3),
			new PresetOrgMemberCombatSkill(227, 3),
			new PresetOrgMemberCombatSkill(423, 3),
			new PresetOrgMemberCombatSkill(700, 3)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 15000, 9000, 10, 70, 4500, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 4, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 12),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 24),
			new IntPair(3, 1),
			new IntPair(13, 42),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(70, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_70"), 3, 2, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 2, 7, 2, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_70_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_70_1")
		}, 600, 4, 2000, 900, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_70_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_70_1")
		}, canStroll: true, 241, new short[4] { 14, 16, 18, 20 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 81, 75),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", 486, 75),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 24), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 10),
			new PresetInventoryItem("SkillBook", 27, 1, 10),
			new PresetInventoryItem("SkillBook", 0, 1, 10),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 10),
			new PresetInventoryItem("Medicine", 142, 1, 10),
			new PresetInventoryItem("Medicine", 154, 1, 10),
			new PresetInventoryItem("Medicine", 166, 1, 10),
			new PresetInventoryItem("Medicine", 178, 1, 10),
			new PresetInventoryItem("Medicine", 190, 1, 10),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 2),
			new PresetOrgMemberCombatSkill(127, 2),
			new PresetOrgMemberCombatSkill(227, 2),
			new PresetOrgMemberCombatSkill(423, 2),
			new PresetOrgMemberCombatSkill(700, 2)
		}, new sbyte[5] { 2, 2, 2, 2, 2 }, new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 11250, 3000, 5, 80, 1800, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 3, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 21),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(71, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_71"), 3, 1, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 1, 7, 1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_71_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_71_1")
		}, 300, 2, 1000, 300, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_71_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_71_1")
		}, canStroll: true, 242, new short[4] { 12, 13, 14, 15 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 24), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 10),
			new PresetInventoryItem("SkillBook", 27, 1, 10),
			new PresetInventoryItem("SkillBook", 0, 1, 10),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 10),
			new PresetInventoryItem("Medicine", 142, 1, 10),
			new PresetInventoryItem("Medicine", 154, 1, 10),
			new PresetInventoryItem("Medicine", 166, 1, 10),
			new PresetInventoryItem("Medicine", 178, 1, 10),
			new PresetInventoryItem("Medicine", 190, 1, 10),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 1),
			new PresetOrgMemberCombatSkill(127, 1),
			new PresetOrgMemberCombatSkill(227, 1),
			new PresetOrgMemberCombatSkill(423, 1),
			new PresetOrgMemberCombatSkill(700, 1)
		}, new sbyte[5], new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 7500, 1500, 5, 90, 600, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 2, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 21),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(72, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_72"), 3, 0, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 0, 6, 0, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_72_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_72_1")
		}, 150, 0, 500, 150, 0, new List<short> { 24, 25, 26, 13 }, new List<short> { 61, 62, 63 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_72_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_72_1")
		}, canStroll: true, 243, new short[4] { 10, 10, 10, 10 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 351, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 225, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 24), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 10),
			new PresetInventoryItem("SkillBook", 27, 1, 10),
			new PresetInventoryItem("SkillBook", 0, 1, 10),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 10),
			new PresetInventoryItem("Medicine", 142, 1, 10),
			new PresetInventoryItem("Medicine", 154, 1, 10),
			new PresetInventoryItem("Medicine", 166, 1, 10),
			new PresetInventoryItem("Medicine", 178, 1, 10),
			new PresetInventoryItem("Medicine", 190, 1, 10),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(21, 0),
			new PresetOrgMemberCombatSkill(127, 0),
			new PresetOrgMemberCombatSkill(423, 0)
		}, new sbyte[5], new short[8] { -70, -60, -80, -70, -70, -60, -70, -70 }, 3750, 750, 1, 100, 300, new short[16]
		{
			9, -1, -1, 12, 2, -1, 2, 2, 12, 9,
			12, -1, -1, -1, 2, 2
		}, 1, new short[14]
		{
			6, 12, 12, -1, 12, 2, -1, -1, 2, -1,
			-1, -1, 12, 9
		}, new short[6] { 2, 12, 9, -1, -1, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 21),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 12),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(73, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_73"), 4, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 4 }, 5, -1, 7, 50, 129, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_73_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_73_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 27, 28, 29, 30, 5, 14 }, new List<short> { 55, 56, 57 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_73_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_73_1")
		}, canStroll: false, 244, new short[4] { 34, 42, 50, 58 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 29), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 40),
			new PresetInventoryItem("SkillBook", 18, 1, 30),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 30),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 220, 1, 20),
			new PresetInventoryItem("Medicine", 268, 1, 30),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 8),
			new PresetOrgMemberCombatSkill(135, 6),
			new PresetOrgMemberCombatSkill(236, 7),
			new PresetOrgMemberCombatSkill(344, 8),
			new PresetOrgMemberCombatSkill(541, 8),
			new PresetOrgMemberCombatSkill(683, 7)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		}, 8, new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		}, new short[6] { -1, 9, 9, -1, 12, -1 }, new List<sbyte> { 12, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 54),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 27),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(74, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_74"), 4, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, 7, new sbyte[1] { 3 }, 5, 8, 7, 50, 129, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_74_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_74_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 27, 28, 29, 30, 5, 14 }, new List<short> { 55, 56, 57 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_74_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_74_1")
		}, canStroll: false, 245, new short[4] { 31, 38, 45, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 28), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 40),
			new PresetInventoryItem("SkillBook", 18, 1, 30),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 30),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 220, 1, 20),
			new PresetInventoryItem("Medicine", 268, 1, 30),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 7),
			new PresetOrgMemberCombatSkill(135, 5),
			new PresetOrgMemberCombatSkill(236, 6),
			new PresetOrgMemberCombatSkill(344, 7),
			new PresetOrgMemberCombatSkill(541, 7),
			new PresetOrgMemberCombatSkill(683, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		}, 8, new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		}, new short[6] { -1, 9, 9, -1, 12, -1 }, new List<sbyte> { 12, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 54),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 27),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(75, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_75"), 4, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 5, 8, 6, 50, 129, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_75_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_75_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 27, 28, 29, 30, 5, 14 }, new List<short> { 55, 56, 57 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_75_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_75_1")
		}, canStroll: false, 246, new short[4] { 28, 34, 40, 46 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 28), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 40),
			new PresetInventoryItem("SkillBook", 18, 1, 30),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 30),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 220, 1, 20),
			new PresetInventoryItem("Medicine", 268, 1, 30),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 6),
			new PresetOrgMemberCombatSkill(135, 5),
			new PresetOrgMemberCombatSkill(236, 6),
			new PresetOrgMemberCombatSkill(344, 6),
			new PresetOrgMemberCombatSkill(541, 6),
			new PresetOrgMemberCombatSkill(683, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		}, 7, new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		}, new short[6] { -1, 9, 9, -1, 12, -1 }, new List<sbyte> { 12, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 54),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 27),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray5 = _dataArray;
		string config5 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_76");
		sbyte[] potentialSuccessorGrades5 = new sbyte[0];
		sbyte[] childGrade5 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_76_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_76_1")
		};
		List<short> favoriteClothingIds5 = new List<short> { 27, 28, 29, 30, 5, 14 };
		List<short> hatedClothingIds5 = new List<short> { 55, 56, 57 };
		string[] spouseAnonymousTitles5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_76_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_76_1")
		};
		short[] initialAges5 = new short[4] { 25, 30, 35, 40 };
		PresetEquipmentItemWithProb[] equipment5 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing5 = new PresetEquipmentItem("Clothing", 28);
		List<PresetInventoryItem> inventory5 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 30),
			new PresetInventoryItem("SkillBook", 18, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 30),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 214, 1, 10),
			new PresetInventoryItem("Medicine", 262, 1, 30),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills5 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 5),
			new PresetOrgMemberCombatSkill(135, 5),
			new PresetOrgMemberCombatSkill(236, 5),
			new PresetOrgMemberCombatSkill(344, 5),
			new PresetOrgMemberCombatSkill(541, 5),
			new PresetOrgMemberCombatSkill(683, 5)
		};
		sbyte[] extraCombatSkillGrids5 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust5 = new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 };
		short[] lifeSkillsAdjust5 = new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		};
		short[] combatSkillsAdjust5 = new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		};
		short[] mainAttributesAdjust5 = new short[6] { -1, 9, 9, -1, 12, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray5.Add(new OrganizationMemberItem(76, config5, 4, 5, potentialSuccessorGrades5, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade5, 5, 8, 5, 50, 129, monasticTitleSuffixes5, 4200, 10, 6000, 8400, 0, favoriteClothingIds5, hatedClothingIds5, spouseAnonymousTitles5, canStroll: true, 247, initialAges5, equipment5, clothing5, inventory5, combatSkills5, extraCombatSkillGrids5, resourcesAdjust5, 40000, 48000, 10, 50, 16800, lifeSkillsAdjust5, 6, combatSkillsAdjust5, mainAttributesAdjust5, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 42),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 21),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray6 = _dataArray;
		string config6 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_77");
		sbyte[] potentialSuccessorGrades6 = new sbyte[0];
		sbyte[] childGrade6 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_77_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_77_1")
		};
		List<short> favoriteClothingIds6 = new List<short> { 27, 28, 29, 30, 5, 14 };
		List<short> hatedClothingIds6 = new List<short> { 55, 56, 57 };
		string[] spouseAnonymousTitles6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_77_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_77_1")
		};
		short[] initialAges6 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment6 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing6 = new PresetEquipmentItem("Clothing", 27);
		List<PresetInventoryItem> inventory6 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 30),
			new PresetInventoryItem("SkillBook", 18, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 30),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 214, 1, 10),
			new PresetInventoryItem("Medicine", 262, 1, 30),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills6 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 4),
			new PresetOrgMemberCombatSkill(135, 4),
			new PresetOrgMemberCombatSkill(236, 4),
			new PresetOrgMemberCombatSkill(344, 4),
			new PresetOrgMemberCombatSkill(541, 4)
		};
		sbyte[] extraCombatSkillGrids6 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust6 = new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 };
		short[] lifeSkillsAdjust6 = new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		};
		short[] combatSkillsAdjust6 = new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		};
		short[] mainAttributesAdjust6 = new short[6] { -1, 9, 9, -1, 12, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray6.Add(new OrganizationMemberItem(77, config6, 4, 4, potentialSuccessorGrades6, 10, 15, 5, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade6, 4, 7, 4, 50, 129, monasticTitleSuffixes6, 2800, 8, 4500, 4650, 0, favoriteClothingIds6, hatedClothingIds6, spouseAnonymousTitles6, canStroll: true, 248, initialAges6, equipment6, clothing6, inventory6, combatSkills6, extraCombatSkillGrids6, resourcesAdjust6, 30000, 24000, 10, 60, 9300, lifeSkillsAdjust6, 5, combatSkillsAdjust6, mainAttributesAdjust6, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 42),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 21),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray7 = _dataArray;
		string config7 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_78");
		sbyte[] potentialSuccessorGrades7 = new sbyte[0];
		sbyte[] childGrade7 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_78_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_78_1")
		};
		List<short> favoriteClothingIds7 = new List<short> { 27, 28, 29, 30, 5, 14 };
		List<short> hatedClothingIds7 = new List<short> { 55, 56, 57 };
		string[] spouseAnonymousTitles7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_78_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_78_1")
		};
		short[] initialAges7 = new short[4] { 19, 22, 25, 28 };
		PresetEquipmentItemWithProb[] equipment7 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing7 = new PresetEquipmentItem("Clothing", 27);
		List<PresetInventoryItem> inventory7 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 30),
			new PresetInventoryItem("SkillBook", 18, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 30),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 214, 1, 10),
			new PresetInventoryItem("Medicine", 262, 1, 30),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills7 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 3),
			new PresetOrgMemberCombatSkill(135, 3),
			new PresetOrgMemberCombatSkill(236, 3),
			new PresetOrgMemberCombatSkill(344, 3),
			new PresetOrgMemberCombatSkill(541, 3)
		};
		sbyte[] extraCombatSkillGrids7 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust7 = new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 };
		short[] lifeSkillsAdjust7 = new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		};
		short[] combatSkillsAdjust7 = new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		};
		short[] mainAttributesAdjust7 = new short[6] { -1, 9, 9, -1, 12, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray7.Add(new OrganizationMemberItem(78, config7, 4, 3, potentialSuccessorGrades7, 10, 15, 5, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade7, 3, 6, 3, 50, 129, monasticTitleSuffixes7, 1800, 6, 3000, 2250, 0, favoriteClothingIds7, hatedClothingIds7, spouseAnonymousTitles7, canStroll: true, 249, initialAges7, equipment7, clothing7, inventory7, combatSkills7, extraCombatSkillGrids7, resourcesAdjust7, 20000, 12000, 10, 70, 4500, lifeSkillsAdjust7, 4, combatSkillsAdjust7, mainAttributesAdjust7, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 42),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 21),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray8 = _dataArray;
		string config8 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_79");
		sbyte[] potentialSuccessorGrades8 = new sbyte[0];
		sbyte[] childGrade8 = new sbyte[1];
		string[] monasticTitleSuffixes8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_79_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_79_1")
		};
		List<short> favoriteClothingIds8 = new List<short> { 27, 28, 29, 30, 5, 14 };
		List<short> hatedClothingIds8 = new List<short> { 55, 56, 57 };
		string[] spouseAnonymousTitles8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_79_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_79_1")
		};
		short[] initialAges8 = new short[4] { 16, 18, 20, 22 };
		PresetEquipmentItemWithProb[] equipment8 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 72, 75),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", 450, 75),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 198, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing8 = new PresetEquipmentItem("Clothing", 27);
		List<PresetInventoryItem> inventory8 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 20),
			new PresetInventoryItem("SkillBook", 18, 1, 10),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 262, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills8 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 2),
			new PresetOrgMemberCombatSkill(135, 2),
			new PresetOrgMemberCombatSkill(236, 2),
			new PresetOrgMemberCombatSkill(344, 2),
			new PresetOrgMemberCombatSkill(541, 2)
		};
		sbyte[] extraCombatSkillGrids8 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust8 = new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 };
		short[] lifeSkillsAdjust8 = new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		};
		short[] combatSkillsAdjust8 = new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		};
		short[] mainAttributesAdjust8 = new short[6] { -1, 9, 9, -1, 12, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray8.Add(new OrganizationMemberItem(79, config8, 4, 2, potentialSuccessorGrades8, 10, 15, 5, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade8, 2, 5, 2, 50, 129, monasticTitleSuffixes8, 600, 4, 2000, 900, 0, favoriteClothingIds8, hatedClothingIds8, spouseAnonymousTitles8, canStroll: true, 250, initialAges8, equipment8, clothing8, inventory8, combatSkills8, extraCombatSkillGrids8, resourcesAdjust8, 15000, 4000, 5, 80, 1800, lifeSkillsAdjust8, 3, combatSkillsAdjust8, mainAttributesAdjust8, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 30),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 15),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray9 = _dataArray;
		string config9 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_80");
		sbyte[] potentialSuccessorGrades9 = new sbyte[0];
		sbyte[] childGrade9 = new sbyte[1];
		string[] monasticTitleSuffixes9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_80_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_80_1")
		};
		List<short> favoriteClothingIds9 = new List<short> { 27, 28, 29, 30, 5, 14 };
		List<short> hatedClothingIds9 = new List<short> { 55, 56, 57 };
		string[] spouseAnonymousTitles9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_80_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_80_1")
		};
		short[] initialAges9 = new short[4] { 13, 14, 15, 16 };
		PresetEquipmentItemWithProb[] equipment9 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing9 = new PresetEquipmentItem("Clothing", 27);
		List<PresetInventoryItem> inventory9 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 20),
			new PresetInventoryItem("SkillBook", 18, 1, 10),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 262, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills9 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 1),
			new PresetOrgMemberCombatSkill(135, 1),
			new PresetOrgMemberCombatSkill(236, 1),
			new PresetOrgMemberCombatSkill(344, 1)
		};
		sbyte[] extraCombatSkillGrids9 = new sbyte[5];
		short[] resourcesAdjust9 = new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 };
		short[] lifeSkillsAdjust9 = new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		};
		short[] combatSkillsAdjust9 = new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		};
		short[] mainAttributesAdjust9 = new short[6] { -1, 9, 9, -1, 12, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray9.Add(new OrganizationMemberItem(80, config9, 4, 1, potentialSuccessorGrades9, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade9, 1, 5, 1, 50, 129, monasticTitleSuffixes9, 300, 2, 1000, 300, 0, favoriteClothingIds9, hatedClothingIds9, spouseAnonymousTitles9, canStroll: true, 251, initialAges9, equipment9, clothing9, inventory9, combatSkills9, extraCombatSkillGrids9, resourcesAdjust9, 10000, 2000, 5, 90, 600, lifeSkillsAdjust9, 2, combatSkillsAdjust9, mainAttributesAdjust9, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 30),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 15),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray10 = _dataArray;
		string config10 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_81");
		sbyte[] potentialSuccessorGrades10 = new sbyte[0];
		sbyte[] childGrade10 = new sbyte[1];
		string[] monasticTitleSuffixes10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_81_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_81_1")
		};
		List<short> favoriteClothingIds10 = new List<short> { 27, 28, 29, 30, 5, 14 };
		List<short> hatedClothingIds10 = new List<short> { 55, 56, 57 };
		string[] spouseAnonymousTitles10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_81_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_81_1")
		};
		short[] initialAges10 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment10 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 369, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 198, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing10 = new PresetEquipmentItem("Clothing", 27);
		List<PresetInventoryItem> inventory10 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 20),
			new PresetInventoryItem("SkillBook", 18, 1, 10),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 262, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills10 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(26, 0),
			new PresetOrgMemberCombatSkill(135, 0),
			new PresetOrgMemberCombatSkill(344, 0)
		};
		sbyte[] extraCombatSkillGrids10 = new sbyte[5];
		short[] resourcesAdjust10 = new short[8] { -70, -70, -70, -70, -50, -70, -70, -60 };
		short[] lifeSkillsAdjust10 = new short[16]
		{
			-1, -1, 9, -1, 6, -1, -1, 9, -1, -1,
			-1, -1, 12, 2, -1, -1
		};
		short[] combatSkillsAdjust10 = new short[14]
		{
			12, 9, 12, 12, -1, -1, 2, 12, -1, -1,
			-1, 12, -1, -1
		};
		short[] mainAttributesAdjust10 = new short[6] { -1, 9, 9, -1, 12, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray10.Add(new OrganizationMemberItem(81, config10, 4, 0, potentialSuccessorGrades10, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade10, 0, 5, 0, 50, 129, monasticTitleSuffixes10, 150, 0, 500, 150, 0, favoriteClothingIds10, hatedClothingIds10, spouseAnonymousTitles10, canStroll: true, 252, initialAges10, equipment10, clothing10, inventory10, combatSkills10, extraCombatSkillGrids10, resourcesAdjust10, 5000, 1000, 1, 100, 300, lifeSkillsAdjust10, 1, combatSkillsAdjust10, mainAttributesAdjust10, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 30),
			new IntPair(6, 0),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 0),
			new IntPair(4, 15),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(82, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_82"), 5, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 4 }, 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_82_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_82_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 }, new List<short> { 52, 53, 54 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_82_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_82_1")
		}, canStroll: false, 253, new short[4] { 42, 50, 58, 66 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 33), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("SkillBook", 108, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 60, 2, 20),
			new PresetInventoryItem("Medicine", 72, 2, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 4),
			new PresetOrgMemberCombatSkill(142, 3),
			new PresetOrgMemberCombatSkill(244, 6),
			new PresetOrgMemberCombatSkill(550, 7),
			new PresetOrgMemberCombatSkill(590, 7),
			new PresetOrgMemberCombatSkill(478, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 }, 80000, 288000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		}, 8, new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		}, new short[6] { 9, -1, 12, 12, -1, 2 }, new List<sbyte> { 13, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 24),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 15),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 18),
			new IntPair(9, 18)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(83, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_83"), 5, 7, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 3 }, 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_83_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_83_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 }, new List<short> { 52, 53, 54 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_83_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_83_1")
		}, canStroll: false, 254, new short[4] { 38, 45, 52, 59 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 32), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("SkillBook", 108, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 60, 2, 20),
			new PresetInventoryItem("Medicine", 72, 2, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 4),
			new PresetOrgMemberCombatSkill(142, 3),
			new PresetOrgMemberCombatSkill(244, 6),
			new PresetOrgMemberCombatSkill(550, 6),
			new PresetOrgMemberCombatSkill(590, 6),
			new PresetOrgMemberCombatSkill(478, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 }, 50000, 144000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		}, 8, new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		}, new short[6] { 9, -1, 12, 12, -1, 2 }, new List<sbyte> { 13, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 24),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 15),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 18),
			new IntPair(9, 18)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(84, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_84"), 5, 6, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 6, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_84_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_84_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 }, new List<short> { 52, 53, 54 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_84_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_84_1")
		}, canStroll: true, 255, new short[4] { 34, 40, 46, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 32), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("SkillBook", 108, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 60, 2, 20),
			new PresetInventoryItem("Medicine", 72, 2, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 3),
			new PresetOrgMemberCombatSkill(142, 3),
			new PresetOrgMemberCombatSkill(244, 5),
			new PresetOrgMemberCombatSkill(550, 6),
			new PresetOrgMemberCombatSkill(590, 6),
			new PresetOrgMemberCombatSkill(478, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 }, 30000, 72000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		}, 7, new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		}, new short[6] { 9, -1, 12, 12, -1, 2 }, new List<sbyte> { 13, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 24),
			new IntPair(6, 24),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 15),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 18),
			new IntPair(9, 18)
		}, null));
		List<OrganizationMemberItem> dataArray11 = _dataArray;
		string config11 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_85");
		sbyte[] potentialSuccessorGrades11 = new sbyte[0];
		sbyte[] childGrade11 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_85_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_85_1")
		};
		List<short> favoriteClothingIds11 = new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds11 = new List<short> { 52, 53, 54 };
		string[] spouseAnonymousTitles11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_85_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_85_1")
		};
		short[] initialAges11 = new short[4] { 30, 35, 40, 45 };
		PresetEquipmentItemWithProb[] equipment11 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing11 = new PresetEquipmentItem("Clothing", 32);
		List<PresetInventoryItem> inventory11 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("SkillBook", 108, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 2, 20),
			new PresetInventoryItem("Medicine", 66, 2, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills11 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 3),
			new PresetOrgMemberCombatSkill(142, 2),
			new PresetOrgMemberCombatSkill(244, 5),
			new PresetOrgMemberCombatSkill(550, 5),
			new PresetOrgMemberCombatSkill(590, 5),
			new PresetOrgMemberCombatSkill(478, 5)
		};
		sbyte[] extraCombatSkillGrids11 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust11 = new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 };
		short[] lifeSkillsAdjust11 = new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		};
		short[] combatSkillsAdjust11 = new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		};
		short[] mainAttributesAdjust11 = new short[6] { 9, -1, 12, 12, -1, 2 };
		identityInteractConfig = new List<sbyte>();
		dataArray11.Add(new OrganizationMemberItem(85, config11, 5, 5, potentialSuccessorGrades11, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade11, 5, 7, 5, 0, 0, monasticTitleSuffixes11, 4200, 10, 6000, 8400, 0, favoriteClothingIds11, hatedClothingIds11, spouseAnonymousTitles11, canStroll: true, 256, initialAges11, equipment11, clothing11, inventory11, combatSkills11, extraCombatSkillGrids11, resourcesAdjust11, 20000, 24000, 10, 50, 16800, lifeSkillsAdjust11, 6, combatSkillsAdjust11, mainAttributesAdjust11, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 15),
			new IntPair(6, 15),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 12),
			new IntPair(4, 1),
			new IntPair(3, 12),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 21),
			new IntPair(9, 21)
		}, null));
		List<OrganizationMemberItem> dataArray12 = _dataArray;
		string config12 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_86");
		sbyte[] potentialSuccessorGrades12 = new sbyte[0];
		sbyte[] childGrade12 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_86_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_86_1")
		};
		List<short> favoriteClothingIds12 = new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds12 = new List<short> { 52, 53, 54 };
		string[] spouseAnonymousTitles12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_86_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_86_1")
		};
		short[] initialAges12 = new short[4] { 26, 30, 34, 38 };
		PresetEquipmentItemWithProb[] equipment12 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing12 = new PresetEquipmentItem("Clothing", 32);
		List<PresetInventoryItem> inventory12 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("SkillBook", 108, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 2, 20),
			new PresetInventoryItem("Medicine", 66, 2, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills12 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 3),
			new PresetOrgMemberCombatSkill(142, 2),
			new PresetOrgMemberCombatSkill(244, 4),
			new PresetOrgMemberCombatSkill(550, 4),
			new PresetOrgMemberCombatSkill(590, 4),
			new PresetOrgMemberCombatSkill(478, 4)
		};
		sbyte[] extraCombatSkillGrids12 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust12 = new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 };
		short[] lifeSkillsAdjust12 = new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		};
		short[] combatSkillsAdjust12 = new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		};
		short[] mainAttributesAdjust12 = new short[6] { 9, -1, 12, 12, -1, 2 };
		identityInteractConfig = new List<sbyte>();
		dataArray12.Add(new OrganizationMemberItem(86, config12, 5, 4, potentialSuccessorGrades12, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade12, 4, 7, 4, 0, 0, monasticTitleSuffixes12, 2800, 8, 4500, 4650, 0, favoriteClothingIds12, hatedClothingIds12, spouseAnonymousTitles12, canStroll: true, 257, initialAges12, equipment12, clothing12, inventory12, combatSkills12, extraCombatSkillGrids12, resourcesAdjust12, 15000, 12000, 10, 60, 9300, lifeSkillsAdjust12, 5, combatSkillsAdjust12, mainAttributesAdjust12, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 15),
			new IntPair(6, 15),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 12),
			new IntPair(4, 1),
			new IntPair(3, 12),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 21),
			new IntPair(9, 21)
		}, null));
		List<OrganizationMemberItem> dataArray13 = _dataArray;
		string config13 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_87");
		sbyte[] potentialSuccessorGrades13 = new sbyte[0];
		sbyte[] childGrade13 = new sbyte[1];
		string[] monasticTitleSuffixes13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_87_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_87_1")
		};
		List<short> favoriteClothingIds13 = new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds13 = new List<short> { 52, 53, 54 };
		string[] spouseAnonymousTitles13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_87_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_87_1")
		};
		short[] initialAges13 = new short[4] { 22, 25, 28, 31 };
		PresetEquipmentItemWithProb[] equipment13 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing13 = new PresetEquipmentItem("Clothing", 31);
		List<PresetInventoryItem> inventory13 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("SkillBook", 108, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 2, 20),
			new PresetInventoryItem("Medicine", 66, 2, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills13 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 2),
			new PresetOrgMemberCombatSkill(142, 2),
			new PresetOrgMemberCombatSkill(244, 3),
			new PresetOrgMemberCombatSkill(550, 3),
			new PresetOrgMemberCombatSkill(590, 3)
		};
		sbyte[] extraCombatSkillGrids13 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust13 = new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 };
		short[] lifeSkillsAdjust13 = new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		};
		short[] combatSkillsAdjust13 = new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		};
		short[] mainAttributesAdjust13 = new short[6] { 9, -1, 12, 12, -1, 2 };
		identityInteractConfig = new List<sbyte>();
		dataArray13.Add(new OrganizationMemberItem(87, config13, 5, 3, potentialSuccessorGrades13, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade13, 3, 5, 3, 0, 0, monasticTitleSuffixes13, 1800, 6, 3000, 2250, 0, favoriteClothingIds13, hatedClothingIds13, spouseAnonymousTitles13, canStroll: true, 258, initialAges13, equipment13, clothing13, inventory13, combatSkills13, extraCombatSkillGrids13, resourcesAdjust13, 10000, 6000, 10, 70, 4500, lifeSkillsAdjust13, 4, combatSkillsAdjust13, mainAttributesAdjust13, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 15),
			new IntPair(6, 15),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 12),
			new IntPair(4, 1),
			new IntPair(3, 12),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 21),
			new IntPair(9, 21)
		}, null));
		List<OrganizationMemberItem> dataArray14 = _dataArray;
		string config14 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_88");
		sbyte[] potentialSuccessorGrades14 = new sbyte[0];
		sbyte[] childGrade14 = new sbyte[1];
		string[] monasticTitleSuffixes14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_88_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_88_1")
		};
		List<short> favoriteClothingIds14 = new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds14 = new List<short> { 52, 53, 54 };
		string[] spouseAnonymousTitles14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_88_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_88_1")
		};
		short[] initialAges14 = new short[4] { 18, 20, 22, 24 };
		PresetEquipmentItemWithProb[] equipment14 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 63, 75),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", 441, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing14 = new PresetEquipmentItem("Clothing", 31);
		List<PresetInventoryItem> inventory14 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("SkillBook", 108, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills14 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 2),
			new PresetOrgMemberCombatSkill(142, 1),
			new PresetOrgMemberCombatSkill(244, 2),
			new PresetOrgMemberCombatSkill(550, 2),
			new PresetOrgMemberCombatSkill(590, 2)
		};
		sbyte[] extraCombatSkillGrids14 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust14 = new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 };
		short[] lifeSkillsAdjust14 = new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		};
		short[] combatSkillsAdjust14 = new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		};
		short[] mainAttributesAdjust14 = new short[6] { 9, -1, 12, 12, -1, 2 };
		identityInteractConfig = new List<sbyte>();
		dataArray14.Add(new OrganizationMemberItem(88, config14, 5, 2, potentialSuccessorGrades14, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade14, 2, 4, 2, 0, 0, monasticTitleSuffixes14, 600, 4, 2000, 900, 0, favoriteClothingIds14, hatedClothingIds14, spouseAnonymousTitles14, canStroll: true, 259, initialAges14, equipment14, clothing14, inventory14, combatSkills14, extraCombatSkillGrids14, resourcesAdjust14, 7500, 2000, 5, 80, 1800, lifeSkillsAdjust14, 3, combatSkillsAdjust14, mainAttributesAdjust14, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 6),
			new IntPair(6, 6),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 9),
			new IntPair(4, 1),
			new IntPair(3, 9),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 24),
			new IntPair(9, 24)
		}, null));
		List<OrganizationMemberItem> dataArray15 = _dataArray;
		string config15 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_89");
		sbyte[] potentialSuccessorGrades15 = new sbyte[0];
		sbyte[] childGrade15 = new sbyte[1];
		string[] monasticTitleSuffixes15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_89_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_89_1")
		};
		List<short> favoriteClothingIds15 = new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds15 = new List<short> { 52, 53, 54 };
		string[] spouseAnonymousTitles15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_89_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_89_1")
		};
		short[] initialAges15 = new short[4] { 14, 15, 16, 17 };
		PresetEquipmentItemWithProb[] equipment15 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 189, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing15 = new PresetEquipmentItem("Clothing", 31);
		List<PresetInventoryItem> inventory15 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("SkillBook", 108, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills15 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 1),
			new PresetOrgMemberCombatSkill(142, 1),
			new PresetOrgMemberCombatSkill(244, 1),
			new PresetOrgMemberCombatSkill(550, 1),
			new PresetOrgMemberCombatSkill(590, 1)
		};
		sbyte[] extraCombatSkillGrids15 = new sbyte[5];
		short[] resourcesAdjust15 = new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 };
		short[] lifeSkillsAdjust15 = new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		};
		short[] combatSkillsAdjust15 = new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		};
		short[] mainAttributesAdjust15 = new short[6] { 9, -1, 12, 12, -1, 2 };
		identityInteractConfig = new List<sbyte>();
		dataArray15.Add(new OrganizationMemberItem(89, config15, 5, 1, potentialSuccessorGrades15, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade15, 1, 4, 1, 0, 0, monasticTitleSuffixes15, 300, 2, 1000, 300, 0, favoriteClothingIds15, hatedClothingIds15, spouseAnonymousTitles15, canStroll: true, 260, initialAges15, equipment15, clothing15, inventory15, combatSkills15, extraCombatSkillGrids15, resourcesAdjust15, 5000, 1000, 5, 90, 600, lifeSkillsAdjust15, 2, combatSkillsAdjust15, mainAttributesAdjust15, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 6),
			new IntPair(6, 6),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 9),
			new IntPair(4, 1),
			new IntPair(3, 9),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 24),
			new IntPair(9, 24)
		}, null));
		List<OrganizationMemberItem> dataArray16 = _dataArray;
		string config16 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_90");
		sbyte[] potentialSuccessorGrades16 = new sbyte[0];
		sbyte[] childGrade16 = new sbyte[1];
		string[] monasticTitleSuffixes16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_90_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_90_1")
		};
		List<short> favoriteClothingIds16 = new List<short> { 31, 32, 33, 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds16 = new List<short> { 52, 53, 54 };
		string[] spouseAnonymousTitles16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_90_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_90_1")
		};
		short[] initialAges16 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment16 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 279, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing16 = new PresetEquipmentItem("Clothing", 31);
		List<PresetInventoryItem> inventory16 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("SkillBook", 108, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills16 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(35, 0),
			new PresetOrgMemberCombatSkill(142, 0),
			new PresetOrgMemberCombatSkill(478, 0)
		};
		sbyte[] extraCombatSkillGrids16 = new sbyte[5];
		short[] resourcesAdjust16 = new short[8] { -70, -70, -50, -70, -70, -80, -70, -50 };
		short[] lifeSkillsAdjust16 = new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 6, 6,
			-1, -1, 6, 6, 6, -1
		};
		short[] combatSkillsAdjust16 = new short[14]
		{
			6, 6, 9, -1, -1, 12, -1, 12, 12, -1,
			-1, -1, -1, 2
		};
		short[] mainAttributesAdjust16 = new short[6] { 9, -1, 12, 12, -1, 2 };
		identityInteractConfig = new List<sbyte>();
		dataArray16.Add(new OrganizationMemberItem(90, config16, 5, 0, potentialSuccessorGrades16, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade16, 0, 4, 0, 0, 0, monasticTitleSuffixes16, 150, 0, 500, 150, 0, favoriteClothingIds16, hatedClothingIds16, spouseAnonymousTitles16, canStroll: true, 261, initialAges16, equipment16, clothing16, inventory16, combatSkills16, extraCombatSkillGrids16, resourcesAdjust16, 2500, 500, 1, 100, 300, lifeSkillsAdjust16, 1, combatSkillsAdjust16, mainAttributesAdjust16, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 6),
			new IntPair(6, 6),
			new IntPair(15, 1),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 9),
			new IntPair(4, 1),
			new IntPair(3, 9),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 24),
			new IntPair(9, 24)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(91, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_91"), 6, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, 1108, 0, 7, new sbyte[1] { 3 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_91_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_91_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 34, 35, 36, 3, 7 }, new List<short> { 43, 44, 45 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_91_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_91_1")
		}, canStroll: false, 262, new short[4] { 26, 34, 42, 50 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 36), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 208, 1, 30),
			new PresetInventoryItem("TeaWine", 0, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 4),
			new PresetOrgMemberCombatSkill(146, 3),
			new PresetOrgMemberCombatSkill(251, 5),
			new PresetOrgMemberCombatSkill(353, 8),
			new PresetOrgMemberCombatSkill(598, 8),
			new PresetOrgMemberCombatSkill(641, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		}, 8, new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		}, new short[6] { 12, 9, -1, 12, 2, -1 }, new List<sbyte> { 14, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 21),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 54),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(92, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_92"), 6, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, 7, new sbyte[1] { 3 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_92_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_92_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 34, 35, 36, 3, 7 }, new List<short> { 43, 44, 45 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_92_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_92_1")
		}, canStroll: false, 263, new short[4] { 24, 31, 38, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 36), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 208, 1, 30),
			new PresetInventoryItem("TeaWine", 0, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 4),
			new PresetOrgMemberCombatSkill(146, 3),
			new PresetOrgMemberCombatSkill(251, 5),
			new PresetOrgMemberCombatSkill(353, 7),
			new PresetOrgMemberCombatSkill(598, 7),
			new PresetOrgMemberCombatSkill(641, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		}, 8, new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		}, new short[6] { 12, 9, -1, 12, 2, -1 }, new List<sbyte> { 14, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 21),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 54),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(93, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_93"), 6, 6, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, 6, new sbyte[1] { 3 }, 3, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_93_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_93_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 34, 35, 36, 3, 7 }, new List<short> { 43, 44, 45 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_93_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_93_1")
		}, canStroll: false, 264, new short[4] { 22, 28, 34, 40 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 35), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 208, 1, 30),
			new PresetInventoryItem("TeaWine", 0, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 3),
			new PresetOrgMemberCombatSkill(146, 2),
			new PresetOrgMemberCombatSkill(251, 4),
			new PresetOrgMemberCombatSkill(598, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		}, 7, new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		}, new short[6] { 12, 9, -1, 12, 2, -1 }, new List<sbyte> { 14, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 21),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 54),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray17 = _dataArray;
		string config17 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_94");
		sbyte[] potentialSuccessorGrades17 = new sbyte[0];
		sbyte[] childGrade17 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_94_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_94_1")
		};
		List<short> favoriteClothingIds17 = new List<short> { 34, 35, 36, 3, 7 };
		List<short> hatedClothingIds17 = new List<short> { 43, 44, 45 };
		string[] spouseAnonymousTitles17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_94_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_94_1")
		};
		short[] initialAges17 = new short[4] { 20, 25, 30, 35 };
		PresetEquipmentItemWithProb[] equipment17 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing17 = new PresetEquipmentItem("Clothing", 35);
		List<PresetInventoryItem> inventory17 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 10),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("Medicine", 202, 1, 30),
			new PresetInventoryItem("TeaWine", 0, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills17 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 3),
			new PresetOrgMemberCombatSkill(146, 2),
			new PresetOrgMemberCombatSkill(251, 4),
			new PresetOrgMemberCombatSkill(641, 5)
		};
		sbyte[] extraCombatSkillGrids17 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust17 = new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 };
		short[] lifeSkillsAdjust17 = new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		};
		short[] combatSkillsAdjust17 = new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		};
		short[] mainAttributesAdjust17 = new short[6] { 12, 9, -1, 12, 2, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray17.Add(new OrganizationMemberItem(94, config17, 6, 5, potentialSuccessorGrades17, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, 5, childGrade17, 2, 8, 5, 0, 0, monasticTitleSuffixes17, 4200, 10, 6000, 8400, 0, favoriteClothingIds17, hatedClothingIds17, spouseAnonymousTitles17, canStroll: false, 265, initialAges17, equipment17, clothing17, inventory17, combatSkills17, extraCombatSkillGrids17, resourcesAdjust17, 40000, 48000, 10, 50, 16800, lifeSkillsAdjust17, 6, combatSkillsAdjust17, mainAttributesAdjust17, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 42),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray18 = _dataArray;
		string config18 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_95");
		sbyte[] potentialSuccessorGrades18 = new sbyte[0];
		sbyte[] childGrade18 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes18 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_95_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_95_1")
		};
		List<short> favoriteClothingIds18 = new List<short> { 34, 35, 36, 3, 7 };
		List<short> hatedClothingIds18 = new List<short> { 43, 44, 45 };
		string[] spouseAnonymousTitles18 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_95_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_95_1")
		};
		short[] initialAges18 = new short[4] { 18, 22, 26, 30 };
		PresetEquipmentItemWithProb[] equipment18 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing18 = new PresetEquipmentItem("Clothing", 35);
		List<PresetInventoryItem> inventory18 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 10),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("Medicine", 202, 1, 30),
			new PresetInventoryItem("TeaWine", 0, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills18 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 3),
			new PresetOrgMemberCombatSkill(146, 2),
			new PresetOrgMemberCombatSkill(251, 4),
			new PresetOrgMemberCombatSkill(353, 4)
		};
		sbyte[] extraCombatSkillGrids18 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust18 = new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 };
		short[] lifeSkillsAdjust18 = new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		};
		short[] combatSkillsAdjust18 = new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		};
		short[] mainAttributesAdjust18 = new short[6] { 12, 9, -1, 12, 2, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray18.Add(new OrganizationMemberItem(95, config18, 6, 4, potentialSuccessorGrades18, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, 4, childGrade18, 1, 8, 4, 0, 0, monasticTitleSuffixes18, 2800, 8, 4500, 4650, 0, favoriteClothingIds18, hatedClothingIds18, spouseAnonymousTitles18, canStroll: false, 266, initialAges18, equipment18, clothing18, inventory18, combatSkills18, extraCombatSkillGrids18, resourcesAdjust18, 30000, 24000, 10, 60, 9300, lifeSkillsAdjust18, 5, combatSkillsAdjust18, mainAttributesAdjust18, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 42),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray19 = _dataArray;
		string config19 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_96");
		sbyte[] potentialSuccessorGrades19 = new sbyte[0];
		sbyte[] childGrade19 = new sbyte[1];
		string[] monasticTitleSuffixes19 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_96_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_96_1")
		};
		List<short> favoriteClothingIds19 = new List<short> { 34, 35, 36, 3, 7 };
		List<short> hatedClothingIds19 = new List<short> { 43, 44, 45 };
		string[] spouseAnonymousTitles19 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_96_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_96_1")
		};
		short[] initialAges19 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment19 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing19 = new PresetEquipmentItem("Clothing", 34);
		List<PresetInventoryItem> inventory19 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 10),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("Medicine", 202, 1, 30),
			new PresetInventoryItem("TeaWine", 0, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills19 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 2),
			new PresetOrgMemberCombatSkill(146, 1),
			new PresetOrgMemberCombatSkill(251, 3),
			new PresetOrgMemberCombatSkill(598, 3)
		};
		sbyte[] extraCombatSkillGrids19 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust19 = new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 };
		short[] lifeSkillsAdjust19 = new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		};
		short[] combatSkillsAdjust19 = new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		};
		short[] mainAttributesAdjust19 = new short[6] { 12, 9, -1, 12, 2, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray19.Add(new OrganizationMemberItem(96, config19, 6, 3, potentialSuccessorGrades19, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade19, 3, 6, 3, 0, 0, monasticTitleSuffixes19, 1800, 6, 3000, 2250, 0, favoriteClothingIds19, hatedClothingIds19, spouseAnonymousTitles19, canStroll: true, 267, initialAges19, equipment19, clothing19, inventory19, combatSkills19, extraCombatSkillGrids19, resourcesAdjust19, 20000, 12000, 10, 70, 4500, lifeSkillsAdjust19, 4, combatSkillsAdjust19, mainAttributesAdjust19, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 42),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray20 = _dataArray;
		string config20 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_97");
		sbyte[] potentialSuccessorGrades20 = new sbyte[0];
		sbyte[] childGrade20 = new sbyte[1];
		string[] monasticTitleSuffixes20 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_97_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_97_1")
		};
		List<short> favoriteClothingIds20 = new List<short> { 34, 35, 36, 3, 7 };
		List<short> hatedClothingIds20 = new List<short> { 43, 44, 45 };
		string[] spouseAnonymousTitles20 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_97_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_97_1")
		};
		short[] initialAges20 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment20 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 0, 75),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", 396, 75),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 100),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing20 = new PresetEquipmentItem("Clothing", 34);
		List<PresetInventoryItem> inventory20 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 202, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills20 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 2),
			new PresetOrgMemberCombatSkill(146, 1),
			new PresetOrgMemberCombatSkill(251, 2),
			new PresetOrgMemberCombatSkill(641, 2)
		};
		sbyte[] extraCombatSkillGrids20 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust20 = new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 };
		short[] lifeSkillsAdjust20 = new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		};
		short[] combatSkillsAdjust20 = new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		};
		short[] mainAttributesAdjust20 = new short[6] { 12, 9, -1, 12, 2, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray20.Add(new OrganizationMemberItem(97, config20, 6, 2, potentialSuccessorGrades20, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade20, 2, 5, 2, 0, 0, monasticTitleSuffixes20, 600, 4, 2000, 900, 0, favoriteClothingIds20, hatedClothingIds20, spouseAnonymousTitles20, canStroll: true, 268, initialAges20, equipment20, clothing20, inventory20, combatSkills20, extraCombatSkillGrids20, resourcesAdjust20, 15000, 4000, 5, 80, 1800, lifeSkillsAdjust20, 3, combatSkillsAdjust20, mainAttributesAdjust20, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 30),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray21 = _dataArray;
		string config21 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_98");
		sbyte[] potentialSuccessorGrades21 = new sbyte[0];
		sbyte[] childGrade21 = new sbyte[1];
		string[] monasticTitleSuffixes21 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_98_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_98_1")
		};
		List<short> favoriteClothingIds21 = new List<short> { 34, 35, 36, 3, 7 };
		List<short> hatedClothingIds21 = new List<short> { 43, 44, 45 };
		string[] spouseAnonymousTitles21 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_98_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_98_1")
		};
		short[] initialAges21 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment21 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing21 = new PresetEquipmentItem("Clothing", 34);
		List<PresetInventoryItem> inventory21 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 202, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills21 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 1),
			new PresetOrgMemberCombatSkill(146, 1),
			new PresetOrgMemberCombatSkill(251, 1),
			new PresetOrgMemberCombatSkill(353, 1)
		};
		sbyte[] extraCombatSkillGrids21 = new sbyte[5];
		short[] resourcesAdjust21 = new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 };
		short[] lifeSkillsAdjust21 = new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		};
		short[] combatSkillsAdjust21 = new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		};
		short[] mainAttributesAdjust21 = new short[6] { 12, 9, -1, 12, 2, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray21.Add(new OrganizationMemberItem(98, config21, 6, 1, potentialSuccessorGrades21, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade21, 1, 4, 1, 0, 0, monasticTitleSuffixes21, 300, 2, 1000, 300, 0, favoriteClothingIds21, hatedClothingIds21, spouseAnonymousTitles21, canStroll: true, 269, initialAges21, equipment21, clothing21, inventory21, combatSkills21, extraCombatSkillGrids21, resourcesAdjust21, 10000, 2000, 5, 90, 600, lifeSkillsAdjust21, 2, combatSkillsAdjust21, mainAttributesAdjust21, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 30),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray22 = _dataArray;
		string config22 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_99");
		sbyte[] potentialSuccessorGrades22 = new sbyte[0];
		sbyte[] childGrade22 = new sbyte[1];
		string[] monasticTitleSuffixes22 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_99_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_99_1")
		};
		List<short> favoriteClothingIds22 = new List<short> { 34, 35, 36, 3, 7 };
		List<short> hatedClothingIds22 = new List<short> { 43, 44, 45 };
		string[] spouseAnonymousTitles22 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_99_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_99_1")
		};
		short[] initialAges22 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment22 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 261, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 126, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing22 = new PresetEquipmentItem("Clothing", 34);
		List<PresetInventoryItem> inventory22 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 202, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills22 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(40, 0),
			new PresetOrgMemberCombatSkill(146, 0),
			new PresetOrgMemberCombatSkill(251, 0),
			new PresetOrgMemberCombatSkill(641, 0)
		};
		sbyte[] extraCombatSkillGrids22 = new sbyte[5];
		short[] resourcesAdjust22 = new short[8] { -70, -70, -60, -70, -80, -70, -60, -50 };
		short[] lifeSkillsAdjust22 = new short[16]
		{
			2, 2, 2, 2, -1, -1, 12, 6, -1, -1,
			-1, -1, -1, -1, 12, 6
		};
		short[] combatSkillsAdjust22 = new short[14]
		{
			6, 6, 9, 12, -1, -1, 2, -1, 12, 12,
			-1, -1, 2, 2
		};
		short[] mainAttributesAdjust22 = new short[6] { 12, 9, -1, 12, 2, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray22.Add(new OrganizationMemberItem(99, config22, 6, 0, potentialSuccessorGrades22, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade22, 0, 7, 0, 0, 0, monasticTitleSuffixes22, 150, 0, 500, 150, 0, favoriteClothingIds22, hatedClothingIds22, spouseAnonymousTitles22, canStroll: true, 270, initialAges22, equipment22, clothing22, inventory22, combatSkills22, extraCombatSkillGrids22, resourcesAdjust22, 5000, 1000, 1, 100, 300, lifeSkillsAdjust22, 1, combatSkillsAdjust22, mainAttributesAdjust22, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 1),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 30),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 36),
			new IntPair(11, 3),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(100, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_100"), 7, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 5 }, 7, -1, 7, 75, 129, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_100_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_100_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 37, 38, 39 }, new List<short> { 34, 35, 36 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_100_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_100_1")
		}, canStroll: false, 271, new short[4] { 34, 42, 50, 58 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 39), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 40),
			new PresetInventoryItem("SkillBook", 18, 1, 30),
			new PresetInventoryItem("SkillBook", 36, 1, 30),
			new PresetInventoryItem("SkillBook", 135, 1, 30),
			new PresetInventoryItem("Material", 28, 1, 30),
			new PresetInventoryItem("Material", 35, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 30),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 112, 1, 20),
			new PresetInventoryItem("Medicine", 268, 1, 20),
			new PresetInventoryItem("Medicine", 292, 1, 20),
			new PresetInventoryItem("Medicine", 316, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 8),
			new PresetOrgMemberCombatSkill(150, 6),
			new PresetOrgMemberCombatSkill(257, 7),
			new PresetOrgMemberCombatSkill(432, 6),
			new PresetOrgMemberCombatSkill(558, 8),
			new PresetOrgMemberCombatSkill(666, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 }, 120000, 432000, 20, 20, 61500, new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		}, 8, new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, 12, 12 }, new List<sbyte> { 15, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 12),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 36),
			new IntPair(12, 3),
			new IntPair(4, 36),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 18),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(101, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_101"), 7, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 4 }, 6, 8, 7, 75, 129, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_101_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_101_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 37, 38, 39 }, new List<short> { 34, 35, 36 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_101_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_101_1")
		}, canStroll: true, 272, new short[4] { 31, 38, 45, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 38), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 40),
			new PresetInventoryItem("SkillBook", 18, 1, 30),
			new PresetInventoryItem("SkillBook", 36, 1, 30),
			new PresetInventoryItem("SkillBook", 135, 1, 30),
			new PresetInventoryItem("Material", 28, 1, 30),
			new PresetInventoryItem("Material", 35, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 30),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 112, 1, 20),
			new PresetInventoryItem("Medicine", 268, 1, 20),
			new PresetInventoryItem("Medicine", 292, 1, 20),
			new PresetInventoryItem("Medicine", 316, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 7),
			new PresetOrgMemberCombatSkill(150, 6),
			new PresetOrgMemberCombatSkill(257, 7),
			new PresetOrgMemberCombatSkill(432, 6),
			new PresetOrgMemberCombatSkill(558, 7),
			new PresetOrgMemberCombatSkill(666, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 }, 75000, 216000, 15, 30, 42300, new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		}, 8, new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, 12, 12 }, new List<sbyte> { 15, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 12),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 36),
			new IntPair(12, 3),
			new IntPair(4, 36),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 18),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(102, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_102"), 7, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 3 }, 6, 7, 6, 75, 129, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_102_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_102_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 37, 38, 39 }, new List<short> { 34, 35, 36 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_102_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_102_1")
		}, canStroll: false, 273, new short[4] { 28, 34, 40, 46 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 38), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 40),
			new PresetInventoryItem("SkillBook", 18, 1, 30),
			new PresetInventoryItem("SkillBook", 36, 1, 30),
			new PresetInventoryItem("SkillBook", 135, 1, 30),
			new PresetInventoryItem("Material", 28, 1, 30),
			new PresetInventoryItem("Material", 35, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 30),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 112, 1, 20),
			new PresetInventoryItem("Medicine", 268, 1, 20),
			new PresetInventoryItem("Medicine", 292, 1, 20),
			new PresetInventoryItem("Medicine", 316, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 6),
			new PresetOrgMemberCombatSkill(150, 5),
			new PresetOrgMemberCombatSkill(257, 6),
			new PresetOrgMemberCombatSkill(432, 5),
			new PresetOrgMemberCombatSkill(558, 6),
			new PresetOrgMemberCombatSkill(666, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 }, 45000, 108000, 15, 40, 27600, new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		}, 7, new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, 12, 12 }, new List<sbyte> { 15, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 12),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 36),
			new IntPair(12, 3),
			new IntPair(4, 36),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 18),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray23 = _dataArray;
		string config23 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_103");
		sbyte[] potentialSuccessorGrades23 = new sbyte[0];
		sbyte[] childGrade23 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes23 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_103_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_103_1")
		};
		List<short> favoriteClothingIds23 = new List<short> { 37, 38, 39 };
		List<short> hatedClothingIds23 = new List<short> { 34, 35, 36 };
		string[] spouseAnonymousTitles23 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_103_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_103_1")
		};
		short[] initialAges23 = new short[4] { 19, 22, 25, 28 };
		PresetEquipmentItemWithProb[] equipment23 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing23 = new PresetEquipmentItem("Clothing", 38);
		List<PresetInventoryItem> inventory23 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 30),
			new PresetInventoryItem("SkillBook", 18, 1, 20),
			new PresetInventoryItem("SkillBook", 36, 1, 20),
			new PresetInventoryItem("SkillBook", 135, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 30),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 106, 1, 10),
			new PresetInventoryItem("Medicine", 262, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 10),
			new PresetInventoryItem("Medicine", 310, 1, 10),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills23 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 5),
			new PresetOrgMemberCombatSkill(150, 5),
			new PresetOrgMemberCombatSkill(257, 5),
			new PresetOrgMemberCombatSkill(432, 5),
			new PresetOrgMemberCombatSkill(558, 5),
			new PresetOrgMemberCombatSkill(666, 5)
		};
		sbyte[] extraCombatSkillGrids23 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust23 = new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 };
		short[] lifeSkillsAdjust23 = new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		};
		short[] combatSkillsAdjust23 = new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust23 = new short[6] { -1, -1, -1, -1, 12, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray23.Add(new OrganizationMemberItem(103, config23, 7, 5, potentialSuccessorGrades23, 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade23, 5, 6, 5, 75, 129, monasticTitleSuffixes23, 4200, 10, 6000, 8400, 0, favoriteClothingIds23, hatedClothingIds23, spouseAnonymousTitles23, canStroll: true, 274, initialAges23, equipment23, clothing23, inventory23, combatSkills23, extraCombatSkillGrids23, resourcesAdjust23, 30000, 36000, 10, 50, 16800, lifeSkillsAdjust23, 6, combatSkillsAdjust23, mainAttributesAdjust23, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 9),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 24),
			new IntPair(12, 3),
			new IntPair(4, 24),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 6),
			new IntPair(2, 6),
			new IntPair(1, 3),
			new IntPair(11, 21),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray24 = _dataArray;
		string config24 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_104");
		sbyte[] potentialSuccessorGrades24 = new sbyte[0];
		sbyte[] childGrade24 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes24 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_104_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_104_1")
		};
		List<short> favoriteClothingIds24 = new List<short> { 37, 38, 39 };
		List<short> hatedClothingIds24 = new List<short> { 34, 35, 36 };
		string[] spouseAnonymousTitles24 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_104_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_104_1")
		};
		short[] initialAges24 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment24 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing24 = new PresetEquipmentItem("Clothing", 37);
		List<PresetInventoryItem> inventory24 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 30),
			new PresetInventoryItem("SkillBook", 18, 1, 20),
			new PresetInventoryItem("SkillBook", 36, 1, 20),
			new PresetInventoryItem("SkillBook", 135, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 30),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 106, 1, 10),
			new PresetInventoryItem("Medicine", 262, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 10),
			new PresetInventoryItem("Medicine", 310, 1, 10),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills24 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 4),
			new PresetOrgMemberCombatSkill(150, 4),
			new PresetOrgMemberCombatSkill(257, 4),
			new PresetOrgMemberCombatSkill(666, 4)
		};
		sbyte[] extraCombatSkillGrids24 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust24 = new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 };
		short[] lifeSkillsAdjust24 = new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		};
		short[] combatSkillsAdjust24 = new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust24 = new short[6] { -1, -1, -1, -1, 12, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray24.Add(new OrganizationMemberItem(104, config24, 7, 4, potentialSuccessorGrades24, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade24, 4, 5, 4, 75, 129, monasticTitleSuffixes24, 2800, 8, 4500, 4650, 0, favoriteClothingIds24, hatedClothingIds24, spouseAnonymousTitles24, canStroll: true, 275, initialAges24, equipment24, clothing24, inventory24, combatSkills24, extraCombatSkillGrids24, resourcesAdjust24, 22500, 18000, 10, 60, 9300, lifeSkillsAdjust24, 5, combatSkillsAdjust24, mainAttributesAdjust24, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 9),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 24),
			new IntPair(12, 3),
			new IntPair(4, 24),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 6),
			new IntPair(2, 6),
			new IntPair(1, 3),
			new IntPair(11, 21),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray25 = _dataArray;
		string config25 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_105");
		sbyte[] potentialSuccessorGrades25 = new sbyte[0];
		sbyte[] childGrade25 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes25 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_105_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_105_1")
		};
		List<short> favoriteClothingIds25 = new List<short> { 37, 38, 39 };
		List<short> hatedClothingIds25 = new List<short> { 34, 35, 36 };
		string[] spouseAnonymousTitles25 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_105_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_105_1")
		};
		short[] initialAges25 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment25 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing25 = new PresetEquipmentItem("Clothing", 37);
		List<PresetInventoryItem> inventory25 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 30),
			new PresetInventoryItem("SkillBook", 18, 1, 20),
			new PresetInventoryItem("SkillBook", 36, 1, 20),
			new PresetInventoryItem("SkillBook", 135, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 30),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 106, 1, 10),
			new PresetInventoryItem("Medicine", 262, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 10),
			new PresetInventoryItem("Medicine", 310, 1, 10),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills25 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 3),
			new PresetOrgMemberCombatSkill(150, 3),
			new PresetOrgMemberCombatSkill(257, 3),
			new PresetOrgMemberCombatSkill(558, 3)
		};
		sbyte[] extraCombatSkillGrids25 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust25 = new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 };
		short[] lifeSkillsAdjust25 = new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		};
		short[] combatSkillsAdjust25 = new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust25 = new short[6] { -1, -1, -1, -1, 12, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray25.Add(new OrganizationMemberItem(105, config25, 7, 3, potentialSuccessorGrades25, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade25, 3, 5, 3, 75, 129, monasticTitleSuffixes25, 1800, 6, 3000, 2250, 0, favoriteClothingIds25, hatedClothingIds25, spouseAnonymousTitles25, canStroll: true, 276, initialAges25, equipment25, clothing25, inventory25, combatSkills25, extraCombatSkillGrids25, resourcesAdjust25, 15000, 9000, 10, 70, 4500, lifeSkillsAdjust25, 4, combatSkillsAdjust25, mainAttributesAdjust25, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 9),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 24),
			new IntPair(12, 3),
			new IntPair(4, 24),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 6),
			new IntPair(2, 6),
			new IntPair(1, 3),
			new IntPair(11, 21),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray26 = _dataArray;
		string config26 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_106");
		sbyte[] potentialSuccessorGrades26 = new sbyte[0];
		sbyte[] childGrade26 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes26 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_106_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_106_1")
		};
		List<short> favoriteClothingIds26 = new List<short> { 37, 38, 39 };
		List<short> hatedClothingIds26 = new List<short> { 34, 35, 36 };
		string[] spouseAnonymousTitles26 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_106_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_106_1")
		};
		short[] initialAges26 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment26 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 90, 75),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", 459, 75),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing26 = new PresetEquipmentItem("Clothing", 37);
		List<PresetInventoryItem> inventory26 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 20),
			new PresetInventoryItem("SkillBook", 18, 1, 10),
			new PresetInventoryItem("SkillBook", 36, 1, 10),
			new PresetInventoryItem("SkillBook", 135, 1, 10),
			new PresetInventoryItem("Material", 28, 1, 10),
			new PresetInventoryItem("Material", 35, 1, 10),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills26 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 2),
			new PresetOrgMemberCombatSkill(150, 2),
			new PresetOrgMemberCombatSkill(257, 2),
			new PresetOrgMemberCombatSkill(432, 2)
		};
		sbyte[] extraCombatSkillGrids26 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust26 = new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 };
		short[] lifeSkillsAdjust26 = new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		};
		short[] combatSkillsAdjust26 = new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust26 = new short[6] { -1, -1, -1, -1, 12, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray26.Add(new OrganizationMemberItem(106, config26, 7, 2, potentialSuccessorGrades26, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade26, 2, 5, 2, 75, 129, monasticTitleSuffixes26, 600, 4, 2000, 900, 0, favoriteClothingIds26, hatedClothingIds26, spouseAnonymousTitles26, canStroll: true, 277, initialAges26, equipment26, clothing26, inventory26, combatSkills26, extraCombatSkillGrids26, resourcesAdjust26, 11250, 3000, 5, 80, 1800, lifeSkillsAdjust26, 3, combatSkillsAdjust26, mainAttributesAdjust26, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 6),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 12),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 9),
			new IntPair(1, 3),
			new IntPair(11, 24),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray27 = _dataArray;
		string config27 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_107");
		sbyte[] potentialSuccessorGrades27 = new sbyte[0];
		sbyte[] childGrade27 = new sbyte[1];
		string[] monasticTitleSuffixes27 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_107_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_107_1")
		};
		List<short> favoriteClothingIds27 = new List<short> { 37, 38, 39 };
		List<short> hatedClothingIds27 = new List<short> { 34, 35, 36 };
		string[] spouseAnonymousTitles27 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_107_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_107_1")
		};
		short[] initialAges27 = new short[4] { 13, 14, 15, 16 };
		PresetEquipmentItemWithProb[] equipment27 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing27 = new PresetEquipmentItem("Clothing", 37);
		List<PresetInventoryItem> inventory27 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 20),
			new PresetInventoryItem("SkillBook", 18, 1, 10),
			new PresetInventoryItem("SkillBook", 36, 1, 10),
			new PresetInventoryItem("SkillBook", 135, 1, 10),
			new PresetInventoryItem("Material", 28, 1, 10),
			new PresetInventoryItem("Material", 35, 1, 10),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills27 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 1),
			new PresetOrgMemberCombatSkill(150, 1),
			new PresetOrgMemberCombatSkill(558, 1)
		};
		sbyte[] extraCombatSkillGrids27 = new sbyte[5];
		short[] resourcesAdjust27 = new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 };
		short[] lifeSkillsAdjust27 = new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		};
		short[] combatSkillsAdjust27 = new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust27 = new short[6] { -1, -1, -1, -1, 12, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray27.Add(new OrganizationMemberItem(107, config27, 7, 1, potentialSuccessorGrades27, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade27, 1, 5, 1, 75, 129, monasticTitleSuffixes27, 300, 2, 1000, 300, 0, favoriteClothingIds27, hatedClothingIds27, spouseAnonymousTitles27, canStroll: true, 278, initialAges27, equipment27, clothing27, inventory27, combatSkills27, extraCombatSkillGrids27, resourcesAdjust27, 7500, 1500, 5, 90, 600, lifeSkillsAdjust27, 2, combatSkillsAdjust27, mainAttributesAdjust27, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 6),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 12),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 9),
			new IntPair(1, 3),
			new IntPair(11, 24),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray28 = _dataArray;
		string config28 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_108");
		sbyte[] potentialSuccessorGrades28 = new sbyte[0];
		sbyte[] childGrade28 = new sbyte[1];
		string[] monasticTitleSuffixes28 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_108_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_108_1")
		};
		List<short> favoriteClothingIds28 = new List<short> { 37, 38, 39 };
		List<short> hatedClothingIds28 = new List<short> { 34, 35, 36 };
		string[] spouseAnonymousTitles28 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_108_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_108_1")
		};
		short[] initialAges28 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment28 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 360, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 216, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing28 = new PresetEquipmentItem("Clothing", 37);
		List<PresetInventoryItem> inventory28 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 108, 3, 20),
			new PresetInventoryItem("SkillBook", 18, 1, 10),
			new PresetInventoryItem("SkillBook", 36, 1, 10),
			new PresetInventoryItem("SkillBook", 135, 1, 10),
			new PresetInventoryItem("Material", 28, 1, 10),
			new PresetInventoryItem("Material", 35, 1, 10),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills28 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(45, 0),
			new PresetOrgMemberCombatSkill(150, 0),
			new PresetOrgMemberCombatSkill(432, 0),
			new PresetOrgMemberCombatSkill(558, 0),
			new PresetOrgMemberCombatSkill(666, 0)
		};
		sbyte[] extraCombatSkillGrids28 = new sbyte[5];
		short[] resourcesAdjust28 = new short[8] { -80, -70, -70, -60, -60, -70, -70, -70 };
		short[] lifeSkillsAdjust28 = new short[16]
		{
			-1, -1, 12, -1, 9, -1, 2, 2, -1, -1,
			-1, 12, 12, 2, 2, 9
		};
		short[] combatSkillsAdjust28 = new short[14]
		{
			12, 9, 12, -1, 9, 2, -1, 12, -1, -1,
			12, -1, -1, -1
		};
		short[] mainAttributesAdjust28 = new short[6] { -1, -1, -1, -1, 12, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray28.Add(new OrganizationMemberItem(108, config28, 7, 0, potentialSuccessorGrades28, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade28, 0, 5, 0, 75, 129, monasticTitleSuffixes28, 150, 0, 500, 150, 0, favoriteClothingIds28, hatedClothingIds28, spouseAnonymousTitles28, canStroll: true, 279, initialAges28, equipment28, clothing28, inventory28, combatSkills28, extraCombatSkillGrids28, resourcesAdjust28, 3750, 750, 1, 100, 300, lifeSkillsAdjust28, 1, combatSkillsAdjust28, mainAttributesAdjust28, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 6),
			new IntPair(6, 3),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 12),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 3),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 9),
			new IntPair(1, 3),
			new IntPair(11, 24),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(109, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_109"), 8, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, 0, -1, 0, -1, new sbyte[0], 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_109_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_109_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_109_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_109_1")
		}, canStroll: false, 280, new short[4] { 24, 31, 38, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 42), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 40),
			new PresetInventoryItem("SkillBook", 27, 1, 30),
			new PresetInventoryItem("SkillBook", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 112, 1, 30),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 8),
			new PresetOrgMemberCombatSkill(157, 8),
			new PresetOrgMemberCombatSkill(265, 6),
			new PresetOrgMemberCombatSkill(362, 6),
			new PresetOrgMemberCombatSkill(439, 7),
			new PresetOrgMemberCombatSkill(725, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 120000, 432000, 20, 20, 61500, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 8, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7, 16, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 42),
			new IntPair(5, 54),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(110, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_110"), 8, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 0, -1, 0, -1, new sbyte[0], 5, 8, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_110_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_110_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_110_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_110_1")
		}, canStroll: false, 281, new short[4] { 22, 28, 34, 40 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 41), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 40),
			new PresetInventoryItem("SkillBook", 27, 1, 30),
			new PresetInventoryItem("SkillBook", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 112, 1, 30),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 7),
			new PresetOrgMemberCombatSkill(157, 7),
			new PresetOrgMemberCombatSkill(265, 6),
			new PresetOrgMemberCombatSkill(362, 6),
			new PresetOrgMemberCombatSkill(439, 6),
			new PresetOrgMemberCombatSkill(725, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 75000, 216000, 15, 30, 42300, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 8, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7, 16, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 42),
			new IntPair(5, 54),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(111, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_111"), 8, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 4, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_111_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_111_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_111_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_111_1")
		}, canStroll: false, 282, new short[4] { 20, 25, 30, 35 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 41), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 40),
			new PresetInventoryItem("SkillBook", 27, 1, 30),
			new PresetInventoryItem("SkillBook", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 112, 1, 30),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 6),
			new PresetOrgMemberCombatSkill(157, 6),
			new PresetOrgMemberCombatSkill(265, 5),
			new PresetOrgMemberCombatSkill(439, 6),
			new PresetOrgMemberCombatSkill(725, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 45000, 108000, 15, 40, 27600, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 7, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7, 16, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 42),
			new IntPair(5, 54),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(112, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_112"), 8, 5, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 4, 8, 5, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_112_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_112_1")
		}, 4200, 10, 6000, 8400, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_112_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_112_1")
		}, canStroll: true, 283, new short[4] { 18, 22, 26, 30 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 41), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 30),
			new PresetInventoryItem("SkillBook", 27, 1, 20),
			new PresetInventoryItem("SkillBook", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 106, 1, 30),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 5),
			new PresetOrgMemberCombatSkill(157, 5),
			new PresetOrgMemberCombatSkill(265, 5),
			new PresetOrgMemberCombatSkill(362, 5),
			new PresetOrgMemberCombatSkill(725, 5)
		}, new sbyte[5] { 6, 6, 6, 6, 6 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 30000, 36000, 10, 50, 16800, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 6, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 30),
			new IntPair(5, 42),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 18),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(113, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_113"), 8, 4, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 4, 7, 4, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_113_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_113_1")
		}, 2800, 8, 4500, 4650, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_113_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_113_1")
		}, canStroll: false, 284, new short[4] { 16, 19, 22, 25 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 41), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 30),
			new PresetInventoryItem("SkillBook", 27, 1, 20),
			new PresetInventoryItem("SkillBook", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 106, 1, 30),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 4),
			new PresetOrgMemberCombatSkill(157, 4),
			new PresetOrgMemberCombatSkill(265, 4),
			new PresetOrgMemberCombatSkill(362, 4),
			new PresetOrgMemberCombatSkill(439, 4)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 22500, 18000, 10, 60, 9300, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 5, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 30),
			new IntPair(5, 42),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 18),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(114, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_114"), 8, 3, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 3, 7, 3, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_114_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_114_1")
		}, 1800, 6, 3000, 2250, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_114_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_114_1")
		}, canStroll: true, 285, new short[4] { 14, 16, 18, 20 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 40), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 30),
			new PresetInventoryItem("SkillBook", 27, 1, 20),
			new PresetInventoryItem("SkillBook", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 106, 1, 30),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 3),
			new PresetOrgMemberCombatSkill(157, 3),
			new PresetOrgMemberCombatSkill(265, 3),
			new PresetOrgMemberCombatSkill(725, 3)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 15000, 9000, 10, 70, 4500, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 4, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 30),
			new IntPair(5, 42),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 18),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(115, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_115"), 8, 2, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 2, 4, 2, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_115_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_115_1")
		}, 600, 4, 2000, 900, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_115_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_115_1")
		}, canStroll: true, 286, new short[4] { 12, 13, 14, 15 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 117, 75),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", 513, 75),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 40), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 20),
			new PresetInventoryItem("SkillBook", 27, 1, 10),
			new PresetInventoryItem("SkillBook", 45, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 106, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 2),
			new PresetOrgMemberCombatSkill(157, 2),
			new PresetOrgMemberCombatSkill(265, 2),
			new PresetOrgMemberCombatSkill(362, 2),
			new PresetOrgMemberCombatSkill(439, 2)
		}, new sbyte[5] { 2, 2, 2, 2, 2 }, new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 11250, 3000, 5, 80, 1800, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 3, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 18),
			new IntPair(5, 30),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 24),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(116, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_116"), 8, 1, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 1, 3, 1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_116_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_116_1")
		}, 300, 2, 1000, 300, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_116_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_116_1")
		}, canStroll: true, 287, new short[4] { 12, 13, 14, 15 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 207, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 40), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 20),
			new PresetInventoryItem("SkillBook", 27, 1, 10),
			new PresetInventoryItem("SkillBook", 45, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 106, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 1),
			new PresetOrgMemberCombatSkill(157, 1),
			new PresetOrgMemberCombatSkill(439, 1)
		}, new sbyte[5], new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 7500, 1500, 5, 90, 600, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 2, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 18),
			new IntPair(5, 30),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 24),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(117, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_117"), 8, 0, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, 0, -1, 1, -1, new sbyte[0], 0, 3, 0, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_117_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_117_1")
		}, 150, 0, 500, 150, 0, new List<short> { 40, 41, 42 }, new List<short> { 46, 47, 48 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_117_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_117_1")
		}, canStroll: true, 288, new short[4] { 10, 10, 10, 10 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 387, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 243, 75),
			new PresetEquipmentItemWithProb("Accessory", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 40), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 0, 3, 20),
			new PresetInventoryItem("SkillBook", 27, 1, 10),
			new PresetInventoryItem("SkillBook", 45, 1, 10),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 106, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(54, 0),
			new PresetOrgMemberCombatSkill(157, 0),
			new PresetOrgMemberCombatSkill(362, 0)
		}, new sbyte[5], new short[8] { -70, -70, -80, -50, -70, -70, -70, -70 }, 3750, 750, 1, 100, 300, new short[16]
		{
			12, 9, 9, 9, -1, 9, 2, 2, -1, -1,
			2, 2, 9, -1, 2, 2
		}, 1, new short[14]
		{
			12, 12, 9, 9, 12, -1, -1, -1, 2, 2,
			-1, -1, -1, 12
		}, new short[6] { 2, 12, -1, -1, 12, 9 }, new List<sbyte> { 7 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 18),
			new IntPair(5, 30),
			new IntPair(6, 0),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 0),
			new IntPair(4, 24),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 0)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(118, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_118"), 9, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 4 }, 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_118_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_118_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_118_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_118_1")
		}, canStroll: false, 289, new short[4] { 42, 50, 58, 66 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 45), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 40),
			new PresetInventoryItem("SkillBook", 63, 3, 40),
			new PresetInventoryItem("SkillBook", 90, 1, 40),
			new PresetInventoryItem("SkillBook", 99, 1, 40),
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Material", 28, 1, 30),
			new PresetInventoryItem("Material", 35, 1, 30),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 5),
			new PresetOrgMemberCombatSkill(166, 6),
			new PresetOrgMemberCombatSkill(272, 6),
			new PresetOrgMemberCombatSkill(567, 7),
			new PresetOrgMemberCombatSkill(607, 7),
			new PresetOrgMemberCombatSkill(650, 7),
			new PresetOrgMemberCombatSkill(709, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 8, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 17, 24, 25, 55, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 24),
			new IntPair(16, 9),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 18),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 54),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(119, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_119"), 9, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 3 }, 7, 8, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_119_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_119_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_119_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_119_1")
		}, canStroll: false, 290, new short[4] { 38, 45, 52, 59 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 44), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 40),
			new PresetInventoryItem("SkillBook", 63, 3, 40),
			new PresetInventoryItem("SkillBook", 90, 1, 40),
			new PresetInventoryItem("SkillBook", 99, 1, 40),
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Material", 28, 1, 30),
			new PresetInventoryItem("Material", 35, 1, 30),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 4),
			new PresetOrgMemberCombatSkill(166, 6),
			new PresetOrgMemberCombatSkill(272, 6),
			new PresetOrgMemberCombatSkill(567, 6),
			new PresetOrgMemberCombatSkill(607, 6),
			new PresetOrgMemberCombatSkill(650, 6),
			new PresetOrgMemberCombatSkill(709, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 8, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 17, 24, 25, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 24),
			new IntPair(16, 9),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 18),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 54),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new OrganizationMemberItem(120, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_120"), 9, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 6, 7, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_120_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_120_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_120_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_120_1")
		}, canStroll: true, 291, new short[4] { 34, 40, 46, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 44), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 40),
			new PresetInventoryItem("SkillBook", 63, 3, 40),
			new PresetInventoryItem("SkillBook", 90, 1, 40),
			new PresetInventoryItem("SkillBook", 99, 1, 40),
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Material", 28, 1, 30),
			new PresetInventoryItem("Material", 35, 1, 30),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 4),
			new PresetOrgMemberCombatSkill(166, 5),
			new PresetOrgMemberCombatSkill(272, 5),
			new PresetOrgMemberCombatSkill(567, 6),
			new PresetOrgMemberCombatSkill(709, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 7, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 17, 24, 25, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 24),
			new IntPair(16, 9),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 18),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 54),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(121, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_121"), 9, 5, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 5, 7, 5, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_121_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_121_1")
		}, 4200, 10, 6000, 8400, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_121_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_121_1")
		}, canStroll: true, 292, new short[4] { 30, 35, 40, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 44), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 30),
			new PresetInventoryItem("SkillBook", 63, 3, 30),
			new PresetInventoryItem("SkillBook", 90, 1, 30),
			new PresetInventoryItem("SkillBook", 99, 1, 30),
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 3),
			new PresetOrgMemberCombatSkill(166, 5),
			new PresetOrgMemberCombatSkill(272, 5),
			new PresetOrgMemberCombatSkill(607, 5),
			new PresetOrgMemberCombatSkill(709, 5)
		}, new sbyte[5] { 6, 6, 6, 6, 6 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 40000, 48000, 10, 50, 16800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 6, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 21),
			new IntPair(16, 6),
			new IntPair(7, 6),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 21),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 42),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(122, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_122"), 9, 4, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 4, 6, 4, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_122_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_122_1")
		}, 2800, 8, 4500, 4650, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_122_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_122_1")
		}, canStroll: true, 293, new short[4] { 26, 30, 34, 38 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 44), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 30),
			new PresetInventoryItem("SkillBook", 63, 3, 30),
			new PresetInventoryItem("SkillBook", 90, 1, 30),
			new PresetInventoryItem("SkillBook", 99, 1, 30),
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 3),
			new PresetOrgMemberCombatSkill(166, 4),
			new PresetOrgMemberCombatSkill(272, 4),
			new PresetOrgMemberCombatSkill(650, 4),
			new PresetOrgMemberCombatSkill(709, 4)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 30000, 24000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 5, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 21),
			new IntPair(16, 6),
			new IntPair(7, 6),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 21),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 42),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(123, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_123"), 9, 3, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 3, 5, 3, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_123_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_123_1")
		}, 1800, 6, 3000, 2250, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_123_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_123_1")
		}, canStroll: true, 294, new short[4] { 22, 25, 28, 31 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 43), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 30),
			new PresetInventoryItem("SkillBook", 63, 3, 30),
			new PresetInventoryItem("SkillBook", 90, 1, 30),
			new PresetInventoryItem("SkillBook", 99, 1, 30),
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 2),
			new PresetOrgMemberCombatSkill(166, 3),
			new PresetOrgMemberCombatSkill(272, 3),
			new PresetOrgMemberCombatSkill(567, 3),
			new PresetOrgMemberCombatSkill(607, 3),
			new PresetOrgMemberCombatSkill(650, 3),
			new PresetOrgMemberCombatSkill(709, 3)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 20000, 12000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 4, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 21),
			new IntPair(16, 6),
			new IntPair(7, 6),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 21),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 42),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(124, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_124"), 9, 2, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 2, 4, 2, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_124_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_124_1")
		}, 600, 4, 2000, 900, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_124_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_124_1")
		}, canStroll: true, 295, new short[4] { 18, 20, 22, 24 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 18, 75),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", 414, 75),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 90),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 43), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 20),
			new PresetInventoryItem("SkillBook", 63, 3, 20),
			new PresetInventoryItem("SkillBook", 90, 1, 20),
			new PresetInventoryItem("SkillBook", 99, 1, 20),
			new PresetInventoryItem("CraftTool", 0, 1, 20),
			new PresetInventoryItem("CraftTool", 9, 1, 20),
			new PresetInventoryItem("CraftTool", 18, 1, 20),
			new PresetInventoryItem("CraftTool", 27, 1, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Material", 28, 1, 10),
			new PresetInventoryItem("Material", 35, 1, 10),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 2),
			new PresetOrgMemberCombatSkill(166, 2),
			new PresetOrgMemberCombatSkill(272, 2),
			new PresetOrgMemberCombatSkill(709, 2)
		}, new sbyte[5] { 2, 2, 2, 2, 2 }, new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 15000, 4000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 3, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 18),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 24),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 30),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(125, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_125"), 9, 1, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 1, 3, 1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_125_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_125_1")
		}, 300, 2, 1000, 300, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_125_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_125_1")
		}, canStroll: true, 296, new short[4] { 14, 15, 16, 17 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 15),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 43), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 20),
			new PresetInventoryItem("SkillBook", 63, 3, 20),
			new PresetInventoryItem("SkillBook", 90, 1, 20),
			new PresetInventoryItem("SkillBook", 99, 1, 20),
			new PresetInventoryItem("CraftTool", 0, 1, 20),
			new PresetInventoryItem("CraftTool", 9, 1, 20),
			new PresetInventoryItem("CraftTool", 18, 1, 20),
			new PresetInventoryItem("CraftTool", 27, 1, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Material", 28, 1, 10),
			new PresetInventoryItem("Material", 35, 1, 10),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 1),
			new PresetOrgMemberCombatSkill(166, 1),
			new PresetOrgMemberCombatSkill(567, 1),
			new PresetOrgMemberCombatSkill(607, 1),
			new PresetOrgMemberCombatSkill(650, 1)
		}, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 10000, 2000, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 2, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 18),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 24),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 30),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(126, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_126"), 9, 0, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 0, 2, 0, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_126_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_126_1")
		}, 150, 0, 500, 150, 0, new List<short> { 43, 44, 45, 2 }, new List<short> { 40, 41, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_126_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_126_1")
		}, canStroll: true, 297, new short[4] { 10, 10, 10, 10 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 288, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 144, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 43), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 54, 3, 20),
			new PresetInventoryItem("SkillBook", 63, 3, 20),
			new PresetInventoryItem("SkillBook", 90, 1, 20),
			new PresetInventoryItem("SkillBook", 99, 1, 20),
			new PresetInventoryItem("CraftTool", 0, 1, 20),
			new PresetInventoryItem("CraftTool", 9, 1, 20),
			new PresetInventoryItem("CraftTool", 18, 1, 20),
			new PresetInventoryItem("CraftTool", 27, 1, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Material", 28, 1, 10),
			new PresetInventoryItem("Material", 35, 1, 10),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(63, 0),
			new PresetOrgMemberCombatSkill(166, 0),
			new PresetOrgMemberCombatSkill(650, 0)
		}, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -80, -70, -60 }, 5000, 1000, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, 2, 2,
			9, 9, 2, 2, -1, -1
		}, 1, new short[14]
		{
			6, 6, 9, -1, -1, -1, -1, 12, 12, 12,
			-1, -1, 12, -1
		}, new short[6] { 9, -1, -1, 12, -1, 9 }, new List<sbyte> { 6, 63 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 18),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 24),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 30),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(127, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_127"), 10, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 5 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_127_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_127_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_127_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_127_1")
		}, canStroll: false, 298, new short[4] { 42, 50, 58, 66 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 48), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 40),
			new PresetInventoryItem("SkillBook", 81, 3, 40),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 4),
			new PresetOrgMemberCombatSkill(173, 4),
			new PresetOrgMemberCombatSkill(279, 8),
			new PresetOrgMemberCombatSkill(369, 5),
			new PresetOrgMemberCombatSkill(447, 5),
			new PresetOrgMemberCombatSkill(487, 7),
			new PresetOrgMemberCombatSkill(503, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 8, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 18, 24, 25, 55, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 9),
			new IntPair(12, 1),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 54),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(128, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_128"), 10, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 4 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_128_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_128_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_128_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_128_1")
		}, canStroll: false, 299, new short[4] { 38, 45, 52, 59 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 47), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 40),
			new PresetInventoryItem("SkillBook", 81, 3, 40),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 4),
			new PresetOrgMemberCombatSkill(173, 4),
			new PresetOrgMemberCombatSkill(279, 7),
			new PresetOrgMemberCombatSkill(369, 5),
			new PresetOrgMemberCombatSkill(447, 5),
			new PresetOrgMemberCombatSkill(487, 6),
			new PresetOrgMemberCombatSkill(503, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 8, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 18, 24, 25, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 9),
			new IntPair(12, 1),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 54),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(129, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_129"), 10, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 3 }, 6, -1, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_129_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_129_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_129_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_129_1")
		}, canStroll: false, 300, new short[4] { 34, 40, 46, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 47), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 40),
			new PresetInventoryItem("SkillBook", 81, 3, 40),
			new PresetInventoryItem("Material", 42, 1, 30),
			new PresetInventoryItem("Material", 49, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 4),
			new PresetOrgMemberCombatSkill(173, 3),
			new PresetOrgMemberCombatSkill(279, 6),
			new PresetOrgMemberCombatSkill(369, 5),
			new PresetOrgMemberCombatSkill(447, 5),
			new PresetOrgMemberCombatSkill(487, 6),
			new PresetOrgMemberCombatSkill(503, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 7, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 18, 24, 25, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 9),
			new IntPair(12, 1),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 54),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(130, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_130"), 10, 5, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 5, 8, 5, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_130_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_130_1")
		}, 4200, 10, 6000, 8400, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_130_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_130_1")
		}, canStroll: true, 301, new short[4] { 30, 35, 40, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 47), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 30),
			new PresetInventoryItem("SkillBook", 81, 3, 30),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 30),
			new PresetInventoryItem("Medicine", 142, 1, 30),
			new PresetInventoryItem("Medicine", 154, 1, 30),
			new PresetInventoryItem("Medicine", 166, 1, 30),
			new PresetInventoryItem("Medicine", 178, 1, 30),
			new PresetInventoryItem("Medicine", 190, 1, 30),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 3),
			new PresetOrgMemberCombatSkill(173, 3),
			new PresetOrgMemberCombatSkill(279, 5),
			new PresetOrgMemberCombatSkill(487, 5),
			new PresetOrgMemberCombatSkill(503, 5)
		}, new sbyte[5] { 6, 6, 6, 6, 6 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 40000, 48000, 10, 50, 16800, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 6, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 6),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 42),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(131, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_131"), 10, 4, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 4, 7, 4, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_131_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_131_1")
		}, 2800, 8, 4500, 4650, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_131_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_131_1")
		}, canStroll: true, 302, new short[4] { 26, 30, 34, 38 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 47), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 30),
			new PresetInventoryItem("SkillBook", 81, 3, 30),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 30),
			new PresetInventoryItem("Medicine", 142, 1, 30),
			new PresetInventoryItem("Medicine", 154, 1, 30),
			new PresetInventoryItem("Medicine", 166, 1, 30),
			new PresetInventoryItem("Medicine", 178, 1, 30),
			new PresetInventoryItem("Medicine", 190, 1, 30),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 3),
			new PresetOrgMemberCombatSkill(173, 3),
			new PresetOrgMemberCombatSkill(279, 4),
			new PresetOrgMemberCombatSkill(369, 4),
			new PresetOrgMemberCombatSkill(447, 4),
			new PresetOrgMemberCombatSkill(503, 4)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 30000, 24000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 5, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 6),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 42),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(132, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_132"), 10, 3, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 3, 6, 3, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_132_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_132_1")
		}, 1800, 6, 3000, 2250, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_132_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_132_1")
		}, canStroll: true, 303, new short[4] { 22, 25, 28, 31 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 46), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 30),
			new PresetInventoryItem("SkillBook", 81, 3, 30),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 30),
			new PresetInventoryItem("Medicine", 142, 1, 30),
			new PresetInventoryItem("Medicine", 154, 1, 30),
			new PresetInventoryItem("Medicine", 166, 1, 30),
			new PresetInventoryItem("Medicine", 178, 1, 30),
			new PresetInventoryItem("Medicine", 190, 1, 30),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 244, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("Medicine", 304, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 2),
			new PresetOrgMemberCombatSkill(173, 2),
			new PresetOrgMemberCombatSkill(279, 3),
			new PresetOrgMemberCombatSkill(503, 3)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 20000, 12000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 4, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 6),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 42),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(133, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_133"), 10, 2, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 2, 5, 2, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_133_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_133_1")
		}, 600, 4, 2000, 900, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_133_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_133_1")
		}, canStroll: true, 304, new short[4] { 18, 20, 22, 24 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 54, 75),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", 468, 75),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 46), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 20),
			new PresetInventoryItem("SkillBook", 81, 3, 20),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 20),
			new PresetInventoryItem("Medicine", 142, 1, 20),
			new PresetInventoryItem("Medicine", 154, 1, 20),
			new PresetInventoryItem("Medicine", 166, 1, 20),
			new PresetInventoryItem("Medicine", 178, 1, 20),
			new PresetInventoryItem("Medicine", 190, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 2),
			new PresetOrgMemberCombatSkill(173, 2),
			new PresetOrgMemberCombatSkill(279, 2),
			new PresetOrgMemberCombatSkill(487, 2),
			new PresetOrgMemberCombatSkill(503, 2)
		}, new sbyte[5] { 2, 2, 2, 2, 2 }, new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 15000, 4000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 3, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 3),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(134, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_134"), 10, 1, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 1, 4, 1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_134_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_134_1")
		}, 300, 2, 1000, 300, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_134_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_134_1")
		}, canStroll: true, 305, new short[4] { 14, 15, 16, 17 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", 144, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 46), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 20),
			new PresetInventoryItem("SkillBook", 81, 3, 20),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 20),
			new PresetInventoryItem("Medicine", 142, 1, 20),
			new PresetInventoryItem("Medicine", 154, 1, 20),
			new PresetInventoryItem("Medicine", 166, 1, 20),
			new PresetInventoryItem("Medicine", 178, 1, 20),
			new PresetInventoryItem("Medicine", 190, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 1),
			new PresetOrgMemberCombatSkill(173, 1),
			new PresetOrgMemberCombatSkill(279, 1),
			new PresetOrgMemberCombatSkill(369, 1),
			new PresetOrgMemberCombatSkill(447, 1),
			new PresetOrgMemberCombatSkill(503, 1)
		}, new sbyte[5], new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 10000, 2000, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 2, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 3),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(135, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_135"), 10, 0, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 0, 4, 0, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_135_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_135_1")
		}, 150, 0, 500, 150, 0, new List<short> { 46, 47, 48 }, new List<short> { 37, 38, 39 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_135_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_135_1")
		}, canStroll: true, 306, new short[4] { 10, 10, 10, 10 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 315, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 171, 75),
			new PresetEquipmentItemWithProb("Accessory", 108, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 46), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 72, 3, 20),
			new PresetInventoryItem("SkillBook", 81, 3, 20),
			new PresetInventoryItem("Material", 42, 1, 10),
			new PresetInventoryItem("Material", 49, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 130, 1, 20),
			new PresetInventoryItem("Medicine", 142, 1, 20),
			new PresetInventoryItem("Medicine", 154, 1, 20),
			new PresetInventoryItem("Medicine", 166, 1, 20),
			new PresetInventoryItem("Medicine", 178, 1, 20),
			new PresetInventoryItem("Medicine", 190, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 238, 1, 10),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("Medicine", 298, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(69, 0),
			new PresetOrgMemberCombatSkill(173, 0),
			new PresetOrgMemberCombatSkill(503, 0)
		}, new sbyte[5], new short[8] { -70, -70, -70, -80, -70, -50, -70, -80 }, 5000, 1000, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, 2, -1, -1, 12, 12,
			6, 6, -1, -1, -1, 2
		}, 1, new short[14]
		{
			6, 6, 12, 6, 6, 12, 12, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 9, -1, 9, 9, 9 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 0),
			new IntPair(14, 3),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 30),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(136, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_136"), 11, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, 1, -1, 0, -1, new sbyte[0], 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_136_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_136_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 49, 50, 51 }, new List<short> { 27, 28, 29, 30 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_136_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_136_1")
		}, canStroll: false, 307, new short[4] { 34, 42, 50, 58 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 51), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 60, 1, 30),
			new PresetInventoryItem("Medicine", 72, 1, 30),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 8),
			new PresetOrgMemberCombatSkill(178, 3),
			new PresetOrgMemberCombatSkill(288, 7),
			new PresetOrgMemberCombatSkill(375, 7),
			new PresetOrgMemberCombatSkill(615, 8),
			new PresetOrgMemberCombatSkill(675, 7)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		}, 8, new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		}, new short[6] { 12, 2, 9, 12, -1, -1 }, new List<sbyte> { 19, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 15),
			new IntPair(5, 0),
			new IntPair(6, 36),
			new IntPair(15, 6),
			new IntPair(16, 9),
			new IntPair(7, 15),
			new IntPair(14, 0),
			new IntPair(12, 3),
			new IntPair(4, 1),
			new IntPair(3, 18),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(137, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_137"), 11, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 1, -1, 0, -1, new sbyte[0], 7, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_137_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_137_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 49, 50, 51 }, new List<short> { 27, 28, 29, 30 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_137_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_137_1")
		}, canStroll: false, 308, new short[4] { 31, 38, 45, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 50), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 60, 1, 30),
			new PresetInventoryItem("Medicine", 72, 1, 30),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 7),
			new PresetOrgMemberCombatSkill(178, 3),
			new PresetOrgMemberCombatSkill(288, 6),
			new PresetOrgMemberCombatSkill(375, 6),
			new PresetOrgMemberCombatSkill(615, 7),
			new PresetOrgMemberCombatSkill(675, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		}, 8, new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		}, new short[6] { 12, 2, 9, 12, -1, -1 }, new List<sbyte> { 19, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 15),
			new IntPair(5, 0),
			new IntPair(6, 36),
			new IntPair(15, 6),
			new IntPair(16, 9),
			new IntPair(7, 15),
			new IntPair(14, 0),
			new IntPair(12, 3),
			new IntPair(4, 1),
			new IntPair(3, 18),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(138, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_138"), 11, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 1, -1, 1, -1, new sbyte[0], 6, -1, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_138_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_138_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 49, 50, 51 }, new List<short> { 27, 28, 29, 30 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_138_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_138_1")
		}, canStroll: false, 309, new short[4] { 28, 34, 40, 46 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 50), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 60, 1, 30),
			new PresetInventoryItem("Medicine", 72, 1, 30),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 232, 1, 20),
			new PresetInventoryItem("Medicine", 280, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 6),
			new PresetOrgMemberCombatSkill(178, 3),
			new PresetOrgMemberCombatSkill(288, 6),
			new PresetOrgMemberCombatSkill(375, 6),
			new PresetOrgMemberCombatSkill(615, 6),
			new PresetOrgMemberCombatSkill(675, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		}, 7, new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		}, new short[6] { 12, 2, 9, 12, -1, -1 }, new List<sbyte> { 19, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 15),
			new IntPair(5, 0),
			new IntPair(6, 36),
			new IntPair(15, 6),
			new IntPair(16, 9),
			new IntPair(7, 15),
			new IntPair(14, 0),
			new IntPair(12, 3),
			new IntPair(4, 1),
			new IntPair(3, 18),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_139");
		sbyte[] potentialSuccessorGrades = new sbyte[0];
		sbyte[] childGrade = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_139_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_139_1")
		};
		List<short> favoriteClothingIds = new List<short> { 49, 50, 51 };
		List<short> hatedClothingIds = new List<short> { 27, 28, 29, 30 };
		string[] spouseAnonymousTitles = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_139_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_139_1")
		};
		short[] initialAges = new short[4] { 25, 30, 35, 40 };
		PresetEquipmentItemWithProb[] equipment = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing = new PresetEquipmentItem("Clothing", 50);
		List<PresetInventoryItem> inventory = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 30),
			new PresetInventoryItem("Medicine", 66, 1, 30),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 5),
			new PresetOrgMemberCombatSkill(178, 2),
			new PresetOrgMemberCombatSkill(288, 5),
			new PresetOrgMemberCombatSkill(615, 5),
			new PresetOrgMemberCombatSkill(675, 5)
		};
		sbyte[] extraCombatSkillGrids = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust = new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 };
		short[] lifeSkillsAdjust = new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		};
		short[] combatSkillsAdjust = new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		};
		short[] mainAttributesAdjust = new short[6] { 12, 2, 9, 12, -1, -1 };
		List<sbyte> identityInteractConfig = new List<sbyte>();
		dataArray.Add(new OrganizationMemberItem(139, config, 11, 5, potentialSuccessorGrades, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade, 5, 8, 5, 0, 0, monasticTitleSuffixes, 4200, 10, 6000, 8400, 0, favoriteClothingIds, hatedClothingIds, spouseAnonymousTitles, canStroll: false, 310, initialAges, equipment, clothing, inventory, combatSkills, extraCombatSkillGrids, resourcesAdjust, 40000, 48000, 10, 50, 16800, lifeSkillsAdjust, 6, combatSkillsAdjust, mainAttributesAdjust, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 24),
			new IntPair(8, 12),
			new IntPair(5, 0),
			new IntPair(6, 27),
			new IntPair(15, 6),
			new IntPair(16, 6),
			new IntPair(7, 12),
			new IntPair(14, 0),
			new IntPair(12, 6),
			new IntPair(4, 1),
			new IntPair(3, 21),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray2 = _dataArray;
		string config2 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_140");
		sbyte[] potentialSuccessorGrades2 = new sbyte[0];
		sbyte[] childGrade2 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_140_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_140_1")
		};
		List<short> favoriteClothingIds2 = new List<short> { 49, 50, 51 };
		List<short> hatedClothingIds2 = new List<short> { 27, 28, 29, 30 };
		string[] spouseAnonymousTitles2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_140_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_140_1")
		};
		short[] initialAges2 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment2 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing2 = new PresetEquipmentItem("Clothing", 49);
		List<PresetInventoryItem> inventory2 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 30),
			new PresetInventoryItem("Medicine", 66, 1, 30),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills2 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 4),
			new PresetOrgMemberCombatSkill(178, 2),
			new PresetOrgMemberCombatSkill(288, 4),
			new PresetOrgMemberCombatSkill(375, 4),
			new PresetOrgMemberCombatSkill(675, 4)
		};
		sbyte[] extraCombatSkillGrids2 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust2 = new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 };
		short[] lifeSkillsAdjust2 = new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		};
		short[] combatSkillsAdjust2 = new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		};
		short[] mainAttributesAdjust2 = new short[6] { 12, 2, 9, 12, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray2.Add(new OrganizationMemberItem(140, config2, 11, 4, potentialSuccessorGrades2, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade2, 4, 7, 4, 0, 0, monasticTitleSuffixes2, 2800, 8, 4500, 4650, 0, favoriteClothingIds2, hatedClothingIds2, spouseAnonymousTitles2, canStroll: true, 311, initialAges2, equipment2, clothing2, inventory2, combatSkills2, extraCombatSkillGrids2, resourcesAdjust2, 30000, 24000, 10, 60, 9300, lifeSkillsAdjust2, 5, combatSkillsAdjust2, mainAttributesAdjust2, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 24),
			new IntPair(8, 12),
			new IntPair(5, 0),
			new IntPair(6, 27),
			new IntPair(15, 6),
			new IntPair(16, 6),
			new IntPair(7, 12),
			new IntPair(14, 0),
			new IntPair(12, 6),
			new IntPair(4, 1),
			new IntPair(3, 21),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray3 = _dataArray;
		string config3 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_141");
		sbyte[] potentialSuccessorGrades3 = new sbyte[0];
		sbyte[] childGrade3 = new sbyte[1];
		string[] monasticTitleSuffixes3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_141_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_141_1")
		};
		List<short> favoriteClothingIds3 = new List<short> { 49, 50, 51 };
		List<short> hatedClothingIds3 = new List<short> { 27, 28, 29, 30 };
		string[] spouseAnonymousTitles3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_141_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_141_1")
		};
		short[] initialAges3 = new short[4] { 19, 22, 25, 28 };
		PresetEquipmentItemWithProb[] equipment3 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing3 = new PresetEquipmentItem("Clothing", 49);
		List<PresetInventoryItem> inventory3 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 30),
			new PresetInventoryItem("Medicine", 66, 1, 30),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 226, 1, 10),
			new PresetInventoryItem("Medicine", 274, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills3 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 3),
			new PresetOrgMemberCombatSkill(178, 1),
			new PresetOrgMemberCombatSkill(288, 3),
			new PresetOrgMemberCombatSkill(675, 3)
		};
		sbyte[] extraCombatSkillGrids3 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust3 = new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 };
		short[] lifeSkillsAdjust3 = new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		};
		short[] combatSkillsAdjust3 = new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		};
		short[] mainAttributesAdjust3 = new short[6] { 12, 2, 9, 12, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray3.Add(new OrganizationMemberItem(141, config3, 11, 3, potentialSuccessorGrades3, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade3, 3, 6, 3, 0, 0, monasticTitleSuffixes3, 1800, 6, 3000, 2250, 0, favoriteClothingIds3, hatedClothingIds3, spouseAnonymousTitles3, canStroll: true, 312, initialAges3, equipment3, clothing3, inventory3, combatSkills3, extraCombatSkillGrids3, resourcesAdjust3, 20000, 12000, 10, 70, 4500, lifeSkillsAdjust3, 4, combatSkillsAdjust3, mainAttributesAdjust3, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 24),
			new IntPair(8, 12),
			new IntPair(5, 0),
			new IntPair(6, 27),
			new IntPair(15, 6),
			new IntPair(16, 6),
			new IntPair(7, 12),
			new IntPair(14, 0),
			new IntPair(12, 6),
			new IntPair(4, 1),
			new IntPair(3, 21),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray4 = _dataArray;
		string config4 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_142");
		sbyte[] potentialSuccessorGrades4 = new sbyte[0];
		sbyte[] childGrade4 = new sbyte[1];
		string[] monasticTitleSuffixes4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_142_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_142_1")
		};
		List<short> favoriteClothingIds4 = new List<short> { 49, 50, 51 };
		List<short> hatedClothingIds4 = new List<short> { 27, 28, 29, 30 };
		string[] spouseAnonymousTitles4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_142_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_142_1")
		};
		short[] initialAges4 = new short[4] { 16, 18, 20, 22 };
		PresetEquipmentItemWithProb[] equipment4 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 108, 75),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", 504, 75),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing4 = new PresetEquipmentItem("Clothing", 49);
		List<PresetInventoryItem> inventory4 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills4 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 2),
			new PresetOrgMemberCombatSkill(178, 1),
			new PresetOrgMemberCombatSkill(288, 2),
			new PresetOrgMemberCombatSkill(375, 2)
		};
		sbyte[] extraCombatSkillGrids4 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust4 = new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 };
		short[] lifeSkillsAdjust4 = new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		};
		short[] combatSkillsAdjust4 = new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		};
		short[] mainAttributesAdjust4 = new short[6] { 12, 2, 9, 12, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray4.Add(new OrganizationMemberItem(142, config4, 11, 2, potentialSuccessorGrades4, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade4, 2, 5, 2, 0, 0, monasticTitleSuffixes4, 600, 4, 2000, 900, 0, favoriteClothingIds4, hatedClothingIds4, spouseAnonymousTitles4, canStroll: true, 313, initialAges4, equipment4, clothing4, inventory4, combatSkills4, extraCombatSkillGrids4, resourcesAdjust4, 15000, 4000, 5, 80, 1800, lifeSkillsAdjust4, 3, combatSkillsAdjust4, mainAttributesAdjust4, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 9),
			new IntPair(5, 0),
			new IntPair(6, 18),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 9),
			new IntPair(14, 0),
			new IntPair(12, 9),
			new IntPair(4, 1),
			new IntPair(3, 24),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray5 = _dataArray;
		string config5 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_143");
		sbyte[] potentialSuccessorGrades5 = new sbyte[0];
		sbyte[] childGrade5 = new sbyte[1];
		string[] monasticTitleSuffixes5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_143_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_143_1")
		};
		List<short> favoriteClothingIds5 = new List<short> { 49, 50, 51 };
		List<short> hatedClothingIds5 = new List<short> { 27, 28, 29, 30 };
		string[] spouseAnonymousTitles5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_143_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_143_1")
		};
		short[] initialAges5 = new short[4] { 13, 14, 15, 16 };
		PresetEquipmentItemWithProb[] equipment5 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 0, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 80),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing5 = new PresetEquipmentItem("Clothing", 49);
		List<PresetInventoryItem> inventory5 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills5 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 1),
			new PresetOrgMemberCombatSkill(178, 1),
			new PresetOrgMemberCombatSkill(288, 1),
			new PresetOrgMemberCombatSkill(615, 1)
		};
		sbyte[] extraCombatSkillGrids5 = new sbyte[5];
		short[] resourcesAdjust5 = new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 };
		short[] lifeSkillsAdjust5 = new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		};
		short[] combatSkillsAdjust5 = new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		};
		short[] mainAttributesAdjust5 = new short[6] { 12, 2, 9, 12, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray5.Add(new OrganizationMemberItem(143, config5, 11, 1, potentialSuccessorGrades5, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade5, 1, 4, 1, 0, 0, monasticTitleSuffixes5, 300, 2, 1000, 300, 0, favoriteClothingIds5, hatedClothingIds5, spouseAnonymousTitles5, canStroll: true, 314, initialAges5, equipment5, clothing5, inventory5, combatSkills5, extraCombatSkillGrids5, resourcesAdjust5, 10000, 2000, 5, 90, 600, lifeSkillsAdjust5, 2, combatSkillsAdjust5, mainAttributesAdjust5, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 9),
			new IntPair(5, 0),
			new IntPair(6, 18),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 9),
			new IntPair(14, 0),
			new IntPair(12, 9),
			new IntPair(4, 1),
			new IntPair(3, 24),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray6 = _dataArray;
		string config6 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_144");
		sbyte[] potentialSuccessorGrades6 = new sbyte[0];
		sbyte[] childGrade6 = new sbyte[1];
		string[] monasticTitleSuffixes6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_144_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_144_1")
		};
		List<short> favoriteClothingIds6 = new List<short> { 49, 50, 51 };
		List<short> hatedClothingIds6 = new List<short> { 27, 28, 29, 30 };
		string[] spouseAnonymousTitles6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_144_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_144_1")
		};
		short[] initialAges6 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment6 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 378, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 234, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing6 = new PresetEquipmentItem("Clothing", 49);
		List<PresetInventoryItem> inventory6 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 117, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills6 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(74, 0),
			new PresetOrgMemberCombatSkill(178, 0),
			new PresetOrgMemberCombatSkill(675, 0)
		};
		sbyte[] extraCombatSkillGrids6 = new sbyte[5];
		short[] resourcesAdjust6 = new short[8] { -70, -80, -70, -70, -70, -70, -50, -60 };
		short[] lifeSkillsAdjust6 = new short[16]
		{
			-1, -1, -1, -1, -1, 6, -1, -1, -1, -1,
			-1, -1, 2, 12, -1, 9
		};
		short[] combatSkillsAdjust6 = new short[14]
		{
			12, 6, 12, 12, -1, -1, -1, -1, 12, -1,
			12, 2, -1, -1
		};
		short[] mainAttributesAdjust6 = new short[6] { 12, 2, 9, 12, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray6.Add(new OrganizationMemberItem(144, config6, 11, 0, potentialSuccessorGrades6, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade6, 0, 4, 0, 0, 0, monasticTitleSuffixes6, 150, 0, 500, 150, 0, favoriteClothingIds6, hatedClothingIds6, spouseAnonymousTitles6, canStroll: true, 315, initialAges6, equipment6, clothing6, inventory6, combatSkills6, extraCombatSkillGrids6, resourcesAdjust6, 5000, 1000, 1, 100, 300, lifeSkillsAdjust6, 1, combatSkillsAdjust6, mainAttributesAdjust6, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 9),
			new IntPair(5, 0),
			new IntPair(6, 18),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 9),
			new IntPair(14, 0),
			new IntPair(12, 9),
			new IntPair(4, 1),
			new IntPair(3, 24),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(145, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_145"), 12, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, 0, -1, 0, -1, new sbyte[0], 5, -1, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_145_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_145_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_145_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_145_1")
		}, canStroll: false, 316, new short[4] { 16, 19, 22, 25 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 54), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 6),
			new PresetOrgMemberCombatSkill(182, 6),
			new PresetOrgMemberCombatSkill(296, 8),
			new PresetOrgMemberCombatSkill(383, 7),
			new PresetOrgMemberCombatSkill(453, 8),
			new PresetOrgMemberCombatSkill(575, 6),
			new PresetOrgMemberCombatSkill(691, 8)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 120000, 432000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 8, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 20, 24, 25, 55, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 15),
			new IntPair(3, 6),
			new IntPair(13, 54),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(146, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_146"), 12, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 0, -1, 0, -1, new sbyte[0], 5, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_146_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_146_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_146_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_146_1")
		}, canStroll: false, 317, new short[4] { 12, 13, 14, 15 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 53), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 6),
			new PresetOrgMemberCombatSkill(182, 6),
			new PresetOrgMemberCombatSkill(296, 7),
			new PresetOrgMemberCombatSkill(383, 6),
			new PresetOrgMemberCombatSkill(453, 7),
			new PresetOrgMemberCombatSkill(575, 6),
			new PresetOrgMemberCombatSkill(691, 7)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 75000, 216000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 8, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 20, 24, 25, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 15),
			new IntPair(3, 6),
			new IntPair(13, 54),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(147, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_147"), 12, 6, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, 0, -1, 0, -1, new sbyte[0], 5, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_147_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_147_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_147_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_147_1")
		}, canStroll: false, 318, new short[4] { 42, 50, 58, 66 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 53), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 30),
			new PresetInventoryItem("Material", 7, 1, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 9, 1, 30),
			new PresetInventoryItem("Medicine", 18, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 45, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 5),
			new PresetOrgMemberCombatSkill(182, 5),
			new PresetOrgMemberCombatSkill(296, 6),
			new PresetOrgMemberCombatSkill(383, 6),
			new PresetOrgMemberCombatSkill(453, 6),
			new PresetOrgMemberCombatSkill(575, 5),
			new PresetOrgMemberCombatSkill(691, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 45000, 108000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 7, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 20, 24, 25, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 15),
			new IntPair(3, 6),
			new IntPair(13, 54),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(148, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_148"), 12, 5, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 3 }, 5, 8, 5, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_148_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_148_1")
		}, 4200, 10, 6000, 8400, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_148_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_148_1")
		}, canStroll: false, 319, new short[4] { 38, 45, 52, 59 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 53), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 30),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 5),
			new PresetOrgMemberCombatSkill(182, 5),
			new PresetOrgMemberCombatSkill(296, 5),
			new PresetOrgMemberCombatSkill(383, 5),
			new PresetOrgMemberCombatSkill(453, 5),
			new PresetOrgMemberCombatSkill(575, 5)
		}, new sbyte[5] { 6, 6, 6, 6, 6 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 30000, 36000, 10, 50, 16800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 6, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 6),
			new IntPair(13, 42),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(149, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_149"), 12, 4, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 2 }, 4, 6, 4, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_149_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_149_1")
		}, 2800, 8, 4500, 4650, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_149_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_149_1")
		}, canStroll: true, 320, new short[4] { 18, 22, 26, 30 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 52), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 30),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 4),
			new PresetOrgMemberCombatSkill(182, 4),
			new PresetOrgMemberCombatSkill(296, 4),
			new PresetOrgMemberCombatSkill(453, 4),
			new PresetOrgMemberCombatSkill(575, 4),
			new PresetOrgMemberCombatSkill(691, 4)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 22500, 18000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 5, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 6),
			new IntPair(13, 42),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(150, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_150"), 12, 3, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 3, 5, 3, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_150_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_150_1")
		}, 1800, 6, 3000, 2250, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_150_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_150_1")
		}, canStroll: true, 321, new short[4] { 16, 19, 22, 25 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 52), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 30),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 136, 1, 20),
			new PresetInventoryItem("Medicine", 148, 1, 20),
			new PresetInventoryItem("Medicine", 160, 1, 20),
			new PresetInventoryItem("Medicine", 172, 1, 20),
			new PresetInventoryItem("Medicine", 184, 1, 20),
			new PresetInventoryItem("Medicine", 196, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 3),
			new PresetOrgMemberCombatSkill(182, 3),
			new PresetOrgMemberCombatSkill(296, 3),
			new PresetOrgMemberCombatSkill(383, 3),
			new PresetOrgMemberCombatSkill(575, 3),
			new PresetOrgMemberCombatSkill(691, 3)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 15000, 9000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 4, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 6),
			new IntPair(13, 42),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(151, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_151"), 12, 2, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 2, 4, 2, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_151_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_151_1")
		}, 600, 4, 2000, 900, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_151_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_151_1")
		}, canStroll: true, 322, new short[4] { 14, 16, 18, 20 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 27, 75),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", 423, 75),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 126, 50),
			new PresetEquipmentItemWithProb("Carrier", 9, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 52), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 20),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 130, 1, 10),
			new PresetInventoryItem("Medicine", 142, 1, 10),
			new PresetInventoryItem("Medicine", 154, 1, 10),
			new PresetInventoryItem("Medicine", 166, 1, 10),
			new PresetInventoryItem("Medicine", 178, 1, 10),
			new PresetInventoryItem("Medicine", 190, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 2),
			new PresetOrgMemberCombatSkill(182, 2),
			new PresetOrgMemberCombatSkill(296, 2),
			new PresetOrgMemberCombatSkill(453, 2),
			new PresetOrgMemberCombatSkill(575, 2),
			new PresetOrgMemberCombatSkill(691, 2)
		}, new sbyte[5] { 2, 2, 2, 2, 2 }, new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 11250, 3000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 3, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 6),
			new IntPair(13, 30),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(152, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_152"), 12, 1, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 1, 3, 1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_152_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_152_1")
		}, 300, 2, 1000, 300, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_152_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_152_1")
		}, canStroll: true, 323, new short[4] { 12, 13, 14, 15 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 52), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 20),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 130, 1, 10),
			new PresetInventoryItem("Medicine", 142, 1, 10),
			new PresetInventoryItem("Medicine", 154, 1, 10),
			new PresetInventoryItem("Medicine", 166, 1, 10),
			new PresetInventoryItem("Medicine", 178, 1, 10),
			new PresetInventoryItem("Medicine", 190, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 1),
			new PresetOrgMemberCombatSkill(182, 1),
			new PresetOrgMemberCombatSkill(296, 1),
			new PresetOrgMemberCombatSkill(383, 1),
			new PresetOrgMemberCombatSkill(453, 1),
			new PresetOrgMemberCombatSkill(691, 1)
		}, new sbyte[5], new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 7500, 1500, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 2, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 6),
			new IntPair(13, 30),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(153, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_153"), 12, 0, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 0, 3, 0, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_153_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_153_1")
		}, 150, 0, 500, 150, 0, new List<short> { 52, 53, 54 }, new List<short> { 18, 19, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_153_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_153_1")
		}, canStroll: true, 324, new short[4] { 10, 10, 10, 10 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 297, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 153, 75),
			new PresetEquipmentItemWithProb("Accessory", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 52), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 81, 3, 20),
			new PresetInventoryItem("Material", 0, 1, 10),
			new PresetInventoryItem("Material", 7, 1, 10),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 0, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 130, 1, 10),
			new PresetInventoryItem("Medicine", 142, 1, 10),
			new PresetInventoryItem("Medicine", 154, 1, 10),
			new PresetInventoryItem("Medicine", 166, 1, 10),
			new PresetInventoryItem("Medicine", 178, 1, 10),
			new PresetInventoryItem("Medicine", 190, 1, 10),
			new PresetInventoryItem("Material", 236, 1, 10),
			new PresetInventoryItem("Material", 243, 1, 10),
			new PresetInventoryItem("Material", 250, 1, 10),
			new PresetInventoryItem("Material", 257, 1, 10),
			new PresetInventoryItem("Material", 264, 1, 10),
			new PresetInventoryItem("Material", 271, 1, 10)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(83, 0),
			new PresetOrgMemberCombatSkill(182, 0),
			new PresetOrgMemberCombatSkill(453, 0)
		}, new sbyte[5], new short[8] { -70, -50, -70, -80, -70, -70, -70, -70 }, 3750, 750, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, 9, 9, 12,
			-1, -1, 2, 2, -1, -1
		}, 1, new short[14]
		{
			9, 9, 12, 12, 12, -1, -1, 9, -1, 2,
			-1, 12, -1, -1
		}, new short[6] { -1, 12, 2, -1, 9, 12 }, new List<sbyte> { 5, 64 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 6),
			new IntPair(13, 30),
			new IntPair(10, 12),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 1),
			new IntPair(0, 21),
			new IntPair(9, 1)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(154, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_154"), 13, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 4 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_154_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_154_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 55, 56, 57 }, new List<short> { 31, 32, 33 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_154_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_154_1")
		}, canStroll: false, 325, new short[4] { 25, 30, 35, 40 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 57), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 40),
			new PresetInventoryItem("SkillBook", 36, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 292, 1, 30),
			new PresetInventoryItem("Medicine", 316, 1, 30)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 6),
			new PresetOrgMemberCombatSkill(189, 8),
			new PresetOrgMemberCombatSkill(305, 6),
			new PresetOrgMemberCombatSkill(462, 8),
			new PresetOrgMemberCombatSkill(512, 8),
			new PresetOrgMemberCombatSkill(582, 7)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		}, 8, new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 12, -1, 2, 9, 12 }, new List<sbyte> { 21, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 9),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 54),
			new IntPair(12, 1),
			new IntPair(4, 21),
			new IntPair(3, 15),
			new IntPair(13, 12),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(155, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_155"), 13, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1] { 4 }, 6, 8, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_155_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_155_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 55, 56, 57 }, new List<short> { 31, 32, 33 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_155_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_155_1")
		}, canStroll: false, 326, new short[4] { 22, 26, 30, 34 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 56), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 40),
			new PresetInventoryItem("SkillBook", 36, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 292, 1, 30),
			new PresetInventoryItem("Medicine", 316, 1, 30)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 6),
			new PresetOrgMemberCombatSkill(189, 7),
			new PresetOrgMemberCombatSkill(305, 6),
			new PresetOrgMemberCombatSkill(462, 7),
			new PresetOrgMemberCombatSkill(512, 7),
			new PresetOrgMemberCombatSkill(582, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		}, 8, new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 12, -1, 2, 9, 12 }, new List<sbyte> { 21, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 9),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 54),
			new IntPair(12, 1),
			new IntPair(4, 21),
			new IntPair(3, 15),
			new IntPair(13, 12),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(156, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_156"), 13, 6, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 3 }, 6, 7, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_156_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_156_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 55, 56, 57 }, new List<short> { 31, 32, 33 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_156_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_156_1")
		}, canStroll: true, 327, new short[4] { 19, 22, 25, 28 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 56), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 40),
			new PresetInventoryItem("SkillBook", 36, 1, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 256, 1, 20),
			new PresetInventoryItem("Medicine", 328, 1, 20),
			new PresetInventoryItem("Medicine", 292, 1, 30),
			new PresetInventoryItem("Medicine", 316, 1, 30)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 5),
			new PresetOrgMemberCombatSkill(189, 6),
			new PresetOrgMemberCombatSkill(305, 5),
			new PresetOrgMemberCombatSkill(462, 6),
			new PresetOrgMemberCombatSkill(512, 6),
			new PresetOrgMemberCombatSkill(582, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, 12, -1, 2, 9, 12 }, new List<sbyte> { 21, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 9),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 54),
			new IntPair(12, 1),
			new IntPair(4, 21),
			new IntPair(3, 15),
			new IntPair(13, 12),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray7 = _dataArray;
		string config7 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_157");
		sbyte[] potentialSuccessorGrades7 = new sbyte[0];
		sbyte[] childGrade7 = new sbyte[1] { 3 };
		string[] monasticTitleSuffixes7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_157_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_157_1")
		};
		List<short> favoriteClothingIds7 = new List<short> { 55, 56, 57 };
		List<short> hatedClothingIds7 = new List<short> { 31, 32, 33 };
		string[] spouseAnonymousTitles7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_157_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_157_1")
		};
		short[] initialAges7 = new short[4] { 25, 30, 35, 40 };
		PresetEquipmentItemWithProb[] equipment7 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing7 = new PresetEquipmentItem("Clothing", 56);
		List<PresetInventoryItem> inventory7 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 30),
			new PresetInventoryItem("SkillBook", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 30),
			new PresetInventoryItem("Medicine", 310, 1, 30)
		};
		List<PresetOrgMemberCombatSkill> combatSkills7 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 5),
			new PresetOrgMemberCombatSkill(189, 5),
			new PresetOrgMemberCombatSkill(305, 5),
			new PresetOrgMemberCombatSkill(512, 5),
			new PresetOrgMemberCombatSkill(582, 5)
		};
		sbyte[] extraCombatSkillGrids7 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust7 = new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 };
		short[] lifeSkillsAdjust7 = new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust7 = new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust7 = new short[6] { -1, 12, -1, 2, 9, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray7.Add(new OrganizationMemberItem(157, config7, 13, 5, potentialSuccessorGrades7, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade7, 5, 7, 5, 0, 0, monasticTitleSuffixes7, 4200, 10, 6000, 8400, 0, favoriteClothingIds7, hatedClothingIds7, spouseAnonymousTitles7, canStroll: true, 328, initialAges7, equipment7, clothing7, inventory7, combatSkills7, extraCombatSkillGrids7, resourcesAdjust7, 40000, 48000, 10, 50, 16800, lifeSkillsAdjust7, 6, combatSkillsAdjust7, mainAttributesAdjust7, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 6),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 42),
			new IntPair(12, 1),
			new IntPair(4, 18),
			new IntPair(3, 18),
			new IntPair(13, 9),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray8 = _dataArray;
		string config8 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_158");
		sbyte[] potentialSuccessorGrades8 = new sbyte[0];
		sbyte[] childGrade8 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_158_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_158_1")
		};
		List<short> favoriteClothingIds8 = new List<short> { 55, 56, 57 };
		List<short> hatedClothingIds8 = new List<short> { 31, 32, 33 };
		string[] spouseAnonymousTitles8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_158_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_158_1")
		};
		short[] initialAges8 = new short[4] { 22, 26, 30, 34 };
		PresetEquipmentItemWithProb[] equipment8 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing8 = new PresetEquipmentItem("Clothing", 55);
		List<PresetInventoryItem> inventory8 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 30),
			new PresetInventoryItem("SkillBook", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 30),
			new PresetInventoryItem("Medicine", 310, 1, 30)
		};
		List<PresetOrgMemberCombatSkill> combatSkills8 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 4),
			new PresetOrgMemberCombatSkill(189, 4),
			new PresetOrgMemberCombatSkill(305, 4),
			new PresetOrgMemberCombatSkill(462, 4),
			new PresetOrgMemberCombatSkill(582, 4)
		};
		sbyte[] extraCombatSkillGrids8 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust8 = new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 };
		short[] lifeSkillsAdjust8 = new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust8 = new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust8 = new short[6] { -1, 12, -1, 2, 9, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray8.Add(new OrganizationMemberItem(158, config8, 13, 4, potentialSuccessorGrades8, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade8, 4, 5, 4, 0, 0, monasticTitleSuffixes8, 2800, 8, 4500, 4650, 0, favoriteClothingIds8, hatedClothingIds8, spouseAnonymousTitles8, canStroll: true, 329, initialAges8, equipment8, clothing8, inventory8, combatSkills8, extraCombatSkillGrids8, resourcesAdjust8, 30000, 24000, 10, 60, 9300, lifeSkillsAdjust8, 5, combatSkillsAdjust8, mainAttributesAdjust8, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 6),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 42),
			new IntPair(12, 1),
			new IntPair(4, 18),
			new IntPair(3, 18),
			new IntPair(13, 9),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray9 = _dataArray;
		string config9 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_159");
		sbyte[] potentialSuccessorGrades9 = new sbyte[0];
		sbyte[] childGrade9 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_159_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_159_1")
		};
		List<short> favoriteClothingIds9 = new List<short> { 55, 56, 57 };
		List<short> hatedClothingIds9 = new List<short> { 31, 32, 33 };
		string[] spouseAnonymousTitles9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_159_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_159_1")
		};
		short[] initialAges9 = new short[4] { 19, 22, 25, 28 };
		PresetEquipmentItemWithProb[] equipment9 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing9 = new PresetEquipmentItem("Clothing", 55);
		List<PresetInventoryItem> inventory9 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 30),
			new PresetInventoryItem("SkillBook", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Medicine", 9, 1, 20),
			new PresetInventoryItem("Medicine", 18, 1, 20),
			new PresetInventoryItem("Medicine", 45, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 250, 1, 10),
			new PresetInventoryItem("Medicine", 322, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 30),
			new PresetInventoryItem("Medicine", 310, 1, 30)
		};
		List<PresetOrgMemberCombatSkill> combatSkills9 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 3),
			new PresetOrgMemberCombatSkill(189, 3),
			new PresetOrgMemberCombatSkill(305, 3),
			new PresetOrgMemberCombatSkill(462, 3),
			new PresetOrgMemberCombatSkill(512, 3),
			new PresetOrgMemberCombatSkill(582, 3)
		};
		sbyte[] extraCombatSkillGrids9 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust9 = new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 };
		short[] lifeSkillsAdjust9 = new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust9 = new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust9 = new short[6] { -1, 12, -1, 2, 9, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray9.Add(new OrganizationMemberItem(159, config9, 13, 3, potentialSuccessorGrades9, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade9, 3, 5, 3, 0, 0, monasticTitleSuffixes9, 1800, 6, 3000, 2250, 0, favoriteClothingIds9, hatedClothingIds9, spouseAnonymousTitles9, canStroll: true, 330, initialAges9, equipment9, clothing9, inventory9, combatSkills9, extraCombatSkillGrids9, resourcesAdjust9, 20000, 12000, 10, 70, 4500, lifeSkillsAdjust9, 4, combatSkillsAdjust9, mainAttributesAdjust9, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 6),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 42),
			new IntPair(12, 1),
			new IntPair(4, 18),
			new IntPair(3, 18),
			new IntPair(13, 9),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray10 = _dataArray;
		string config10 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_160");
		sbyte[] potentialSuccessorGrades10 = new sbyte[0];
		sbyte[] childGrade10 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_160_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_160_1")
		};
		List<short> favoriteClothingIds10 = new List<short> { 55, 56, 57 };
		List<short> hatedClothingIds10 = new List<short> { 31, 32, 33 };
		string[] spouseAnonymousTitles10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_160_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_160_1")
		};
		short[] initialAges10 = new short[4] { 16, 18, 20, 22 };
		PresetEquipmentItemWithProb[] equipment10 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 36, 75),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", 477, 75),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", 72, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing10 = new PresetEquipmentItem("Clothing", 55);
		List<PresetInventoryItem> inventory10 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 20),
			new PresetInventoryItem("SkillBook", 36, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 20),
			new PresetInventoryItem("Medicine", 310, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills10 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 2),
			new PresetOrgMemberCombatSkill(189, 2),
			new PresetOrgMemberCombatSkill(305, 2),
			new PresetOrgMemberCombatSkill(462, 2),
			new PresetOrgMemberCombatSkill(512, 2)
		};
		sbyte[] extraCombatSkillGrids10 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust10 = new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 };
		short[] lifeSkillsAdjust10 = new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust10 = new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust10 = new short[6] { -1, 12, -1, 2, 9, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray10.Add(new OrganizationMemberItem(160, config10, 13, 2, potentialSuccessorGrades10, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade10, 2, 5, 2, 0, 0, monasticTitleSuffixes10, 600, 4, 2000, 900, 0, favoriteClothingIds10, hatedClothingIds10, spouseAnonymousTitles10, canStroll: true, 331, initialAges10, equipment10, clothing10, inventory10, combatSkills10, extraCombatSkillGrids10, resourcesAdjust10, 15000, 4000, 5, 80, 1800, lifeSkillsAdjust10, 3, combatSkillsAdjust10, mainAttributesAdjust10, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 3),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 1),
			new IntPair(4, 15),
			new IntPair(3, 21),
			new IntPair(13, 6),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray11 = _dataArray;
		string config11 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_161");
		sbyte[] potentialSuccessorGrades11 = new sbyte[0];
		sbyte[] childGrade11 = new sbyte[1];
		string[] monasticTitleSuffixes11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_161_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_161_1")
		};
		List<short> favoriteClothingIds11 = new List<short> { 55, 56, 57 };
		List<short> hatedClothingIds11 = new List<short> { 31, 32, 33 };
		string[] spouseAnonymousTitles11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_161_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_161_1")
		};
		short[] initialAges11 = new short[4] { 13, 14, 15, 16 };
		PresetEquipmentItemWithProb[] equipment11 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 135, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing11 = new PresetEquipmentItem("Clothing", 55);
		List<PresetInventoryItem> inventory11 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 20),
			new PresetInventoryItem("SkillBook", 36, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 20),
			new PresetInventoryItem("Medicine", 310, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills11 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 1),
			new PresetOrgMemberCombatSkill(189, 1),
			new PresetOrgMemberCombatSkill(305, 1),
			new PresetOrgMemberCombatSkill(512, 1),
			new PresetOrgMemberCombatSkill(582, 1)
		};
		sbyte[] extraCombatSkillGrids11 = new sbyte[5];
		short[] resourcesAdjust11 = new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 };
		short[] lifeSkillsAdjust11 = new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust11 = new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust11 = new short[6] { -1, 12, -1, 2, 9, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray11.Add(new OrganizationMemberItem(161, config11, 13, 1, potentialSuccessorGrades11, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade11, 1, 5, 1, 0, 0, monasticTitleSuffixes11, 300, 2, 1000, 300, 0, favoriteClothingIds11, hatedClothingIds11, spouseAnonymousTitles11, canStroll: true, 332, initialAges11, equipment11, clothing11, inventory11, combatSkills11, extraCombatSkillGrids11, resourcesAdjust11, 10000, 2000, 5, 90, 600, lifeSkillsAdjust11, 2, combatSkillsAdjust11, mainAttributesAdjust11, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 3),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 1),
			new IntPair(4, 15),
			new IntPair(3, 21),
			new IntPair(13, 6),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		List<OrganizationMemberItem> dataArray12 = _dataArray;
		string config12 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_162");
		sbyte[] potentialSuccessorGrades12 = new sbyte[0];
		sbyte[] childGrade12 = new sbyte[1];
		string[] monasticTitleSuffixes12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_162_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_162_1")
		};
		List<short> favoriteClothingIds12 = new List<short> { 55, 56, 57 };
		List<short> hatedClothingIds12 = new List<short> { 31, 32, 33 };
		string[] spouseAnonymousTitles12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_162_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_162_1")
		};
		short[] initialAges12 = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment12 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 324, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 162, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing12 = new PresetEquipmentItem("Clothing", 55);
		List<PresetInventoryItem> inventory12 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 9, 1, 20),
			new PresetInventoryItem("SkillBook", 36, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Medicine", 9, 1, 10),
			new PresetInventoryItem("Medicine", 18, 1, 10),
			new PresetInventoryItem("Medicine", 45, 1, 10),
			new PresetInventoryItem("Medicine", 286, 1, 20),
			new PresetInventoryItem("Medicine", 310, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills12 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(90, 0),
			new PresetOrgMemberCombatSkill(189, 0),
			new PresetOrgMemberCombatSkill(512, 0)
		};
		sbyte[] extraCombatSkillGrids12 = new sbyte[5];
		short[] resourcesAdjust12 = new short[8] { -70, -70, -70, -70, -60, -60, -70, -70 };
		short[] lifeSkillsAdjust12 = new short[16]
		{
			-1, 12, -1, -1, 12, 2, -1, -1, 2, 9,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust12 = new short[14]
		{
			6, 12, 6, -1, 12, -1, 12, 12, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust12 = new short[6] { -1, 12, -1, 2, 9, 12 };
		identityInteractConfig = new List<sbyte>();
		dataArray12.Add(new OrganizationMemberItem(162, config12, 13, 0, potentialSuccessorGrades12, 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade12, 0, 2, 0, 0, 0, monasticTitleSuffixes12, 150, 0, 500, 150, 0, favoriteClothingIds12, hatedClothingIds12, spouseAnonymousTitles12, canStroll: true, 333, initialAges12, equipment12, clothing12, inventory12, combatSkills12, extraCombatSkillGrids12, resourcesAdjust12, 5000, 1000, 1, 100, 300, lifeSkillsAdjust12, 1, combatSkillsAdjust12, mainAttributesAdjust12, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 3),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 30),
			new IntPair(12, 1),
			new IntPair(4, 15),
			new IntPair(3, 21),
			new IntPair(13, 6),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 6),
			new IntPair(0, 3),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(163, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_163"), 14, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, 1119, 0, 7, new sbyte[1] { 5 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_163_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_163_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_163_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_163_1")
		}, canStroll: false, 334, new short[4] { 42, 50, 58, 66 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 60), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 40),
			new PresetInventoryItem("SkillBook", 45, 1, 40),
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 30),
			new PresetInventoryItem("Medicine", 124, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 30),
			new PresetInventoryItem("TeaWine", 9, 1, 30),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 7),
			new PresetOrgMemberCombatSkill(198, 5),
			new PresetOrgMemberCombatSkill(312, 7),
			new PresetOrgMemberCombatSkill(391, 8),
			new PresetOrgMemberCombatSkill(521, 5),
			new PresetOrgMemberCombatSkill(624, 7)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 8, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 22, 24, 25, 55, 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 9),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 9),
			new IntPair(16, 6),
			new IntPair(7, 54),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(164, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_164"), 14, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, 1831, 0, 7, new sbyte[1] { 4 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_164_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_164_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_164_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_164_1")
		}, canStroll: false, 335, new short[4] { 38, 45, 52, 59 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 59), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 40),
			new PresetInventoryItem("SkillBook", 45, 1, 40),
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 30),
			new PresetInventoryItem("Medicine", 124, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 30),
			new PresetInventoryItem("TeaWine", 9, 1, 30),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 6),
			new PresetOrgMemberCombatSkill(198, 5),
			new PresetOrgMemberCombatSkill(312, 6),
			new PresetOrgMemberCombatSkill(391, 7),
			new PresetOrgMemberCombatSkill(521, 5),
			new PresetOrgMemberCombatSkill(624, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 8, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 22, 24, 25, 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 9),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 9),
			new IntPair(16, 6),
			new IntPair(7, 54),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(165, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_165"), 14, 6, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, 1119, 1, -1, new sbyte[1] { 3 }, 6, -1, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_165_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_165_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_165_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_165_1")
		}, canStroll: false, 336, new short[4] { 34, 40, 46, 52 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 59), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 40),
			new PresetInventoryItem("SkillBook", 45, 1, 40),
			new PresetInventoryItem("Material", 14, 1, 30),
			new PresetInventoryItem("Material", 21, 1, 30),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 30),
			new PresetInventoryItem("Medicine", 124, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 30),
			new PresetInventoryItem("TeaWine", 9, 1, 30),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 6),
			new PresetOrgMemberCombatSkill(198, 4),
			new PresetOrgMemberCombatSkill(312, 6),
			new PresetOrgMemberCombatSkill(391, 6),
			new PresetOrgMemberCombatSkill(521, 5),
			new PresetOrgMemberCombatSkill(624, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 7, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 22, 24, 25, 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 9),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 9),
			new IntPair(16, 6),
			new IntPair(7, 54),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 6)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(166, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_166"), 14, 5, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, 1831, 1, -1, new sbyte[1] { 2 }, 5, 8, 5, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_166_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_166_1")
		}, 4200, 10, 6000, 8400, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_166_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_166_1")
		}, canStroll: true, 337, new short[4] { 30, 35, 40, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 59), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 30),
			new PresetInventoryItem("SkillBook", 45, 1, 30),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 30),
			new PresetInventoryItem("Medicine", 118, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 30),
			new PresetInventoryItem("TeaWine", 9, 1, 30),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 5),
			new PresetOrgMemberCombatSkill(198, 4),
			new PresetOrgMemberCombatSkill(312, 5),
			new PresetOrgMemberCombatSkill(391, 5),
			new PresetOrgMemberCombatSkill(624, 5)
		}, new sbyte[5] { 6, 6, 6, 6, 6 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 40000, 48000, 10, 50, 16800, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 6, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 6),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 6),
			new IntPair(7, 42),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 9)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(167, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_167"), 14, 4, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, 1119, 1, -1, new sbyte[1] { 2 }, 4, 7, 4, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_167_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_167_1")
		}, 2800, 8, 4500, 4650, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_167_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_167_1")
		}, canStroll: true, 338, new short[4] { 26, 30, 34, 38 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 59), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 30),
			new PresetInventoryItem("SkillBook", 45, 1, 30),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 30),
			new PresetInventoryItem("Medicine", 118, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 30),
			new PresetInventoryItem("TeaWine", 9, 1, 30),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 4),
			new PresetOrgMemberCombatSkill(198, 3),
			new PresetOrgMemberCombatSkill(312, 4),
			new PresetOrgMemberCombatSkill(521, 4),
			new PresetOrgMemberCombatSkill(624, 4)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 30000, 24000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 5, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 6),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 6),
			new IntPair(7, 42),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 9)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(168, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_168"), 14, 3, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, 1831, 1, -1, new sbyte[1] { 1 }, 3, 6, 3, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_168_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_168_1")
		}, 1800, 6, 3000, 2250, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_168_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_168_1")
		}, canStroll: true, 339, new short[4] { 22, 25, 28, 31 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 58), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 30),
			new PresetInventoryItem("SkillBook", 45, 1, 30),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 30),
			new PresetInventoryItem("Medicine", 118, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 30),
			new PresetInventoryItem("TeaWine", 9, 1, 30),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 3),
			new PresetOrgMemberCombatSkill(198, 3),
			new PresetOrgMemberCombatSkill(312, 3),
			new PresetOrgMemberCombatSkill(391, 3),
			new PresetOrgMemberCombatSkill(624, 3)
		}, new sbyte[5] { 4, 4, 4, 4, 4 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 20000, 12000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 4, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 6),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 6),
			new IntPair(7, 42),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 9)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(169, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_169"), 14, 2, new sbyte[0], 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 1 }, 2, 5, 2, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_169_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_169_1")
		}, 600, 4, 2000, 900, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_169_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_169_1")
		}, canStroll: true, 340, new short[4] { 18, 20, 22, 24 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 9, 75),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", 405, 75),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 9, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 58), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 20),
			new PresetInventoryItem("SkillBook", 45, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 2),
			new PresetOrgMemberCombatSkill(198, 2),
			new PresetOrgMemberCombatSkill(312, 2),
			new PresetOrgMemberCombatSkill(391, 2)
		}, new sbyte[5] { 2, 2, 2, 2, 2 }, new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 15000, 4000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 3, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 6),
			new IntPair(7, 30),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 12)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(170, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_170"), 14, 1, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 1, 3, 1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_170_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_170_1")
		}, 300, 2, 1000, 300, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_170_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_170_1")
		}, canStroll: true, 341, new short[4] { 14, 15, 16, 17 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 58), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 20),
			new PresetInventoryItem("SkillBook", 45, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 1),
			new PresetOrgMemberCombatSkill(198, 1),
			new PresetOrgMemberCombatSkill(624, 1)
		}, new sbyte[5], new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 10000, 2000, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 2, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 6),
			new IntPair(7, 30),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 12)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(171, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_171"), 14, 0, new sbyte[0], 6, 9, 3, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1], 0, 2, 0, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_171_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_171_1")
		}, 150, 0, 500, 150, 0, new List<short> { 58, 59, 60, 81, 82 }, new List<short> { 24, 25, 26 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_171_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_171_1")
		}, canStroll: true, 342, new short[4] { 10, 10, 10, 10 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 270, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 135, 75),
			new PresetEquipmentItemWithProb("Accessory", 99, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 58), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 126, 1, 20),
			new PresetInventoryItem("SkillBook", 45, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 10),
			new PresetInventoryItem("Material", 21, 1, 10),
			new PresetInventoryItem("Misc", 82, 1, 30),
			new PresetInventoryItem("CraftTool", 36, 1, 20),
			new PresetInventoryItem("Food", 93, 3, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(97, 0),
			new PresetOrgMemberCombatSkill(198, 0),
			new PresetOrgMemberCombatSkill(521, 0)
		}, new sbyte[5], new short[8] { -60, -80, -60, -70, -70, -70, -70, -50 }, 5000, 1000, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, 12, 9, -1, -1, -1,
			-1, -1, 2, 2, 12, -1
		}, 1, new short[14]
		{
			12, 6, 12, 12, -1, -1, 6, -1, 12, -1,
			2, -1, -1, -1
		}, new short[6] { 12, -1, -1, 9, 9, -1 }, new List<sbyte> { 65 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 6),
			new IntPair(7, 30),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 36),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 12)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(172, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_172"), 15, 8, new sbyte[0], 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, new sbyte[1] { 5 }, 6, -1, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_172_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_172_1")
		}, 15800, 16, 13000, 30750, 0, new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 }, new List<short> { 21, 22, 23 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_172_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_172_1")
		}, canStroll: false, 343, new short[4] { 22, 28, 34, 40 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 63), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 30),
			new PresetInventoryItem("Misc", 9, 3, 40),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 20),
			new PresetInventoryItem("Medicine", 124, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 8),
			new PresetOrgMemberCombatSkill(204, 4),
			new PresetOrgMemberCombatSkill(320, 8),
			new PresetOrgMemberCombatSkill(400, 7),
			new PresetOrgMemberCombatSkill(471, 6),
			new PresetOrgMemberCombatSkill(495, 7),
			new PresetOrgMemberCombatSkill(527, 6)
		}, new sbyte[5] { 10, 10, 10, 10, 10 }, new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		}, 8, new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { 12, 12, 2, 9, -1, -1 }, new List<sbyte> { 23, 24, 25, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 42),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(173, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_173"), 15, 7, new sbyte[0], 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 0, 7, new sbyte[1] { 5 }, 6, 8, 7, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_173_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_173_1")
		}, 8600, 14, 10000, 21150, 0, new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 }, new List<short> { 21, 22, 23 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_173_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_173_1")
		}, canStroll: false, 344, new short[4] { 24, 31, 38, 45 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 62), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 30),
			new PresetInventoryItem("Misc", 9, 3, 40),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 20),
			new PresetInventoryItem("Medicine", 124, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 7),
			new PresetOrgMemberCombatSkill(204, 4),
			new PresetOrgMemberCombatSkill(320, 7),
			new PresetOrgMemberCombatSkill(400, 6),
			new PresetOrgMemberCombatSkill(471, 6),
			new PresetOrgMemberCombatSkill(495, 6),
			new PresetOrgMemberCombatSkill(527, 6)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		}, 8, new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { 12, 12, 2, 9, -1, -1 }, new List<sbyte> { 23, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 42),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		_dataArray.Add(new OrganizationMemberItem(174, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_174"), 15, 6, new sbyte[0], 12, 18, 6, restrictPrincipalAmount: false, -1, -1, 1, -1, new sbyte[1] { 4 }, 6, 8, 6, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_174_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_174_1")
		}, 6100, 12, 8000, 13800, 0, new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 }, new List<short> { 21, 22, 23 }, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_174_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_174_1")
		}, canStroll: false, 345, new short[4] { 26, 34, 42, 50 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", 62), new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 30),
			new PresetInventoryItem("Misc", 9, 3, 40),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 0, 1, 30),
			new PresetInventoryItem("Medicine", 27, 1, 30),
			new PresetInventoryItem("Medicine", 36, 1, 30),
			new PresetInventoryItem("Medicine", 60, 1, 20),
			new PresetInventoryItem("Medicine", 72, 1, 20),
			new PresetInventoryItem("Medicine", 88, 1, 20),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("Medicine", 340, 1, 20),
			new PresetInventoryItem("Medicine", 124, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		}, new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 6),
			new PresetOrgMemberCombatSkill(204, 3),
			new PresetOrgMemberCombatSkill(320, 6),
			new PresetOrgMemberCombatSkill(400, 6),
			new PresetOrgMemberCombatSkill(471, 5),
			new PresetOrgMemberCombatSkill(495, 6),
			new PresetOrgMemberCombatSkill(527, 5)
		}, new sbyte[5] { 8, 8, 8, 8, 8 }, new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		}, 7, new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { 12, 12, 2, 9, -1, -1 }, new List<sbyte> { 23, 24, 25 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 42),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		List<OrganizationMemberItem> dataArray13 = _dataArray;
		string config13 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_175");
		sbyte[] potentialSuccessorGrades13 = new sbyte[0];
		sbyte[] childGrade13 = new sbyte[1] { 3 };
		string[] monasticTitleSuffixes13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_175_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_175_1")
		};
		List<short> favoriteClothingIds13 = new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds13 = new List<short> { 21, 22, 23 };
		string[] spouseAnonymousTitles13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_175_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_175_1")
		};
		short[] initialAges13 = new short[4] { 20, 25, 30, 35 };
		PresetEquipmentItemWithProb[] equipment13 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing13 = new PresetEquipmentItem("Clothing", 62);
		List<PresetInventoryItem> inventory13 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 20),
			new PresetInventoryItem("Misc", 9, 3, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 10),
			new PresetInventoryItem("Medicine", 118, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills13 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 5),
			new PresetOrgMemberCombatSkill(204, 3),
			new PresetOrgMemberCombatSkill(320, 5),
			new PresetOrgMemberCombatSkill(495, 5),
			new PresetOrgMemberCombatSkill(527, 5)
		};
		sbyte[] extraCombatSkillGrids13 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust13 = new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 };
		short[] lifeSkillsAdjust13 = new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		};
		short[] combatSkillsAdjust13 = new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust13 = new short[6] { 12, 12, 2, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray13.Add(new OrganizationMemberItem(175, config13, 15, 5, potentialSuccessorGrades13, 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade13, 5, 7, 5, 0, 0, monasticTitleSuffixes13, 4200, 10, 6000, 8400, 0, favoriteClothingIds13, hatedClothingIds13, spouseAnonymousTitles13, canStroll: true, 346, initialAges13, equipment13, clothing13, inventory13, combatSkills13, extraCombatSkillGrids13, resourcesAdjust13, 40000, 48000, 10, 50, 16800, lifeSkillsAdjust13, 6, combatSkillsAdjust13, mainAttributesAdjust13, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 15),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		List<OrganizationMemberItem> dataArray14 = _dataArray;
		string config14 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_176");
		sbyte[] potentialSuccessorGrades14 = new sbyte[0];
		sbyte[] childGrade14 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_176_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_176_1")
		};
		List<short> favoriteClothingIds14 = new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds14 = new List<short> { 21, 22, 23 };
		string[] spouseAnonymousTitles14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_176_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_176_1")
		};
		short[] initialAges14 = new short[4] { 18, 22, 26, 30 };
		PresetEquipmentItemWithProb[] equipment14 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing14 = new PresetEquipmentItem("Clothing", 62);
		List<PresetInventoryItem> inventory14 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 20),
			new PresetInventoryItem("Misc", 9, 3, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 10),
			new PresetInventoryItem("Medicine", 118, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills14 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 4),
			new PresetOrgMemberCombatSkill(204, 3),
			new PresetOrgMemberCombatSkill(320, 4),
			new PresetOrgMemberCombatSkill(400, 4),
			new PresetOrgMemberCombatSkill(471, 4),
			new PresetOrgMemberCombatSkill(495, 4)
		};
		sbyte[] extraCombatSkillGrids14 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust14 = new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 };
		short[] lifeSkillsAdjust14 = new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		};
		short[] combatSkillsAdjust14 = new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust14 = new short[6] { 12, 12, 2, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray14.Add(new OrganizationMemberItem(176, config14, 15, 4, potentialSuccessorGrades14, 4, 6, 2, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade14, 4, 6, 4, 0, 0, monasticTitleSuffixes14, 2800, 8, 4500, 4650, 0, favoriteClothingIds14, hatedClothingIds14, spouseAnonymousTitles14, canStroll: true, 347, initialAges14, equipment14, clothing14, inventory14, combatSkills14, extraCombatSkillGrids14, resourcesAdjust14, 30000, 24000, 10, 60, 9300, lifeSkillsAdjust14, 5, combatSkillsAdjust14, mainAttributesAdjust14, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 15),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		List<OrganizationMemberItem> dataArray15 = _dataArray;
		string config15 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_177");
		sbyte[] potentialSuccessorGrades15 = new sbyte[0];
		sbyte[] childGrade15 = new sbyte[1] { 2 };
		string[] monasticTitleSuffixes15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_177_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_177_1")
		};
		List<short> favoriteClothingIds15 = new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds15 = new List<short> { 21, 22, 23 };
		string[] spouseAnonymousTitles15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_177_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_177_1")
		};
		short[] initialAges15 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment15 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", 90, 100),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing15 = new PresetEquipmentItem("Clothing", 61);
		List<PresetInventoryItem> inventory15 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 20),
			new PresetInventoryItem("Misc", 9, 3, 30),
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 30),
			new PresetInventoryItem("Food", 51, 3, 30),
			new PresetInventoryItem("Food", 135, 3, 30),
			new PresetInventoryItem("Medicine", 0, 1, 20),
			new PresetInventoryItem("Medicine", 27, 1, 20),
			new PresetInventoryItem("Medicine", 36, 1, 20),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Medicine", 334, 1, 10),
			new PresetInventoryItem("Medicine", 118, 1, 10),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills15 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 3),
			new PresetOrgMemberCombatSkill(204, 2),
			new PresetOrgMemberCombatSkill(320, 3),
			new PresetOrgMemberCombatSkill(471, 3),
			new PresetOrgMemberCombatSkill(527, 3)
		};
		sbyte[] extraCombatSkillGrids15 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust15 = new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 };
		short[] lifeSkillsAdjust15 = new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		};
		short[] combatSkillsAdjust15 = new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust15 = new short[6] { 12, 12, 2, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray15.Add(new OrganizationMemberItem(177, config15, 15, 3, potentialSuccessorGrades15, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade15, 3, 5, 3, 0, 0, monasticTitleSuffixes15, 1800, 6, 3000, 2250, 0, favoriteClothingIds15, hatedClothingIds15, spouseAnonymousTitles15, canStroll: true, 348, initialAges15, equipment15, clothing15, inventory15, combatSkills15, extraCombatSkillGrids15, resourcesAdjust15, 20000, 12000, 10, 70, 4500, lifeSkillsAdjust15, 4, combatSkillsAdjust15, mainAttributesAdjust15, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 15),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		List<OrganizationMemberItem> dataArray16 = _dataArray;
		string config16 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_178");
		sbyte[] potentialSuccessorGrades16 = new sbyte[0];
		sbyte[] childGrade16 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_178_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_178_1")
		};
		List<short> favoriteClothingIds16 = new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds16 = new List<short> { 21, 22, 23 };
		string[] spouseAnonymousTitles16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_178_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_178_1")
		};
		short[] initialAges16 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment16 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", 45, 75),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", 432, 75),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", 81, 50),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing16 = new PresetEquipmentItem("Clothing", 61);
		List<PresetInventoryItem> inventory16 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 10),
			new PresetInventoryItem("Misc", 9, 3, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10)
		};
		List<PresetOrgMemberCombatSkill> combatSkills16 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 2),
			new PresetOrgMemberCombatSkill(204, 2),
			new PresetOrgMemberCombatSkill(320, 2),
			new PresetOrgMemberCombatSkill(400, 2),
			new PresetOrgMemberCombatSkill(527, 2)
		};
		sbyte[] extraCombatSkillGrids16 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust16 = new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 };
		short[] lifeSkillsAdjust16 = new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		};
		short[] combatSkillsAdjust16 = new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust16 = new short[6] { 12, 12, 2, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray16.Add(new OrganizationMemberItem(178, config16, 15, 2, potentialSuccessorGrades16, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade16, 2, 4, 2, 0, 0, monasticTitleSuffixes16, 600, 4, 2000, 900, 0, favoriteClothingIds16, hatedClothingIds16, spouseAnonymousTitles16, canStroll: true, 349, initialAges16, equipment16, clothing16, inventory16, combatSkills16, extraCombatSkillGrids16, resourcesAdjust16, 15000, 4000, 5, 80, 1800, lifeSkillsAdjust16, 3, combatSkillsAdjust16, mainAttributesAdjust16, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		List<OrganizationMemberItem> dataArray17 = _dataArray;
		string config17 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_179");
		sbyte[] potentialSuccessorGrades17 = new sbyte[0];
		sbyte[] childGrade17 = new sbyte[1] { 1 };
		string[] monasticTitleSuffixes17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_179_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_179_1")
		};
		List<short> favoriteClothingIds17 = new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds17 = new List<short> { 21, 22, 23 };
		string[] spouseAnonymousTitles17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_179_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_179_1")
		};
		short[] initialAges17 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment17 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", 153, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 50),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", 90, 50),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing17 = new PresetEquipmentItem("Clothing", 61);
		List<PresetInventoryItem> inventory17 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 10),
			new PresetInventoryItem("Misc", 9, 3, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10)
		};
		List<PresetOrgMemberCombatSkill> combatSkills17 = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 1),
			new PresetOrgMemberCombatSkill(204, 1),
			new PresetOrgMemberCombatSkill(320, 1),
			new PresetOrgMemberCombatSkill(495, 1),
			new PresetOrgMemberCombatSkill(527, 1)
		};
		sbyte[] extraCombatSkillGrids17 = new sbyte[5];
		short[] resourcesAdjust17 = new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 };
		short[] lifeSkillsAdjust17 = new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		};
		short[] combatSkillsAdjust17 = new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust17 = new short[6] { 12, 12, 2, 9, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray17.Add(new OrganizationMemberItem(179, config17, 15, 1, potentialSuccessorGrades17, 12, 18, 6, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade17, 1, 3, 1, 0, 0, monasticTitleSuffixes17, 300, 2, 1000, 300, 0, favoriteClothingIds17, hatedClothingIds17, spouseAnonymousTitles17, canStroll: true, 350, initialAges17, equipment17, clothing17, inventory17, combatSkills17, extraCombatSkillGrids17, resourcesAdjust17, 10000, 2000, 5, 90, 600, lifeSkillsAdjust17, 2, combatSkillsAdjust17, mainAttributesAdjust17, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
	}

	private void CreateItems3()
	{
		List<OrganizationMemberItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_180");
		sbyte[] potentialSuccessorGrades = new sbyte[0];
		sbyte[] childGrade = new sbyte[1];
		string[] monasticTitleSuffixes = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_180_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_180_1")
		};
		List<short> favoriteClothingIds = new List<short> { 61, 62, 63, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds = new List<short> { 21, 22, 23 };
		string[] spouseAnonymousTitles = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_180_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_180_1")
		};
		short[] initialAges = new short[4] { 10, 10, 10, 10 };
		PresetEquipmentItemWithProb[] equipment = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 306, 100),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", 180, 75),
			new PresetEquipmentItemWithProb("Accessory", 117, 75),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing = new PresetEquipmentItem("Clothing", 61);
		List<PresetInventoryItem> inventory = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("SkillBook", 135, 1, 10),
			new PresetInventoryItem("Misc", 9, 3, 20),
			new PresetInventoryItem("CraftTool", 45, 1, 20),
			new PresetInventoryItem("Food", 9, 3, 20),
			new PresetInventoryItem("Food", 51, 3, 20),
			new PresetInventoryItem("Food", 135, 3, 20),
			new PresetInventoryItem("Medicine", 0, 1, 10),
			new PresetInventoryItem("Medicine", 27, 1, 10),
			new PresetInventoryItem("Medicine", 36, 1, 10)
		};
		List<PresetOrgMemberCombatSkill> combatSkills = new List<PresetOrgMemberCombatSkill>
		{
			new PresetOrgMemberCombatSkill(105, 0),
			new PresetOrgMemberCombatSkill(204, 0),
			new PresetOrgMemberCombatSkill(400, 0)
		};
		sbyte[] extraCombatSkillGrids = new sbyte[5];
		short[] resourcesAdjust = new short[8] { -70, -70, -70, -60, -80, -70, -60, -60 };
		short[] lifeSkillsAdjust = new short[16]
		{
			-1, -1, -1, -1, -1, 9, 2, 2, 9, 9,
			-1, -1, 9, -1, -1, 12
		};
		short[] combatSkillsAdjust = new short[14]
		{
			12, 6, 12, 12, 9, 12, 9, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust = new short[6] { 12, 12, 2, 9, -1, -1 };
		List<sbyte> identityInteractConfig = new List<sbyte>();
		dataArray.Add(new OrganizationMemberItem(180, config, 15, 0, potentialSuccessorGrades, 8, 12, 4, restrictPrincipalAmount: false, -1, -1, 1, -1, childGrade, 0, 2, 0, 0, 0, monasticTitleSuffixes, 150, 0, 500, 150, 0, favoriteClothingIds, hatedClothingIds, spouseAnonymousTitles, canStroll: true, 351, initialAges, equipment, clothing, inventory, combatSkills, extraCombatSkillGrids, resourcesAdjust, 5000, 1000, 1, 100, 300, lifeSkillsAdjust, 1, combatSkillsAdjust, mainAttributesAdjust, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 9),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 1),
			new IntPair(3, 15),
			new IntPair(13, 1),
			new IntPair(10, 1),
			new IntPair(2, 1),
			new IntPair(1, 3),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 42)
		}, null));
		List<OrganizationMemberItem> dataArray2 = _dataArray;
		string config2 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_181");
		sbyte[] potentialSuccessorGrades2 = new sbyte[0];
		sbyte[] childGrade2 = new sbyte[2] { 7, 6 };
		string[] monasticTitleSuffixes2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_181_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_181_1")
		};
		List<short> favoriteClothingIds2 = new List<short> { 7, 8, 16, 17 };
		List<short> hatedClothingIds2 = new List<short> { 0, 1, 2, 3, 9, 10, 11, 12 };
		string[] spouseAnonymousTitles2 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_181_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_181_1")
		};
		short[] initialAges2 = new short[4] { 28, 37, 46, 55 };
		PresetEquipmentItemWithProb[] equipment2 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing2 = new PresetEquipmentItem("Clothing", 17);
		List<PresetInventoryItem> inventory2 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 91, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		List<PresetOrgMemberCombatSkill> combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray2.Add(new OrganizationMemberItem(181, config2, -1, 8, potentialSuccessorGrades2, 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, childGrade2, 7, -1, 7, 0, 0, monasticTitleSuffixes2, 0, 0, 13000, 21150, -100, favoriteClothingIds2, hatedClothingIds2, spouseAnonymousTitles2, canStroll: false, -1, initialAges2, equipment2, clothing2, inventory2, combatSkills2, new sbyte[5], new short[8] { -60, -60, -60, -60, -60, -60, -60, -60 }, 160000, 576000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 0, 55 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 30),
			new IntPair(8, 30),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 9),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray3 = _dataArray;
		string config3 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_182");
		sbyte[] potentialSuccessorGrades3 = new sbyte[3] { 6, 5, 2 };
		sbyte[] childGrade3 = new sbyte[3] { 7, 6, 5 };
		string[] monasticTitleSuffixes3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_182_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_182_1")
		};
		List<short> favoriteClothingIds3 = new List<short> { 6, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds3 = new List<short> { 0, 1, 2, 9, 10, 11 };
		string[] spouseAnonymousTitles3 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_182_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_182_1")
		};
		short[] initialAges3 = new short[4] { 26, 34, 42, 50 };
		PresetEquipmentItemWithProb[] equipment3 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing3 = new PresetEquipmentItem("Clothing", 8);
		List<PresetInventoryItem> inventory3 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray3.Add(new OrganizationMemberItem(182, config3, -1, 7, potentialSuccessorGrades3, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade3, 7, -1, 7, 0, 0, monasticTitleSuffixes3, 0, 0, 10000, 13800, -100, favoriteClothingIds3, hatedClothingIds3, spouseAnonymousTitles3, canStroll: false, -1, initialAges3, equipment3, clothing3, inventory3, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -50 }, 100000, 288000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 52, 56 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 24),
			new IntPair(8, 24),
			new IntPair(5, 3),
			new IntPair(6, 3),
			new IntPair(15, 9),
			new IntPair(16, 9),
			new IntPair(7, 9),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray4 = _dataArray;
		string config4 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_183");
		sbyte[] potentialSuccessorGrades4 = new sbyte[2] { 5, 2 };
		sbyte[] childGrade4 = new sbyte[3] { 6, 5, 4 };
		string[] monasticTitleSuffixes4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_183_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_183_1")
		};
		List<short> favoriteClothingIds4 = new List<short> { 5, 6, 7, 8, 14, 15, 16, 17 };
		List<short> hatedClothingIds4 = new List<short> { 0, 1, 9, 10 };
		string[] spouseAnonymousTitles4 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_183_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_183_1")
		};
		short[] initialAges4 = new short[4] { 24, 31, 38, 45 };
		PresetEquipmentItemWithProb[] equipment4 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing4 = new PresetEquipmentItem("Clothing", 16);
		List<PresetInventoryItem> inventory4 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray4.Add(new OrganizationMemberItem(183, config4, -1, 6, potentialSuccessorGrades4, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade4, 6, -1, 6, 0, 0, monasticTitleSuffixes4, 0, 0, 8000, 8400, -100, favoriteClothingIds4, hatedClothingIds4, spouseAnonymousTitles4, canStroll: false, -1, initialAges4, equipment4, clothing4, inventory4, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -50, -70 }, 60000, 144000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 2, 57 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 21),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 15),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray5 = _dataArray;
		string config5 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_184");
		sbyte[] potentialSuccessorGrades5 = new sbyte[2] { 2, 1 };
		sbyte[] childGrade5 = new sbyte[3] { 5, 4, 3 };
		string[] monasticTitleSuffixes5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_184_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_184_1")
		};
		List<short> favoriteClothingIds5 = new List<short> { 4 };
		List<short> list = new List<short>();
		List<short> hatedClothingIds5 = list;
		string[] spouseAnonymousTitles5 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_184_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_184_1")
		};
		short[] initialAges5 = new short[4] { 22, 28, 34, 40 };
		PresetEquipmentItemWithProb[] equipment5 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing5 = new PresetEquipmentItem("Clothing", 4);
		List<PresetInventoryItem> inventory5 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray5.Add(new OrganizationMemberItem(184, config5, -1, 5, potentialSuccessorGrades5, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade5, 5, -1, 5, 0, 0, monasticTitleSuffixes5, 0, 0, 6000, 4650, -75, favoriteClothingIds5, hatedClothingIds5, spouseAnonymousTitles5, canStroll: true, -1, initialAges5, equipment5, clothing5, inventory5, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -80, -50 }, 40000, 48000, 10, 50, 16800, new short[16]
		{
			12, 12, 12, 12, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 3, 58, 66 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 6),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 30),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray6 = _dataArray;
		string config6 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_185");
		sbyte[] potentialSuccessorGrades6 = new sbyte[3] { 2, 1, 0 };
		sbyte[] childGrade6 = new sbyte[3] { 4, 3, 2 };
		string[] monasticTitleSuffixes6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_185_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_185_1")
		};
		List<short> favoriteClothingIds6 = new List<short> { 15 };
		list = new List<short>();
		List<short> hatedClothingIds6 = list;
		string[] spouseAnonymousTitles6 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_185_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_185_1")
		};
		short[] initialAges6 = new short[4] { 20, 25, 30, 35 };
		PresetEquipmentItemWithProb[] equipment6 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing6 = new PresetEquipmentItem("Clothing", 15);
		List<PresetInventoryItem> inventory6 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray6.Add(new OrganizationMemberItem(185, config6, -1, 4, potentialSuccessorGrades6, 4, 4, 4, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade6, 4, -1, 4, 0, 0, monasticTitleSuffixes6, 0, 0, 4500, 2250, -50, favoriteClothingIds6, hatedClothingIds6, spouseAnonymousTitles6, canStroll: true, -1, initialAges6, equipment6, clothing6, inventory6, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -50, -80 }, 30000, 24000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 9
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 4, 53 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 30),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray7 = _dataArray;
		string config7 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_186");
		sbyte[] potentialSuccessorGrades7 = new sbyte[0];
		sbyte[] childGrade7 = new sbyte[3] { 3, 2, 1 };
		string[] monasticTitleSuffixes7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_186_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_186_1")
		};
		List<short> favoriteClothingIds7 = new List<short> { 13 };
		list = new List<short>();
		List<short> hatedClothingIds7 = list;
		string[] spouseAnonymousTitles7 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_186_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_186_1")
		};
		short[] initialAges7 = new short[4] { 18, 22, 26, 30 };
		PresetEquipmentItemWithProb[] equipment7 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing7 = new PresetEquipmentItem("Clothing", 13);
		List<PresetInventoryItem> inventory7 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray7.Add(new OrganizationMemberItem(186, config7, -1, 3, potentialSuccessorGrades7, 4, 4, 4, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade7, 3, -1, 3, 0, 0, monasticTitleSuffixes7, 0, 0, 3000, 900, -25, favoriteClothingIds7, hatedClothingIds7, spouseAnonymousTitles7, canStroll: true, -1, initialAges7, equipment7, clothing7, inventory7, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -50, -80, -80 }, 20000, 12000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 12, 12,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 5, 54, 64 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 9),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray8 = _dataArray;
		string config8 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_187");
		sbyte[] potentialSuccessorGrades8 = new sbyte[0];
		sbyte[] childGrade8 = new sbyte[3] { 2, 1, 0 };
		string[] monasticTitleSuffixes8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_187_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_187_1")
		};
		List<short> favoriteClothingIds8 = new List<short> { 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds8 = new List<short> { 7, 8, 16, 17 };
		string[] spouseAnonymousTitles8 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_187_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_187_1")
		};
		short[] initialAges8 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment8 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing8 = new PresetEquipmentItem("Clothing", 11);
		List<PresetInventoryItem> inventory8 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray8.Add(new OrganizationMemberItem(187, config8, -1, 2, potentialSuccessorGrades8, 4, 4, 4, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade8, 2, -1, 2, 0, 0, monasticTitleSuffixes8, 0, 0, 2000, 300, 0, favoriteClothingIds8, hatedClothingIds8, spouseAnonymousTitles8, canStroll: true, -1, initialAges8, equipment8, clothing8, inventory8, combatSkills2, new sbyte[5], new short[8] { -90, -50, -50, -50, -50, -90, -90, -90 }, 15000, 4000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, -1, -1,
			12, 12, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 6, 61, 63 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 9),
			new IntPair(16, 3),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 15),
			new IntPair(2, 30),
			new IntPair(1, 9),
			new IntPair(11, 15),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray9 = _dataArray;
		string config9 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_188");
		sbyte[] potentialSuccessorGrades9 = new sbyte[0];
		sbyte[] childGrade9 = new sbyte[2] { 1, 0 };
		string[] monasticTitleSuffixes9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_188_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_188_1")
		};
		List<short> favoriteClothingIds9 = new List<short> { 0, 1, 9, 10 };
		List<short> hatedClothingIds9 = new List<short> { 6, 7, 8, 15, 16, 17 };
		string[] spouseAnonymousTitles9 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_188_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_188_1")
		};
		short[] initialAges9 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment9 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing9 = new PresetEquipmentItem("Clothing", 10);
		List<PresetInventoryItem> inventory9 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray9.Add(new OrganizationMemberItem(188, config9, -1, 1, potentialSuccessorGrades9, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade9, 1, -1, 1, 0, 0, monasticTitleSuffixes9, 0, 0, 1000, 150, 0, favoriteClothingIds9, hatedClothingIds9, spouseAnonymousTitles9, canStroll: true, -1, initialAges9, equipment9, clothing9, inventory9, combatSkills2, new sbyte[5], new short[8] { -50, -90, -90, -90, -90, -90, -90, -90 }, 10000, 2000, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, 12, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 7, 60 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 30),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 18)
		}, null));
		List<OrganizationMemberItem> dataArray10 = _dataArray;
		string config10 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_189");
		sbyte[] potentialSuccessorGrades10 = new sbyte[0];
		sbyte[] childGrade10 = new sbyte[1];
		string[] monasticTitleSuffixes10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_189_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_189_1")
		};
		List<short> favoriteClothingIds10 = new List<short> { 0, 9 };
		List<short> hatedClothingIds10 = new List<short> { 5, 6, 7, 8, 14, 15, 16, 17 };
		string[] spouseAnonymousTitles10 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_189_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_189_1")
		};
		short[] initialAges10 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment10 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing10 = new PresetEquipmentItem("Clothing", 9);
		List<PresetInventoryItem> inventory10 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 19, 1, 10),
			new PresetInventoryItem("Misc", 20, 1, 10),
			new PresetInventoryItem("Misc", 21, 1, 10),
			new PresetInventoryItem("Misc", 22, 1, 10),
			new PresetInventoryItem("Misc", 23, 1, 10),
			new PresetInventoryItem("Misc", 24, 1, 10),
			new PresetInventoryItem("Misc", 25, 1, 10),
			new PresetInventoryItem("Misc", 26, 1, 10),
			new PresetInventoryItem("Misc", 27, 1, 10),
			new PresetInventoryItem("Misc", 28, 1, 10),
			new PresetInventoryItem("Misc", 29, 1, 10),
			new PresetInventoryItem("Misc", 30, 1, 10),
			new PresetInventoryItem("Misc", 31, 1, 10),
			new PresetInventoryItem("Misc", 32, 1, 10),
			new PresetInventoryItem("Misc", 33, 1, 10),
			new PresetInventoryItem("Misc", 34, 1, 10),
			new PresetInventoryItem("Misc", 35, 1, 10),
			new PresetInventoryItem("Misc", 36, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray10.Add(new OrganizationMemberItem(189, config10, -1, 0, potentialSuccessorGrades10, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade10, 0, -1, 0, 0, 0, monasticTitleSuffixes10, 0, 0, 500, 0, 0, favoriteClothingIds10, hatedClothingIds10, spouseAnonymousTitles10, canStroll: true, -1, initialAges10, equipment10, clothing10, inventory10, combatSkills2, new sbyte[5], new short[8] { -90, -90, -90, -90, -90, -90, -90, -90 }, 5000, 1000, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 12
		}, 3, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 8, 44 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 27),
			new IntPair(2, 6),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 30)
		}, null));
		List<OrganizationMemberItem> dataArray11 = _dataArray;
		string config11 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_190");
		sbyte[] potentialSuccessorGrades11 = new sbyte[0];
		sbyte[] childGrade11 = new sbyte[2] { 7, 6 };
		string[] monasticTitleSuffixes11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_190_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_190_1")
		};
		List<short> favoriteClothingIds11 = new List<short> { 6, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds11 = new List<short> { 0, 1, 9, 10 };
		string[] spouseAnonymousTitles11 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_190_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_190_1")
		};
		short[] initialAges11 = new short[4] { 28, 37, 46, 55 };
		PresetEquipmentItemWithProb[] equipment11 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing11 = new PresetEquipmentItem("Clothing", 13);
		List<PresetInventoryItem> inventory11 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 91, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray11.Add(new OrganizationMemberItem(190, config11, 36, 8, potentialSuccessorGrades11, 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, childGrade11, 7, -1, 7, 0, 0, monasticTitleSuffixes11, 0, 0, 13000, 21150, -100, favoriteClothingIds11, hatedClothingIds11, spouseAnonymousTitles11, canStroll: false, -1, initialAges11, equipment11, clothing11, inventory11, combatSkills2, new sbyte[5], new short[8] { -60, -60, -60, -60, -60, -60, -60, -60 }, 80000, 288000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 0 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 18),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 3),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray12 = _dataArray;
		string config12 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_191");
		sbyte[] potentialSuccessorGrades12 = new sbyte[3] { 6, 5, 2 };
		sbyte[] childGrade12 = new sbyte[3] { 7, 6, 5 };
		string[] monasticTitleSuffixes12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_191_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_191_1")
		};
		List<short> favoriteClothingIds12 = new List<short> { 5, 6, 7, 8, 14, 15, 16, 17 };
		List<short> hatedClothingIds12 = new List<short> { 0, 9 };
		string[] spouseAnonymousTitles12 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_191_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_191_1")
		};
		short[] initialAges12 = new short[4] { 26, 34, 42, 50 };
		PresetEquipmentItemWithProb[] equipment12 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing12 = new PresetEquipmentItem("Clothing", 4);
		List<PresetInventoryItem> inventory12 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray12.Add(new OrganizationMemberItem(191, config12, 36, 7, potentialSuccessorGrades12, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade12, 7, -1, 7, 0, 0, monasticTitleSuffixes12, 0, 0, 10000, 13800, -100, favoriteClothingIds12, hatedClothingIds12, spouseAnonymousTitles12, canStroll: false, -1, initialAges12, equipment12, clothing12, inventory12, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -50 }, 50000, 144000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 52, 56 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 15),
			new IntPair(8, 15),
			new IntPair(5, 3),
			new IntPair(6, 3),
			new IntPair(15, 9),
			new IntPair(16, 12),
			new IntPair(7, 12),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 3),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray13 = _dataArray;
		string config13 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_192");
		sbyte[] potentialSuccessorGrades13 = new sbyte[2] { 5, 2 };
		sbyte[] childGrade13 = new sbyte[3] { 6, 5, 4 };
		string[] monasticTitleSuffixes13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_192_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_192_1")
		};
		List<short> favoriteClothingIds13 = new List<short> { 4, 5, 6, 7, 8, 13, 14, 15, 16, 17 };
		list = new List<short>();
		List<short> hatedClothingIds13 = list;
		string[] spouseAnonymousTitles13 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_192_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_192_1")
		};
		short[] initialAges13 = new short[4] { 24, 31, 38, 45 };
		PresetEquipmentItemWithProb[] equipment13 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing13 = new PresetEquipmentItem("Clothing", 13);
		List<PresetInventoryItem> inventory13 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray13.Add(new OrganizationMemberItem(192, config13, 36, 6, potentialSuccessorGrades13, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade13, 6, -1, 6, 0, 0, monasticTitleSuffixes13, 0, 0, 8000, 8400, -100, favoriteClothingIds13, hatedClothingIds13, spouseAnonymousTitles13, canStroll: false, -1, initialAges13, equipment13, clothing13, inventory13, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -50, -70 }, 30000, 72000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 2, 57 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 12),
			new IntPair(8, 12),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 15),
			new IntPair(16, 18),
			new IntPair(7, 18),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 6),
			new IntPair(11, 3),
			new IntPair(0, 3),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray14 = _dataArray;
		string config14 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_193");
		sbyte[] potentialSuccessorGrades14 = new sbyte[2] { 2, 1 };
		sbyte[] childGrade14 = new sbyte[3] { 5, 4, 3 };
		string[] monasticTitleSuffixes14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_193_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_193_1")
		};
		List<short> favoriteClothingIds14 = new List<short> { 4 };
		list = new List<short>();
		List<short> hatedClothingIds14 = list;
		string[] spouseAnonymousTitles14 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_193_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_193_1")
		};
		short[] initialAges14 = new short[4] { 22, 28, 34, 40 };
		PresetEquipmentItemWithProb[] equipment14 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing14 = new PresetEquipmentItem("Clothing", 10);
		List<PresetInventoryItem> inventory14 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray14.Add(new OrganizationMemberItem(193, config14, 36, 5, potentialSuccessorGrades14, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade14, 5, -1, 5, 0, 0, monasticTitleSuffixes14, 0, 0, 6000, 4650, -75, favoriteClothingIds14, hatedClothingIds14, spouseAnonymousTitles14, canStroll: true, -1, initialAges14, equipment14, clothing14, inventory14, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -80, -50 }, 10000, 24000, 10, 50, 16800, new short[16]
		{
			12, 12, 12, 12, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 3, 58, 66 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 6),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 30),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, new sbyte[1] { 5 }));
		List<OrganizationMemberItem> dataArray15 = _dataArray;
		string config15 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_194");
		sbyte[] potentialSuccessorGrades15 = new sbyte[3] { 2, 1, 0 };
		sbyte[] childGrade15 = new sbyte[3] { 4, 3, 2 };
		string[] monasticTitleSuffixes15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_194_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_194_1")
		};
		List<short> favoriteClothingIds15 = new List<short> { 15 };
		list = new List<short>();
		List<short> hatedClothingIds15 = list;
		string[] spouseAnonymousTitles15 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_194_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_194_1")
		};
		short[] initialAges15 = new short[4] { 20, 25, 30, 35 };
		PresetEquipmentItemWithProb[] equipment15 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing15 = new PresetEquipmentItem("Clothing", 11);
		List<PresetInventoryItem> inventory15 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray15.Add(new OrganizationMemberItem(194, config15, 36, 4, potentialSuccessorGrades15, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade15, 4, -1, 4, 0, 0, monasticTitleSuffixes15, 0, 0, 4500, 2250, -50, favoriteClothingIds15, hatedClothingIds15, spouseAnonymousTitles15, canStroll: true, -1, initialAges15, equipment15, clothing15, inventory15, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -50, -80 }, 20000, 12000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 9
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 4, 53 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 30),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray16 = _dataArray;
		string config16 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_195");
		sbyte[] potentialSuccessorGrades16 = new sbyte[0];
		sbyte[] childGrade16 = new sbyte[3] { 3, 2, 1 };
		string[] monasticTitleSuffixes16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_195_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_195_1")
		};
		List<short> favoriteClothingIds16 = new List<short> { 13 };
		list = new List<short>();
		List<short> hatedClothingIds16 = list;
		string[] spouseAnonymousTitles16 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_195_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_195_1")
		};
		short[] initialAges16 = new short[4] { 18, 22, 26, 30 };
		PresetEquipmentItemWithProb[] equipment16 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing16 = new PresetEquipmentItem("Clothing", 10);
		List<PresetInventoryItem> inventory16 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray16.Add(new OrganizationMemberItem(195, config16, 36, 3, potentialSuccessorGrades16, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade16, 3, -1, 3, 0, 0, monasticTitleSuffixes16, 0, 0, 3000, 900, -25, favoriteClothingIds16, hatedClothingIds16, spouseAnonymousTitles16, canStroll: true, -1, initialAges16, equipment16, clothing16, inventory16, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -50, -80, -80 }, 15000, 6000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 12, 12,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 5, 54, 64 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 9),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, new sbyte[2] { 8, 9 }));
		List<OrganizationMemberItem> dataArray17 = _dataArray;
		string config17 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_196");
		sbyte[] potentialSuccessorGrades17 = new sbyte[0];
		sbyte[] childGrade17 = new sbyte[3] { 2, 1, 0 };
		string[] monasticTitleSuffixes17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_196_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_196_1")
		};
		List<short> favoriteClothingIds17 = new List<short> { 0, 1, 2, 3, 9, 10, 11, 12 };
		list = new List<short>();
		List<short> hatedClothingIds17 = list;
		string[] spouseAnonymousTitles17 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_196_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_196_1")
		};
		short[] initialAges17 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment17 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing17 = new PresetEquipmentItem("Clothing", 1);
		List<PresetInventoryItem> inventory17 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray17.Add(new OrganizationMemberItem(196, config17, 36, 2, potentialSuccessorGrades17, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade17, 2, -1, 2, 0, 0, monasticTitleSuffixes17, 0, 0, 2000, 300, 0, favoriteClothingIds17, hatedClothingIds17, spouseAnonymousTitles17, canStroll: true, -1, initialAges17, equipment17, clothing17, inventory17, combatSkills2, new sbyte[5], new short[8] { -90, -50, -50, -50, -50, -90, -90, -90 }, 7500, 2000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, -1, -1,
			12, 12, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 6, 61, 63 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 18),
			new IntPair(2, 30),
			new IntPair(1, 9),
			new IntPair(11, 15),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, new sbyte[4] { 6, 7, 10, 11 }));
		List<OrganizationMemberItem> dataArray18 = _dataArray;
		string config18 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_197");
		sbyte[] potentialSuccessorGrades18 = new sbyte[0];
		sbyte[] childGrade18 = new sbyte[2] { 1, 0 };
		string[] monasticTitleSuffixes18 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_197_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_197_1")
		};
		List<short> favoriteClothingIds18 = new List<short> { 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds18 = new List<short> { 8, 17 };
		string[] spouseAnonymousTitles18 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_197_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_197_1")
		};
		short[] initialAges18 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment18 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing18 = new PresetEquipmentItem("Clothing", 0);
		List<PresetInventoryItem> inventory18 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray18.Add(new OrganizationMemberItem(197, config18, 36, 1, potentialSuccessorGrades18, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade18, 1, -1, 1, 0, 0, monasticTitleSuffixes18, 0, 0, 1000, 150, 0, favoriteClothingIds18, hatedClothingIds18, spouseAnonymousTitles18, canStroll: true, -1, initialAges18, equipment18, clothing18, inventory18, combatSkills2, new sbyte[5], new short[8] { -50, -90, -90, -90, -90, -90, -90, -90 }, 5000, 1000, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, 12, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 59, 62, 65 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 1),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 18),
			new IntPair(2, 6),
			new IntPair(1, 15),
			new IntPair(11, 15),
			new IntPair(0, 30),
			new IntPair(9, 6)
		}, new sbyte[1] { 14 }));
		List<OrganizationMemberItem> dataArray19 = _dataArray;
		string config19 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_198");
		sbyte[] potentialSuccessorGrades19 = new sbyte[0];
		sbyte[] childGrade19 = new sbyte[1];
		string[] monasticTitleSuffixes19 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_198_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_198_1")
		};
		List<short> favoriteClothingIds19 = new List<short> { 0, 1, 9, 10 };
		List<short> hatedClothingIds19 = new List<short> { 7, 8, 16, 17 };
		string[] spouseAnonymousTitles19 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_198_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_198_1")
		};
		short[] initialAges19 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment19 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing19 = new PresetEquipmentItem("Clothing", 9);
		List<PresetInventoryItem> inventory19 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 19, 1, 10),
			new PresetInventoryItem("Misc", 20, 1, 10),
			new PresetInventoryItem("Misc", 21, 1, 10),
			new PresetInventoryItem("Misc", 22, 1, 10),
			new PresetInventoryItem("Misc", 23, 1, 10),
			new PresetInventoryItem("Misc", 24, 1, 10),
			new PresetInventoryItem("Misc", 25, 1, 10),
			new PresetInventoryItem("Misc", 26, 1, 10),
			new PresetInventoryItem("Misc", 27, 1, 10),
			new PresetInventoryItem("Misc", 28, 1, 10),
			new PresetInventoryItem("Misc", 29, 1, 10),
			new PresetInventoryItem("Misc", 30, 1, 10),
			new PresetInventoryItem("Misc", 31, 1, 10),
			new PresetInventoryItem("Misc", 32, 1, 10),
			new PresetInventoryItem("Misc", 33, 1, 10),
			new PresetInventoryItem("Misc", 34, 1, 10),
			new PresetInventoryItem("Misc", 35, 1, 10),
			new PresetInventoryItem("Misc", 36, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray19.Add(new OrganizationMemberItem(198, config19, 36, 0, potentialSuccessorGrades19, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade19, 0, -1, 0, 0, 0, monasticTitleSuffixes19, 0, 0, 500, 0, 0, favoriteClothingIds19, hatedClothingIds19, spouseAnonymousTitles19, canStroll: true, -1, initialAges19, equipment19, clothing19, inventory19, combatSkills2, new sbyte[5], new short[8] { -90, -90, -90, -90, -90, -90, -90, -90 }, 500, 500, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 12
		}, 3, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 8, 44 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 27),
			new IntPair(2, 6),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 30)
		}, null));
		List<OrganizationMemberItem> dataArray20 = _dataArray;
		string config20 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_199");
		sbyte[] potentialSuccessorGrades20 = new sbyte[0];
		sbyte[] childGrade20 = new sbyte[2] { 7, 6 };
		string[] monasticTitleSuffixes20 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_199_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_199_1")
		};
		List<short> favoriteClothingIds20 = new List<short> { 6, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds20 = new List<short> { 0, 1, 2, 9, 10, 11 };
		string[] spouseAnonymousTitles20 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_199_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_199_1")
		};
		short[] initialAges20 = new short[4] { 28, 37, 46, 55 };
		PresetEquipmentItemWithProb[] equipment20 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing20 = new PresetEquipmentItem("Clothing", 16);
		List<PresetInventoryItem> inventory20 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 91, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray20.Add(new OrganizationMemberItem(199, config20, 37, 8, potentialSuccessorGrades20, 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, childGrade20, 7, -1, 7, 0, 0, monasticTitleSuffixes20, 0, 0, 13000, 21150, -100, favoriteClothingIds20, hatedClothingIds20, spouseAnonymousTitles20, canStroll: false, -1, initialAges20, equipment20, clothing20, inventory20, combatSkills2, new sbyte[5], new short[8] { -60, -60, -60, -60, -60, -60, -60, -60 }, 120000, 432000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 0 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 24),
			new IntPair(8, 24),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray21 = _dataArray;
		string config21 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_200");
		sbyte[] potentialSuccessorGrades21 = new sbyte[3] { 6, 5, 2 };
		sbyte[] childGrade21 = new sbyte[3] { 7, 6, 5 };
		string[] monasticTitleSuffixes21 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_200_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_200_1")
		};
		List<short> favoriteClothingIds21 = new List<short> { 5, 6, 7, 8, 14, 15, 16, 17 };
		List<short> hatedClothingIds21 = new List<short> { 0, 1, 9, 10 };
		string[] spouseAnonymousTitles21 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_200_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_200_1")
		};
		short[] initialAges21 = new short[4] { 26, 34, 42, 50 };
		PresetEquipmentItemWithProb[] equipment21 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing21 = new PresetEquipmentItem("Clothing", 16);
		List<PresetInventoryItem> inventory21 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray21.Add(new OrganizationMemberItem(200, config21, 37, 7, potentialSuccessorGrades21, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade21, 7, -1, 7, 0, 0, monasticTitleSuffixes21, 0, 0, 10000, 13800, -100, favoriteClothingIds21, hatedClothingIds21, spouseAnonymousTitles21, canStroll: false, -1, initialAges21, equipment21, clothing21, inventory21, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -50 }, 75000, 216000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 52, 56 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 21),
			new IntPair(8, 21),
			new IntPair(5, 3),
			new IntPair(6, 3),
			new IntPair(15, 9),
			new IntPair(16, 12),
			new IntPair(7, 12),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray22 = _dataArray;
		string config22 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_201");
		sbyte[] potentialSuccessorGrades22 = new sbyte[2] { 5, 2 };
		sbyte[] childGrade22 = new sbyte[3] { 6, 5, 4 };
		string[] monasticTitleSuffixes22 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_201_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_201_1")
		};
		List<short> favoriteClothingIds22 = new List<short> { 4, 5, 6, 7, 8, 13, 14, 15, 16, 17 };
		List<short> hatedClothingIds22 = new List<short> { 0, 9 };
		string[] spouseAnonymousTitles22 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_201_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_201_1")
		};
		short[] initialAges22 = new short[4] { 24, 31, 38, 45 };
		PresetEquipmentItemWithProb[] equipment22 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing22 = new PresetEquipmentItem("Clothing", 15);
		List<PresetInventoryItem> inventory22 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray22.Add(new OrganizationMemberItem(201, config22, 37, 6, potentialSuccessorGrades22, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade22, 6, -1, 6, 0, 0, monasticTitleSuffixes22, 0, 0, 8000, 8400, -100, favoriteClothingIds22, hatedClothingIds22, spouseAnonymousTitles22, canStroll: false, -1, initialAges22, equipment22, clothing22, inventory22, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -50, -70 }, 45000, 108000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 2, 57 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 18),
			new IntPair(8, 18),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 15),
			new IntPair(16, 18),
			new IntPair(7, 18),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 1),
			new IntPair(0, 1),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray23 = _dataArray;
		string config23 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_202");
		sbyte[] potentialSuccessorGrades23 = new sbyte[2] { 2, 1 };
		sbyte[] childGrade23 = new sbyte[3] { 5, 4, 3 };
		string[] monasticTitleSuffixes23 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_202_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_202_1")
		};
		List<short> favoriteClothingIds23 = new List<short> { 4 };
		list = new List<short>();
		List<short> hatedClothingIds23 = list;
		string[] spouseAnonymousTitles23 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_202_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_202_1")
		};
		short[] initialAges23 = new short[4] { 22, 28, 34, 40 };
		PresetEquipmentItemWithProb[] equipment23 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing23 = new PresetEquipmentItem("Clothing", 4);
		List<PresetInventoryItem> inventory23 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray23.Add(new OrganizationMemberItem(202, config23, 37, 5, potentialSuccessorGrades23, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade23, 5, -1, 5, 0, 0, monasticTitleSuffixes23, 0, 0, 6000, 4650, -75, favoriteClothingIds23, hatedClothingIds23, spouseAnonymousTitles23, canStroll: true, -1, initialAges23, equipment23, clothing23, inventory23, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -80, -50 }, 30000, 36000, 10, 50, 16800, new short[16]
		{
			12, 12, 12, 12, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 3, 58, 66 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 6),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 30),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray24 = _dataArray;
		string config24 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_203");
		sbyte[] potentialSuccessorGrades24 = new sbyte[3] { 2, 1, 0 };
		sbyte[] childGrade24 = new sbyte[3] { 4, 3, 2 };
		string[] monasticTitleSuffixes24 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_203_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_203_1")
		};
		List<short> favoriteClothingIds24 = new List<short> { 15 };
		list = new List<short>();
		List<short> hatedClothingIds24 = list;
		string[] spouseAnonymousTitles24 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_203_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_203_1")
		};
		short[] initialAges24 = new short[4] { 20, 25, 30, 35 };
		PresetEquipmentItemWithProb[] equipment24 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing24 = new PresetEquipmentItem("Clothing", 15);
		List<PresetInventoryItem> inventory24 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray24.Add(new OrganizationMemberItem(203, config24, 37, 4, potentialSuccessorGrades24, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade24, 4, -1, 4, 0, 0, monasticTitleSuffixes24, 0, 0, 4500, 2250, -50, favoriteClothingIds24, hatedClothingIds24, spouseAnonymousTitles24, canStroll: true, -1, initialAges24, equipment24, clothing24, inventory24, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -50, -80 }, 22500, 18000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 9
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 4, 53 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 30),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 9),
			new IntPair(2, 3),
			new IntPair(1, 3),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray25 = _dataArray;
		string config25 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_204");
		sbyte[] potentialSuccessorGrades25 = new sbyte[0];
		sbyte[] childGrade25 = new sbyte[3] { 3, 2, 1 };
		string[] monasticTitleSuffixes25 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_204_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_204_1")
		};
		List<short> favoriteClothingIds25 = new List<short> { 13 };
		list = new List<short>();
		List<short> hatedClothingIds25 = list;
		string[] spouseAnonymousTitles25 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_204_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_204_1")
		};
		short[] initialAges25 = new short[4] { 18, 22, 26, 30 };
		PresetEquipmentItemWithProb[] equipment25 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing25 = new PresetEquipmentItem("Clothing", 13);
		List<PresetInventoryItem> inventory25 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray25.Add(new OrganizationMemberItem(204, config25, 37, 3, potentialSuccessorGrades25, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade25, 3, -1, 3, 0, 0, monasticTitleSuffixes25, 0, 0, 3000, 900, -25, favoriteClothingIds25, hatedClothingIds25, spouseAnonymousTitles25, canStroll: true, -1, initialAges25, equipment25, clothing25, inventory25, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -50, -80, -80 }, 15000, 9000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 12, 12,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 5, 54, 64 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 9),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray26 = _dataArray;
		string config26 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_205");
		sbyte[] potentialSuccessorGrades26 = new sbyte[0];
		sbyte[] childGrade26 = new sbyte[3] { 2, 1, 0 };
		string[] monasticTitleSuffixes26 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_205_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_205_1")
		};
		List<short> favoriteClothingIds26 = new List<short> { 0, 1, 2, 3, 9, 10, 11, 12 };
		List<short> hatedClothingIds26 = new List<short> { 8, 17 };
		string[] spouseAnonymousTitles26 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_205_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_205_1")
		};
		short[] initialAges26 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment26 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 0, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing26 = new PresetEquipmentItem("Clothing", 11);
		List<PresetInventoryItem> inventory26 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray26.Add(new OrganizationMemberItem(205, config26, 37, 2, potentialSuccessorGrades26, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade26, 2, -1, 2, 0, 0, monasticTitleSuffixes26, 0, 0, 2000, 300, 0, favoriteClothingIds26, hatedClothingIds26, spouseAnonymousTitles26, canStroll: true, -1, initialAges26, equipment26, clothing26, inventory26, combatSkills2, new sbyte[5], new short[8] { -90, -50, -50, -50, -50, -90, -90, -90 }, 11250, 3000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, -1, -1,
			12, 12, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 6, 61, 63 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 9),
			new IntPair(16, 3),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 15),
			new IntPair(2, 30),
			new IntPair(1, 9),
			new IntPair(11, 15),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray27 = _dataArray;
		string config27 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_206");
		sbyte[] potentialSuccessorGrades27 = new sbyte[0];
		sbyte[] childGrade27 = new sbyte[2] { 1, 0 };
		string[] monasticTitleSuffixes27 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_206_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_206_1")
		};
		List<short> favoriteClothingIds27 = new List<short> { 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds27 = new List<short> { 7, 8, 16, 17 };
		string[] spouseAnonymousTitles27 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_206_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_206_1")
		};
		short[] initialAges27 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment27 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing27 = new PresetEquipmentItem("Clothing", 10);
		List<PresetInventoryItem> inventory27 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray27.Add(new OrganizationMemberItem(206, config27, 37, 1, potentialSuccessorGrades27, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade27, 1, -1, 1, 0, 0, monasticTitleSuffixes27, 0, 0, 1000, 150, 0, favoriteClothingIds27, hatedClothingIds27, spouseAnonymousTitles27, canStroll: true, -1, initialAges27, equipment27, clothing27, inventory27, combatSkills2, new sbyte[5], new short[8] { -50, -90, -90, -90, -90, -90, -90, -90 }, 7500, 1500, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, 12, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 7, 60 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 30),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 18)
		}, null));
		List<OrganizationMemberItem> dataArray28 = _dataArray;
		string config28 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_207");
		sbyte[] potentialSuccessorGrades28 = new sbyte[0];
		sbyte[] childGrade28 = new sbyte[1];
		string[] monasticTitleSuffixes28 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_207_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_207_1")
		};
		List<short> favoriteClothingIds28 = new List<short> { 0, 1, 9, 10 };
		List<short> hatedClothingIds28 = new List<short> { 6, 7, 8, 15, 16, 17 };
		string[] spouseAnonymousTitles28 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_207_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_207_1")
		};
		short[] initialAges28 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment28 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing28 = new PresetEquipmentItem("Clothing", 9);
		List<PresetInventoryItem> inventory28 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 19, 1, 10),
			new PresetInventoryItem("Misc", 20, 1, 10),
			new PresetInventoryItem("Misc", 21, 1, 10),
			new PresetInventoryItem("Misc", 22, 1, 10),
			new PresetInventoryItem("Misc", 23, 1, 10),
			new PresetInventoryItem("Misc", 24, 1, 10),
			new PresetInventoryItem("Misc", 25, 1, 10),
			new PresetInventoryItem("Misc", 26, 1, 10),
			new PresetInventoryItem("Misc", 27, 1, 10),
			new PresetInventoryItem("Misc", 28, 1, 10),
			new PresetInventoryItem("Misc", 29, 1, 10),
			new PresetInventoryItem("Misc", 30, 1, 10),
			new PresetInventoryItem("Misc", 31, 1, 10),
			new PresetInventoryItem("Misc", 32, 1, 10),
			new PresetInventoryItem("Misc", 33, 1, 10),
			new PresetInventoryItem("Misc", 34, 1, 10),
			new PresetInventoryItem("Misc", 35, 1, 10),
			new PresetInventoryItem("Misc", 36, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray28.Add(new OrganizationMemberItem(207, config28, 37, 0, potentialSuccessorGrades28, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade28, 0, -1, 0, 0, 0, monasticTitleSuffixes28, 0, 0, 500, 0, 0, favoriteClothingIds28, hatedClothingIds28, spouseAnonymousTitles28, canStroll: true, -1, initialAges28, equipment28, clothing28, inventory28, combatSkills2, new sbyte[5], new short[8] { -90, -90, -90, -90, -90, -90, -90, -90 }, 3750, 750, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 12
		}, 3, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 8, 44 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 27),
			new IntPair(2, 6),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 30)
		}, null));
		List<OrganizationMemberItem> dataArray29 = _dataArray;
		string config29 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_208");
		sbyte[] potentialSuccessorGrades29 = new sbyte[0];
		sbyte[] childGrade29 = new sbyte[2] { 7, 6 };
		string[] monasticTitleSuffixes29 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_208_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_208_1")
		};
		List<short> favoriteClothingIds29 = new List<short> { 6, 7, 8, 15, 16, 17 };
		List<short> hatedClothingIds29 = new List<short> { 0, 1, 2, 9, 10, 11 };
		string[] spouseAnonymousTitles29 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_208_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_208_1")
		};
		short[] initialAges29 = new short[4] { 28, 37, 46, 55 };
		PresetEquipmentItemWithProb[] equipment29 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing29 = new PresetEquipmentItem("Clothing", 16);
		List<PresetInventoryItem> inventory29 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 91, 1, 30),
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray29.Add(new OrganizationMemberItem(208, config29, 38, 8, potentialSuccessorGrades29, 1, 1, 1, restrictPrincipalAmount: true, -1, -1, 0, 7, childGrade29, 7, -1, 7, 0, 0, monasticTitleSuffixes29, 0, 0, 13000, 21150, -100, favoriteClothingIds29, hatedClothingIds29, spouseAnonymousTitles29, canStroll: false, -1, initialAges29, equipment29, clothing29, inventory29, combatSkills2, new sbyte[5], new short[8] { -60, -60, -60, -60, -60, -60, -60, -60 }, 120000, 432000, 20, 20, 61500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 0 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 12),
			new IntPair(8, 12),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 6),
			new IntPair(0, 9),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray30 = _dataArray;
		string config30 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_209");
		sbyte[] potentialSuccessorGrades30 = new sbyte[3] { 6, 5, 2 };
		sbyte[] childGrade30 = new sbyte[3] { 7, 6, 5 };
		string[] monasticTitleSuffixes30 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_209_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_209_1")
		};
		List<short> favoriteClothingIds30 = new List<short> { 5, 6, 7, 8, 14, 15, 16, 17 };
		List<short> hatedClothingIds30 = new List<short> { 0, 1, 9, 10 };
		string[] spouseAnonymousTitles30 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_209_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_209_1")
		};
		short[] initialAges30 = new short[4] { 26, 34, 42, 50 };
		PresetEquipmentItemWithProb[] equipment30 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing30 = new PresetEquipmentItem("Clothing", 7);
		List<PresetInventoryItem> inventory30 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 100, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray30.Add(new OrganizationMemberItem(209, config30, 38, 7, potentialSuccessorGrades30, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, 7, childGrade30, 7, -1, 7, 0, 0, monasticTitleSuffixes30, 0, 0, 10000, 13800, -100, favoriteClothingIds30, hatedClothingIds30, spouseAnonymousTitles30, canStroll: false, -1, initialAges30, equipment30, clothing30, inventory30, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -70, -50 }, 75000, 216000, 15, 30, 42300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 52, 56 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 9),
			new IntPair(8, 9),
			new IntPair(5, 3),
			new IntPair(6, 3),
			new IntPair(15, 9),
			new IntPair(16, 12),
			new IntPair(7, 12),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 6),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 6),
			new IntPair(0, 9),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray31 = _dataArray;
		string config31 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_210");
		sbyte[] potentialSuccessorGrades31 = new sbyte[2] { 5, 2 };
		sbyte[] childGrade31 = new sbyte[3] { 6, 5, 4 };
		string[] monasticTitleSuffixes31 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_210_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_210_1")
		};
		List<short> favoriteClothingIds31 = new List<short> { 4, 5, 6, 7, 8, 13, 14, 15, 16, 17 };
		List<short> hatedClothingIds31 = new List<short> { 0, 9 };
		string[] spouseAnonymousTitles31 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_210_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_210_1")
		};
		short[] initialAges31 = new short[4] { 24, 31, 38, 45 };
		PresetEquipmentItemWithProb[] equipment31 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing31 = new PresetEquipmentItem("Clothing", 15);
		List<PresetInventoryItem> inventory31 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 51, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray31.Add(new OrganizationMemberItem(210, config31, 38, 6, potentialSuccessorGrades31, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade31, 6, -1, 6, 0, 0, monasticTitleSuffixes31, 0, 0, 8000, 8400, -100, favoriteClothingIds31, hatedClothingIds31, spouseAnonymousTitles31, canStroll: false, -1, initialAges31, equipment31, clothing31, inventory31, combatSkills2, new sbyte[5], new short[8] { -70, -70, -70, -70, -70, -70, -50, -70 }, 45000, 108000, 15, 40, 27600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 6, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 2, 57 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 6),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 15),
			new IntPair(16, 18),
			new IntPair(7, 18),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 9),
			new IntPair(11, 6),
			new IntPair(0, 9),
			new IntPair(9, 3)
		}, null));
		List<OrganizationMemberItem> dataArray32 = _dataArray;
		string config32 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_211");
		sbyte[] potentialSuccessorGrades32 = new sbyte[2] { 2, 1 };
		sbyte[] childGrade32 = new sbyte[3] { 5, 4, 3 };
		string[] monasticTitleSuffixes32 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_211_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_211_1")
		};
		List<short> favoriteClothingIds32 = new List<short> { 4 };
		list = new List<short>();
		List<short> hatedClothingIds32 = list;
		string[] spouseAnonymousTitles32 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_211_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_211_1")
		};
		short[] initialAges32 = new short[4] { 22, 28, 34, 40 };
		PresetEquipmentItemWithProb[] equipment32 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing32 = new PresetEquipmentItem("Clothing", 4);
		List<PresetInventoryItem> inventory32 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray32.Add(new OrganizationMemberItem(211, config32, 38, 5, potentialSuccessorGrades32, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade32, 5, -1, 5, 0, 0, monasticTitleSuffixes32, 0, 0, 6000, 4650, -75, favoriteClothingIds32, hatedClothingIds32, spouseAnonymousTitles32, canStroll: true, -1, initialAges32, equipment32, clothing32, inventory32, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -80, -50 }, 30000, 36000, 10, 50, 16800, new short[16]
		{
			12, 12, 12, 12, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 3, 58, 66 }, 16, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 21),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 3),
			new IntPair(16, 21),
			new IntPair(7, 6),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 30),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 3),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 3),
			new IntPair(0, 1),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray33 = _dataArray;
		string config33 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_212");
		sbyte[] potentialSuccessorGrades33 = new sbyte[3] { 2, 1, 0 };
		sbyte[] childGrade33 = new sbyte[3] { 4, 3, 2 };
		string[] monasticTitleSuffixes33 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_212_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_212_1")
		};
		List<short> favoriteClothingIds33 = new List<short> { 15 };
		list = new List<short>();
		List<short> hatedClothingIds33 = list;
		string[] spouseAnonymousTitles33 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_212_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_212_1")
		};
		short[] initialAges33 = new short[4] { 20, 25, 30, 35 };
		PresetEquipmentItemWithProb[] equipment33 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing33 = new PresetEquipmentItem("Clothing", 15);
		List<PresetInventoryItem> inventory33 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Food", 9, 3, 40),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("TeaWine", 18, 1, 20),
			new PresetInventoryItem("TeaWine", 27, 1, 20),
			new PresetInventoryItem("TeaWine", 0, 1, 20),
			new PresetInventoryItem("TeaWine", 9, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray33.Add(new OrganizationMemberItem(212, config33, 38, 4, potentialSuccessorGrades33, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade33, 4, -1, 4, 0, 0, monasticTitleSuffixes33, 0, 0, 4500, 2250, -50, favoriteClothingIds33, hatedClothingIds33, spouseAnonymousTitles33, canStroll: true, -1, initialAges33, equipment33, clothing33, inventory33, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -80, -50, -80 }, 22500, 18000, 10, 60, 9300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 9
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 4, 53 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 27),
			new IntPair(16, 15),
			new IntPair(7, 15),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 6),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 6),
			new IntPair(2, 3),
			new IntPair(1, 1),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray34 = _dataArray;
		string config34 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_213");
		sbyte[] potentialSuccessorGrades34 = new sbyte[0];
		sbyte[] childGrade34 = new sbyte[3] { 3, 2, 1 };
		string[] monasticTitleSuffixes34 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_213_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_213_1")
		};
		List<short> favoriteClothingIds34 = new List<short> { 13 };
		list = new List<short>();
		List<short> hatedClothingIds34 = list;
		string[] spouseAnonymousTitles34 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_213_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_213_1")
		};
		short[] initialAges34 = new short[4] { 18, 22, 26, 30 };
		PresetEquipmentItemWithProb[] equipment34 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing34 = new PresetEquipmentItem("Clothing", 13);
		List<PresetInventoryItem> inventory34 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 45, 1, 30),
			new PresetInventoryItem("Food", 135, 3, 40),
			new PresetInventoryItem("Medicine", 54, 1, 20),
			new PresetInventoryItem("Medicine", 66, 1, 20),
			new PresetInventoryItem("Medicine", 82, 1, 20),
			new PresetInventoryItem("Medicine", 94, 1, 20),
			new PresetInventoryItem("Material", 140, 1, 10),
			new PresetInventoryItem("Material", 144, 1, 10),
			new PresetInventoryItem("Material", 148, 1, 10),
			new PresetInventoryItem("Material", 152, 1, 10),
			new PresetInventoryItem("Material", 156, 1, 10),
			new PresetInventoryItem("Material", 160, 1, 10),
			new PresetInventoryItem("Material", 164, 1, 10),
			new PresetInventoryItem("Material", 168, 1, 10),
			new PresetInventoryItem("Material", 172, 1, 10),
			new PresetInventoryItem("Material", 176, 1, 10),
			new PresetInventoryItem("Material", 180, 1, 10),
			new PresetInventoryItem("Material", 184, 1, 10),
			new PresetInventoryItem("Material", 188, 1, 10),
			new PresetInventoryItem("Material", 192, 1, 10),
			new PresetInventoryItem("Material", 196, 1, 10),
			new PresetInventoryItem("Material", 200, 1, 10),
			new PresetInventoryItem("Material", 204, 1, 10),
			new PresetInventoryItem("Material", 208, 1, 10),
			new PresetInventoryItem("Material", 212, 1, 10),
			new PresetInventoryItem("Material", 216, 1, 10),
			new PresetInventoryItem("Material", 220, 1, 10),
			new PresetInventoryItem("Material", 224, 1, 10),
			new PresetInventoryItem("Material", 228, 1, 10),
			new PresetInventoryItem("Material", 232, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray34.Add(new OrganizationMemberItem(213, config34, 38, 3, potentialSuccessorGrades34, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade34, 3, -1, 3, 0, 0, monasticTitleSuffixes34, 0, 0, 3000, 900, -25, favoriteClothingIds34, hatedClothingIds34, spouseAnonymousTitles34, canStroll: true, -1, initialAges34, equipment34, clothing34, inventory34, combatSkills2, new sbyte[5], new short[8] { -80, -80, -80, -80, -80, -50, -80, -80 }, 15000, 9000, 10, 70, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, 12, 12,
			-1, -1, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 5, 54, 64 }, 14, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 6),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 6),
			new IntPair(7, 1),
			new IntPair(14, 3),
			new IntPair(12, 3),
			new IntPair(4, 12),
			new IntPair(3, 1),
			new IntPair(13, 30),
			new IntPair(10, 18),
			new IntPair(2, 1),
			new IntPair(1, 1),
			new IntPair(11, 9),
			new IntPair(0, 12),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray35 = _dataArray;
		string config35 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_214");
		sbyte[] potentialSuccessorGrades35 = new sbyte[0];
		sbyte[] childGrade35 = new sbyte[3] { 2, 1, 0 };
		string[] monasticTitleSuffixes35 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_214_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_214_1")
		};
		List<short> favoriteClothingIds35 = new List<short> { 0, 1, 2, 3, 9, 10, 11, 12 };
		List<short> hatedClothingIds35 = new List<short> { 8, 17 };
		string[] spouseAnonymousTitles35 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_214_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_214_1")
		};
		short[] initialAges35 = new short[4] { 16, 19, 22, 25 };
		PresetEquipmentItemWithProb[] equipment35 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", 18, 75),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing35 = new PresetEquipmentItem("Clothing", 11);
		List<PresetInventoryItem> inventory35 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 0, 1, 30),
			new PresetInventoryItem("CraftTool", 9, 1, 30),
			new PresetInventoryItem("CraftTool", 18, 1, 30),
			new PresetInventoryItem("CraftTool", 27, 1, 30),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 0, 1, 20),
			new PresetInventoryItem("Material", 7, 1, 20),
			new PresetInventoryItem("Material", 14, 1, 20),
			new PresetInventoryItem("Material", 21, 1, 20),
			new PresetInventoryItem("Material", 28, 1, 20),
			new PresetInventoryItem("Material", 35, 1, 20),
			new PresetInventoryItem("Material", 42, 1, 20),
			new PresetInventoryItem("Material", 49, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray35.Add(new OrganizationMemberItem(214, config35, 38, 2, potentialSuccessorGrades35, 3, 3, 3, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade35, 2, -1, 2, 0, 0, monasticTitleSuffixes35, 0, 0, 2000, 300, 0, favoriteClothingIds35, hatedClothingIds35, spouseAnonymousTitles35, canStroll: true, -1, initialAges35, equipment35, clothing35, inventory35, combatSkills2, new sbyte[5], new short[8] { -90, -50, -50, -50, -50, -90, -90, -90 }, 11250, 3000, 5, 80, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, 12, 12, -1, -1,
			12, 12, -1, -1, -1, -1
		}, 7, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 6, 61, 63 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 1),
			new IntPair(8, 1),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 1),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 9),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 18),
			new IntPair(2, 30),
			new IntPair(1, 9),
			new IntPair(11, 15),
			new IntPair(0, 6),
			new IntPair(9, 1)
		}, null));
		List<OrganizationMemberItem> dataArray36 = _dataArray;
		string config36 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_215");
		sbyte[] potentialSuccessorGrades36 = new sbyte[0];
		sbyte[] childGrade36 = new sbyte[2] { 1, 0 };
		string[] monasticTitleSuffixes36 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_215_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_215_1")
		};
		List<short> favoriteClothingIds36 = new List<short> { 0, 1, 2, 9, 10, 11 };
		List<short> hatedClothingIds36 = new List<short> { 7, 8, 16, 17 };
		string[] spouseAnonymousTitles36 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_215_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_215_1")
		};
		short[] initialAges36 = new short[4] { 14, 16, 18, 20 };
		PresetEquipmentItemWithProb[] equipment36 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing36 = new PresetEquipmentItem("Clothing", 10);
		List<PresetInventoryItem> inventory36 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("CraftTool", 36, 1, 30),
			new PresetInventoryItem("Food", 0, 3, 40),
			new PresetInventoryItem("Food", 93, 3, 40),
			new PresetInventoryItem("Material", 57, 1, 20),
			new PresetInventoryItem("Material", 64, 1, 20),
			new PresetInventoryItem("Material", 71, 1, 20),
			new PresetInventoryItem("Material", 78, 1, 20)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray36.Add(new OrganizationMemberItem(215, config36, 38, 1, potentialSuccessorGrades36, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade36, 1, -1, 1, 0, 0, monasticTitleSuffixes36, 0, 0, 1000, 150, 0, favoriteClothingIds36, hatedClothingIds36, spouseAnonymousTitles36, canStroll: true, -1, initialAges36, equipment36, clothing36, inventory36, combatSkills2, new sbyte[5], new short[8] { -50, -90, -90, -90, -90, -90, -90, -90 }, 7500, 1500, 5, 90, 600, new short[16]
		{
			-1, -1, -1, -1, -1, 12, -1, -1, -1, -1,
			-1, -1, -1, -1, 12, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 7, 60 }, 12, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 6),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 1),
			new IntPair(10, 30),
			new IntPair(2, 12),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 18)
		}, null));
		List<OrganizationMemberItem> dataArray37 = _dataArray;
		string config37 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_216");
		sbyte[] potentialSuccessorGrades37 = new sbyte[0];
		sbyte[] childGrade37 = new sbyte[1];
		string[] monasticTitleSuffixes37 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_216_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_216_1")
		};
		List<short> favoriteClothingIds37 = new List<short> { 0, 1, 9, 10 };
		List<short> hatedClothingIds37 = new List<short> { 6, 7, 8, 15, 16, 17 };
		string[] spouseAnonymousTitles37 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_216_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_216_1")
		};
		short[] initialAges37 = new short[4] { 12, 13, 14, 15 };
		PresetEquipmentItemWithProb[] equipment37 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing37 = new PresetEquipmentItem("Clothing", 9);
		List<PresetInventoryItem> inventory37 = new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 19, 1, 10),
			new PresetInventoryItem("Misc", 20, 1, 10),
			new PresetInventoryItem("Misc", 21, 1, 10),
			new PresetInventoryItem("Misc", 22, 1, 10),
			new PresetInventoryItem("Misc", 23, 1, 10),
			new PresetInventoryItem("Misc", 24, 1, 10),
			new PresetInventoryItem("Misc", 25, 1, 10),
			new PresetInventoryItem("Misc", 26, 1, 10),
			new PresetInventoryItem("Misc", 27, 1, 10),
			new PresetInventoryItem("Misc", 28, 1, 10),
			new PresetInventoryItem("Misc", 29, 1, 10),
			new PresetInventoryItem("Misc", 30, 1, 10),
			new PresetInventoryItem("Misc", 31, 1, 10),
			new PresetInventoryItem("Misc", 32, 1, 10),
			new PresetInventoryItem("Misc", 33, 1, 10),
			new PresetInventoryItem("Misc", 34, 1, 10),
			new PresetInventoryItem("Misc", 35, 1, 10),
			new PresetInventoryItem("Misc", 36, 1, 10)
		};
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		dataArray37.Add(new OrganizationMemberItem(216, config37, 38, 0, potentialSuccessorGrades37, 2, 2, 2, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade37, 0, -1, 0, 0, 0, monasticTitleSuffixes37, 0, 0, 500, 0, 0, favoriteClothingIds37, hatedClothingIds37, spouseAnonymousTitles37, canStroll: true, -1, initialAges37, equipment37, clothing37, inventory37, combatSkills2, new sbyte[5], new short[8] { -90, -90, -90, -90, -90, -90, -90, -90 }, 3750, 750, 1, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 12
		}, 3, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte> { 8, 44 }, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[18]
		{
			new IntPair(17, 3),
			new IntPair(8, 3),
			new IntPair(5, 1),
			new IntPair(6, 1),
			new IntPair(15, 1),
			new IntPair(16, 3),
			new IntPair(7, 3),
			new IntPair(14, 1),
			new IntPair(12, 1),
			new IntPair(4, 3),
			new IntPair(3, 1),
			new IntPair(13, 3),
			new IntPair(10, 27),
			new IntPair(2, 6),
			new IntPair(1, 9),
			new IntPair(11, 9),
			new IntPair(0, 3),
			new IntPair(9, 30)
		}, null));
		List<OrganizationMemberItem> dataArray38 = _dataArray;
		string config38 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_217");
		sbyte[] potentialSuccessorGrades38 = new sbyte[0];
		sbyte[] childGrade38 = new sbyte[1];
		string[] monasticTitleSuffixes38 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_217_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_217_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds38 = list;
		list = new List<short>();
		List<short> hatedClothingIds38 = list;
		string[] spouseAnonymousTitles38 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_217_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_217_1")
		};
		short[] initialAges38 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment38 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing38 = new PresetEquipmentItem("Clothing", -1);
		List<PresetInventoryItem> list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory38 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills3 = combatSkills2;
		sbyte[] extraCombatSkillGrids2 = new sbyte[5] { 10, 10, 10, 10, 10 };
		short[] resourcesAdjust2 = new short[8];
		short[] lifeSkillsAdjust2 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust2 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust2 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray38.Add(new OrganizationMemberItem(217, config38, 39, 8, potentialSuccessorGrades38, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade38, 0, -1, -1, 0, 0, monasticTitleSuffixes38, 0, 0, 0, 0, 0, favoriteClothingIds38, hatedClothingIds38, spouseAnonymousTitles38, canStroll: false, -1, initialAges38, equipment38, clothing38, inventory38, combatSkills3, extraCombatSkillGrids2, resourcesAdjust2, 0, 0, 0, 100, 61500, lifeSkillsAdjust2, 8, combatSkillsAdjust2, mainAttributesAdjust2, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray39 = _dataArray;
		string config39 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_218");
		sbyte[] potentialSuccessorGrades39 = new sbyte[0];
		sbyte[] childGrade39 = new sbyte[1];
		string[] monasticTitleSuffixes39 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_218_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_218_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds39 = list;
		list = new List<short>();
		List<short> hatedClothingIds39 = list;
		string[] spouseAnonymousTitles39 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_218_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_218_1")
		};
		short[] initialAges39 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment39 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing39 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory39 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills4 = combatSkills2;
		sbyte[] extraCombatSkillGrids3 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust3 = new short[8];
		short[] lifeSkillsAdjust3 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust3 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust3 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray39.Add(new OrganizationMemberItem(218, config39, 39, 7, potentialSuccessorGrades39, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade39, 0, -1, -1, 0, 0, monasticTitleSuffixes39, 0, 0, 0, 0, 0, favoriteClothingIds39, hatedClothingIds39, spouseAnonymousTitles39, canStroll: false, -1, initialAges39, equipment39, clothing39, inventory39, combatSkills4, extraCombatSkillGrids3, resourcesAdjust3, 0, 0, 0, 100, 42300, lifeSkillsAdjust3, 8, combatSkillsAdjust3, mainAttributesAdjust3, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray40 = _dataArray;
		string config40 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_219");
		sbyte[] potentialSuccessorGrades40 = new sbyte[0];
		sbyte[] childGrade40 = new sbyte[1];
		string[] monasticTitleSuffixes40 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_219_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_219_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds40 = list;
		list = new List<short>();
		List<short> hatedClothingIds40 = list;
		string[] spouseAnonymousTitles40 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_219_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_219_1")
		};
		short[] initialAges40 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment40 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing40 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory40 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills5 = combatSkills2;
		sbyte[] extraCombatSkillGrids4 = new sbyte[5] { 8, 8, 8, 8, 8 };
		short[] resourcesAdjust4 = new short[8];
		short[] lifeSkillsAdjust4 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust4 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust4 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray40.Add(new OrganizationMemberItem(219, config40, 39, 6, potentialSuccessorGrades40, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade40, 0, -1, -1, 0, 0, monasticTitleSuffixes40, 0, 0, 0, 0, 0, favoriteClothingIds40, hatedClothingIds40, spouseAnonymousTitles40, canStroll: false, -1, initialAges40, equipment40, clothing40, inventory40, combatSkills5, extraCombatSkillGrids4, resourcesAdjust4, 0, 0, 0, 100, 27600, lifeSkillsAdjust4, 7, combatSkillsAdjust4, mainAttributesAdjust4, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray41 = _dataArray;
		string config41 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_220");
		sbyte[] potentialSuccessorGrades41 = new sbyte[0];
		sbyte[] childGrade41 = new sbyte[1];
		string[] monasticTitleSuffixes41 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_220_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_220_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds41 = list;
		list = new List<short>();
		List<short> hatedClothingIds41 = list;
		string[] spouseAnonymousTitles41 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_220_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_220_1")
		};
		short[] initialAges41 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment41 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing41 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory41 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills6 = combatSkills2;
		sbyte[] extraCombatSkillGrids5 = new sbyte[5] { 6, 6, 6, 6, 6 };
		short[] resourcesAdjust5 = new short[8];
		short[] lifeSkillsAdjust5 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust5 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust5 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray41.Add(new OrganizationMemberItem(220, config41, 39, 5, potentialSuccessorGrades41, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade41, 0, -1, -1, 0, 0, monasticTitleSuffixes41, 0, 0, 0, 0, 0, favoriteClothingIds41, hatedClothingIds41, spouseAnonymousTitles41, canStroll: false, -1, initialAges41, equipment41, clothing41, inventory41, combatSkills6, extraCombatSkillGrids5, resourcesAdjust5, 0, 0, 0, 100, 16800, lifeSkillsAdjust5, 7, combatSkillsAdjust5, mainAttributesAdjust5, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray42 = _dataArray;
		string config42 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_221");
		sbyte[] potentialSuccessorGrades42 = new sbyte[0];
		sbyte[] childGrade42 = new sbyte[1];
		string[] monasticTitleSuffixes42 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_221_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_221_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds42 = list;
		list = new List<short>();
		List<short> hatedClothingIds42 = list;
		string[] spouseAnonymousTitles42 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_221_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_221_1")
		};
		short[] initialAges42 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment42 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing42 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory42 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills7 = combatSkills2;
		sbyte[] extraCombatSkillGrids6 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust6 = new short[8];
		short[] lifeSkillsAdjust6 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust6 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust6 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray42.Add(new OrganizationMemberItem(221, config42, 39, 4, potentialSuccessorGrades42, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade42, 0, -1, -1, 0, 0, monasticTitleSuffixes42, 0, 0, 0, 0, 0, favoriteClothingIds42, hatedClothingIds42, spouseAnonymousTitles42, canStroll: false, -1, initialAges42, equipment42, clothing42, inventory42, combatSkills7, extraCombatSkillGrids6, resourcesAdjust6, 0, 0, 0, 100, 9300, lifeSkillsAdjust6, 6, combatSkillsAdjust6, mainAttributesAdjust6, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray43 = _dataArray;
		string config43 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_222");
		sbyte[] potentialSuccessorGrades43 = new sbyte[0];
		sbyte[] childGrade43 = new sbyte[1];
		string[] monasticTitleSuffixes43 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_222_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_222_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds43 = list;
		list = new List<short>();
		List<short> hatedClothingIds43 = list;
		string[] spouseAnonymousTitles43 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_222_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_222_1")
		};
		short[] initialAges43 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment43 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing43 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory43 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills8 = combatSkills2;
		sbyte[] extraCombatSkillGrids7 = new sbyte[5] { 4, 4, 4, 4, 4 };
		short[] resourcesAdjust7 = new short[8];
		short[] lifeSkillsAdjust7 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust7 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust7 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray43.Add(new OrganizationMemberItem(222, config43, 39, 3, potentialSuccessorGrades43, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade43, 0, -1, -1, 0, 0, monasticTitleSuffixes43, 0, 0, 0, 0, 0, favoriteClothingIds43, hatedClothingIds43, spouseAnonymousTitles43, canStroll: false, -1, initialAges43, equipment43, clothing43, inventory43, combatSkills8, extraCombatSkillGrids7, resourcesAdjust7, 0, 0, 0, 100, 4500, lifeSkillsAdjust7, 5, combatSkillsAdjust7, mainAttributesAdjust7, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray44 = _dataArray;
		string config44 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_223");
		sbyte[] potentialSuccessorGrades44 = new sbyte[0];
		sbyte[] childGrade44 = new sbyte[1];
		string[] monasticTitleSuffixes44 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_223_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_223_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds44 = list;
		list = new List<short>();
		List<short> hatedClothingIds44 = list;
		string[] spouseAnonymousTitles44 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_223_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_223_1")
		};
		short[] initialAges44 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment44 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing44 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory44 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills9 = combatSkills2;
		sbyte[] extraCombatSkillGrids8 = new sbyte[5] { 2, 2, 2, 2, 2 };
		short[] resourcesAdjust8 = new short[8];
		short[] lifeSkillsAdjust8 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust8 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust8 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray44.Add(new OrganizationMemberItem(223, config44, 39, 2, potentialSuccessorGrades44, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade44, 0, -1, -1, 0, 0, monasticTitleSuffixes44, 0, 0, 0, 0, 0, favoriteClothingIds44, hatedClothingIds44, spouseAnonymousTitles44, canStroll: false, -1, initialAges44, equipment44, clothing44, inventory44, combatSkills9, extraCombatSkillGrids8, resourcesAdjust8, 0, 0, 0, 100, 1800, lifeSkillsAdjust8, 4, combatSkillsAdjust8, mainAttributesAdjust8, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray45 = _dataArray;
		string config45 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_224");
		sbyte[] potentialSuccessorGrades45 = new sbyte[0];
		sbyte[] childGrade45 = new sbyte[1];
		string[] monasticTitleSuffixes45 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_224_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_224_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds45 = list;
		list = new List<short>();
		List<short> hatedClothingIds45 = list;
		string[] spouseAnonymousTitles45 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_224_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_224_1")
		};
		short[] initialAges45 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment45 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing45 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory45 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills10 = combatSkills2;
		sbyte[] extraCombatSkillGrids9 = new sbyte[5];
		short[] resourcesAdjust9 = new short[8];
		short[] lifeSkillsAdjust9 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust9 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust9 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray45.Add(new OrganizationMemberItem(224, config45, 39, 1, potentialSuccessorGrades45, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade45, 0, -1, -1, 0, 0, monasticTitleSuffixes45, 0, 0, 0, 0, 0, favoriteClothingIds45, hatedClothingIds45, spouseAnonymousTitles45, canStroll: false, -1, initialAges45, equipment45, clothing45, inventory45, combatSkills10, extraCombatSkillGrids9, resourcesAdjust9, 0, 0, 0, 100, 600, lifeSkillsAdjust9, 3, combatSkillsAdjust9, mainAttributesAdjust9, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray46 = _dataArray;
		string config46 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_225");
		sbyte[] potentialSuccessorGrades46 = new sbyte[0];
		sbyte[] childGrade46 = new sbyte[1];
		string[] monasticTitleSuffixes46 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_225_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_225_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds46 = list;
		list = new List<short>();
		List<short> hatedClothingIds46 = list;
		string[] spouseAnonymousTitles46 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_225_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_225_1")
		};
		short[] initialAges46 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment46 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing46 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory46 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills11 = combatSkills2;
		sbyte[] extraCombatSkillGrids10 = new sbyte[5];
		short[] resourcesAdjust10 = new short[8];
		short[] lifeSkillsAdjust10 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust10 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust10 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray46.Add(new OrganizationMemberItem(225, config46, 39, 0, potentialSuccessorGrades46, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade46, 0, -1, -1, 0, 0, monasticTitleSuffixes46, 0, 0, 0, 0, 0, favoriteClothingIds46, hatedClothingIds46, spouseAnonymousTitles46, canStroll: false, -1, initialAges46, equipment46, clothing46, inventory46, combatSkills11, extraCombatSkillGrids10, resourcesAdjust10, 0, 0, 0, 100, 300, lifeSkillsAdjust10, 2, combatSkillsAdjust10, mainAttributesAdjust10, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray47 = _dataArray;
		string config47 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_226");
		sbyte[] potentialSuccessorGrades47 = new sbyte[0];
		sbyte[] childGrade47 = new sbyte[1];
		string[] monasticTitleSuffixes47 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_226_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_226_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds47 = list;
		list = new List<short>();
		List<short> hatedClothingIds47 = list;
		string[] spouseAnonymousTitles47 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_226_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_226_1")
		};
		short[] initialAges47 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment47 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing47 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory47 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills12 = combatSkills2;
		sbyte[] extraCombatSkillGrids11 = new sbyte[5];
		short[] resourcesAdjust11 = new short[8];
		short[] lifeSkillsAdjust11 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust11 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust11 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray47.Add(new OrganizationMemberItem(226, config47, 40, 8, potentialSuccessorGrades47, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade47, 0, -1, -1, 0, 0, monasticTitleSuffixes47, 0, 0, 0, 0, 0, favoriteClothingIds47, hatedClothingIds47, spouseAnonymousTitles47, canStroll: false, -1, initialAges47, equipment47, clothing47, inventory47, combatSkills12, extraCombatSkillGrids11, resourcesAdjust11, 0, 0, 0, 100, 61500, lifeSkillsAdjust11, 8, combatSkillsAdjust11, mainAttributesAdjust11, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray48 = _dataArray;
		string config48 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_227");
		sbyte[] potentialSuccessorGrades48 = new sbyte[0];
		sbyte[] childGrade48 = new sbyte[1];
		string[] monasticTitleSuffixes48 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_227_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_227_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds48 = list;
		list = new List<short>();
		List<short> hatedClothingIds48 = list;
		string[] spouseAnonymousTitles48 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_227_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_227_1")
		};
		short[] initialAges48 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment48 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing48 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory48 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills13 = combatSkills2;
		sbyte[] extraCombatSkillGrids12 = new sbyte[5];
		short[] resourcesAdjust12 = new short[8];
		short[] lifeSkillsAdjust12 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust12 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust12 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray48.Add(new OrganizationMemberItem(227, config48, 40, 7, potentialSuccessorGrades48, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade48, 0, -1, -1, 0, 0, monasticTitleSuffixes48, 0, 0, 0, 0, 0, favoriteClothingIds48, hatedClothingIds48, spouseAnonymousTitles48, canStroll: false, -1, initialAges48, equipment48, clothing48, inventory48, combatSkills13, extraCombatSkillGrids12, resourcesAdjust12, 0, 0, 0, 100, 42300, lifeSkillsAdjust12, 8, combatSkillsAdjust12, mainAttributesAdjust12, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray49 = _dataArray;
		string config49 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_228");
		sbyte[] potentialSuccessorGrades49 = new sbyte[0];
		sbyte[] childGrade49 = new sbyte[1];
		string[] monasticTitleSuffixes49 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_228_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_228_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds49 = list;
		list = new List<short>();
		List<short> hatedClothingIds49 = list;
		string[] spouseAnonymousTitles49 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_228_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_228_1")
		};
		short[] initialAges49 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment49 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing49 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory49 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills14 = combatSkills2;
		sbyte[] extraCombatSkillGrids13 = new sbyte[5];
		short[] resourcesAdjust13 = new short[8];
		short[] lifeSkillsAdjust13 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust13 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust13 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray49.Add(new OrganizationMemberItem(228, config49, 40, 6, potentialSuccessorGrades49, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade49, 0, -1, -1, 0, 0, monasticTitleSuffixes49, 0, 0, 0, 0, 0, favoriteClothingIds49, hatedClothingIds49, spouseAnonymousTitles49, canStroll: false, -1, initialAges49, equipment49, clothing49, inventory49, combatSkills14, extraCombatSkillGrids13, resourcesAdjust13, 0, 0, 0, 100, 27600, lifeSkillsAdjust13, 7, combatSkillsAdjust13, mainAttributesAdjust13, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray50 = _dataArray;
		string config50 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_229");
		sbyte[] potentialSuccessorGrades50 = new sbyte[0];
		sbyte[] childGrade50 = new sbyte[1];
		string[] monasticTitleSuffixes50 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_229_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_229_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds50 = list;
		list = new List<short>();
		List<short> hatedClothingIds50 = list;
		string[] spouseAnonymousTitles50 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_229_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_229_1")
		};
		short[] initialAges50 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment50 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing50 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory50 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills15 = combatSkills2;
		sbyte[] extraCombatSkillGrids14 = new sbyte[5];
		short[] resourcesAdjust14 = new short[8];
		short[] lifeSkillsAdjust14 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust14 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust14 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray50.Add(new OrganizationMemberItem(229, config50, 40, 5, potentialSuccessorGrades50, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade50, 0, -1, -1, 0, 0, monasticTitleSuffixes50, 0, 0, 0, 0, 0, favoriteClothingIds50, hatedClothingIds50, spouseAnonymousTitles50, canStroll: false, -1, initialAges50, equipment50, clothing50, inventory50, combatSkills15, extraCombatSkillGrids14, resourcesAdjust14, 0, 0, 0, 100, 16800, lifeSkillsAdjust14, 7, combatSkillsAdjust14, mainAttributesAdjust14, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray51 = _dataArray;
		string config51 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_230");
		sbyte[] potentialSuccessorGrades51 = new sbyte[0];
		sbyte[] childGrade51 = new sbyte[1];
		string[] monasticTitleSuffixes51 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_230_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_230_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds51 = list;
		list = new List<short>();
		List<short> hatedClothingIds51 = list;
		string[] spouseAnonymousTitles51 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_230_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_230_1")
		};
		short[] initialAges51 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment51 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing51 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory51 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills16 = combatSkills2;
		sbyte[] extraCombatSkillGrids15 = new sbyte[5];
		short[] resourcesAdjust15 = new short[8];
		short[] lifeSkillsAdjust15 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust15 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust15 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray51.Add(new OrganizationMemberItem(230, config51, 40, 4, potentialSuccessorGrades51, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade51, 0, -1, -1, 0, 0, monasticTitleSuffixes51, 0, 0, 0, 0, 0, favoriteClothingIds51, hatedClothingIds51, spouseAnonymousTitles51, canStroll: false, -1, initialAges51, equipment51, clothing51, inventory51, combatSkills16, extraCombatSkillGrids15, resourcesAdjust15, 0, 0, 0, 100, 9300, lifeSkillsAdjust15, 6, combatSkillsAdjust15, mainAttributesAdjust15, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray52 = _dataArray;
		string config52 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_231");
		sbyte[] potentialSuccessorGrades52 = new sbyte[0];
		sbyte[] childGrade52 = new sbyte[1];
		string[] monasticTitleSuffixes52 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_231_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_231_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds52 = list;
		list = new List<short>();
		List<short> hatedClothingIds52 = list;
		string[] spouseAnonymousTitles52 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_231_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_231_1")
		};
		short[] initialAges52 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment52 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing52 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory52 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills17 = combatSkills2;
		sbyte[] extraCombatSkillGrids16 = new sbyte[5];
		short[] resourcesAdjust16 = new short[8];
		short[] lifeSkillsAdjust16 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust16 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust16 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray52.Add(new OrganizationMemberItem(231, config52, 40, 3, potentialSuccessorGrades52, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade52, 0, -1, -1, 0, 0, monasticTitleSuffixes52, 0, 0, 0, 0, 0, favoriteClothingIds52, hatedClothingIds52, spouseAnonymousTitles52, canStroll: false, -1, initialAges52, equipment52, clothing52, inventory52, combatSkills17, extraCombatSkillGrids16, resourcesAdjust16, 0, 0, 0, 100, 4500, lifeSkillsAdjust16, 5, combatSkillsAdjust16, mainAttributesAdjust16, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray53 = _dataArray;
		string config53 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_232");
		sbyte[] potentialSuccessorGrades53 = new sbyte[0];
		sbyte[] childGrade53 = new sbyte[1];
		string[] monasticTitleSuffixes53 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_232_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_232_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds53 = list;
		list = new List<short>();
		List<short> hatedClothingIds53 = list;
		string[] spouseAnonymousTitles53 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_232_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_232_1")
		};
		short[] initialAges53 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment53 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing53 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory53 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills18 = combatSkills2;
		sbyte[] extraCombatSkillGrids17 = new sbyte[5];
		short[] resourcesAdjust17 = new short[8];
		short[] lifeSkillsAdjust17 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust17 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust17 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray53.Add(new OrganizationMemberItem(232, config53, 40, 2, potentialSuccessorGrades53, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade53, 0, -1, -1, 0, 0, monasticTitleSuffixes53, 0, 0, 0, 0, 0, favoriteClothingIds53, hatedClothingIds53, spouseAnonymousTitles53, canStroll: false, -1, initialAges53, equipment53, clothing53, inventory53, combatSkills18, extraCombatSkillGrids17, resourcesAdjust17, 0, 0, 0, 100, 1800, lifeSkillsAdjust17, 4, combatSkillsAdjust17, mainAttributesAdjust17, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray54 = _dataArray;
		string config54 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_233");
		sbyte[] potentialSuccessorGrades54 = new sbyte[0];
		sbyte[] childGrade54 = new sbyte[1];
		string[] monasticTitleSuffixes54 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_233_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_233_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds54 = list;
		list = new List<short>();
		List<short> hatedClothingIds54 = list;
		string[] spouseAnonymousTitles54 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_233_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_233_1")
		};
		short[] initialAges54 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment54 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing54 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory54 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills19 = combatSkills2;
		sbyte[] extraCombatSkillGrids18 = new sbyte[5];
		short[] resourcesAdjust18 = new short[8];
		short[] lifeSkillsAdjust18 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust18 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust18 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray54.Add(new OrganizationMemberItem(233, config54, 40, 1, potentialSuccessorGrades54, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade54, 0, -1, -1, 0, 0, monasticTitleSuffixes54, 0, 0, 0, 0, 0, favoriteClothingIds54, hatedClothingIds54, spouseAnonymousTitles54, canStroll: false, -1, initialAges54, equipment54, clothing54, inventory54, combatSkills19, extraCombatSkillGrids18, resourcesAdjust18, 0, 0, 0, 100, 600, lifeSkillsAdjust18, 3, combatSkillsAdjust18, mainAttributesAdjust18, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray55 = _dataArray;
		string config55 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_234");
		sbyte[] potentialSuccessorGrades55 = new sbyte[0];
		sbyte[] childGrade55 = new sbyte[1];
		string[] monasticTitleSuffixes55 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_234_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_234_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds55 = list;
		list = new List<short>();
		List<short> hatedClothingIds55 = list;
		string[] spouseAnonymousTitles55 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_234_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_234_1")
		};
		short[] initialAges55 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment55 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing55 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory55 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills20 = combatSkills2;
		sbyte[] extraCombatSkillGrids19 = new sbyte[5];
		short[] resourcesAdjust19 = new short[8];
		short[] lifeSkillsAdjust19 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust19 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust19 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray55.Add(new OrganizationMemberItem(234, config55, 40, 0, potentialSuccessorGrades55, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade55, 0, -1, -1, 0, 0, monasticTitleSuffixes55, 0, 0, 0, 0, 0, favoriteClothingIds55, hatedClothingIds55, spouseAnonymousTitles55, canStroll: false, -1, initialAges55, equipment55, clothing55, inventory55, combatSkills20, extraCombatSkillGrids19, resourcesAdjust19, 0, 0, 0, 100, 300, lifeSkillsAdjust19, 2, combatSkillsAdjust19, mainAttributesAdjust19, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray56 = _dataArray;
		string config56 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_235");
		sbyte[] potentialSuccessorGrades56 = new sbyte[0];
		sbyte[] childGrade56 = new sbyte[1];
		string[] monasticTitleSuffixes56 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_235_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_235_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds56 = list;
		list = new List<short>();
		List<short> hatedClothingIds56 = list;
		string[] spouseAnonymousTitles56 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_235_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_235_1")
		};
		short[] initialAges56 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment56 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing56 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory56 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills21 = combatSkills2;
		sbyte[] extraCombatSkillGrids20 = new sbyte[5];
		short[] resourcesAdjust20 = new short[8];
		short[] lifeSkillsAdjust20 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust20 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust20 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray56.Add(new OrganizationMemberItem(235, config56, 41, 8, potentialSuccessorGrades56, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade56, 0, -1, -1, 0, 0, monasticTitleSuffixes56, 0, 0, 0, 0, 0, favoriteClothingIds56, hatedClothingIds56, spouseAnonymousTitles56, canStroll: false, -1, initialAges56, equipment56, clothing56, inventory56, combatSkills21, extraCombatSkillGrids20, resourcesAdjust20, 0, 0, 0, 100, 61500, lifeSkillsAdjust20, 8, combatSkillsAdjust20, mainAttributesAdjust20, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray57 = _dataArray;
		string config57 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_236");
		sbyte[] potentialSuccessorGrades57 = new sbyte[0];
		sbyte[] childGrade57 = new sbyte[1];
		string[] monasticTitleSuffixes57 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_236_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_236_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds57 = list;
		list = new List<short>();
		List<short> hatedClothingIds57 = list;
		string[] spouseAnonymousTitles57 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_236_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_236_1")
		};
		short[] initialAges57 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment57 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing57 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory57 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills22 = combatSkills2;
		sbyte[] extraCombatSkillGrids21 = new sbyte[5];
		short[] resourcesAdjust21 = new short[8];
		short[] lifeSkillsAdjust21 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust21 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust21 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray57.Add(new OrganizationMemberItem(236, config57, 41, 7, potentialSuccessorGrades57, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade57, 0, -1, -1, 0, 0, monasticTitleSuffixes57, 0, 0, 0, 0, 0, favoriteClothingIds57, hatedClothingIds57, spouseAnonymousTitles57, canStroll: false, -1, initialAges57, equipment57, clothing57, inventory57, combatSkills22, extraCombatSkillGrids21, resourcesAdjust21, 0, 0, 0, 100, 42300, lifeSkillsAdjust21, 8, combatSkillsAdjust21, mainAttributesAdjust21, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray58 = _dataArray;
		string config58 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_237");
		sbyte[] potentialSuccessorGrades58 = new sbyte[0];
		sbyte[] childGrade58 = new sbyte[1];
		string[] monasticTitleSuffixes58 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_237_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_237_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds58 = list;
		list = new List<short>();
		List<short> hatedClothingIds58 = list;
		string[] spouseAnonymousTitles58 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_237_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_237_1")
		};
		short[] initialAges58 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment58 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing58 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory58 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills23 = combatSkills2;
		sbyte[] extraCombatSkillGrids22 = new sbyte[5];
		short[] resourcesAdjust22 = new short[8];
		short[] lifeSkillsAdjust22 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust22 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust22 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray58.Add(new OrganizationMemberItem(237, config58, 41, 6, potentialSuccessorGrades58, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade58, 0, -1, -1, 0, 0, monasticTitleSuffixes58, 0, 0, 0, 0, 0, favoriteClothingIds58, hatedClothingIds58, spouseAnonymousTitles58, canStroll: false, -1, initialAges58, equipment58, clothing58, inventory58, combatSkills23, extraCombatSkillGrids22, resourcesAdjust22, 0, 0, 0, 100, 27600, lifeSkillsAdjust22, 7, combatSkillsAdjust22, mainAttributesAdjust22, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray59 = _dataArray;
		string config59 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_238");
		sbyte[] potentialSuccessorGrades59 = new sbyte[0];
		sbyte[] childGrade59 = new sbyte[1];
		string[] monasticTitleSuffixes59 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_238_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_238_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds59 = list;
		list = new List<short>();
		List<short> hatedClothingIds59 = list;
		string[] spouseAnonymousTitles59 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_238_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_238_1")
		};
		short[] initialAges59 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment59 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing59 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory59 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills24 = combatSkills2;
		sbyte[] extraCombatSkillGrids23 = new sbyte[5];
		short[] resourcesAdjust23 = new short[8];
		short[] lifeSkillsAdjust23 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust23 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust23 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray59.Add(new OrganizationMemberItem(238, config59, 41, 5, potentialSuccessorGrades59, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade59, 0, -1, -1, 0, 0, monasticTitleSuffixes59, 0, 0, 0, 0, 0, favoriteClothingIds59, hatedClothingIds59, spouseAnonymousTitles59, canStroll: false, -1, initialAges59, equipment59, clothing59, inventory59, combatSkills24, extraCombatSkillGrids23, resourcesAdjust23, 0, 0, 0, 100, 16800, lifeSkillsAdjust23, 7, combatSkillsAdjust23, mainAttributesAdjust23, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		List<OrganizationMemberItem> dataArray60 = _dataArray;
		string config60 = LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_239");
		sbyte[] potentialSuccessorGrades60 = new sbyte[0];
		sbyte[] childGrade60 = new sbyte[1];
		string[] monasticTitleSuffixes60 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_239_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_239_1")
		};
		list = new List<short>();
		List<short> favoriteClothingIds60 = list;
		list = new List<short>();
		List<short> hatedClothingIds60 = list;
		string[] spouseAnonymousTitles60 = new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_239_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_239_1")
		};
		short[] initialAges60 = new short[4] { -1, -1, -1, -1 };
		PresetEquipmentItemWithProb[] equipment60 = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		PresetEquipmentItem clothing60 = new PresetEquipmentItem("Clothing", -1);
		list2 = new List<PresetInventoryItem>();
		List<PresetInventoryItem> inventory60 = list2;
		combatSkills2 = new List<PresetOrgMemberCombatSkill>();
		List<PresetOrgMemberCombatSkill> combatSkills25 = combatSkills2;
		sbyte[] extraCombatSkillGrids24 = new sbyte[5];
		short[] resourcesAdjust24 = new short[8];
		short[] lifeSkillsAdjust24 = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		short[] combatSkillsAdjust24 = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		short[] mainAttributesAdjust24 = new short[6] { -1, -1, -1, -1, -1, -1 };
		identityInteractConfig = new List<sbyte>();
		dataArray60.Add(new OrganizationMemberItem(239, config60, 41, 4, potentialSuccessorGrades60, 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, childGrade60, 0, -1, -1, 0, 0, monasticTitleSuffixes60, 0, 0, 0, 0, 0, favoriteClothingIds60, hatedClothingIds60, spouseAnonymousTitles60, canStroll: false, -1, initialAges60, equipment60, clothing60, inventory60, combatSkills25, extraCombatSkillGrids24, resourcesAdjust24, 0, 0, 0, 100, 9300, lifeSkillsAdjust24, 6, combatSkillsAdjust24, mainAttributesAdjust24, identityInteractConfig, 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new OrganizationMemberItem(240, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_240"), 41, 3, new sbyte[0], 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1], 0, -1, -1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_240_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_240_1")
		}, 0, 0, 0, 0, 0, new List<short>(), new List<short>(), new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_240_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_240_1")
		}, canStroll: false, -1, new short[4] { -1, -1, -1, -1 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", -1), new List<PresetInventoryItem>(), new List<PresetOrgMemberCombatSkill>(), new sbyte[5], new short[8], 0, 0, 0, 100, 4500, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 5, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte>(), 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		_dataArray.Add(new OrganizationMemberItem(241, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_241"), 41, 2, new sbyte[0], 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1], 0, -1, -1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_241_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_241_1")
		}, 0, 0, 0, 0, 0, new List<short>(), new List<short>(), new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_241_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_241_1")
		}, canStroll: false, -1, new short[4] { -1, -1, -1, -1 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", -1), new List<PresetInventoryItem>(), new List<PresetOrgMemberCombatSkill>(), new sbyte[5], new short[8], 0, 0, 0, 100, 1800, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 4, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte>(), 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		_dataArray.Add(new OrganizationMemberItem(242, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_242"), 41, 1, new sbyte[0], 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1], 0, -1, -1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_242_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_242_1")
		}, 0, 0, 0, 0, 0, new List<short>(), new List<short>(), new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_242_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_242_1")
		}, canStroll: false, -1, new short[4] { -1, -1, -1, -1 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", -1), new List<PresetInventoryItem>(), new List<PresetOrgMemberCombatSkill>(), new sbyte[5], new short[8], 0, 0, 0, 100, 600, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 3, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte>(), 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
		_dataArray.Add(new OrganizationMemberItem(243, LocalStringManager.GetConfig("OrganizationMember_language", "GradeName_243"), 41, 0, new sbyte[0], 0, 0, 0, restrictPrincipalAmount: false, -1, -1, 0, -1, new sbyte[1], 0, -1, -1, 0, 0, new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_243_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "MonasticTitleSuffixes_243_1")
		}, 0, 0, 0, 0, 0, new List<short>(), new List<short>(), new string[2]
		{
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_243_0"),
			LocalStringManager.GetConfig("OrganizationMember_language", "SpouseAnonymousTitles_243_1")
		}, canStroll: false, -1, new short[4] { -1, -1, -1, -1 }, new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		}, new PresetEquipmentItem("Clothing", -1), new List<PresetInventoryItem>(), new List<PresetOrgMemberCombatSkill>(), new sbyte[5], new short[8], 0, 0, 0, 100, 300, new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}, 2, new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		}, new short[6] { -1, -1, -1, -1, -1, -1 }, new List<sbyte>(), 3, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new IntPair[0], null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<OrganizationMemberItem>(244);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
