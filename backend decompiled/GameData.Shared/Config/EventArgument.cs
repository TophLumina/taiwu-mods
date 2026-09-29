using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class EventArgument : ConfigData<EventArgumentItem, int>
{
	public static class DefKey
	{
		public const int Dynamic = 0;

		public const int Integer = 1;

		public const int Float = 2;

		public const int Bool = 3;

		public const int String = 4;

		public const int Condition = 72;

		public const int Event = 5;

		public const int GlobalScript = 48;

		public const int Character = 6;

		public const int Item = 7;

		public const int ItemList = 85;

		public const int ItemTemplate = 8;

		public const int ItemTemplateList = 78;

		public const int MapBlock = 9;

		public const int MapBlockTemplate = 105;

		public const int Settlement = 10;

		public const int SettlementType = 59;

		public const int Sect = 11;

		public const int SectFunctionStatusType = 67;

		public const int MapArea = 12;

		public const int MapState = 47;

		public const int MapBlockMatcher = 58;

		public const int Grade = 13;

		public const int BodyPartType = 14;

		public const int PoisonType = 15;

		public const int WugType = 16;

		public const int BehaviorType = 17;

		public const int PersonalityType = 18;

		public const int MainAttributeType = 19;

		public const int FavorabilityType = 53;

		public const int CharacterPropertyReferenced = 96;

		public const int CharacterPropertyModifyType = 97;

		public const int Gender = 20;

		public const int ResourceType = 21;

		public const int ItemType = 22;

		public const int ItemSubType = 23;

		public const int CombatSkillType = 24;

		public const int LifeSkillType = 25;

		public const int LifeSkill = 51;

		public const int EquipmentSlot = 26;

		public const int CombatSkillEquipType = 27;

		public const int FiveElementsType = 28;

		public const int CharacterFeature = 29;

		public const int LegacyPoint = 30;

		public const int CharacterDeathType = 31;

		public const int CharacterMatcher = 60;

		public const int MainStoryLineProgress = 32;

		public const int WorldFunctionType = 33;

		public const int CricketPartsTemplate = 34;

		public const int CombatSkillTemplate = 35;

		public const int LifeSkillTemplate = 36;

		public const int MerchantType = 37;

		public const int TaskInfo = 38;

		public const int TaskChain = 39;

		public const int AdventureTemplate = 40;

		public const int ConditionOperator = 41;

		public const int CombatConfig = 42;

		public const int CombatResultType = 43;

		public const int CombatType = 84;

		public const int EventActorTemplate = 44;

		public const int EnemyCharacterTemplate = 45;

		public const int FixedCharacterTemplate = 46;

		public const int CharacterSearchRange = 49;

		public const int CharacterFilterRules = 50;

		public const int Profession = 52;

		public const int ProfessionSkill = 107;

		public const int MonthlyActions = 54;

		public const int BuildingBlockTemplate = 55;

		public const int MerchantTemplate = 56;

		public const int AgeGroup = 57;

		public const int WorldFavorability = 63;

		public const int AdventureRemakeElementCoreId = 61;

		public const int AdventureRemakeElementTag = 62;

		public const int EnemyNestTemplate = 64;

		public const int AdventureRemakeBlockRangeType = 65;

		public const int AdventureRemakeViewType = 66;

		public const int StateTaskStatus = 68;

		public const int CharacterTemplate = 69;

		public const int NpcCombatResultType = 70;

		public const int MajorEventTemplate = 71;

		public const int TagArrayMatchType = 73;

		public const int RandomEnemyCharacterTemplate = 74;

		public const int RandomEnemyTemplate = 75;

		public const int NeiliAllocationType = 76;

		public const int EventCommonOptionType = 77;

		public const int EquipmentEffect = 79;

		public const int InstantNotificationTemplate = 80;

		public const int AdventureRemakeTemplate = 81;

		public const int AdventureElement = 82;

		public const int HarmfulActionPhase = 83;

		public const int CutsceneTemplate = 86;

		public const int CgTextureTemplate = 101;

		public const int AdventureBlockIndex = 87;

		public const int RelationType = 88;

		public const int OneWayRelationType = 127;

		public const int SectMainStoryEventArgKey = 89;

		public const int InteractionEventOption = 90;

		public const int LanguageKey = 91;

		public const int NormalInformation = 92;

		public const int MonthlyEventTemplate = 93;

		public const int MonthlyNotificationTemplate = 94;

		public const int GraveLevel = 95;

		public const int NormalInformationData = 98;

		public const int InformationType = 99;

		public const int TutorialVideoTemplate = 100;

		public const int InventoryItemOperationType = 102;

		public const int TutorialFunctionType = 103;

		public const int TutorialChapter = 104;

		public const int EventActionKey = 106;

		public const int EventTriggerParameter = 108;

		public const int SectGoodness = 111;

		public const int GuidingChapter = 112;

		public const int GuidingChapterState = 113;

		public const int GuidingChapterTrigger = 114;

		public const int TaiwuLifeSummaryType = 115;

		public const int StatInfo = 116;

		public const int XiangshuAvatarId = 118;

		public const int JuniorXiangshuTaskStatus = 119;

		public const int XiangshuAvatarDisplayStatus = 120;

		public const int SwordTombInformationType = 121;

		public const int EventSelectCharacterRange = 122;

		public const int Weather = 123;

		public const int CharacterTitle = 124;

		public const int Fame = 125;

		public const int Clothing = 126;

		public const int TwelveImmortals = 128;

		public const int AssisterDefeatTwelveImmortalsProgress = 129;

		public const int ChickenTemplate = 130;

		public const int DlcTemplate = 131;

		public const int DlcEventArgKey = 132;

		public const int TwelveImmortalsStatus = 133;

		public const int TwelveImmortalsCharacterTemplate = 134;

		public const int ThreeRealmsPowerCharacterTemplate = 135;

		public const int NewFunctionUnlockTemplate = 136;
	}

	public static class DefValue
	{
		public static EventArgumentItem Dynamic => Instance[0];

		public static EventArgumentItem Integer => Instance[1];

		public static EventArgumentItem Float => Instance[2];

		public static EventArgumentItem Bool => Instance[3];

		public static EventArgumentItem String => Instance[4];

		public static EventArgumentItem Condition => Instance[72];

		public static EventArgumentItem Event => Instance[5];

		public static EventArgumentItem GlobalScript => Instance[48];

		public static EventArgumentItem Character => Instance[6];

		public static EventArgumentItem Item => Instance[7];

		public static EventArgumentItem ItemList => Instance[85];

		public static EventArgumentItem ItemTemplate => Instance[8];

		public static EventArgumentItem ItemTemplateList => Instance[78];

		public static EventArgumentItem MapBlock => Instance[9];

		public static EventArgumentItem MapBlockTemplate => Instance[105];

		public static EventArgumentItem Settlement => Instance[10];

		public static EventArgumentItem SettlementType => Instance[59];

		public static EventArgumentItem Sect => Instance[11];

		public static EventArgumentItem SectFunctionStatusType => Instance[67];

		public static EventArgumentItem MapArea => Instance[12];

		public static EventArgumentItem MapState => Instance[47];

		public static EventArgumentItem MapBlockMatcher => Instance[58];

		public static EventArgumentItem Grade => Instance[13];

		public static EventArgumentItem BodyPartType => Instance[14];

		public static EventArgumentItem PoisonType => Instance[15];

		public static EventArgumentItem WugType => Instance[16];

		public static EventArgumentItem BehaviorType => Instance[17];

		public static EventArgumentItem PersonalityType => Instance[18];

		public static EventArgumentItem MainAttributeType => Instance[19];

		public static EventArgumentItem FavorabilityType => Instance[53];

		public static EventArgumentItem CharacterPropertyReferenced => Instance[96];

		public static EventArgumentItem CharacterPropertyModifyType => Instance[97];

		public static EventArgumentItem Gender => Instance[20];

		public static EventArgumentItem ResourceType => Instance[21];

		public static EventArgumentItem ItemType => Instance[22];

		public static EventArgumentItem ItemSubType => Instance[23];

		public static EventArgumentItem CombatSkillType => Instance[24];

		public static EventArgumentItem LifeSkillType => Instance[25];

		public static EventArgumentItem LifeSkill => Instance[51];

		public static EventArgumentItem EquipmentSlot => Instance[26];

		public static EventArgumentItem CombatSkillEquipType => Instance[27];

		public static EventArgumentItem FiveElementsType => Instance[28];

		public static EventArgumentItem CharacterFeature => Instance[29];

		public static EventArgumentItem LegacyPoint => Instance[30];

		public static EventArgumentItem CharacterDeathType => Instance[31];

		public static EventArgumentItem CharacterMatcher => Instance[60];

		public static EventArgumentItem MainStoryLineProgress => Instance[32];

		public static EventArgumentItem WorldFunctionType => Instance[33];

		public static EventArgumentItem CricketPartsTemplate => Instance[34];

		public static EventArgumentItem CombatSkillTemplate => Instance[35];

		public static EventArgumentItem LifeSkillTemplate => Instance[36];

		public static EventArgumentItem MerchantType => Instance[37];

		public static EventArgumentItem TaskInfo => Instance[38];

		public static EventArgumentItem TaskChain => Instance[39];

		public static EventArgumentItem AdventureTemplate => Instance[40];

		public static EventArgumentItem ConditionOperator => Instance[41];

		public static EventArgumentItem CombatConfig => Instance[42];

		public static EventArgumentItem CombatResultType => Instance[43];

		public static EventArgumentItem CombatType => Instance[84];

		public static EventArgumentItem EventActorTemplate => Instance[44];

		public static EventArgumentItem EnemyCharacterTemplate => Instance[45];

		public static EventArgumentItem FixedCharacterTemplate => Instance[46];

		public static EventArgumentItem CharacterSearchRange => Instance[49];

		public static EventArgumentItem CharacterFilterRules => Instance[50];

		public static EventArgumentItem Profession => Instance[52];

		public static EventArgumentItem ProfessionSkill => Instance[107];

		public static EventArgumentItem MonthlyActions => Instance[54];

		public static EventArgumentItem BuildingBlockTemplate => Instance[55];

		public static EventArgumentItem MerchantTemplate => Instance[56];

		public static EventArgumentItem AgeGroup => Instance[57];

		public static EventArgumentItem WorldFavorability => Instance[63];

		public static EventArgumentItem AdventureRemakeElementCoreId => Instance[61];

		public static EventArgumentItem AdventureRemakeElementTag => Instance[62];

		public static EventArgumentItem EnemyNestTemplate => Instance[64];

		public static EventArgumentItem AdventureRemakeBlockRangeType => Instance[65];

		public static EventArgumentItem AdventureRemakeViewType => Instance[66];

		public static EventArgumentItem StateTaskStatus => Instance[68];

		public static EventArgumentItem CharacterTemplate => Instance[69];

		public static EventArgumentItem NpcCombatResultType => Instance[70];

		public static EventArgumentItem MajorEventTemplate => Instance[71];

		public static EventArgumentItem TagArrayMatchType => Instance[73];

		public static EventArgumentItem RandomEnemyCharacterTemplate => Instance[74];

		public static EventArgumentItem RandomEnemyTemplate => Instance[75];

		public static EventArgumentItem NeiliAllocationType => Instance[76];

		public static EventArgumentItem EventCommonOptionType => Instance[77];

		public static EventArgumentItem EquipmentEffect => Instance[79];

		public static EventArgumentItem InstantNotificationTemplate => Instance[80];

		public static EventArgumentItem AdventureRemakeTemplate => Instance[81];

		public static EventArgumentItem AdventureElement => Instance[82];

		public static EventArgumentItem HarmfulActionPhase => Instance[83];

		public static EventArgumentItem CutsceneTemplate => Instance[86];

		public static EventArgumentItem CgTextureTemplate => Instance[101];

		public static EventArgumentItem AdventureBlockIndex => Instance[87];

		public static EventArgumentItem RelationType => Instance[88];

		public static EventArgumentItem OneWayRelationType => Instance[127];

		public static EventArgumentItem SectMainStoryEventArgKey => Instance[89];

		public static EventArgumentItem InteractionEventOption => Instance[90];

		public static EventArgumentItem LanguageKey => Instance[91];

		public static EventArgumentItem NormalInformation => Instance[92];

		public static EventArgumentItem MonthlyEventTemplate => Instance[93];

		public static EventArgumentItem MonthlyNotificationTemplate => Instance[94];

		public static EventArgumentItem GraveLevel => Instance[95];

		public static EventArgumentItem NormalInformationData => Instance[98];

		public static EventArgumentItem InformationType => Instance[99];

		public static EventArgumentItem TutorialVideoTemplate => Instance[100];

		public static EventArgumentItem InventoryItemOperationType => Instance[102];

		public static EventArgumentItem TutorialFunctionType => Instance[103];

		public static EventArgumentItem TutorialChapter => Instance[104];

		public static EventArgumentItem EventActionKey => Instance[106];

		public static EventArgumentItem EventTriggerParameter => Instance[108];

		public static EventArgumentItem SectGoodness => Instance[111];

		public static EventArgumentItem GuidingChapter => Instance[112];

		public static EventArgumentItem GuidingChapterState => Instance[113];

		public static EventArgumentItem GuidingChapterTrigger => Instance[114];

		public static EventArgumentItem TaiwuLifeSummaryType => Instance[115];

		public static EventArgumentItem StatInfo => Instance[116];

		public static EventArgumentItem XiangshuAvatarId => Instance[118];

		public static EventArgumentItem JuniorXiangshuTaskStatus => Instance[119];

		public static EventArgumentItem XiangshuAvatarDisplayStatus => Instance[120];

		public static EventArgumentItem SwordTombInformationType => Instance[121];

		public static EventArgumentItem EventSelectCharacterRange => Instance[122];

		public static EventArgumentItem Weather => Instance[123];

		public static EventArgumentItem CharacterTitle => Instance[124];

		public static EventArgumentItem Fame => Instance[125];

		public static EventArgumentItem Clothing => Instance[126];

		public static EventArgumentItem TwelveImmortals => Instance[128];

		public static EventArgumentItem AssisterDefeatTwelveImmortalsProgress => Instance[129];

		public static EventArgumentItem ChickenTemplate => Instance[130];

		public static EventArgumentItem DlcTemplate => Instance[131];

		public static EventArgumentItem DlcEventArgKey => Instance[132];

		public static EventArgumentItem TwelveImmortalsStatus => Instance[133];

		public static EventArgumentItem TwelveImmortalsCharacterTemplate => Instance[134];

		public static EventArgumentItem ThreeRealmsPowerCharacterTemplate => Instance[135];

		public static EventArgumentItem NewFunctionUnlockTemplate => Instance[136];
	}

	public static EventArgument Instance = new EventArgument();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "CustomEnumText", "TemplateId", "DefaultValue", "ConfigTable" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new EventArgumentItem(0, EEventArgumentType.Basic, LocalStringManager.GetConfig("EventArgument_language", "Name_0"), LocalStringManager.GetConfig("EventArgument_language", "Desc_0"), "0", isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(1, EEventArgumentType.Basic, LocalStringManager.GetConfig("EventArgument_language", "Name_1"), LocalStringManager.GetConfig("EventArgument_language", "Desc_1"), "0", isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(2, EEventArgumentType.Basic, LocalStringManager.GetConfig("EventArgument_language", "Name_2"), LocalStringManager.GetConfig("EventArgument_language", "Desc_2"), "0", isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(3, EEventArgumentType.Basic, LocalStringManager.GetConfig("EventArgument_language", "Name_3"), LocalStringManager.GetConfig("EventArgument_language", "Desc_3"), "0", isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(4, EEventArgumentType.Basic, LocalStringManager.GetConfig("EventArgument_language", "Name_4"), LocalStringManager.GetConfig("EventArgument_language", "Desc_4"), null, isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(5, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_5"), LocalStringManager.GetConfig("EventArgument_language", "Desc_5"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(6, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_6"), LocalStringManager.GetConfig("EventArgument_language", "Desc_6"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(7, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_7"), LocalStringManager.GetConfig("EventArgument_language", "Desc_7"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(8, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_8"), LocalStringManager.GetConfig("EventArgument_language", "Desc_8"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(9, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_9"), LocalStringManager.GetConfig("EventArgument_language", "Desc_9"), null, isExpression: true, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(10, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_10"), LocalStringManager.GetConfig("EventArgument_language", "Desc_10"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(11, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_11"), LocalStringManager.GetConfig("EventArgument_language", "Desc_11"), null, isExpression: false, allowSwitchingExpression: true, "Organization", new string[0], new int[0], new IntPair(1, 15)));
		_dataArray.Add(new EventArgumentItem(12, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_12"), LocalStringManager.GetConfig("EventArgument_language", "Desc_12"), null, isExpression: false, allowSwitchingExpression: true, "MapArea", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(13, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_13"), LocalStringManager.GetConfig("EventArgument_language", "Desc_13"), null, isExpression: false, allowSwitchingExpression: true, null, new string[10]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_6"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_7"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_8"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_13_9")
		}, new int[10] { -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(14, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_14"), LocalStringManager.GetConfig("EventArgument_language", "Desc_14"), null, isExpression: false, allowSwitchingExpression: true, "BodyPart", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(15, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_15"), LocalStringManager.GetConfig("EventArgument_language", "Desc_15"), null, isExpression: false, allowSwitchingExpression: true, "Poison", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(16, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_16"), LocalStringManager.GetConfig("EventArgument_language", "Desc_16"), null, isExpression: false, allowSwitchingExpression: true, null, new string[8]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_6"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_16_7")
		}, new int[0], new IntPair(0, 7)));
		_dataArray.Add(new EventArgumentItem(17, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_17"), LocalStringManager.GetConfig("EventArgument_language", "Desc_17"), null, isExpression: false, allowSwitchingExpression: true, "BehaviorType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(18, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_18"), LocalStringManager.GetConfig("EventArgument_language", "Desc_18"), null, isExpression: false, allowSwitchingExpression: true, null, new string[7]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_18_6")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(19, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_19"), LocalStringManager.GetConfig("EventArgument_language", "Desc_19"), null, isExpression: false, allowSwitchingExpression: true, null, new string[6]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_19_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_19_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_19_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_19_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_19_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_19_5")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(20, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_20"), LocalStringManager.GetConfig("EventArgument_language", "Desc_20"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_20_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_20_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_20_2")
		}, new int[3] { -1, 0, 1 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(21, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_21"), LocalStringManager.GetConfig("EventArgument_language", "Desc_21"), null, isExpression: false, allowSwitchingExpression: true, "ResourceType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(22, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_22"), LocalStringManager.GetConfig("EventArgument_language", "Desc_22"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(23, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_23"), LocalStringManager.GetConfig("EventArgument_language", "Desc_23"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(24, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_24"), LocalStringManager.GetConfig("EventArgument_language", "Desc_24"), null, isExpression: false, allowSwitchingExpression: true, "CombatSkillType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(25, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_25"), LocalStringManager.GetConfig("EventArgument_language", "Desc_25"), null, isExpression: false, allowSwitchingExpression: true, "LifeSkillType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(26, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_26"), LocalStringManager.GetConfig("EventArgument_language", "Desc_26"), null, isExpression: false, allowSwitchingExpression: true, null, new string[18]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_6"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_7"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_8"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_9"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_10"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_11"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_12"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_13"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_14"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_15"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_16"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_26_17")
		}, new int[18]
		{
			-1, 0, 1, 2, 3, 4, 5, 6, 7, 8,
			9, 10, 11, 12, 13, 14, 15, 16
		}, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(27, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_27"), LocalStringManager.GetConfig("EventArgument_language", "Desc_27"), null, isExpression: false, allowSwitchingExpression: true, null, new string[5]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_27_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_27_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_27_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_27_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_27_4")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(28, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_28"), LocalStringManager.GetConfig("EventArgument_language", "Desc_28"), null, isExpression: false, allowSwitchingExpression: true, null, new string[6]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_28_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_28_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_28_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_28_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_28_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_28_5")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(29, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_29"), LocalStringManager.GetConfig("EventArgument_language", "Desc_29"), null, isExpression: false, allowSwitchingExpression: true, "CharacterFeature", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(30, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_30"), LocalStringManager.GetConfig("EventArgument_language", "Desc_30"), null, isExpression: false, allowSwitchingExpression: true, "LegacyPoint", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(31, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_31"), LocalStringManager.GetConfig("EventArgument_language", "Desc_31"), null, isExpression: false, allowSwitchingExpression: true, "CharacterDeathType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(32, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_32"), LocalStringManager.GetConfig("EventArgument_language", "Desc_32"), null, isExpression: false, allowSwitchingExpression: true, "MainStoryLineProgress", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(33, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_33"), LocalStringManager.GetConfig("EventArgument_language", "Desc_33"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(34, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_34"), LocalStringManager.GetConfig("EventArgument_language", "Desc_34"), null, isExpression: false, allowSwitchingExpression: true, "CricketParts", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(35, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_35"), LocalStringManager.GetConfig("EventArgument_language", "Desc_35"), null, isExpression: false, allowSwitchingExpression: true, "CombatSkill", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(36, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_36"), LocalStringManager.GetConfig("EventArgument_language", "Desc_36"), null, isExpression: false, allowSwitchingExpression: true, "LifeSkillType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(37, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_37"), LocalStringManager.GetConfig("EventArgument_language", "Desc_37"), null, isExpression: false, allowSwitchingExpression: true, "MerchantType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(38, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_38"), LocalStringManager.GetConfig("EventArgument_language", "Desc_38"), null, isExpression: false, allowSwitchingExpression: true, "TaskInfo", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(39, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_39"), LocalStringManager.GetConfig("EventArgument_language", "Desc_39"), null, isExpression: false, allowSwitchingExpression: true, "TaskChain", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(40, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_40"), LocalStringManager.GetConfig("EventArgument_language", "Desc_40"), null, isExpression: false, allowSwitchingExpression: true, "Adventure", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(41, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_41"), LocalStringManager.GetConfig("EventArgument_language", "Desc_41"), null, isExpression: false, allowSwitchingExpression: false, "EventConditionOperator", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(42, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_42"), LocalStringManager.GetConfig("EventArgument_language", "Desc_42"), null, isExpression: false, allowSwitchingExpression: true, "CombatConfig", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(43, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_43"), LocalStringManager.GetConfig("EventArgument_language", "Desc_43"), null, isExpression: false, allowSwitchingExpression: true, null, new string[6]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_43_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_43_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_43_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_43_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_43_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_43_5")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(44, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_44"), LocalStringManager.GetConfig("EventArgument_language", "Desc_44"), null, isExpression: false, allowSwitchingExpression: true, "EventActors", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(45, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_45"), LocalStringManager.GetConfig("EventArgument_language", "Desc_45"), null, isExpression: false, allowSwitchingExpression: true, "Character", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(46, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_46"), LocalStringManager.GetConfig("EventArgument_language", "Desc_46"), null, isExpression: false, allowSwitchingExpression: true, "Character", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(47, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_47"), LocalStringManager.GetConfig("EventArgument_language", "Desc_47"), null, isExpression: false, allowSwitchingExpression: true, "MapState", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(48, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_48"), LocalStringManager.GetConfig("EventArgument_language", "Desc_48"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(49, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_49"), LocalStringManager.GetConfig("EventArgument_language", "Desc_49"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_49_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_49_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_49_2")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(50, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_50"), LocalStringManager.GetConfig("EventArgument_language", "Desc_50"), null, isExpression: false, allowSwitchingExpression: true, "CharacterFilterRules", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(51, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_51"), LocalStringManager.GetConfig("EventArgument_language", "Desc_51"), null, isExpression: false, allowSwitchingExpression: true, "LifeSkill", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(52, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_52"), LocalStringManager.GetConfig("EventArgument_language", "Desc_52"), null, isExpression: false, allowSwitchingExpression: true, "Profession", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(53, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_53"), LocalStringManager.GetConfig("EventArgument_language", "Desc_53"), null, isExpression: false, allowSwitchingExpression: true, null, new string[13]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_6"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_7"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_8"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_9"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_10"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_11"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_53_12")
		}, new int[13]
		{
			-6, -5, -4, -3, -2, -1, 0, 1, 2, 3,
			4, 5, 6
		}, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(54, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_54"), LocalStringManager.GetConfig("EventArgument_language", "Desc_54"), null, isExpression: false, allowSwitchingExpression: false, "MonthlyActions", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(55, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_55"), LocalStringManager.GetConfig("EventArgument_language", "Desc_55"), null, isExpression: false, allowSwitchingExpression: true, "BuildingBlock", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(56, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_56"), LocalStringManager.GetConfig("EventArgument_language", "Desc_56"), null, isExpression: false, allowSwitchingExpression: true, "Merchant", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(57, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_57"), LocalStringManager.GetConfig("EventArgument_language", "Desc_57"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_57_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_57_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_57_2")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(58, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_58"), LocalStringManager.GetConfig("EventArgument_language", "Desc_58"), null, isExpression: false, allowSwitchingExpression: true, "MapBlockMatcher", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(59, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_59"), LocalStringManager.GetConfig("EventArgument_language", "Desc_59"), null, isExpression: false, allowSwitchingExpression: true, null, new string[7]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_59_6")
		}, new int[7] { -1, 0, 1, 2, 3, 4, 5 }, new IntPair(0, 0)));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EventArgumentItem(60, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_60"), LocalStringManager.GetConfig("EventArgument_language", "Desc_60"), null, isExpression: false, allowSwitchingExpression: true, "CharacterMatcher", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(61, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_61"), LocalStringManager.GetConfig("EventArgument_language", "Desc_61"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(62, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_62"), LocalStringManager.GetConfig("EventArgument_language", "Desc_62"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(63, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_63"), LocalStringManager.GetConfig("EventArgument_language", "Desc_63"), null, isExpression: false, allowSwitchingExpression: true, "WorldFavorability", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(64, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_64"), LocalStringManager.GetConfig("EventArgument_language", "Desc_64"), null, isExpression: false, allowSwitchingExpression: true, "EnemyNest", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(65, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_65"), LocalStringManager.GetConfig("EventArgument_language", "Desc_65"), null, isExpression: false, allowSwitchingExpression: true, null, new string[2]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_65_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_65_1")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(66, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_66"), LocalStringManager.GetConfig("EventArgument_language", "Desc_66"), "近", isExpression: false, allowSwitchingExpression: false, null, new string[2]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_66_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_66_1")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(67, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_67"), LocalStringManager.GetConfig("EventArgument_language", "Desc_67"), null, isExpression: false, allowSwitchingExpression: true, null, new string[2]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_67_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_67_1")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(68, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_68"), LocalStringManager.GetConfig("EventArgument_language", "Desc_68"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_68_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_68_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_68_2")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(69, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_69"), LocalStringManager.GetConfig("EventArgument_language", "Desc_69"), null, isExpression: false, allowSwitchingExpression: true, "Character", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(70, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_70"), LocalStringManager.GetConfig("EventArgument_language", "Desc_70"), null, isExpression: false, allowSwitchingExpression: true, null, new string[4]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_70_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_70_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_70_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_70_3")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(71, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_71"), LocalStringManager.GetConfig("EventArgument_language", "Desc_71"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(72, EEventArgumentType.Basic, LocalStringManager.GetConfig("EventArgument_language", "Name_72"), LocalStringManager.GetConfig("EventArgument_language", "Desc_72"), null, isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(73, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_73"), LocalStringManager.GetConfig("EventArgument_language", "Desc_73"), "任一匹配", isExpression: false, allowSwitchingExpression: false, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_73_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_73_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_73_2")
		}, new int[3] { 0, 1, 2 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(74, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_74"), LocalStringManager.GetConfig("EventArgument_language", "Desc_74"), null, isExpression: false, allowSwitchingExpression: false, "Character", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(75, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_75"), LocalStringManager.GetConfig("EventArgument_language", "Desc_75"), null, isExpression: false, allowSwitchingExpression: false, "RandomEnemy", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(76, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_76"), LocalStringManager.GetConfig("EventArgument_language", "Desc_76"), null, isExpression: false, allowSwitchingExpression: true, null, new string[4]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_76_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_76_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_76_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_76_3")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(77, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_77"), LocalStringManager.GetConfig("EventArgument_language", "Desc_77"), null, isExpression: false, allowSwitchingExpression: true, "EventCommonOption", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(78, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_78"), LocalStringManager.GetConfig("EventArgument_language", "Desc_78"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(79, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_79"), LocalStringManager.GetConfig("EventArgument_language", "Desc_79"), null, isExpression: false, allowSwitchingExpression: true, "EquipmentEffect", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(80, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_80"), LocalStringManager.GetConfig("EventArgument_language", "Desc_80"), null, isExpression: false, allowSwitchingExpression: true, "InstantNotification", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(81, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_81"), LocalStringManager.GetConfig("EventArgument_language", "Desc_81"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(82, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_82"), LocalStringManager.GetConfig("EventArgument_language", "Desc_82"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(83, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_83"), LocalStringManager.GetConfig("EventArgument_language", "Desc_83"), null, isExpression: false, allowSwitchingExpression: true, null, new string[6]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_83_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_83_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_83_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_83_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_83_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_83_5")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(84, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_84"), LocalStringManager.GetConfig("EventArgument_language", "Desc_84"), null, isExpression: false, allowSwitchingExpression: true, null, new string[4]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_84_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_84_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_84_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_84_3")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(85, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_85"), LocalStringManager.GetConfig("EventArgument_language", "Desc_85"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(86, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_86"), LocalStringManager.GetConfig("EventArgument_language", "Desc_86"), null, isExpression: false, allowSwitchingExpression: true, "EventCutscene", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(87, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_87"), LocalStringManager.GetConfig("EventArgument_language", "Desc_87"), null, isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(88, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_88"), LocalStringManager.GetConfig("EventArgument_language", "Desc_88"), null, isExpression: false, allowSwitchingExpression: true, null, new string[17]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_6"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_7"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_8"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_9"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_10"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_11"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_12"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_13"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_14"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_15"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_88_16")
		}, new int[17]
		{
			0, 1, 2, 4, 8, 16, 32, 64, 128, 256,
			512, 1024, 2048, 4096, 8192, 16384, 32768
		}, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(89, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_89"), LocalStringManager.GetConfig("EventArgument_language", "Desc_89"), null, isExpression: true, allowSwitchingExpression: true, "SectMainStoryEventArgKey", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(90, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_90"), LocalStringManager.GetConfig("EventArgument_language", "Desc_90"), null, isExpression: false, allowSwitchingExpression: false, "InteractionEventOption", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(91, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_91"), LocalStringManager.GetConfig("EventArgument_language", "Desc_91"), null, isExpression: false, allowSwitchingExpression: true, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(92, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_92"), LocalStringManager.GetConfig("EventArgument_language", "Desc_92"), null, isExpression: false, allowSwitchingExpression: true, "Information", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(93, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_93"), LocalStringManager.GetConfig("EventArgument_language", "Desc_93"), null, isExpression: false, allowSwitchingExpression: true, "MonthlyEvent", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(94, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_94"), LocalStringManager.GetConfig("EventArgument_language", "Desc_94"), null, isExpression: false, allowSwitchingExpression: true, "MonthlyNotification", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(95, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_95"), LocalStringManager.GetConfig("EventArgument_language", "Desc_95"), null, isExpression: false, allowSwitchingExpression: true, null, new string[4]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_95_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_95_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_95_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_95_3")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(96, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_96"), LocalStringManager.GetConfig("EventArgument_language", "Desc_96"), null, isExpression: false, allowSwitchingExpression: true, "CharacterPropertyReferenced", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(97, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_97"), LocalStringManager.GetConfig("EventArgument_language", "Desc_97"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_97_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_97_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_97_2")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(98, EEventArgumentType.Object, LocalStringManager.GetConfig("EventArgument_language", "Name_98"), LocalStringManager.GetConfig("EventArgument_language", "Desc_98"), null, isExpression: true, allowSwitchingExpression: false, null, new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(99, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_99"), LocalStringManager.GetConfig("EventArgument_language", "Desc_99"), null, isExpression: false, allowSwitchingExpression: true, "InformationType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(100, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_100"), LocalStringManager.GetConfig("EventArgument_language", "Desc_100"), null, isExpression: false, allowSwitchingExpression: true, "TutorialVideo", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(101, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_101"), LocalStringManager.GetConfig("EventArgument_language", "Desc_101"), null, isExpression: false, allowSwitchingExpression: true, "EventCgTexture", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(102, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_102"), LocalStringManager.GetConfig("EventArgument_language", "Desc_102"), null, isExpression: false, allowSwitchingExpression: true, null, new string[4]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_102_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_102_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_102_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_102_3")
		}, new int[4] { 0, 1, 2, 9 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(103, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_103"), LocalStringManager.GetConfig("EventArgument_language", "Desc_103"), null, isExpression: false, allowSwitchingExpression: true, "TutorialFunctionType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(104, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_104"), LocalStringManager.GetConfig("EventArgument_language", "Desc_104"), null, isExpression: false, allowSwitchingExpression: true, "TutorialChapters", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(105, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_105"), LocalStringManager.GetConfig("EventArgument_language", "Desc_105"), null, isExpression: false, allowSwitchingExpression: true, "MapBlock", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(106, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_106"), LocalStringManager.GetConfig("EventArgument_language", "Desc_106"), null, isExpression: false, allowSwitchingExpression: true, "EventActionKey", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(107, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_107"), LocalStringManager.GetConfig("EventArgument_language", "Desc_107"), null, isExpression: false, allowSwitchingExpression: true, "ProfessionSkill", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(108, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_108"), LocalStringManager.GetConfig("EventArgument_language", "Desc_108"), null, isExpression: false, allowSwitchingExpression: true, "EventTriggerParameter", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(109, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_109"), LocalStringManager.GetConfig("EventArgument_language", "Desc_109"), null, isExpression: false, allowSwitchingExpression: true, "AdventureRemakeBlockEffect", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(110, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_110"), LocalStringManager.GetConfig("EventArgument_language", "Desc_110"), null, isExpression: false, allowSwitchingExpression: true, "AdventureRemakePerformanceEffect", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(111, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_111"), LocalStringManager.GetConfig("EventArgument_language", "Desc_111"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_111_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_111_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_111_2")
		}, new int[3] { -1, 0, 1 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(112, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_112"), LocalStringManager.GetConfig("EventArgument_language", "Desc_112"), null, isExpression: false, allowSwitchingExpression: true, "GuidingChapter", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(113, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_113"), LocalStringManager.GetConfig("EventArgument_language", "Desc_113"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_113_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_113_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_113_2")
		}, new int[3] { 0, 1, 2 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(114, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_114"), LocalStringManager.GetConfig("EventArgument_language", "Desc_114"), null, isExpression: false, allowSwitchingExpression: true, "GuidingChapterTrigger", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(115, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_115"), LocalStringManager.GetConfig("EventArgument_language", "Desc_115"), null, isExpression: false, allowSwitchingExpression: true, "TaiwuLifeSummaryType", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(116, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_116"), LocalStringManager.GetConfig("EventArgument_language", "Desc_116"), null, isExpression: false, allowSwitchingExpression: true, "StatInfo", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(117, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_117"), LocalStringManager.GetConfig("EventArgument_language", "Desc_117"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_117_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_117_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_117_2")
		}, new int[3] { 0, 8, 16 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(118, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_118"), LocalStringManager.GetConfig("EventArgument_language", "Desc_118"), null, isExpression: false, allowSwitchingExpression: true, "SwordTomb", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(119, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_119"), LocalStringManager.GetConfig("EventArgument_language", "Desc_119"), null, isExpression: false, allowSwitchingExpression: true, null, new string[7]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_119_6")
		}, new int[0], new IntPair(0, 0)));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new EventArgumentItem(120, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_120"), LocalStringManager.GetConfig("EventArgument_language", "Desc_120"), null, isExpression: false, allowSwitchingExpression: true, null, new string[5]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_120_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_120_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_120_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_120_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_120_4")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(121, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_121"), LocalStringManager.GetConfig("EventArgument_language", "Desc_121"), null, isExpression: false, allowSwitchingExpression: true, null, new string[4]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_121_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_121_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_121_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_121_3")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(122, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_122"), LocalStringManager.GetConfig("EventArgument_language", "Desc_122"), null, isExpression: false, allowSwitchingExpression: true, null, new string[5]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_122_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_122_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_122_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_122_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_122_4")
		}, new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(123, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_123"), LocalStringManager.GetConfig("EventArgument_language", "Desc_123"), null, isExpression: false, allowSwitchingExpression: true, "Weather", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(124, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_124"), LocalStringManager.GetConfig("EventArgument_language", "Desc_124"), null, isExpression: false, allowSwitchingExpression: true, "CharacterTitle", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(125, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_125"), LocalStringManager.GetConfig("EventArgument_language", "Desc_125"), "3", isExpression: false, allowSwitchingExpression: true, null, new string[9]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_5"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_6"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_7"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_125_8")
		}, new int[9] { 0, 1, 2, 3, 4, 5, 6, -2, -1 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(126, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_126"), LocalStringManager.GetConfig("EventArgument_language", "Desc_126"), null, isExpression: false, allowSwitchingExpression: true, "Clothing", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(127, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_127"), LocalStringManager.GetConfig("EventArgument_language", "Desc_127"), null, isExpression: false, allowSwitchingExpression: true, null, new string[2]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_127_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_127_1")
		}, new int[2] { 16384, 32768 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(128, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_128"), LocalStringManager.GetConfig("EventArgument_language", "Desc_128"), null, isExpression: false, allowSwitchingExpression: true, "TwelveImmortals", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(129, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_129"), LocalStringManager.GetConfig("EventArgument_language", "Desc_129"), null, isExpression: false, allowSwitchingExpression: true, null, new string[6]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_129_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_129_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_129_2"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_129_3"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_129_4"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_129_5")
		}, new int[6] { 0, 1, 2, 3, 4, 5 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(130, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_130"), LocalStringManager.GetConfig("EventArgument_language", "Desc_130"), null, isExpression: false, allowSwitchingExpression: true, "Chicken", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(131, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_131"), LocalStringManager.GetConfig("EventArgument_language", "Desc_131"), null, isExpression: false, allowSwitchingExpression: true, "ImplementedDlc", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(132, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_132"), LocalStringManager.GetConfig("EventArgument_language", "Desc_132"), null, isExpression: false, allowSwitchingExpression: true, "DlcEventArgKey", new string[0], new int[0], new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(133, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_133"), LocalStringManager.GetConfig("EventArgument_language", "Desc_133"), null, isExpression: false, allowSwitchingExpression: true, null, new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_133_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_133_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_133_2")
		}, new int[3] { 0, 1, 2 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(134, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_134"), LocalStringManager.GetConfig("EventArgument_language", "Desc_134"), null, isExpression: false, allowSwitchingExpression: true, "Character", new string[0], new int[0], new IntPair(1075, 1086)));
		_dataArray.Add(new EventArgumentItem(135, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_135"), LocalStringManager.GetConfig("EventArgument_language", "Desc_135"), null, isExpression: false, allowSwitchingExpression: true, "Character", new string[3]
		{
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_135_0"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_135_1"),
			LocalStringManager.GetConfig("EventArgument_language", "CustomEnumText_135_2")
		}, new int[3] { 913, 916, 914 }, new IntPair(0, 0)));
		_dataArray.Add(new EventArgumentItem(136, EEventArgumentType.Enum, LocalStringManager.GetConfig("EventArgument_language", "Name_136"), LocalStringManager.GetConfig("EventArgument_language", "Desc_136"), null, isExpression: false, allowSwitchingExpression: true, "NewFunctionUnlock", new string[0], new int[0], new IntPair(0, 0)));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventArgumentItem>(137);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
