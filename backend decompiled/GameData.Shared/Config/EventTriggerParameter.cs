using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerParameter : ConfigData<EventTriggerParameterItem, int>
{
	public static class DefKey
	{
		public const int CharacterId = 0;

		public const int CharacterTemplateId = 1;

		public const int TombId = 2;

		public const int AnimalId = 3;

		public const int CaravanId = 4;

		public const int ChickenId = 5;

		public const int ChickenTemplateId = 6;

		public const int ItemKey = 7;

		public const int Location = 8;

		public const int InviteLocation = 9;

		public const int XiangshuAvatarId = 10;

		public const int BlockFrom = 11;

		public const int BlockTo = 12;

		public const int Amount = 13;

		public const int IsTaiwuDying = 14;

		public const int MaskVisible = 15;

		public const int BuildingBlockKey = 16;

		public const int BuildingTemplateId = 17;

		public const int CricketCatchSuccess = 18;

		public const int ProfessionTemplateId = 19;

		public const int ProfessionSkillTemplateId = 20;

		public const int PoolId = 21;

		public const int ResourceType = 22;

		public const int IsEvent = 23;

		public const int UIName = 24;

		public const int ThiefLevel = 25;

		public const int IsTimeout = 26;

		public const int BrokenLevel = 27;

		public const int FindResult = 28;

		public const int DreamBackUnlockStateType = 29;

		public const int InventoryItemOperationType = 30;

		public const int ChapterIndex = 31;

		public const int VitalType = 32;

		public const int IsGoodEnd = 33;

		public const int BossIndex = 34;

		public const int IsPickUpAll = 35;

		public const int MapPickupIndex = 36;

		public const int TreasuryOrPrisonCurrentPage = 37;

		public const int TreasuryOrPrisonVisitStatus = 38;

		public const int MonkProfessionSaveCount = 39;

		public const int BuildingLevel = 40;

		public const int SelectInventoryItemKey = 51;

		public const int JiaoEggItemKey = 41;

		public const int TianjieFuluItemKey = 42;

		public const int TianjieFuluCount = 43;

		public const int ShowingGetItem = 44;

		public const int LifeSkillCombatConcessionCount = 45;

		public const int LifeSkillCombatInducementCount = 46;

		public const int InteractPrisonerType = 47;

		public const int PresetInt = 48;

		public const int PresetBool = 49;

		public const int OnFinishPassingLegacyEvent = 50;

		public const int BreakSuccess = 52;

		public const int CombatSkillTemplateId = 53;

		public const int PersonalityType = 54;

		public const int Gender = 55;
	}

	public static class DefValue
	{
		public static EventTriggerParameterItem CharacterId => Instance[0];

		public static EventTriggerParameterItem CharacterTemplateId => Instance[1];

		public static EventTriggerParameterItem TombId => Instance[2];

		public static EventTriggerParameterItem AnimalId => Instance[3];

		public static EventTriggerParameterItem CaravanId => Instance[4];

		public static EventTriggerParameterItem ChickenId => Instance[5];

		public static EventTriggerParameterItem ChickenTemplateId => Instance[6];

		public static EventTriggerParameterItem ItemKey => Instance[7];

		public static EventTriggerParameterItem Location => Instance[8];

		public static EventTriggerParameterItem InviteLocation => Instance[9];

		public static EventTriggerParameterItem XiangshuAvatarId => Instance[10];

		public static EventTriggerParameterItem BlockFrom => Instance[11];

		public static EventTriggerParameterItem BlockTo => Instance[12];

		public static EventTriggerParameterItem Amount => Instance[13];

		public static EventTriggerParameterItem IsTaiwuDying => Instance[14];

		public static EventTriggerParameterItem MaskVisible => Instance[15];

		public static EventTriggerParameterItem BuildingBlockKey => Instance[16];

		public static EventTriggerParameterItem BuildingTemplateId => Instance[17];

		public static EventTriggerParameterItem CricketCatchSuccess => Instance[18];

		public static EventTriggerParameterItem ProfessionTemplateId => Instance[19];

		public static EventTriggerParameterItem ProfessionSkillTemplateId => Instance[20];

		public static EventTriggerParameterItem PoolId => Instance[21];

		public static EventTriggerParameterItem ResourceType => Instance[22];

		public static EventTriggerParameterItem IsEvent => Instance[23];

		public static EventTriggerParameterItem UIName => Instance[24];

		public static EventTriggerParameterItem ThiefLevel => Instance[25];

		public static EventTriggerParameterItem IsTimeout => Instance[26];

		public static EventTriggerParameterItem BrokenLevel => Instance[27];

		public static EventTriggerParameterItem FindResult => Instance[28];

		public static EventTriggerParameterItem DreamBackUnlockStateType => Instance[29];

		public static EventTriggerParameterItem InventoryItemOperationType => Instance[30];

		public static EventTriggerParameterItem ChapterIndex => Instance[31];

		public static EventTriggerParameterItem VitalType => Instance[32];

		public static EventTriggerParameterItem IsGoodEnd => Instance[33];

		public static EventTriggerParameterItem BossIndex => Instance[34];

		public static EventTriggerParameterItem IsPickUpAll => Instance[35];

		public static EventTriggerParameterItem MapPickupIndex => Instance[36];

		public static EventTriggerParameterItem TreasuryOrPrisonCurrentPage => Instance[37];

		public static EventTriggerParameterItem TreasuryOrPrisonVisitStatus => Instance[38];

		public static EventTriggerParameterItem MonkProfessionSaveCount => Instance[39];

		public static EventTriggerParameterItem BuildingLevel => Instance[40];

		public static EventTriggerParameterItem SelectInventoryItemKey => Instance[51];

		public static EventTriggerParameterItem JiaoEggItemKey => Instance[41];

		public static EventTriggerParameterItem TianjieFuluItemKey => Instance[42];

		public static EventTriggerParameterItem TianjieFuluCount => Instance[43];

		public static EventTriggerParameterItem ShowingGetItem => Instance[44];

		public static EventTriggerParameterItem LifeSkillCombatConcessionCount => Instance[45];

		public static EventTriggerParameterItem LifeSkillCombatInducementCount => Instance[46];

		public static EventTriggerParameterItem InteractPrisonerType => Instance[47];

		public static EventTriggerParameterItem PresetInt => Instance[48];

		public static EventTriggerParameterItem PresetBool => Instance[49];

		public static EventTriggerParameterItem OnFinishPassingLegacyEvent => Instance[50];

		public static EventTriggerParameterItem BreakSuccess => Instance[52];

		public static EventTriggerParameterItem CombatSkillTemplateId => Instance[53];

		public static EventTriggerParameterItem PersonalityType => Instance[54];

		public static EventTriggerParameterItem Gender => Instance[55];
	}

	public static EventTriggerParameter Instance = new EventTriggerParameter();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "DataTypeName", "ArgBoxKey" };

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
		_dataArray.Add(new EventTriggerParameterItem(0, "int", "CharacterId"));
		_dataArray.Add(new EventTriggerParameterItem(1, "short", "CharacterTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(2, "int", "TombId"));
		_dataArray.Add(new EventTriggerParameterItem(3, "int", "AnimalId"));
		_dataArray.Add(new EventTriggerParameterItem(4, "int", "CaravanId"));
		_dataArray.Add(new EventTriggerParameterItem(5, "int", "ChickenId"));
		_dataArray.Add(new EventTriggerParameterItem(6, "short", "ChickenTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(7, "ItemKey", "ItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(8, "Location", "Location"));
		_dataArray.Add(new EventTriggerParameterItem(9, "Location", "InviteLocation"));
		_dataArray.Add(new EventTriggerParameterItem(10, "sbyte", "XiangshuAvatarId"));
		_dataArray.Add(new EventTriggerParameterItem(11, "Location", "BlockFrom"));
		_dataArray.Add(new EventTriggerParameterItem(12, "Location", "BlockTo"));
		_dataArray.Add(new EventTriggerParameterItem(13, "int", "Amount"));
		_dataArray.Add(new EventTriggerParameterItem(14, "bool", "IsTaiwuDying"));
		_dataArray.Add(new EventTriggerParameterItem(15, "bool", "MaskVisible"));
		_dataArray.Add(new EventTriggerParameterItem(16, "BuildingBlockKey", "BuildingBlockKey"));
		_dataArray.Add(new EventTriggerParameterItem(17, "short", "BuildingTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(18, "bool", "CricketCatchSuccess"));
		_dataArray.Add(new EventTriggerParameterItem(19, "int", "ProfessionTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(20, "int", "ProfessionSkillTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(21, "int", "PoolId"));
		_dataArray.Add(new EventTriggerParameterItem(22, "sbyte", "ResourceType"));
		_dataArray.Add(new EventTriggerParameterItem(23, "bool", "IsEvent"));
		_dataArray.Add(new EventTriggerParameterItem(24, "string", "UIName"));
		_dataArray.Add(new EventTriggerParameterItem(25, "sbyte", "ThiefLevel"));
		_dataArray.Add(new EventTriggerParameterItem(26, "bool", "IsTimeout"));
		_dataArray.Add(new EventTriggerParameterItem(27, "int", "BrokenLevel"));
		_dataArray.Add(new EventTriggerParameterItem(28, "TreasureFindResult", "FindResult"));
		_dataArray.Add(new EventTriggerParameterItem(29, "sbyte", "DreamBackUnlockStateType"));
		_dataArray.Add(new EventTriggerParameterItem(30, "sbyte", "InventoryItemOperationType"));
		_dataArray.Add(new EventTriggerParameterItem(31, "short", "ChapterIndex"));
		_dataArray.Add(new EventTriggerParameterItem(32, "int", "VitalType"));
		_dataArray.Add(new EventTriggerParameterItem(33, "bool", "IsGoodEnd"));
		_dataArray.Add(new EventTriggerParameterItem(34, "int", "BossIndex"));
		_dataArray.Add(new EventTriggerParameterItem(35, "bool", "IsPickUpAll"));
		_dataArray.Add(new EventTriggerParameterItem(36, "int", "MapPickupIndex"));
		_dataArray.Add(new EventTriggerParameterItem(37, "sbyte", "CurrentPage"));
		_dataArray.Add(new EventTriggerParameterItem(38, "byte", "TreasuryOrPrisonVisitStatus"));
		_dataArray.Add(new EventTriggerParameterItem(39, "int", "SaveCount"));
		_dataArray.Add(new EventTriggerParameterItem(40, "sbyte", "Level"));
		_dataArray.Add(new EventTriggerParameterItem(41, "ItemKey", "EggItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(42, "ItemKey", "ItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(43, "int", "Count"));
		_dataArray.Add(new EventTriggerParameterItem(44, "bool", "ShowingGetItem"));
		_dataArray.Add(new EventTriggerParameterItem(45, "sbyte", "ConcessionCount"));
		_dataArray.Add(new EventTriggerParameterItem(46, "sbyte", "InducementCount"));
		_dataArray.Add(new EventTriggerParameterItem(47, "int", "InteractPrisonerType"));
		_dataArray.Add(new EventTriggerParameterItem(48, "int", "PresetInt"));
		_dataArray.Add(new EventTriggerParameterItem(49, "bool", "PresetBool"));
		_dataArray.Add(new EventTriggerParameterItem(50, "string", "OnFinishPassingLegacyEvent"));
		_dataArray.Add(new EventTriggerParameterItem(51, "ItemKey", "SelectItemKey"));
		_dataArray.Add(new EventTriggerParameterItem(52, "bool", "BreakSuccess"));
		_dataArray.Add(new EventTriggerParameterItem(53, "short", "CombatSkillTemplateId"));
		_dataArray.Add(new EventTriggerParameterItem(54, "sbyte", "PersonalityType"));
		_dataArray.Add(new EventTriggerParameterItem(55, "sbyte", "Gender"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventTriggerParameterItem>(56);
		CreateItems0();
	}
}
