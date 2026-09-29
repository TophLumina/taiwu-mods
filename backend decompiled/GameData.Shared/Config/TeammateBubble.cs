using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeammateBubble : ConfigData<TeammateBubbleItem, short>
{
	public static class DefKey
	{
		public const short WildAnimal = 155;

		public const short FedAnimal = 156;

		public const short Family = 158;

		public const short Friend = 159;

		public const short Enemy = 160;

		public const short Actor = 161;

		public const short Reactor = 162;

		public const short PartlyInfected = 163;

		public const short CompletelyInfected = 164;

		public const short LegendaryBookShocked = 165;

		public const short LegendaryBookInsane = 166;

		public const short NonEnemyGrave = 167;

		public const short Leader = 168;

		public const short BrokenArea = 187;

		public const short FulongFlame = 188;
	}

	public static class DefValue
	{
		public static TeammateBubbleItem WildAnimal => Instance[(short)155];

		public static TeammateBubbleItem FedAnimal => Instance[(short)156];

		public static TeammateBubbleItem Family => Instance[(short)158];

		public static TeammateBubbleItem Friend => Instance[(short)159];

		public static TeammateBubbleItem Enemy => Instance[(short)160];

		public static TeammateBubbleItem Actor => Instance[(short)161];

		public static TeammateBubbleItem Reactor => Instance[(short)162];

		public static TeammateBubbleItem PartlyInfected => Instance[(short)163];

		public static TeammateBubbleItem CompletelyInfected => Instance[(short)164];

		public static TeammateBubbleItem LegendaryBookShocked => Instance[(short)165];

		public static TeammateBubbleItem LegendaryBookInsane => Instance[(short)166];

		public static TeammateBubbleItem NonEnemyGrave => Instance[(short)167];

		public static TeammateBubbleItem Leader => Instance[(short)168];

		public static TeammateBubbleItem BrokenArea => Instance[(short)187];

		public static TeammateBubbleItem FulongFlame => Instance[(short)188];
	}

	public static TeammateBubble Instance = new TeammateBubble();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "MapStateTemplateId", "MapBlockTemplateId", "CharacterTemplateIdList", "CharacterFeatureTemplateIdList", "AdventureTemplateIdList", "SpecialDesc0", "SpecialDesc1", "SpecialDesc2", "SpecialDesc3",
		"SpecialDesc4", "FamilyDesc", "FriendDesc", "Cricket", "BehaviorDesc", "TemplateId", "BubbleElementType", "PersonalityType"
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
		_dataArray.Add(new TeammateBubbleItem(0, LocalStringManager.GetConfig("TeammateBubble_language", "Name_0"), ETeammateBubbleBubbleElementType.TaiwuVillage, 180, -1, 0, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_0"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_0"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_0"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_0"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_0"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_0"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_0"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_0_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_0_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_0_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_0_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_0_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(1, LocalStringManager.GetConfig("TeammateBubble_language", "Name_1"), ETeammateBubbleBubbleElementType.City, 180, -1, 1, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_1"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_1"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_1"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_1"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_1"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_1"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_1"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_1_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_1_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_1_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_1_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_1_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(2, LocalStringManager.GetConfig("TeammateBubble_language", "Name_2"), ETeammateBubbleBubbleElementType.City, 180, -1, 2, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_2"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_2"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_2"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_2"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_2"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_2"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_2"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_2_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_2_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_2_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_2_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_2_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(3, LocalStringManager.GetConfig("TeammateBubble_language", "Name_3"), ETeammateBubbleBubbleElementType.City, 180, -1, 3, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_3"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_3"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_3"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_3"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_3"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_3"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_3"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_3_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_3_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_3_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_3_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_3_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(4, LocalStringManager.GetConfig("TeammateBubble_language", "Name_4"), ETeammateBubbleBubbleElementType.City, 180, -1, 4, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_4"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_4"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_4"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_4"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_4"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_4"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_4"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_4_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_4_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_4_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_4_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_4_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(5, LocalStringManager.GetConfig("TeammateBubble_language", "Name_5"), ETeammateBubbleBubbleElementType.City, 180, -1, 5, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_5"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_5"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_5"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_5"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_5"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_5"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_5"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_5_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_5_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_5_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_5_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_5_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(6, LocalStringManager.GetConfig("TeammateBubble_language", "Name_6"), ETeammateBubbleBubbleElementType.City, 180, -1, 6, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_6"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_6"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_6"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_6"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_6"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_6"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_6"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_6_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_6_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_6_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_6_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_6_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(7, LocalStringManager.GetConfig("TeammateBubble_language", "Name_7"), ETeammateBubbleBubbleElementType.City, 180, -1, 7, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_7"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_7"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_7"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_7"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_7"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_7"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_7"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_7_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_7_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_7_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_7_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_7_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(8, LocalStringManager.GetConfig("TeammateBubble_language", "Name_8"), ETeammateBubbleBubbleElementType.City, 180, -1, 8, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_8"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_8"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_8"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_8"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_8"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_8"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_8"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_8_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_8_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_8_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_8_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_8_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(9, LocalStringManager.GetConfig("TeammateBubble_language", "Name_9"), ETeammateBubbleBubbleElementType.City, 180, -1, 9, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_9"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_9"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_9"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_9"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_9"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_9"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_9"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_9_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_9_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_9_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_9_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_9_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(10, LocalStringManager.GetConfig("TeammateBubble_language", "Name_10"), ETeammateBubbleBubbleElementType.City, 180, -1, 10, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_10"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_10"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_10"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_10"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_10"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_10"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_10"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_10_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_10_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_10_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_10_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_10_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(11, LocalStringManager.GetConfig("TeammateBubble_language", "Name_11"), ETeammateBubbleBubbleElementType.City, 180, -1, 11, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_11"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_11"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_11"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_11"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_11"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_11"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_11"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_11_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_11_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_11_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_11_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_11_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(12, LocalStringManager.GetConfig("TeammateBubble_language", "Name_12"), ETeammateBubbleBubbleElementType.City, 180, -1, 12, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_12"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_12"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_12"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_12"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_12"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_12"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_12"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_12_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_12_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_12_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_12_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_12_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(13, LocalStringManager.GetConfig("TeammateBubble_language", "Name_13"), ETeammateBubbleBubbleElementType.City, 180, -1, 13, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_13"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_13"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_13"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_13"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_13"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_13"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_13"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_13_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_13_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_13_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_13_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_13_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(14, LocalStringManager.GetConfig("TeammateBubble_language", "Name_14"), ETeammateBubbleBubbleElementType.City, 180, -1, 14, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_14"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_14"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_14"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_14"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_14"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_14"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_14"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_14_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_14_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_14_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_14_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_14_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(15, LocalStringManager.GetConfig("TeammateBubble_language", "Name_15"), ETeammateBubbleBubbleElementType.City, 180, -1, 15, null, null, null, 2, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_15"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_15"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_15"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_15"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_15"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_15"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_15"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_15_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_15_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_15_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_15_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_15_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(16, LocalStringManager.GetConfig("TeammateBubble_language", "Name_16"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 19, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_16"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_16"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_16"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_16"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_16"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_16"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_16"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_16_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_16_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_16_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_16_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_16_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(17, LocalStringManager.GetConfig("TeammateBubble_language", "Name_17"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 20, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_17"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_17"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_17"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_17"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_17"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_17"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_17"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_17_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_17_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_17_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_17_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_17_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(18, LocalStringManager.GetConfig("TeammateBubble_language", "Name_18"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 21, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_18"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_18"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_18"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_18"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_18"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_18"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_18"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_18_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_18_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_18_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_18_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_18_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(19, LocalStringManager.GetConfig("TeammateBubble_language", "Name_19"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 22, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_19"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_19"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_19"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_19"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_19"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_19"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_19"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_19_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_19_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_19_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_19_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_19_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(20, LocalStringManager.GetConfig("TeammateBubble_language", "Name_20"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 23, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_20"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_20"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_20"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_20"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_20"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_20"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_20"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_20_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_20_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_20_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_20_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_20_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(21, LocalStringManager.GetConfig("TeammateBubble_language", "Name_21"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 24, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_21"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_21"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_21"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_21"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_21"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_21"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_21"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_21_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_21_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_21_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_21_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_21_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(22, LocalStringManager.GetConfig("TeammateBubble_language", "Name_22"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 25, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_22"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_22"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_22"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_22"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_22"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_22"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_22"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_22_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_22_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_22_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_22_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_22_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(23, LocalStringManager.GetConfig("TeammateBubble_language", "Name_23"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 26, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_23"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_23"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_23"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_23"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_23"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_23"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_23"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_23_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_23_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_23_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_23_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_23_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(24, LocalStringManager.GetConfig("TeammateBubble_language", "Name_24"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 27, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_24"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_24"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_24"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_24"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_24"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_24"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_24"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_24_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_24_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_24_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_24_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_24_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(25, LocalStringManager.GetConfig("TeammateBubble_language", "Name_25"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 28, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_25"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_25"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_25"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_25"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_25"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_25"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_25"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_25_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_25_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_25_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_25_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_25_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(26, LocalStringManager.GetConfig("TeammateBubble_language", "Name_26"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 29, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_26"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_26"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_26"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_26"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_26"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_26"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_26"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_26_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_26_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_26_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_26_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_26_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(27, LocalStringManager.GetConfig("TeammateBubble_language", "Name_27"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 30, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_27"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_27"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_27"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_27"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_27"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_27"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_27"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_27_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_27_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_27_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_27_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_27_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(28, LocalStringManager.GetConfig("TeammateBubble_language", "Name_28"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 31, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_28"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_28"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_28"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_28"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_28"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_28"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_28"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_28_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_28_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_28_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_28_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_28_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(29, LocalStringManager.GetConfig("TeammateBubble_language", "Name_29"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 32, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_29"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_29"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_29"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_29"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_29"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_29"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_29"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_29_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_29_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_29_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_29_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_29_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(30, LocalStringManager.GetConfig("TeammateBubble_language", "Name_30"), ETeammateBubbleBubbleElementType.Organization, 180, -1, 33, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_30"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_30"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_30"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_30"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_30"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_30"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_30"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_30_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_30_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_30_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_30_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_30_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(31, LocalStringManager.GetConfig("TeammateBubble_language", "Name_31"), ETeammateBubbleBubbleElementType.Village, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_31"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_31"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_31"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_31"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_31"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_31"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_31"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_31_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_31_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_31_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_31_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_31_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(32, LocalStringManager.GetConfig("TeammateBubble_language", "Name_32"), ETeammateBubbleBubbleElementType.Chicken, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_32"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_32"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_32"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_32"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_32"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_32"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_32"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_32_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_32_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_32_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_32_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_32_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(33, LocalStringManager.GetConfig("TeammateBubble_language", "Name_33"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_33"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_33"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_33"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_33"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_33"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_33"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_33"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_33_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_33_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_33_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_33_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_33_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(34, LocalStringManager.GetConfig("TeammateBubble_language", "Name_34"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_34"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_34"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_34"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_34"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_34"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_34"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_34"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_34_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_34_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_34_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_34_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_34_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(35, LocalStringManager.GetConfig("TeammateBubble_language", "Name_35"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_35"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_35"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_35"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_35"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_35"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_35"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_35"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_35_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_35_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_35_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_35_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_35_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(36, LocalStringManager.GetConfig("TeammateBubble_language", "Name_36"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_36"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_36"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_36"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_36"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_36"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_36"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_36"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_36_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_36_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_36_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_36_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_36_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(37, LocalStringManager.GetConfig("TeammateBubble_language", "Name_37"), ETeammateBubbleBubbleElementType.SummerCombatMatch, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_37"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_37"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_37"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_37"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_37"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_37"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_37"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_37_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_37_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_37_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_37_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_37_4")
		}, new string[3] { "CombatSkillType", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(38, LocalStringManager.GetConfig("TeammateBubble_language", "Name_38"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_38"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_38"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_38"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_38"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_38"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_38"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_38"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_38_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_38_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_38_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_38_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_38_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(39, LocalStringManager.GetConfig("TeammateBubble_language", "Name_39"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_39"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_39"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_39"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_39"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_39"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_39"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_39"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_39_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_39_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_39_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_39_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_39_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(40, LocalStringManager.GetConfig("TeammateBubble_language", "Name_40"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_40"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_40"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_40"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_40"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_40"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_40"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_40"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_40_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_40_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_40_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_40_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_40_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(41, LocalStringManager.GetConfig("TeammateBubble_language", "Name_41"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_41"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_41"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_41"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_41"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_41"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_41"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_41"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_41_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_41_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_41_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_41_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_41_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(42, LocalStringManager.GetConfig("TeammateBubble_language", "Name_42"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_42"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_42"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_42"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_42"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_42"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_42"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_42"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_42_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_42_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_42_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_42_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_42_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(43, LocalStringManager.GetConfig("TeammateBubble_language", "Name_43"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_43"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_43"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_43"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_43"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_43"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_43"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_43"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_43_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_43_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_43_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_43_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_43_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(44, LocalStringManager.GetConfig("TeammateBubble_language", "Name_44"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_44"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_44"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_44"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_44"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_44"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_44"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_44"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_44_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_44_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_44_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_44_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_44_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(45, LocalStringManager.GetConfig("TeammateBubble_language", "Name_45"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_45"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_45"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_45"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_45"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_45"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_45"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_45"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_45_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_45_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_45_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_45_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_45_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(46, LocalStringManager.GetConfig("TeammateBubble_language", "Name_46"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 19, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_46"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_46"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_46"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_46"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_46"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_46"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_46"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_46_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_46_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_46_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_46_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_46_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(47, LocalStringManager.GetConfig("TeammateBubble_language", "Name_47"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 20, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_47"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_47"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_47"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_47"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_47"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_47"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_47"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_47_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_47_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_47_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_47_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_47_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(48, LocalStringManager.GetConfig("TeammateBubble_language", "Name_48"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 21, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_48"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_48"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_48"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_48"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_48"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_48"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_48"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_48_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_48_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_48_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_48_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_48_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(49, LocalStringManager.GetConfig("TeammateBubble_language", "Name_49"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 22, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_49"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_49"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_49"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_49"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_49"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_49"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_49"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_49_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_49_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_49_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_49_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_49_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(50, LocalStringManager.GetConfig("TeammateBubble_language", "Name_50"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 23, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_50"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_50"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_50"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_50"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_50"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_50"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_50"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_50_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_50_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_50_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_50_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_50_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(51, LocalStringManager.GetConfig("TeammateBubble_language", "Name_51"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 24, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_51"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_51"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_51"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_51"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_51"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_51"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_51"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_51_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_51_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_51_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_51_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_51_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(52, LocalStringManager.GetConfig("TeammateBubble_language", "Name_52"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 25, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_52"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_52"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_52"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_52"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_52"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_52"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_52"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_52_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_52_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_52_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_52_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_52_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(53, LocalStringManager.GetConfig("TeammateBubble_language", "Name_53"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 26, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_53"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_53"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_53"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_53"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_53"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_53"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_53"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_53_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_53_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_53_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_53_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_53_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(54, LocalStringManager.GetConfig("TeammateBubble_language", "Name_54"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 27, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_54"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_54"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_54"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_54"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_54"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_54"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_54"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_54_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_54_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_54_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_54_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_54_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(55, LocalStringManager.GetConfig("TeammateBubble_language", "Name_55"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 28, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_55"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_55"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_55"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_55"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_55"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_55"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_55"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_55_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_55_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_55_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_55_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_55_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(56, LocalStringManager.GetConfig("TeammateBubble_language", "Name_56"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 29, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_56"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_56"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_56"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_56"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_56"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_56"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_56"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_56_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_56_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_56_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_56_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_56_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(57, LocalStringManager.GetConfig("TeammateBubble_language", "Name_57"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 30, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_57"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_57"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_57"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_57"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_57"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_57"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_57"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_57_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_57_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_57_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_57_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_57_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(58, LocalStringManager.GetConfig("TeammateBubble_language", "Name_58"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 31, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_58"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_58"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_58"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_58"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_58"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_58"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_58"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_58_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_58_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_58_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_58_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_58_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(59, LocalStringManager.GetConfig("TeammateBubble_language", "Name_59"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 32, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_59"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_59"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_59"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_59"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_59"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_59"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_59"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_59_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_59_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_59_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_59_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_59_4")
		}, new string[3] { "", "", "" }));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TeammateBubbleItem(60, LocalStringManager.GetConfig("TeammateBubble_language", "Name_60"), ETeammateBubbleBubbleElementType.SectCombatMatch, 180, -1, 33, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_60"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_60"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_60"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_60"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_60"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_60"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_60"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_60_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_60_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_60_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_60_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_60_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(61, LocalStringManager.GetConfig("TeammateBubble_language", "Name_61"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_61"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_61"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_61"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_61"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_61"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_61"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_61"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_61_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_61_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_61_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_61_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_61_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(62, LocalStringManager.GetConfig("TeammateBubble_language", "Name_62"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_62"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_62"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_62"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_62"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_62"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_62"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_62"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_62_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_62_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_62_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_62_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_62_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(63, LocalStringManager.GetConfig("TeammateBubble_language", "Name_63"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_63"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_63"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_63"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_63"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_63"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_63"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_63"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_63_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_63_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_63_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_63_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_63_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(64, LocalStringManager.GetConfig("TeammateBubble_language", "Name_64"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_64"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_64"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_64"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_64"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_64"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_64"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_64"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_64_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_64_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_64_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_64_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_64_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(65, LocalStringManager.GetConfig("TeammateBubble_language", "Name_65"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_65"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_65"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_65"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_65"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_65"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_65"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_65"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_65_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_65_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_65_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_65_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_65_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(66, LocalStringManager.GetConfig("TeammateBubble_language", "Name_66"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_66"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_66"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_66"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_66"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_66"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_66"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_66"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_66_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_66_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_66_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_66_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_66_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(67, LocalStringManager.GetConfig("TeammateBubble_language", "Name_67"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_67"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_67"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_67"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_67"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_67"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_67"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_67"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_67_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_67_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_67_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_67_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_67_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(68, LocalStringManager.GetConfig("TeammateBubble_language", "Name_68"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_68"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_68"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_68"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_68"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_68"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_68"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_68"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_68_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_68_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_68_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_68_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_68_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(69, LocalStringManager.GetConfig("TeammateBubble_language", "Name_69"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_69"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_69"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_69"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_69"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_69"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_69"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_69"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_69_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_69_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_69_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_69_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_69_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(70, LocalStringManager.GetConfig("TeammateBubble_language", "Name_70"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_70"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_70"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_70"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_70"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_70"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_70"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_70"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_70_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_70_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_70_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_70_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_70_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(71, LocalStringManager.GetConfig("TeammateBubble_language", "Name_71"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_71"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_71"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_71"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_71"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_71"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_71"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_71"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_71_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_71_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_71_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_71_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_71_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(72, LocalStringManager.GetConfig("TeammateBubble_language", "Name_72"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_72"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_72"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_72"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_72"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_72"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_72"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_72"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_72_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_72_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_72_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_72_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_72_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(73, LocalStringManager.GetConfig("TeammateBubble_language", "Name_73"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_73"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_73"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_73"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_73"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_73"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_73"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_73"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_73_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_73_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_73_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_73_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_73_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(74, LocalStringManager.GetConfig("TeammateBubble_language", "Name_74"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_74"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_74"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_74"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_74"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_74"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_74"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_74"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_74_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_74_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_74_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_74_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_74_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(75, LocalStringManager.GetConfig("TeammateBubble_language", "Name_75"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_75"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_75"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_75"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_75"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_75"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_75"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_75"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_75_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_75_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_75_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_75_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_75_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(76, LocalStringManager.GetConfig("TeammateBubble_language", "Name_76"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_76"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_76"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_76"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_76"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_76"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_76"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_76"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_76_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_76_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_76_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_76_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_76_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(77, LocalStringManager.GetConfig("TeammateBubble_language", "Name_77"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_77"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_77"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_77"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_77"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_77"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_77"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_77"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_77_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_77_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_77_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_77_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_77_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(78, LocalStringManager.GetConfig("TeammateBubble_language", "Name_78"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_78"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_78"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_78"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_78"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_78"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_78"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_78"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_78_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_78_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_78_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_78_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_78_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(79, LocalStringManager.GetConfig("TeammateBubble_language", "Name_79"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_79"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_79"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_79"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_79"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_79"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_79"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_79"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_79_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_79_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_79_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_79_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_79_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(80, LocalStringManager.GetConfig("TeammateBubble_language", "Name_80"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_80"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_80"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_80"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_80"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_80"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_80"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_80"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_80_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_80_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_80_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_80_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_80_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(81, LocalStringManager.GetConfig("TeammateBubble_language", "Name_81"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_81"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_81"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_81"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_81"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_81"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_81"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_81"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_81_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_81_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_81_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_81_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_81_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(82, LocalStringManager.GetConfig("TeammateBubble_language", "Name_82"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_82"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_82"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_82"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_82"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_82"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_82"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_82"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_82_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_82_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_82_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_82_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_82_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(83, LocalStringManager.GetConfig("TeammateBubble_language", "Name_83"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_83"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_83"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_83"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_83"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_83"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_83"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_83"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_83_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_83_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_83_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_83_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_83_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(84, LocalStringManager.GetConfig("TeammateBubble_language", "Name_84"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_84"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_84"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_84"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_84"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_84"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_84"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_84"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_84_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_84_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_84_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_84_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_84_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(85, LocalStringManager.GetConfig("TeammateBubble_language", "Name_85"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_85"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_85"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_85"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_85"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_85"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_85"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_85"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_85_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_85_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_85_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_85_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_85_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(86, LocalStringManager.GetConfig("TeammateBubble_language", "Name_86"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_86"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_86"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_86"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_86"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_86"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_86"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_86"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_86_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_86_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_86_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_86_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_86_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(87, LocalStringManager.GetConfig("TeammateBubble_language", "Name_87"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_87"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_87"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_87"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_87"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_87"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_87"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_87"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_87_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_87_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_87_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_87_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_87_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(88, LocalStringManager.GetConfig("TeammateBubble_language", "Name_88"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_88"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_88"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_88"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_88"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_88"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_88"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_88"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_88_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_88_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_88_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_88_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_88_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(89, LocalStringManager.GetConfig("TeammateBubble_language", "Name_89"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_89"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_89"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_89"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_89"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_89"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_89"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_89"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_89_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_89_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_89_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_89_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_89_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(90, LocalStringManager.GetConfig("TeammateBubble_language", "Name_90"), ETeammateBubbleBubbleElementType.SettlementAdventure, 180, -1, -1, null, null, null, 6, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_90"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_90"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_90"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_90"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_90"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_90"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_90"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_90_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_90_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_90_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_90_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_90_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(91, LocalStringManager.GetConfig("TeammateBubble_language", "Name_91"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, new List<int> { 282394811 }, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_91"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_91"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_91"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_91"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_91"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_91"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_91"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_91_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_91_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_91_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_91_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_91_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_91_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(92, LocalStringManager.GetConfig("TeammateBubble_language", "Name_92"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_92"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_92"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_92"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_92"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_92"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_92"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_92"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_92_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_92_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_92_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_92_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_92_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_92_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(93, LocalStringManager.GetConfig("TeammateBubble_language", "Name_93"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_93"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_93"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_93"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_93"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_93"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_93"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_93"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_93_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_93_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_93_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_93_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_93_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_93_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(94, LocalStringManager.GetConfig("TeammateBubble_language", "Name_94"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_94"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_94"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_94"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_94"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_94"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_94"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_94"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_94_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_94_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_94_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_94_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_94_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_94_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(95, LocalStringManager.GetConfig("TeammateBubble_language", "Name_95"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_95"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_95"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_95"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_95"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_95"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_95"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_95"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_95_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_95_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_95_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_95_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_95_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_95_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(96, LocalStringManager.GetConfig("TeammateBubble_language", "Name_96"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_96"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_96"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_96"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_96"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_96"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_96"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_96"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_96_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_96_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_96_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_96_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_96_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_96_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(97, LocalStringManager.GetConfig("TeammateBubble_language", "Name_97"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_97"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_97"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_97"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_97"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_97"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_97"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_97"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_97_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_97_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_97_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_97_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_97_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_97_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(98, LocalStringManager.GetConfig("TeammateBubble_language", "Name_98"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_98"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_98"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_98"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_98"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_98"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_98"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_98"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_98_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_98_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_98_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_98_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_98_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_98_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(99, LocalStringManager.GetConfig("TeammateBubble_language", "Name_99"), ETeammateBubbleBubbleElementType.SwordGrave, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_99"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_99"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_99"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_99"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_99"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_99"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_99"), new string[22]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_4"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_5"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_6"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_7"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_8"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_9"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_10"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_11"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_12"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_13"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_14"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_15"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_16"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_17"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_18"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_19"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_20"),
			LocalStringManager.GetConfig("TeammateBubble_language", "Cricket_99_21")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_99_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_99_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_99_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_99_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_99_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(100, LocalStringManager.GetConfig("TeammateBubble_language", "Name_100"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_100"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_100"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_100"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_100"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_100"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_100"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_100"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_100_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_100_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_100_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_100_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_100_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(101, LocalStringManager.GetConfig("TeammateBubble_language", "Name_101"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_101"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_101"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_101"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_101"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_101"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_101"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_101"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_101_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_101_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_101_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_101_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_101_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(102, LocalStringManager.GetConfig("TeammateBubble_language", "Name_102"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_102"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_102"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_102"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_102"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_102"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_102"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_102"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_102_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_102_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_102_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_102_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_102_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(103, LocalStringManager.GetConfig("TeammateBubble_language", "Name_103"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_103"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_103"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_103"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_103"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_103"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_103"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_103"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_103_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_103_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_103_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_103_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_103_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(104, LocalStringManager.GetConfig("TeammateBubble_language", "Name_104"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_104"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_104"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_104"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_104"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_104"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_104"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_104"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_104_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_104_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_104_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_104_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_104_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(105, LocalStringManager.GetConfig("TeammateBubble_language", "Name_105"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_105"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_105"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_105"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_105"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_105"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_105"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_105"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_105_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_105_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_105_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_105_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_105_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(106, LocalStringManager.GetConfig("TeammateBubble_language", "Name_106"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_106"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_106"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_106"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_106"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_106"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_106"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_106"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_106_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_106_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_106_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_106_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_106_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(107, LocalStringManager.GetConfig("TeammateBubble_language", "Name_107"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_107"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_107"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_107"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_107"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_107"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_107"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_107"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_107_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_107_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_107_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_107_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_107_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(108, LocalStringManager.GetConfig("TeammateBubble_language", "Name_108"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_108"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_108"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_108"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_108"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_108"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_108"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_108"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_108_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_108_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_108_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_108_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_108_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(109, LocalStringManager.GetConfig("TeammateBubble_language", "Name_109"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_109"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_109"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_109"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_109"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_109"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_109"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_109"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_109_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_109_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_109_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_109_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_109_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(110, LocalStringManager.GetConfig("TeammateBubble_language", "Name_110"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_110"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_110"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_110"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_110"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_110"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_110"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_110"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_110_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_110_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_110_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_110_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_110_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(111, LocalStringManager.GetConfig("TeammateBubble_language", "Name_111"), ETeammateBubbleBubbleElementType.Story, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_111"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_111"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_111"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_111"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_111"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_111"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_111"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_111_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_111_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_111_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_111_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_111_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(112, LocalStringManager.GetConfig("TeammateBubble_language", "Name_112"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_112"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_112"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_112"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_112"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_112"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_112"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_112"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_112_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_112_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_112_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_112_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_112_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(113, LocalStringManager.GetConfig("TeammateBubble_language", "Name_113"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_113"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_113"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_113"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_113"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_113"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_113"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_113"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_113_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_113_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_113_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_113_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_113_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(114, LocalStringManager.GetConfig("TeammateBubble_language", "Name_114"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_114"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_114"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_114"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_114"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_114"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_114"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_114"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_114_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_114_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_114_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_114_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_114_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(115, LocalStringManager.GetConfig("TeammateBubble_language", "Name_115"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_115"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_115"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_115"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_115"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_115"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_115"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_115"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_115_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_115_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_115_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_115_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_115_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(116, LocalStringManager.GetConfig("TeammateBubble_language", "Name_116"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_116"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_116"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_116"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_116"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_116"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_116"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_116"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_116_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_116_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_116_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_116_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_116_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(117, LocalStringManager.GetConfig("TeammateBubble_language", "Name_117"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_117"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_117"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_117"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_117"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_117"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_117"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_117"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_117_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_117_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_117_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_117_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_117_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(118, LocalStringManager.GetConfig("TeammateBubble_language", "Name_118"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_118"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_118"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_118"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_118"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_118"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_118"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_118"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_118_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_118_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_118_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_118_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_118_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(119, LocalStringManager.GetConfig("TeammateBubble_language", "Name_119"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_119"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_119"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_119"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_119"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_119"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_119"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_119"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_119_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_119_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_119_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_119_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_119_4")
		}, new string[3] { "", "", "" }));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new TeammateBubbleItem(120, LocalStringManager.GetConfig("TeammateBubble_language", "Name_120"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_120"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_120"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_120"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_120"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_120"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_120"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_120"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_120_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_120_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_120_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_120_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_120_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(121, LocalStringManager.GetConfig("TeammateBubble_language", "Name_121"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_121"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_121"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_121"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_121"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_121"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_121"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_121"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_121_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_121_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_121_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_121_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_121_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(122, LocalStringManager.GetConfig("TeammateBubble_language", "Name_122"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_122"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_122"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_122"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_122"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_122"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_122"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_122"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_122_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_122_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_122_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_122_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_122_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(123, LocalStringManager.GetConfig("TeammateBubble_language", "Name_123"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_123"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_123"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_123"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_123"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_123"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_123"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_123"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_123_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_123_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_123_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_123_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_123_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(124, LocalStringManager.GetConfig("TeammateBubble_language", "Name_124"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_124"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_124"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_124"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_124"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_124"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_124"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_124"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_124_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_124_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_124_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_124_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_124_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(125, LocalStringManager.GetConfig("TeammateBubble_language", "Name_125"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_125"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_125"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_125"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_125"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_125"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_125"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_125"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_125_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_125_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_125_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_125_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_125_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(126, LocalStringManager.GetConfig("TeammateBubble_language", "Name_126"), ETeammateBubbleBubbleElementType.EnemyNest, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_126"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_126"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_126"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_126"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_126"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_126"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_126"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_126_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_126_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_126_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_126_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_126_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(127, LocalStringManager.GetConfig("TeammateBubble_language", "Name_127"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_127"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_127"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_127"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_127"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_127"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_127"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_127"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_127_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_127_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_127_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_127_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_127_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(128, LocalStringManager.GetConfig("TeammateBubble_language", "Name_128"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_128"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_128"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_128"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_128"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_128"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_128"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_128"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_128_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_128_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_128_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_128_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_128_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(129, LocalStringManager.GetConfig("TeammateBubble_language", "Name_129"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_129"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_129"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_129"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_129"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_129"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_129"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_129"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_129_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_129_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_129_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_129_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_129_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(130, LocalStringManager.GetConfig("TeammateBubble_language", "Name_130"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_130"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_130"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_130"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_130"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_130"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_130"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_130"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_130_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_130_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_130_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_130_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_130_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(131, LocalStringManager.GetConfig("TeammateBubble_language", "Name_131"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_131"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_131"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_131"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_131"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_131"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_131"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_131"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_131_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_131_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_131_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_131_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_131_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(132, LocalStringManager.GetConfig("TeammateBubble_language", "Name_132"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_132"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_132"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_132"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_132"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_132"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_132"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_132"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_132_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_132_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_132_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_132_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_132_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(133, LocalStringManager.GetConfig("TeammateBubble_language", "Name_133"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_133"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_133"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_133"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_133"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_133"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_133"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_133"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_133_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_133_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_133_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_133_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_133_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(134, LocalStringManager.GetConfig("TeammateBubble_language", "Name_134"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_134"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_134"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_134"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_134"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_134"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_134"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_134"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_134_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_134_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_134_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_134_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_134_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(135, LocalStringManager.GetConfig("TeammateBubble_language", "Name_135"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_135"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_135"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_135"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_135"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_135"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_135"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_135"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_135_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_135_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_135_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_135_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_135_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(136, LocalStringManager.GetConfig("TeammateBubble_language", "Name_136"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_136"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_136"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_136"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_136"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_136"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_136"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_136"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_136_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_136_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_136_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_136_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_136_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(137, LocalStringManager.GetConfig("TeammateBubble_language", "Name_137"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_137"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_137"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_137"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_137"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_137"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_137"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_137"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_137_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_137_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_137_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_137_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_137_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(138, LocalStringManager.GetConfig("TeammateBubble_language", "Name_138"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_138"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_138"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_138"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_138"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_138"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_138"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_138"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_138_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_138_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_138_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_138_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_138_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(139, LocalStringManager.GetConfig("TeammateBubble_language", "Name_139"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_139"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_139"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_139"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_139"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_139"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_139"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_139"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_139_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_139_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_139_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_139_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_139_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(140, LocalStringManager.GetConfig("TeammateBubble_language", "Name_140"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_140"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_140"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_140"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_140"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_140"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_140"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_140"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_140_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_140_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_140_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_140_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_140_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(141, LocalStringManager.GetConfig("TeammateBubble_language", "Name_141"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_141"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_141"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_141"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_141"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_141"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_141"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_141"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_141_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_141_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_141_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_141_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_141_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(142, LocalStringManager.GetConfig("TeammateBubble_language", "Name_142"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_142"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_142"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_142"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_142"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_142"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_142"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_142"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_142_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_142_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_142_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_142_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_142_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(143, LocalStringManager.GetConfig("TeammateBubble_language", "Name_143"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_143"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_143"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_143"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_143"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_143"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_143"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_143"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_143_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_143_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_143_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_143_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_143_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(144, LocalStringManager.GetConfig("TeammateBubble_language", "Name_144"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_144"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_144"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_144"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_144"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_144"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_144"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_144"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_144_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_144_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_144_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_144_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_144_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(145, LocalStringManager.GetConfig("TeammateBubble_language", "Name_145"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_145"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_145"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_145"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_145"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_145"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_145"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_145"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_145_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_145_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_145_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_145_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_145_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(146, LocalStringManager.GetConfig("TeammateBubble_language", "Name_146"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_146"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_146"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_146"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_146"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_146"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_146"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_146"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_146_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_146_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_146_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_146_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_146_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(147, LocalStringManager.GetConfig("TeammateBubble_language", "Name_147"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_147"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_147"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_147"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_147"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_147"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_147"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_147"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_147_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_147_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_147_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_147_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_147_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(148, LocalStringManager.GetConfig("TeammateBubble_language", "Name_148"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_148"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_148"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_148"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_148"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_148"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_148"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_148"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_148_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_148_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_148_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_148_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_148_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(149, LocalStringManager.GetConfig("TeammateBubble_language", "Name_149"), ETeammateBubbleBubbleElementType.Treasure, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_149"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_149"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_149"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_149"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_149"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_149"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_149"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_149_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_149_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_149_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_149_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_149_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(150, LocalStringManager.GetConfig("TeammateBubble_language", "Name_150"), ETeammateBubbleBubbleElementType.Queerbook, 180, -1, -1, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_150"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_150"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_150"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_150"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_150"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_150"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_150"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_150_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_150_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_150_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_150_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_150_4")
		}, new string[3] { "Adventure", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(151, LocalStringManager.GetConfig("TeammateBubble_language", "Name_151"), ETeammateBubbleBubbleElementType.None, 180, -1, -1, null, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_151"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_151"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_151"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_151"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_151"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_151"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_151"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_151_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_151_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_151_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_151_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_151_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(152, LocalStringManager.GetConfig("TeammateBubble_language", "Name_152"), ETeammateBubbleBubbleElementType.None, 180, -1, -1, new List<short>
		{
			296, 297, 298, 299, 300, 301, 302, 303, 304, 305,
			306, 307, 308, 309, 310, 311, 312, 313, 314, 315,
			316, 317, 318, 319, 320, 321, 322, 323, 324, 325,
			326, 327, 328, 329, 330, 331, 332, 333, 334, 335,
			336, 337, 338, 339, 340, 341, 342, 343, 344, 345,
			346, 347, 348, 349, 350, 351, 352, 353, 354, 355,
			356, 357, 358, 359, 360, 361, 362, 363, 364, 365
		}, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_152"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_152"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_152"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_152"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_152"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_152"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_152"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_152_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_152_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_152_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_152_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_152_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(153, LocalStringManager.GetConfig("TeammateBubble_language", "Name_153"), ETeammateBubbleBubbleElementType.None, 180, -1, -1, new List<short> { 375, 376, 377, 378, 379, 380, 381, 382, 383 }, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_153"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_153"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_153"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_153"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_153"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_153"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_153"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_153_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_153_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_153_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_153_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_153_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(154, LocalStringManager.GetConfig("TeammateBubble_language", "Name_154"), ETeammateBubbleBubbleElementType.None, 180, -1, -1, new List<short> { 366, 367, 368, 369, 370, 371, 372, 373, 374 }, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_154"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_154"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_154"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_154"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_154"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_154"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_154"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_154_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_154_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_154_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_154_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_154_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(155, LocalStringManager.GetConfig("TeammateBubble_language", "Name_155"), ETeammateBubbleBubbleElementType.Animal, 180, -1, -1, new List<short>
		{
			228, 229, 230, 231, 232, 233, 234, 235, 236, 237,
			238, 239, 240, 241, 242, 243, 244, 245
		}, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_155"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_155"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_155"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_155"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_155"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_155"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_155"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_155_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_155_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_155_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_155_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_155_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(156, LocalStringManager.GetConfig("TeammateBubble_language", "Name_156"), ETeammateBubbleBubbleElementType.Animal, 180, -1, -1, null, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_156"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_156"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_156"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_156"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_156"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_156"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_156"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_156_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_156_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_156_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_156_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_156_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(157, LocalStringManager.GetConfig("TeammateBubble_language", "Name_157"), ETeammateBubbleBubbleElementType.Caravan, 180, -1, -1, null, null, null, 0, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_157"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_157"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_157"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_157"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_157"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_157"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_157"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_157_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_157_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_157_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_157_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_157_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(158, LocalStringManager.GetConfig("TeammateBubble_language", "Name_158"), ETeammateBubbleBubbleElementType.RelatedCharacter, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_158"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_158"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_158"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_158"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_158"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_158"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_158"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_158_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_158_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_158_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_158_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_158_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(159, LocalStringManager.GetConfig("TeammateBubble_language", "Name_159"), ETeammateBubbleBubbleElementType.RelatedCharacter, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_159"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_159"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_159"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_159"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_159"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_159"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_159"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_159_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_159_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_159_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_159_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_159_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(160, LocalStringManager.GetConfig("TeammateBubble_language", "Name_160"), ETeammateBubbleBubbleElementType.RelatedCharacter, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_160"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_160"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_160"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_160"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_160"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_160"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_160"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_160_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_160_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_160_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_160_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_160_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(161, LocalStringManager.GetConfig("TeammateBubble_language", "Name_161"), ETeammateBubbleBubbleElementType.None, 180, -1, -1, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_161"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_161"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_161"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_161"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_161"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_161"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_161"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_161_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_161_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_161_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_161_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_161_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(162, LocalStringManager.GetConfig("TeammateBubble_language", "Name_162"), ETeammateBubbleBubbleElementType.None, 180, -1, -1, null, null, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_162"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_162"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_162"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_162"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_162"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_162"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_162"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_162_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_162_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_162_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_162_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_162_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(163, LocalStringManager.GetConfig("TeammateBubble_language", "Name_163"), ETeammateBubbleBubbleElementType.Infected, 180, -1, -1, null, new List<short> { 210 }, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_163"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_163"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_163"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_163"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_163"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_163"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_163"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_163_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_163_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_163_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_163_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_163_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(164, LocalStringManager.GetConfig("TeammateBubble_language", "Name_164"), ETeammateBubbleBubbleElementType.Infected, 180, -1, -1, null, new List<short> { 211 }, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_164"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_164"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_164"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_164"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_164"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_164"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_164"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_164_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_164_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_164_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_164_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_164_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(165, LocalStringManager.GetConfig("TeammateBubble_language", "Name_165"), ETeammateBubbleBubbleElementType.LegendaryBookInsane, 180, -1, -1, null, new List<short> { 214, 215 }, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_165"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_165"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_165"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_165"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_165"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_165"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_165"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_165_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_165_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_165_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_165_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_165_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(166, LocalStringManager.GetConfig("TeammateBubble_language", "Name_166"), ETeammateBubbleBubbleElementType.LegendaryBookInsane, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_166"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_166"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_166"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_166"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_166"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_166"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_166"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_166_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_166_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_166_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_166_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_166_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(167, LocalStringManager.GetConfig("TeammateBubble_language", "Name_167"), ETeammateBubbleBubbleElementType.Grave, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_167"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_167"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_167"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_167"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_167"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_167"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_167"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_167_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_167_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_167_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_167_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_167_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(168, LocalStringManager.GetConfig("TeammateBubble_language", "Name_168"), ETeammateBubbleBubbleElementType.SectLeader, 180, -1, -1, null, new List<short> { 696 }, null, 1, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_168"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_168"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_168"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_168"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_168"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_168"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_168"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_168_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_168_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_168_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_168_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_168_4")
		}, new string[3] { "Settlement", "OrgGrade", "" }));
		_dataArray.Add(new TeammateBubbleItem(169, LocalStringManager.GetConfig("TeammateBubble_language", "Name_169"), ETeammateBubbleBubbleElementType.Cricket, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_169"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_169"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_169"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_169"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_169"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_169"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_169"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_169_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_169_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_169_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_169_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_169_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(170, LocalStringManager.GetConfig("TeammateBubble_language", "Name_170"), ETeammateBubbleBubbleElementType.Worker, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_170"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_170"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_170"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_170"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_170"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_170"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_170"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_170_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_170_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_170_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_170_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_170_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(171, LocalStringManager.GetConfig("TeammateBubble_language", "Name_171"), ETeammateBubbleBubbleElementType.Lost, 180, -1, -1, null, null, null, 5, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_171"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_171"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_171"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_171"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_171"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_171"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_171"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_171_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_171_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_171_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_171_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_171_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(172, LocalStringManager.GetConfig("TeammateBubble_language", "Name_172"), ETeammateBubbleBubbleElementType.Traveling, 180, 1, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_172"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_172"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_172"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_172"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_172"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_172"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_172"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_172_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_172_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_172_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_172_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_172_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(173, LocalStringManager.GetConfig("TeammateBubble_language", "Name_173"), ETeammateBubbleBubbleElementType.Traveling, 180, 2, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_173"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_173"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_173"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_173"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_173"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_173"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_173"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_173_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_173_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_173_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_173_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_173_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(174, LocalStringManager.GetConfig("TeammateBubble_language", "Name_174"), ETeammateBubbleBubbleElementType.Traveling, 180, 3, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_174"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_174"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_174"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_174"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_174"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_174"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_174"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_174_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_174_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_174_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_174_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_174_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(175, LocalStringManager.GetConfig("TeammateBubble_language", "Name_175"), ETeammateBubbleBubbleElementType.Traveling, 180, 4, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_175"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_175"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_175"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_175"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_175"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_175"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_175"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_175_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_175_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_175_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_175_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_175_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(176, LocalStringManager.GetConfig("TeammateBubble_language", "Name_176"), ETeammateBubbleBubbleElementType.Traveling, 180, 5, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_176"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_176"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_176"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_176"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_176"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_176"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_176"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_176_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_176_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_176_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_176_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_176_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(177, LocalStringManager.GetConfig("TeammateBubble_language", "Name_177"), ETeammateBubbleBubbleElementType.Traveling, 180, 6, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_177"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_177"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_177"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_177"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_177"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_177"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_177"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_177_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_177_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_177_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_177_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_177_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(178, LocalStringManager.GetConfig("TeammateBubble_language", "Name_178"), ETeammateBubbleBubbleElementType.Traveling, 180, 7, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_178"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_178"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_178"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_178"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_178"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_178"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_178"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_178_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_178_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_178_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_178_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_178_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(179, LocalStringManager.GetConfig("TeammateBubble_language", "Name_179"), ETeammateBubbleBubbleElementType.Traveling, 180, 8, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_179"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_179"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_179"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_179"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_179"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_179"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_179"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_179_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_179_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_179_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_179_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_179_4")
		}, new string[3] { "", "", "" }));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new TeammateBubbleItem(180, LocalStringManager.GetConfig("TeammateBubble_language", "Name_180"), ETeammateBubbleBubbleElementType.Traveling, 180, 9, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_180"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_180"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_180"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_180"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_180"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_180"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_180"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_180_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_180_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_180_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_180_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_180_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(181, LocalStringManager.GetConfig("TeammateBubble_language", "Name_181"), ETeammateBubbleBubbleElementType.Traveling, 180, 10, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_181"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_181"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_181"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_181"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_181"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_181"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_181"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_181_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_181_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_181_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_181_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_181_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(182, LocalStringManager.GetConfig("TeammateBubble_language", "Name_182"), ETeammateBubbleBubbleElementType.Traveling, 180, 11, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_182"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_182"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_182"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_182"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_182"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_182"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_182"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_182_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_182_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_182_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_182_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_182_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(183, LocalStringManager.GetConfig("TeammateBubble_language", "Name_183"), ETeammateBubbleBubbleElementType.Traveling, 180, 12, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_183"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_183"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_183"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_183"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_183"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_183"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_183"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_183_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_183_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_183_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_183_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_183_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(184, LocalStringManager.GetConfig("TeammateBubble_language", "Name_184"), ETeammateBubbleBubbleElementType.Traveling, 180, 13, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_184"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_184"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_184"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_184"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_184"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_184"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_184"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_184_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_184_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_184_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_184_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_184_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(185, LocalStringManager.GetConfig("TeammateBubble_language", "Name_185"), ETeammateBubbleBubbleElementType.Traveling, 180, 14, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_185"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_185"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_185"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_185"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_185"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_185"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_185"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_185_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_185_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_185_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_185_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_185_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(186, LocalStringManager.GetConfig("TeammateBubble_language", "Name_186"), ETeammateBubbleBubbleElementType.Traveling, 180, 15, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_186"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_186"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_186"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_186"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_186"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_186"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_186"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_186_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_186_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_186_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_186_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_186_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(187, LocalStringManager.GetConfig("TeammateBubble_language", "Name_187"), ETeammateBubbleBubbleElementType.DestroyedArea, 180, -1, -1, null, null, null, 4, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_187"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_187"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_187"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_187"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_187"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_187"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_187"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_187_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_187_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_187_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_187_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_187_4")
		}, new string[3] { "", "", "" }));
		_dataArray.Add(new TeammateBubbleItem(188, LocalStringManager.GetConfig("TeammateBubble_language", "Name_188"), ETeammateBubbleBubbleElementType.StoryMapblockEffect, 180, -1, -1, null, null, null, 3, LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc0_188"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc1_188"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc2_188"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc3_188"), LocalStringManager.GetConfig("TeammateBubble_language", "SpecialDesc4_188"), LocalStringManager.GetConfig("TeammateBubble_language", "FamilyDesc_188"), LocalStringManager.GetConfig("TeammateBubble_language", "FriendDesc_188"), new string[0], new string[5]
		{
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_188_0"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_188_1"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_188_2"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_188_3"),
			LocalStringManager.GetConfig("TeammateBubble_language", "BehaviorDesc_188_4")
		}, new string[3] { "", "", "" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TeammateBubbleItem>(189);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
	}
}
