using System;
using System.Collections.Generic;
using GameData.DLC;
using GameData.DLC.FiveLoong;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation.RelationTree;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.SpecialEffect;
using GameData.Domains.Story.SectMainStory;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class CrossArchiveGameData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TaiwuChar = 0;

		public const ushort TaiwuResources = 1;

		public const ushort TaiwuExp = 2;

		public const ushort ExternalEquippedCombatSkills = 3;

		public const ushort NormalInformation = 4;

		public const ushort CombatSkills = 5;

		public const ushort TaiwuEffects = 6;

		public const ushort UnpackedItems = 7;

		public const ushort TaiwuVillageLocation = 8;

		public const ushort TaiwuVillageAreaData = 9;

		public const ushort TaiwuVillageBlocks = 10;

		public const ushort Chicken = 11;

		public const ushort XiangshuIdInKungfuPracticeRoom = 12;

		public const ushort CricketCollectionDatas = 13;

		public const ushort AutoWorkBlockIndexList = 14;

		public const ushort AutoSoldBlockIndexList = 15;

		public const ushort AutoCheckInList = 16;

		public const ushort WarehouseItems = 17;

		public const ushort TaiwuCombatSkills = 18;

		public const ushort TaiwuLifeSkills = 19;

		public const ushort NotLearnedCombatSkills = 20;

		public const ushort NotLearnedLifeSkills = 21;

		public const ushort CombatSkillPlans = 22;

		public const ushort CurrCombatSkillPlanId = 23;

		public const ushort CurrLifeSkillAttainmentPanelPlanIndex = 24;

		public const ushort SkillBreakPlateDict = 25;

		public const ushort SkillBreakBonusDict = 26;

		public const ushort CombatSkillAttainmentPanelPlans = 27;

		public const ushort CurrCombatSkillAttainmentPanelPlanIds = 28;

		public const ushort EquipmentsPlans = 29;

		public const ushort CurrEquipmentPlanId = 30;

		public const ushort WeaponInnerRatios = 31;

		public const ushort VoiceWeaponInnerRatio = 32;

		public const ushort ReadingBooks = 33;

		public const ushort BuildingSpaceExtraAdd = 34;

		public const ushort ExtraNeiliAllocationProgress = 35;

		public const ushort ExtraNeiliAllocation = 36;

		public const ushort Professions = 37;

		public const ushort HandledOneShotEvents = 38;

		public const ushort TreasuryItems = 39;

		public const ushort TroughItems = 40;

		public const ushort LegaciesBuildingTemplateIds = 41;

		public const ushort ReadingEventBookIdList = 42;

		public const ushort ProfessionSkillSlots = 43;

		public const ushort AvailableReadingStrategyMap = 44;

		public const ushort ClearedSkillPlateStepInfo = 45;

		public const ushort TaiwuMaxNeiliAllocation = 46;

		public const ushort CurrMasteredCombatSkillPlan = 47;

		public const ushort MasteredCombatSkillPlans = 48;

		public const ushort UnlockedCombatSkillPlanCount = 49;

		public const ushort JiaoPools = 50;

		public const ushort IsJiaoPoolOpen = 51;

		public const ushort MaxTaiwuVillageLevel = 52;

		public const ushort TaiwuCombatSkillProficiencies = 53;

		public const ushort SectEmeiSkillBreakBonus = 54;

		public const ushort SectEmeiBreakBonusTemplateIds = 55;

		public const ushort SectEmeiBonusData = 56;

		public const ushort SectFulongOrgMemberChickens = 57;

		public const ushort SectZhujianGearMate = 58;

		public const ushort LegendaryBookBreakPlateCounts = 59;

		public const ushort CombatSkillBreakPlateList = 60;

		public const ushort CombatSkillBreakPlateLastClearTimeList = 61;

		public const ushort CombatSkillBreakPlateLastForceBreakoutStepsCount = 62;

		public const ushort CombatSkillCurrBreakPlateIndex = 63;

		public const ushort LegendaryBookWeaponSlot = 64;

		public const ushort LegendaryBookWeaponEffectId = 65;

		public const ushort LegendaryBookSkillSlot = 66;

		public const ushort LegendaryBookSkillEffectId = 67;

		public const ushort LegendaryBookBonusCountYin = 68;

		public const ushort LegendaryBookBonusCountYang = 69;

		public const ushort StockItems = 70;

		public const ushort WeaponInnerRatiosByTemplateId = 71;

		public const ushort WeaponInnerRatiosById = 72;

		public const ushort TaiwuTreasuryResources = 73;

		public const ushort LockedItems = 74;

		public const ushort CombatSkillBreakPresets = 75;

		public const ushort CombatSkillBreakPlates = 76;

		public const ushort IsExtraProfessionSkillUnlocked = 77;

		public const ushort ProfessionFeatures = 78;

		public const ushort BuildingResourceOutputSettings = 79;

		public const ushort FarmerAutoCollectStorageType = 80;

		public const ushort VillagerRoleAutoActionStates = 81;

		public const ushort ComfortableHousesAutoCheckInType = 82;

		public const ushort BuildingDefaultStoreLocation = 83;

		public const ushort AutoCheckInComfortableList = 84;

		public const ushort Count = 85;

		public static readonly string[] FieldId2FieldName = new string[85]
		{
			"TaiwuChar", "TaiwuResources", "TaiwuExp", "ExternalEquippedCombatSkills", "NormalInformation", "CombatSkills", "TaiwuEffects", "UnpackedItems", "TaiwuVillageLocation", "TaiwuVillageAreaData",
			"TaiwuVillageBlocks", "Chicken", "XiangshuIdInKungfuPracticeRoom", "CricketCollectionDatas", "AutoWorkBlockIndexList", "AutoSoldBlockIndexList", "AutoCheckInList", "WarehouseItems", "TaiwuCombatSkills", "TaiwuLifeSkills",
			"NotLearnedCombatSkills", "NotLearnedLifeSkills", "CombatSkillPlans", "CurrCombatSkillPlanId", "CurrLifeSkillAttainmentPanelPlanIndex", "SkillBreakPlateDict", "SkillBreakBonusDict", "CombatSkillAttainmentPanelPlans", "CurrCombatSkillAttainmentPanelPlanIds", "EquipmentsPlans",
			"CurrEquipmentPlanId", "WeaponInnerRatios", "VoiceWeaponInnerRatio", "ReadingBooks", "BuildingSpaceExtraAdd", "ExtraNeiliAllocationProgress", "ExtraNeiliAllocation", "Professions", "HandledOneShotEvents", "TreasuryItems",
			"TroughItems", "LegaciesBuildingTemplateIds", "ReadingEventBookIdList", "ProfessionSkillSlots", "AvailableReadingStrategyMap", "ClearedSkillPlateStepInfo", "TaiwuMaxNeiliAllocation", "CurrMasteredCombatSkillPlan", "MasteredCombatSkillPlans", "UnlockedCombatSkillPlanCount",
			"JiaoPools", "IsJiaoPoolOpen", "MaxTaiwuVillageLevel", "TaiwuCombatSkillProficiencies", "SectEmeiSkillBreakBonus", "SectEmeiBreakBonusTemplateIds", "SectEmeiBonusData", "SectFulongOrgMemberChickens", "SectZhujianGearMate", "LegendaryBookBreakPlateCounts",
			"CombatSkillBreakPlateList", "CombatSkillBreakPlateLastClearTimeList", "CombatSkillBreakPlateLastForceBreakoutStepsCount", "CombatSkillCurrBreakPlateIndex", "LegendaryBookWeaponSlot", "LegendaryBookWeaponEffectId", "LegendaryBookSkillSlot", "LegendaryBookSkillEffectId", "LegendaryBookBonusCountYin", "LegendaryBookBonusCountYang",
			"StockItems", "WeaponInnerRatiosByTemplateId", "WeaponInnerRatiosById", "TaiwuTreasuryResources", "LockedItems", "CombatSkillBreakPresets", "CombatSkillBreakPlates", "IsExtraProfessionSkillUnlocked", "ProfessionFeatures", "BuildingResourceOutputSettings",
			"FarmerAutoCollectStorageType", "VillagerRoleAutoActionStates", "ComfortableHousesAutoCheckInType", "BuildingDefaultStoreLocation", "AutoCheckInComfortableList"
		};
	}

	[SerializableGameDataField]
	public GameData.Domains.Character.Character TaiwuChar;

	public AbridgedCharacter DreamBackTaiwuAbridged;

	public int NextObjectId;

	public Dictionary<int, AbridgedCharacter> AbridgedCharacters;

	public ReadonlyLifeRecords LifeRecords;

	public Genealogy Genealogy;

	public Dictionary<int, DeadCharacter> PreexistenceDeadCharacters;

	[SerializableGameDataField]
	public ResourceInts TaiwuResources;

	[SerializableGameDataField]
	public int TaiwuExp;

	[SerializableGameDataField]
	public CombatSkillPlan ExternalEquippedCombatSkills;

	public int FuyuFaith;

	[SerializableGameDataField]
	public NormalInformationCollection NormalInformation;

	[SerializableGameDataField]
	public List<GameData.Domains.CombatSkill.CombatSkill> CombatSkills;

	[SerializableGameDataField]
	public List<SpecialEffectWrapper> TaiwuEffects;

	public ItemGroupPackage ItemGroupPackage;

	[SerializableGameDataField]
	public Dictionary<int, ItemKey> UnpackedItems;

	[SerializableGameDataField]
	public Location TaiwuVillageLocation;

	[SerializableGameDataField]
	public BuildingAreaData TaiwuVillageAreaData;

	[SerializableGameDataField]
	public List<BuildingBlockData> TaiwuVillageBlocks;

	[SerializableGameDataField]
	public Dictionary<int, Chicken> Chicken;

	[SerializableGameDataField]
	public List<sbyte> XiangshuIdInKungfuPracticeRoom;

	public CombatSkillShorts SamsaraPlatformAddCombatSkillQualifications;

	public LifeSkillShorts SamsaraPlatformAddLifeSkillQualifications;

	public MainAttributes SamsaraPlatformAddMainAttributes;

	[SerializableGameDataField]
	public List<CricketCollectionData> CricketCollectionDatas;

	[SerializableGameDataField]
	public List<short> AutoWorkBlockIndexList;

	[SerializableGameDataField]
	public List<short> AutoSoldBlockIndexList;

	[SerializableGameDataField]
	public List<short> AutoCheckInList;

	[SerializableGameDataField]
	public List<short> AutoCheckInComfortableList;

	[SerializableGameDataField]
	public Dictionary<BuildingBlockKey, bool> ComfortableHousesAutoCheckInType;

	[SerializableGameDataField]
	public Inventory WarehouseItems;

	[SerializableGameDataField]
	public Inventory TreasuryItems;

	[SerializableGameDataField]
	public Inventory TroughItems;

	[SerializableGameDataField]
	public Inventory StockItems;

	[SerializableGameDataField]
	public ResourceInts TaiwuTreasuryResources;

	[SerializableGameDataField]
	public Inventory LockedItems;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuCombatSkill> TaiwuCombatSkills;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuLifeSkills;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuCombatSkill> NotLearnedCombatSkills;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> NotLearnedLifeSkills;

	[SerializableGameDataField]
	public Dictionary<short, SkillBreakPlate> CombatSkillBreakPlates;

	[SerializableGameDataField]
	public Dictionary<short, CombatSkillBreakPreset> CombatSkillBreakPresets;

	[SerializableGameDataField]
	public CombatSkillPlan[] CombatSkillPlans;

	[SerializableGameDataField]
	public int CurrCombatSkillPlanId;

	[SerializableGameDataField]
	public sbyte[] CurrLifeSkillAttainmentPanelPlanIndex;

	[SerializableGameDataField]
	[Obsolete("Use CombatSkillBreakPlates instead.")]
	public Dictionary<short, SkillBreakPlate> SkillBreakPlateDict;

	[SerializableGameDataField]
	[Obsolete("This field is no longer used.")]
	public Dictionary<short, SkillBreakBonusCollection> SkillBreakBonusDict;

	[SerializableGameDataField]
	public short[] CombatSkillAttainmentPanelPlans;

	[SerializableGameDataField]
	public sbyte[] CurrCombatSkillAttainmentPanelPlanIds;

	[SerializableGameDataField]
	public EquipmentPlan[] EquipmentsPlans;

	[SerializableGameDataField]
	public int CurrEquipmentPlanId;

	[SerializableGameDataField]
	[Obsolete]
	public sbyte[] WeaponInnerRatios;

	[SerializableGameDataField]
	[Obsolete]
	public sbyte VoiceWeaponInnerRatio;

	[SerializableGameDataField]
	public Dictionary<int, sbyte> WeaponInnerRatiosById;

	[SerializableGameDataField]
	public Dictionary<short, sbyte> WeaponInnerRatiosByTemplateId;

	[SerializableGameDataField]
	public Dictionary<ItemKey, ReadingBookStrategies> ReadingBooks;

	public Dictionary<int, NotificationSortingGroup> MonthlyNotificationSortingGroups;

	public List<int> PreviousTaiwuCharIds;

	[SerializableGameDataField]
	public int BuildingSpaceExtraAdd;

	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationProgress;

	[SerializableGameDataField]
	public NeiliAllocation ExtraNeiliAllocation;

	public Dictionary<int, string> CustomTexts;

	public int NextCustomTextId;

	public int FinalDateBeforeDreamBack;

	public WorldCreationInfo WorldCreationInfo;

	public uint WorldId;

	[SerializableGameDataField]
	public Dictionary<int, ProfessionData> Professions;

	[SerializableGameDataField]
	public List<short> ProfessionFeatures;

	[SerializableGameDataField]
	public List<int> HandledOneShotEvents;

	[SerializableGameDataField]
	public List<short> LegaciesBuildingTemplateIds;

	[SerializableGameDataField]
	public List<int> ReadingEventBookIdList;

	[SerializableGameDataField]
	public TaiwuProfessionSkillSlots ProfessionSkillSlots;

	[SerializableGameDataField]
	public bool IsExtraProfessionSkillUnlocked;

	[SerializableGameDataField]
	public Dictionary<int, SByteList> AvailableReadingStrategyMap;

	[SerializableGameDataField]
	public Dictionary<short, IntPair> ClearedSkillPlateStepInfo;

	[SerializableGameDataField]
	public NeiliAllocation TaiwuMaxNeiliAllocation;

	[SerializableGameDataField]
	public ShortList CurrMasteredCombatSkillPlan;

	[SerializableGameDataField]
	public ShortList[] MasteredCombatSkillPlans;

	[SerializableGameDataField]
	public byte UnlockedCombatSkillPlanCount;

	[SerializableGameDataField]
	public List<JiaoPool> JiaoPools;

	[SerializableGameDataField]
	public bool IsJiaoPoolOpen;

	[SerializableGameDataField]
	public int MaxTaiwuVillageLevel;

	[SerializableGameDataField]
	public Dictionary<short, int> TaiwuCombatSkillProficiencies;

	[SerializableGameDataField]
	public Dictionary<short, SkillBreakBonusCollection> SectEmeiSkillBreakBonus;

	[SerializableGameDataField]
	public Dictionary<short, ShortList> SectEmeiBreakBonusTemplateIds;

	[SerializableGameDataField]
	public Dictionary<short, SectEmeiBreakBonusData> SectEmeiBonusData;

	[SerializableGameDataField]
	public Dictionary<short, IntList> SectFulongOrgMemberChickens;

	[SerializableGameDataField]
	public Dictionary<short, GearMateDreamBackData> SectZhujianGearMate;

	[SerializableGameDataField]
	public BuildingDefaultStoreLocation BuildingDefaultStoreLocation;

	[SerializableGameDataField]
	public Dictionary<int, BuildingResourceOutputSetting> BuildingResourceOutputSettings;

	[SerializableGameDataField]
	public sbyte FarmerAutoCollectStorageType;

	[SerializableGameDataField]
	public Dictionary<short, ulong> VillagerRoleAutoActionStates;

	public EventArgBox GlobalEventArgBox;

	public EventArgBox DlcEventArgBox;

	public Dictionary<ulong, DlcEntryWrapper> DlcEntries;

	public EventArgBox[] SectMainStoryEventArgBoxes;

	public Dictionary<short, CharacterPropertyBonus> TaiwuPropertyPermanentBonuses;

	public byte TaiwuPoisonImmunities;

	public Dictionary<IntPair, int> CharacterTemporaryFeatures;

	public List<short> SelectedUniqueLegacies;

	public HashSetAsDictionary<short> ProficiencyEnoughSkills;

	public HashSetAsDictionary<short> OwnedClothingSet;

	public Dictionary<int, short> ClothingDisplayModifications;

	public bool EnemyUnyieldingFallen;

	public bool EnemyDisableAi;

	public short LastTargetDistance;

	public CricketPreset CricketCombatPreset;

	[SerializableGameDataField]
	public Dictionary<sbyte, sbyte> LegendaryBookBreakPlateCounts;

	[SerializableGameDataField]
	[Obsolete("Use CombatSkillBreakPresets instead.")]
	public Dictionary<short, SkillBreakPlateList> CombatSkillBreakPlateList;

	[SerializableGameDataField]
	[Obsolete("Use CombatSkillBreakPresets instead.")]
	public Dictionary<short, IntList> CombatSkillBreakPlateLastClearTimeList;

	[SerializableGameDataField]
	[Obsolete("Use CombatSkillBreakPresets instead.")]
	public Dictionary<short, IntList> CombatSkillBreakPlateLastForceBreakoutStepsCount;

	[SerializableGameDataField]
	[Obsolete("Use CombatSkillBreakPresets instead.")]
	public Dictionary<short, sbyte> CombatSkillCurrBreakPlateIndex;

	[SerializableGameDataField]
	public Dictionary<sbyte, ItemKey> LegendaryBookWeaponSlot;

	[SerializableGameDataField]
	public Dictionary<sbyte, long> LegendaryBookWeaponEffectId;

	[SerializableGameDataField]
	public Dictionary<sbyte, ShortList> LegendaryBookSkillSlot;

	[SerializableGameDataField]
	public Dictionary<sbyte, LongList> LegendaryBookSkillEffectId;

	[SerializableGameDataField]
	public SByteList LegendaryBookBonusCountYin;

	[SerializableGameDataField]
	public SByteList LegendaryBookBonusCountYang;

	public List<int> InteractedCharacterList;

	public List<int> FollowingNpcList;

	public void PackItemInventory(ItemKey itemKey, int amount, Inventory inventory)
	{
		if (ItemTemplateHelper.IsInheritable(itemKey.ItemType, itemKey.TemplateId))
		{
			inventory.OfflineAdd(itemKey, amount);
			DomainManager.Item.PackCrossArchiveItem(this, itemKey);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 113;
		totalSize = ((TaiwuChar == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuChar.GetSerializedSize())));
		totalSize = ((ExternalEquippedCombatSkills == null) ? (totalSize + 2) : (totalSize + (2 + ExternalEquippedCombatSkills.GetSerializedSize())));
		totalSize = ((NormalInformation == null) ? (totalSize + 2) : (totalSize + (2 + NormalInformation.GetSerializedSize())));
		totalSize = ((CombatSkills == null) ? (totalSize + 2) : (totalSize + (2 + 88 * CombatSkills.Count)));
		if (TaiwuEffects != null)
		{
			totalSize += 2;
			int elementsCount = TaiwuEffects.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SpecialEffectWrapper element = TaiwuEffects[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(UnpackedItems);
		if (TaiwuVillageBlocks != null)
		{
			totalSize += 2;
			int elementsCount2 = TaiwuVillageBlocks.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				BuildingBlockData element2 = TaiwuVillageBlocks[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Chicken);
		totalSize = ((XiangshuIdInKungfuPracticeRoom == null) ? (totalSize + 2) : (totalSize + (2 + XiangshuIdInKungfuPracticeRoom.Count)));
		if (CricketCollectionDatas != null)
		{
			totalSize += 2;
			int elementsCount3 = CricketCollectionDatas.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				CricketCollectionData element3 = CricketCollectionDatas[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((AutoWorkBlockIndexList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AutoWorkBlockIndexList.Count)));
		totalSize = ((AutoSoldBlockIndexList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AutoSoldBlockIndexList.Count)));
		totalSize = ((AutoCheckInList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AutoCheckInList.Count)));
		totalSize = ((WarehouseItems == null) ? (totalSize + 2) : (totalSize + (2 + WarehouseItems.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuCombatSkills);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuLifeSkills);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(NotLearnedCombatSkills);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(NotLearnedLifeSkills);
		if (CombatSkillPlans != null)
		{
			totalSize += 2;
			int elementsCount4 = CombatSkillPlans.Length;
			for (int l = 0; l < elementsCount4; l++)
			{
				CombatSkillPlan element4 = CombatSkillPlans[l];
				totalSize = ((element4 == null) ? (totalSize + 2) : (totalSize + (2 + element4.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CurrLifeSkillAttainmentPanelPlanIndex == null) ? (totalSize + 2) : (totalSize + (2 + CurrLifeSkillAttainmentPanelPlanIndex.Length)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SkillBreakPlateDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SkillBreakBonusDict);
		totalSize = ((CombatSkillAttainmentPanelPlans == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CombatSkillAttainmentPanelPlans.Length)));
		totalSize = ((CurrCombatSkillAttainmentPanelPlanIds == null) ? (totalSize + 2) : (totalSize + (2 + CurrCombatSkillAttainmentPanelPlanIds.Length)));
		if (EquipmentsPlans != null)
		{
			totalSize += 2;
			int elementsCount5 = EquipmentsPlans.Length;
			for (int m = 0; m < elementsCount5; m++)
			{
				EquipmentPlan element5 = EquipmentsPlans[m];
				totalSize = ((element5 == null) ? (totalSize + 2) : (totalSize + (2 + element5.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((WeaponInnerRatios == null) ? (totalSize + 2) : (totalSize + (2 + WeaponInnerRatios.Length)));
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(ReadingBooks);
		totalSize += ExtraNeiliAllocationProgress.GetSerializedSize();
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Professions);
		totalSize = ((HandledOneShotEvents == null) ? (totalSize + 2) : (totalSize + (2 + 4 * HandledOneShotEvents.Count)));
		totalSize = ((TreasuryItems == null) ? (totalSize + 2) : (totalSize + (2 + TreasuryItems.GetSerializedSize())));
		totalSize = ((TroughItems == null) ? (totalSize + 2) : (totalSize + (2 + TroughItems.GetSerializedSize())));
		totalSize = ((LegaciesBuildingTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LegaciesBuildingTemplateIds.Count)));
		totalSize = ((ReadingEventBookIdList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ReadingEventBookIdList.Count)));
		totalSize = ((ProfessionSkillSlots == null) ? (totalSize + 2) : (totalSize + (2 + ProfessionSkillSlots.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(AvailableReadingStrategyMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(ClearedSkillPlateStepInfo);
		totalSize += CurrMasteredCombatSkillPlan.GetSerializedSize();
		if (MasteredCombatSkillPlans != null)
		{
			totalSize += 2;
			int elementsCount6 = MasteredCombatSkillPlans.Length;
			for (int n = 0; n < elementsCount6; n++)
			{
				totalSize += MasteredCombatSkillPlans[n].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (JiaoPools != null)
		{
			totalSize += 2;
			int elementsCount7 = JiaoPools.Count;
			for (int num = 0; num < elementsCount7; num++)
			{
				JiaoPool element6 = JiaoPools[num];
				totalSize = ((element6 == null) ? (totalSize + 2) : (totalSize + (2 + element6.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(TaiwuCombatSkillProficiencies);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectEmeiSkillBreakBonus);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectEmeiBreakBonusTemplateIds);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectEmeiBonusData);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectFulongOrgMemberChickens);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectZhujianGearMate);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(LegendaryBookBreakPlateCounts);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillBreakPlateList);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillBreakPlateLastClearTimeList);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillBreakPlateLastForceBreakoutStepsCount);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CombatSkillCurrBreakPlateIndex);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(LegendaryBookWeaponSlot);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(LegendaryBookWeaponEffectId);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(LegendaryBookSkillSlot);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(LegendaryBookSkillEffectId);
		totalSize += LegendaryBookBonusCountYin.GetSerializedSize();
		totalSize += LegendaryBookBonusCountYang.GetSerializedSize();
		totalSize = ((StockItems == null) ? (totalSize + 2) : (totalSize + (2 + StockItems.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(WeaponInnerRatiosByTemplateId);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(WeaponInnerRatiosById);
		totalSize = ((LockedItems == null) ? (totalSize + 2) : (totalSize + (2 + LockedItems.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillBreakPresets);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillBreakPlates);
		totalSize = ((ProfessionFeatures == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ProfessionFeatures.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(BuildingResourceOutputSettings);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(VillagerRoleAutoActionStates);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(ComfortableHousesAutoCheckInType);
		totalSize = ((BuildingDefaultStoreLocation == null) ? (totalSize + 2) : (totalSize + (2 + BuildingDefaultStoreLocation.GetSerializedSize())));
		totalSize = ((AutoCheckInComfortableList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AutoCheckInComfortableList.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 85;
		pCurrData += 2;
		if (TaiwuChar != null)
		{
			byte* pSubDataCount = pCurrData;
			pCurrData += 2;
			int fieldSize = TaiwuChar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)pSubDataCount = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += TaiwuResources.Serialize(pCurrData);
		*(int*)pCurrData = TaiwuExp;
		pCurrData += 4;
		if (ExternalEquippedCombatSkills != null)
		{
			byte* pSubDataCount2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = ExternalEquippedCombatSkills.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)pSubDataCount2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (NormalInformation != null)
		{
			byte* pSubDataCount3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = NormalInformation.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)pSubDataCount3 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatSkills != null)
		{
			int elementsCount = CombatSkills.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += CombatSkills[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuEffects != null)
		{
			int elementsCount2 = TaiwuEffects.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				SpecialEffectWrapper element = TaiwuEffects[j];
				if (element != null)
				{
					byte* pSubDataCount4 = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)pSubDataCount4 = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref UnpackedItems);
		pCurrData += TaiwuVillageLocation.Serialize(pCurrData);
		pCurrData += TaiwuVillageAreaData.Serialize(pCurrData);
		if (TaiwuVillageBlocks != null)
		{
			int elementsCount3 = TaiwuVillageBlocks.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				BuildingBlockData element2 = TaiwuVillageBlocks[k];
				if (element2 != null)
				{
					byte* pSubDataCount5 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)pSubDataCount5 = (ushort)subDataSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Chicken);
		if (XiangshuIdInKungfuPracticeRoom != null)
		{
			int elementsCount4 = XiangshuIdInKungfuPracticeRoom.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (byte)XiangshuIdInKungfuPracticeRoom[l];
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CricketCollectionDatas != null)
		{
			int elementsCount5 = CricketCollectionDatas.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				CricketCollectionData element3 = CricketCollectionDatas[m];
				if (element3 != null)
				{
					byte* pSubDataCount6 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)pSubDataCount6 = (ushort)subDataSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AutoWorkBlockIndexList != null)
		{
			int elementsCount6 = AutoWorkBlockIndexList.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				((short*)pCurrData)[n] = AutoWorkBlockIndexList[n];
			}
			pCurrData += 2 * elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AutoSoldBlockIndexList != null)
		{
			int elementsCount7 = AutoSoldBlockIndexList.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				((short*)pCurrData)[num] = AutoSoldBlockIndexList[num];
			}
			pCurrData += 2 * elementsCount7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AutoCheckInList != null)
		{
			int elementsCount8 = AutoCheckInList.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				((short*)pCurrData)[num2] = AutoCheckInList[num2];
			}
			pCurrData += 2 * elementsCount8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (WarehouseItems != null)
		{
			byte* pSubDataCount7 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = WarehouseItems.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)pSubDataCount7 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuCombatSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref NotLearnedCombatSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref NotLearnedLifeSkills);
		if (CombatSkillPlans != null)
		{
			int elementsCount9 = CombatSkillPlans.Length;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				CombatSkillPlan element4 = CombatSkillPlans[num3];
				if (element4 != null)
				{
					byte* pSubDataCount8 = pCurrData;
					pCurrData += 2;
					int subDataSize4 = element4.Serialize(pCurrData);
					pCurrData += subDataSize4;
					Tester.Assert(subDataSize4 <= 65535);
					*(ushort*)pSubDataCount8 = (ushort)subDataSize4;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CurrCombatSkillPlanId;
		pCurrData += 4;
		if (CurrLifeSkillAttainmentPanelPlanIndex != null)
		{
			int elementsCount10 = CurrLifeSkillAttainmentPanelPlanIndex.Length;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				pCurrData[num4] = (byte)CurrLifeSkillAttainmentPanelPlanIndex[num4];
			}
			pCurrData += elementsCount10;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SkillBreakPlateDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SkillBreakBonusDict);
		if (CombatSkillAttainmentPanelPlans != null)
		{
			int elementsCount11 = CombatSkillAttainmentPanelPlans.Length;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				((short*)pCurrData)[num5] = CombatSkillAttainmentPanelPlans[num5];
			}
			pCurrData += 2 * elementsCount11;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CurrCombatSkillAttainmentPanelPlanIds != null)
		{
			int elementsCount12 = CurrCombatSkillAttainmentPanelPlanIds.Length;
			Tester.Assert(elementsCount12 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount12;
			pCurrData += 2;
			for (int num6 = 0; num6 < elementsCount12; num6++)
			{
				pCurrData[num6] = (byte)CurrCombatSkillAttainmentPanelPlanIds[num6];
			}
			pCurrData += elementsCount12;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EquipmentsPlans != null)
		{
			int elementsCount13 = EquipmentsPlans.Length;
			Tester.Assert(elementsCount13 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount13;
			pCurrData += 2;
			for (int num7 = 0; num7 < elementsCount13; num7++)
			{
				EquipmentPlan element5 = EquipmentsPlans[num7];
				if (element5 != null)
				{
					byte* pSubDataCount9 = pCurrData;
					pCurrData += 2;
					int subDataSize5 = element5.Serialize(pCurrData);
					pCurrData += subDataSize5;
					Tester.Assert(subDataSize5 <= 65535);
					*(ushort*)pSubDataCount9 = (ushort)subDataSize5;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CurrEquipmentPlanId;
		pCurrData += 4;
		if (WeaponInnerRatios != null)
		{
			int elementsCount14 = WeaponInnerRatios.Length;
			Tester.Assert(elementsCount14 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount14;
			pCurrData += 2;
			for (int num8 = 0; num8 < elementsCount14; num8++)
			{
				pCurrData[num8] = (byte)WeaponInnerRatios[num8];
			}
			pCurrData += elementsCount14;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)VoiceWeaponInnerRatio;
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Serialize(pCurrData, ref ReadingBooks);
		*(int*)pCurrData = BuildingSpaceExtraAdd;
		pCurrData += 4;
		int fieldSize5 = ExtraNeiliAllocationProgress.Serialize(pCurrData);
		pCurrData += fieldSize5;
		Tester.Assert(fieldSize5 <= 65535);
		pCurrData += ExtraNeiliAllocation.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Professions);
		if (HandledOneShotEvents != null)
		{
			int elementsCount15 = HandledOneShotEvents.Count;
			Tester.Assert(elementsCount15 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount15;
			pCurrData += 2;
			for (int num9 = 0; num9 < elementsCount15; num9++)
			{
				((int*)pCurrData)[num9] = HandledOneShotEvents[num9];
			}
			pCurrData += 4 * elementsCount15;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TreasuryItems != null)
		{
			byte* pSubDataCount10 = pCurrData;
			pCurrData += 2;
			int fieldSize6 = TreasuryItems.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= 65535);
			*(ushort*)pSubDataCount10 = (ushort)fieldSize6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TroughItems != null)
		{
			byte* pSubDataCount11 = pCurrData;
			pCurrData += 2;
			int fieldSize7 = TroughItems.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= 65535);
			*(ushort*)pSubDataCount11 = (ushort)fieldSize7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LegaciesBuildingTemplateIds != null)
		{
			int elementsCount16 = LegaciesBuildingTemplateIds.Count;
			Tester.Assert(elementsCount16 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount16;
			pCurrData += 2;
			for (int num10 = 0; num10 < elementsCount16; num10++)
			{
				((short*)pCurrData)[num10] = LegaciesBuildingTemplateIds[num10];
			}
			pCurrData += 2 * elementsCount16;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReadingEventBookIdList != null)
		{
			int elementsCount17 = ReadingEventBookIdList.Count;
			Tester.Assert(elementsCount17 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount17;
			pCurrData += 2;
			for (int num11 = 0; num11 < elementsCount17; num11++)
			{
				((int*)pCurrData)[num11] = ReadingEventBookIdList[num11];
			}
			pCurrData += 4 * elementsCount17;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ProfessionSkillSlots != null)
		{
			byte* pSubDataCount12 = pCurrData;
			pCurrData += 2;
			int fieldSize8 = ProfessionSkillSlots.Serialize(pCurrData);
			pCurrData += fieldSize8;
			Tester.Assert(fieldSize8 <= 65535);
			*(ushort*)pSubDataCount12 = (ushort)fieldSize8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref AvailableReadingStrategyMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref ClearedSkillPlateStepInfo);
		pCurrData += TaiwuMaxNeiliAllocation.Serialize(pCurrData);
		int fieldSize9 = CurrMasteredCombatSkillPlan.Serialize(pCurrData);
		pCurrData += fieldSize9;
		Tester.Assert(fieldSize9 <= 65535);
		if (MasteredCombatSkillPlans != null)
		{
			int elementsCount18 = MasteredCombatSkillPlans.Length;
			Tester.Assert(elementsCount18 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount18;
			pCurrData += 2;
			for (int num12 = 0; num12 < elementsCount18; num12++)
			{
				int subDataSize6 = MasteredCombatSkillPlans[num12].Serialize(pCurrData);
				pCurrData += subDataSize6;
				Tester.Assert(subDataSize6 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = UnlockedCombatSkillPlanCount;
		pCurrData++;
		if (JiaoPools != null)
		{
			int elementsCount19 = JiaoPools.Count;
			Tester.Assert(elementsCount19 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount19;
			pCurrData += 2;
			for (int num13 = 0; num13 < elementsCount19; num13++)
			{
				JiaoPool element6 = JiaoPools[num13];
				if (element6 != null)
				{
					byte* pSubDataCount13 = pCurrData;
					pCurrData += 2;
					int subDataSize7 = element6.Serialize(pCurrData);
					pCurrData += subDataSize7;
					Tester.Assert(subDataSize7 <= 65535);
					*(ushort*)pSubDataCount13 = (ushort)subDataSize7;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsJiaoPoolOpen ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = MaxTaiwuVillageLevel;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref TaiwuCombatSkillProficiencies);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectEmeiSkillBreakBonus);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectEmeiBreakBonusTemplateIds);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectEmeiBonusData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectFulongOrgMemberChickens);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectZhujianGearMate);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref LegendaryBookBreakPlateCounts);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkillBreakPlateList);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkillBreakPlateLastClearTimeList);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkillBreakPlateLastForceBreakoutStepsCount);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CombatSkillCurrBreakPlateIndex);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref LegendaryBookWeaponSlot);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref LegendaryBookWeaponEffectId);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref LegendaryBookSkillSlot);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref LegendaryBookSkillEffectId);
		int fieldSize10 = LegendaryBookBonusCountYin.Serialize(pCurrData);
		pCurrData += fieldSize10;
		Tester.Assert(fieldSize10 <= 65535);
		int fieldSize11 = LegendaryBookBonusCountYang.Serialize(pCurrData);
		pCurrData += fieldSize11;
		Tester.Assert(fieldSize11 <= 65535);
		if (StockItems != null)
		{
			byte* pSubDataCount14 = pCurrData;
			pCurrData += 2;
			int fieldSize12 = StockItems.Serialize(pCurrData);
			pCurrData += fieldSize12;
			Tester.Assert(fieldSize12 <= 65535);
			*(ushort*)pSubDataCount14 = (ushort)fieldSize12;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref WeaponInnerRatiosByTemplateId);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref WeaponInnerRatiosById);
		pCurrData += TaiwuTreasuryResources.Serialize(pCurrData);
		if (LockedItems != null)
		{
			byte* pSubDataCount15 = pCurrData;
			pCurrData += 2;
			int fieldSize13 = LockedItems.Serialize(pCurrData);
			pCurrData += fieldSize13;
			Tester.Assert(fieldSize13 <= 65535);
			*(ushort*)pSubDataCount15 = (ushort)fieldSize13;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkillBreakPresets);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkillBreakPlates);
		*pCurrData = (IsExtraProfessionSkillUnlocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ProfessionFeatures != null)
		{
			int elementsCount20 = ProfessionFeatures.Count;
			Tester.Assert(elementsCount20 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount20;
			pCurrData += 2;
			for (int num14 = 0; num14 < elementsCount20; num14++)
			{
				((short*)pCurrData)[num14] = ProfessionFeatures[num14];
			}
			pCurrData += 2 * elementsCount20;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref BuildingResourceOutputSettings);
		*pCurrData = (byte)FarmerAutoCollectStorageType;
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref VillagerRoleAutoActionStates);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref ComfortableHousesAutoCheckInType);
		if (BuildingDefaultStoreLocation != null)
		{
			byte* pSubDataCount16 = pCurrData;
			pCurrData += 2;
			int fieldSize14 = BuildingDefaultStoreLocation.Serialize(pCurrData);
			pCurrData += fieldSize14;
			Tester.Assert(fieldSize14 <= 65535);
			*(ushort*)pSubDataCount16 = (ushort)fieldSize14;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AutoCheckInComfortableList != null)
		{
			int elementsCount21 = AutoCheckInComfortableList.Count;
			Tester.Assert(elementsCount21 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount21;
			pCurrData += 2;
			for (int num15 = 0; num15 < elementsCount21; num15++)
			{
				((short*)pCurrData)[num15] = AutoCheckInComfortableList[num15];
			}
			pCurrData += 2 * elementsCount21;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort fieldSize = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize > 0)
			{
				if (TaiwuChar == null)
				{
					TaiwuChar = new GameData.Domains.Character.Character();
				}
				pCurrData += TaiwuChar.Deserialize(pCurrData);
			}
			else
			{
				TaiwuChar = null;
			}
		}
		if (fieldCount > 1)
		{
			pCurrData += TaiwuResources.Deserialize(pCurrData);
		}
		if (fieldCount > 2)
		{
			TaiwuExp = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			ushort fieldSize2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize2 > 0)
			{
				if (ExternalEquippedCombatSkills == null)
				{
					ExternalEquippedCombatSkills = new CombatSkillPlan();
				}
				pCurrData += ExternalEquippedCombatSkills.Deserialize(pCurrData);
			}
			else
			{
				ExternalEquippedCombatSkills = null;
			}
		}
		if (fieldCount > 4)
		{
			ushort fieldSize3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize3 > 0)
			{
				if (NormalInformation == null)
				{
					NormalInformation = new NormalInformationCollection();
				}
				pCurrData += NormalInformation.Deserialize(pCurrData);
			}
			else
			{
				NormalInformation = null;
			}
		}
		if (fieldCount > 5)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (CombatSkills == null)
				{
					CombatSkills = new List<GameData.Domains.CombatSkill.CombatSkill>(elementsCount);
				}
				else
				{
					CombatSkills.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					GameData.Domains.CombatSkill.CombatSkill element = new GameData.Domains.CombatSkill.CombatSkill();
					pCurrData += element.Deserialize(pCurrData);
					CombatSkills.Add(element);
				}
			}
			else
			{
				CombatSkills?.Clear();
			}
		}
		if (fieldCount > 6)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (TaiwuEffects == null)
				{
					TaiwuEffects = new List<SpecialEffectWrapper>(elementsCount2);
				}
				else
				{
					TaiwuEffects.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ushort subDataCount = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount > 0)
					{
						SpecialEffectWrapper element2 = new SpecialEffectWrapper();
						pCurrData += element2.Deserialize(pCurrData);
						TaiwuEffects.Add(element2);
					}
					else
					{
						TaiwuEffects.Add(null);
					}
				}
			}
			else
			{
				TaiwuEffects?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref UnpackedItems);
		}
		if (fieldCount > 8)
		{
			pCurrData += TaiwuVillageLocation.Deserialize(pCurrData);
		}
		if (fieldCount > 9)
		{
			if (TaiwuVillageAreaData == null)
			{
				TaiwuVillageAreaData = new BuildingAreaData();
			}
			pCurrData += TaiwuVillageAreaData.Deserialize(pCurrData);
		}
		if (fieldCount > 10)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (TaiwuVillageBlocks == null)
				{
					TaiwuVillageBlocks = new List<BuildingBlockData>(elementsCount3);
				}
				else
				{
					TaiwuVillageBlocks.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ushort subDataCount2 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount2 > 0)
					{
						BuildingBlockData element3 = new BuildingBlockData();
						pCurrData += element3.Deserialize(pCurrData);
						TaiwuVillageBlocks.Add(element3);
					}
					else
					{
						TaiwuVillageBlocks.Add(null);
					}
				}
			}
			else
			{
				TaiwuVillageBlocks?.Clear();
			}
		}
		if (fieldCount > 11)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Chicken);
		}
		if (fieldCount > 12)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (XiangshuIdInKungfuPracticeRoom == null)
				{
					XiangshuIdInKungfuPracticeRoom = new List<sbyte>(elementsCount4);
				}
				else
				{
					XiangshuIdInKungfuPracticeRoom.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					XiangshuIdInKungfuPracticeRoom.Add((sbyte)pCurrData[l]);
				}
				pCurrData += (int)elementsCount4;
			}
			else
			{
				XiangshuIdInKungfuPracticeRoom?.Clear();
			}
		}
		if (fieldCount > 13)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (CricketCollectionDatas == null)
				{
					CricketCollectionDatas = new List<CricketCollectionData>(elementsCount5);
				}
				else
				{
					CricketCollectionDatas.Clear();
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					ushort subDataCount3 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount3 > 0)
					{
						CricketCollectionData element4 = new CricketCollectionData();
						pCurrData += element4.Deserialize(pCurrData);
						CricketCollectionDatas.Add(element4);
					}
					else
					{
						CricketCollectionDatas.Add(null);
					}
				}
			}
			else
			{
				CricketCollectionDatas?.Clear();
			}
		}
		if (fieldCount > 14)
		{
			ushort elementsCount6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount6 > 0)
			{
				if (AutoWorkBlockIndexList == null)
				{
					AutoWorkBlockIndexList = new List<short>(elementsCount6);
				}
				else
				{
					AutoWorkBlockIndexList.Clear();
				}
				for (int n = 0; n < elementsCount6; n++)
				{
					AutoWorkBlockIndexList.Add(((short*)pCurrData)[n]);
				}
				pCurrData += 2 * elementsCount6;
			}
			else
			{
				AutoWorkBlockIndexList?.Clear();
			}
		}
		if (fieldCount > 15)
		{
			ushort elementsCount7 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount7 > 0)
			{
				if (AutoSoldBlockIndexList == null)
				{
					AutoSoldBlockIndexList = new List<short>(elementsCount7);
				}
				else
				{
					AutoSoldBlockIndexList.Clear();
				}
				for (int num = 0; num < elementsCount7; num++)
				{
					AutoSoldBlockIndexList.Add(((short*)pCurrData)[num]);
				}
				pCurrData += 2 * elementsCount7;
			}
			else
			{
				AutoSoldBlockIndexList?.Clear();
			}
		}
		if (fieldCount > 16)
		{
			ushort elementsCount8 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount8 > 0)
			{
				if (AutoCheckInList == null)
				{
					AutoCheckInList = new List<short>(elementsCount8);
				}
				else
				{
					AutoCheckInList.Clear();
				}
				for (int num2 = 0; num2 < elementsCount8; num2++)
				{
					AutoCheckInList.Add(((short*)pCurrData)[num2]);
				}
				pCurrData += 2 * elementsCount8;
			}
			else
			{
				AutoCheckInList?.Clear();
			}
		}
		if (fieldCount > 17)
		{
			ushort fieldSize4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize4 > 0)
			{
				if (WarehouseItems == null)
				{
					WarehouseItems = new Inventory();
				}
				pCurrData += WarehouseItems.Deserialize(pCurrData);
			}
			else
			{
				WarehouseItems = null;
			}
		}
		if (fieldCount > 18)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuCombatSkills);
		}
		if (fieldCount > 19)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuLifeSkills);
		}
		if (fieldCount > 20)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref NotLearnedCombatSkills);
		}
		if (fieldCount > 21)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref NotLearnedLifeSkills);
		}
		if (fieldCount > 22)
		{
			ushort elementsCount9 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount9 > 0)
			{
				if (CombatSkillPlans == null || CombatSkillPlans.Length != elementsCount9)
				{
					CombatSkillPlans = new CombatSkillPlan[elementsCount9];
				}
				for (int num3 = 0; num3 < elementsCount9; num3++)
				{
					ushort subDataCount4 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount4 > 0)
					{
						CombatSkillPlan element5 = CombatSkillPlans[num3] ?? new CombatSkillPlan();
						pCurrData += element5.Deserialize(pCurrData);
						CombatSkillPlans[num3] = element5;
					}
					else
					{
						CombatSkillPlans[num3] = null;
					}
				}
			}
			else
			{
				CombatSkillPlans = null;
			}
		}
		if (fieldCount > 23)
		{
			CurrCombatSkillPlanId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 24)
		{
			ushort elementsCount10 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount10 > 0)
			{
				if (CurrLifeSkillAttainmentPanelPlanIndex == null || CurrLifeSkillAttainmentPanelPlanIndex.Length != elementsCount10)
				{
					CurrLifeSkillAttainmentPanelPlanIndex = new sbyte[elementsCount10];
				}
				for (int num4 = 0; num4 < elementsCount10; num4++)
				{
					CurrLifeSkillAttainmentPanelPlanIndex[num4] = (sbyte)pCurrData[num4];
				}
				pCurrData += (int)elementsCount10;
			}
			else
			{
				CurrLifeSkillAttainmentPanelPlanIndex = null;
			}
		}
		if (fieldCount > 25)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SkillBreakPlateDict);
		}
		if (fieldCount > 26)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SkillBreakBonusDict);
		}
		if (fieldCount > 27)
		{
			ushort elementsCount11 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount11 > 0)
			{
				if (CombatSkillAttainmentPanelPlans == null || CombatSkillAttainmentPanelPlans.Length != elementsCount11)
				{
					CombatSkillAttainmentPanelPlans = new short[elementsCount11];
				}
				for (int num5 = 0; num5 < elementsCount11; num5++)
				{
					CombatSkillAttainmentPanelPlans[num5] = ((short*)pCurrData)[num5];
				}
				pCurrData += 2 * elementsCount11;
			}
			else
			{
				CombatSkillAttainmentPanelPlans = null;
			}
		}
		if (fieldCount > 28)
		{
			ushort elementsCount12 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount12 > 0)
			{
				if (CurrCombatSkillAttainmentPanelPlanIds == null || CurrCombatSkillAttainmentPanelPlanIds.Length != elementsCount12)
				{
					CurrCombatSkillAttainmentPanelPlanIds = new sbyte[elementsCount12];
				}
				for (int num6 = 0; num6 < elementsCount12; num6++)
				{
					CurrCombatSkillAttainmentPanelPlanIds[num6] = (sbyte)pCurrData[num6];
				}
				pCurrData += (int)elementsCount12;
			}
			else
			{
				CurrCombatSkillAttainmentPanelPlanIds = null;
			}
		}
		if (fieldCount > 29)
		{
			ushort elementsCount13 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount13 > 0)
			{
				if (EquipmentsPlans == null || EquipmentsPlans.Length != elementsCount13)
				{
					EquipmentsPlans = new EquipmentPlan[elementsCount13];
				}
				for (int num7 = 0; num7 < elementsCount13; num7++)
				{
					ushort subDataCount5 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount5 > 0)
					{
						EquipmentPlan element6 = EquipmentsPlans[num7] ?? new EquipmentPlan();
						pCurrData += element6.Deserialize(pCurrData);
						EquipmentsPlans[num7] = element6;
					}
					else
					{
						EquipmentsPlans[num7] = null;
					}
				}
			}
			else
			{
				EquipmentsPlans = null;
			}
		}
		if (fieldCount > 30)
		{
			CurrEquipmentPlanId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 31)
		{
			ushort elementsCount14 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount14 > 0)
			{
				if (WeaponInnerRatios == null || WeaponInnerRatios.Length != elementsCount14)
				{
					WeaponInnerRatios = new sbyte[elementsCount14];
				}
				for (int num8 = 0; num8 < elementsCount14; num8++)
				{
					WeaponInnerRatios[num8] = (sbyte)pCurrData[num8];
				}
				pCurrData += (int)elementsCount14;
			}
			else
			{
				WeaponInnerRatios = null;
			}
		}
		if (fieldCount > 32)
		{
			VoiceWeaponInnerRatio = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 33)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref ReadingBooks);
		}
		if (fieldCount > 34)
		{
			BuildingSpaceExtraAdd = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 35)
		{
			pCurrData += ExtraNeiliAllocationProgress.Deserialize(pCurrData);
		}
		if (fieldCount > 36)
		{
			pCurrData += ExtraNeiliAllocation.Deserialize(pCurrData);
		}
		if (fieldCount > 37)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Professions);
		}
		if (fieldCount > 38)
		{
			ushort elementsCount15 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount15 > 0)
			{
				if (HandledOneShotEvents == null)
				{
					HandledOneShotEvents = new List<int>(elementsCount15);
				}
				else
				{
					HandledOneShotEvents.Clear();
				}
				for (int num9 = 0; num9 < elementsCount15; num9++)
				{
					HandledOneShotEvents.Add(((int*)pCurrData)[num9]);
				}
				pCurrData += 4 * elementsCount15;
			}
			else
			{
				HandledOneShotEvents?.Clear();
			}
		}
		if (fieldCount > 39)
		{
			ushort fieldSize5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize5 > 0)
			{
				if (TreasuryItems == null)
				{
					TreasuryItems = new Inventory();
				}
				pCurrData += TreasuryItems.Deserialize(pCurrData);
			}
			else
			{
				TreasuryItems = null;
			}
		}
		if (fieldCount > 40)
		{
			ushort fieldSize6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize6 > 0)
			{
				if (TroughItems == null)
				{
					TroughItems = new Inventory();
				}
				pCurrData += TroughItems.Deserialize(pCurrData);
			}
			else
			{
				TroughItems = null;
			}
		}
		if (fieldCount > 41)
		{
			ushort elementsCount16 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount16 > 0)
			{
				if (LegaciesBuildingTemplateIds == null)
				{
					LegaciesBuildingTemplateIds = new List<short>(elementsCount16);
				}
				else
				{
					LegaciesBuildingTemplateIds.Clear();
				}
				for (int num10 = 0; num10 < elementsCount16; num10++)
				{
					LegaciesBuildingTemplateIds.Add(((short*)pCurrData)[num10]);
				}
				pCurrData += 2 * elementsCount16;
			}
			else
			{
				LegaciesBuildingTemplateIds?.Clear();
			}
		}
		if (fieldCount > 42)
		{
			ushort elementsCount17 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount17 > 0)
			{
				if (ReadingEventBookIdList == null)
				{
					ReadingEventBookIdList = new List<int>(elementsCount17);
				}
				else
				{
					ReadingEventBookIdList.Clear();
				}
				for (int num11 = 0; num11 < elementsCount17; num11++)
				{
					ReadingEventBookIdList.Add(((int*)pCurrData)[num11]);
				}
				pCurrData += 4 * elementsCount17;
			}
			else
			{
				ReadingEventBookIdList?.Clear();
			}
		}
		if (fieldCount > 43)
		{
			ushort fieldSize7 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize7 > 0)
			{
				if (ProfessionSkillSlots == null)
				{
					ProfessionSkillSlots = new TaiwuProfessionSkillSlots();
				}
				pCurrData += ProfessionSkillSlots.Deserialize(pCurrData);
			}
			else
			{
				ProfessionSkillSlots = null;
			}
		}
		if (fieldCount > 44)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref AvailableReadingStrategyMap);
		}
		if (fieldCount > 45)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref ClearedSkillPlateStepInfo);
		}
		if (fieldCount > 46)
		{
			pCurrData += TaiwuMaxNeiliAllocation.Deserialize(pCurrData);
		}
		if (fieldCount > 47)
		{
			pCurrData += CurrMasteredCombatSkillPlan.Deserialize(pCurrData);
		}
		if (fieldCount > 48)
		{
			ushort elementsCount18 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount18 > 0)
			{
				if (MasteredCombatSkillPlans == null || MasteredCombatSkillPlans.Length != elementsCount18)
				{
					MasteredCombatSkillPlans = new ShortList[elementsCount18];
				}
				for (int num12 = 0; num12 < elementsCount18; num12++)
				{
					ShortList element7 = default(ShortList);
					pCurrData += element7.Deserialize(pCurrData);
					MasteredCombatSkillPlans[num12] = element7;
				}
			}
			else
			{
				MasteredCombatSkillPlans = null;
			}
		}
		if (fieldCount > 49)
		{
			UnlockedCombatSkillPlanCount = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 50)
		{
			ushort elementsCount19 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount19 > 0)
			{
				if (JiaoPools == null)
				{
					JiaoPools = new List<JiaoPool>(elementsCount19);
				}
				else
				{
					JiaoPools.Clear();
				}
				for (int num13 = 0; num13 < elementsCount19; num13++)
				{
					ushort subDataCount6 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount6 > 0)
					{
						JiaoPool element8 = new JiaoPool();
						pCurrData += element8.Deserialize(pCurrData);
						JiaoPools.Add(element8);
					}
					else
					{
						JiaoPools.Add(null);
					}
				}
			}
			else
			{
				JiaoPools?.Clear();
			}
		}
		if (fieldCount > 51)
		{
			IsJiaoPoolOpen = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 52)
		{
			MaxTaiwuVillageLevel = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 53)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref TaiwuCombatSkillProficiencies);
		}
		if (fieldCount > 54)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectEmeiSkillBreakBonus);
		}
		if (fieldCount > 55)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectEmeiBreakBonusTemplateIds);
		}
		if (fieldCount > 56)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectEmeiBonusData);
		}
		if (fieldCount > 57)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectFulongOrgMemberChickens);
		}
		if (fieldCount > 58)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectZhujianGearMate);
		}
		if (fieldCount > 59)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref LegendaryBookBreakPlateCounts);
		}
		if (fieldCount > 60)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillBreakPlateList);
		}
		if (fieldCount > 61)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillBreakPlateLastClearTimeList);
		}
		if (fieldCount > 62)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillBreakPlateLastForceBreakoutStepsCount);
		}
		if (fieldCount > 63)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CombatSkillCurrBreakPlateIndex);
		}
		if (fieldCount > 64)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref LegendaryBookWeaponSlot);
		}
		if (fieldCount > 65)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref LegendaryBookWeaponEffectId);
		}
		if (fieldCount > 66)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref LegendaryBookSkillSlot);
		}
		if (fieldCount > 67)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref LegendaryBookSkillEffectId);
		}
		if (fieldCount > 68)
		{
			pCurrData += LegendaryBookBonusCountYin.Deserialize(pCurrData);
		}
		if (fieldCount > 69)
		{
			pCurrData += LegendaryBookBonusCountYang.Deserialize(pCurrData);
		}
		if (fieldCount > 70)
		{
			ushort fieldSize8 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize8 > 0)
			{
				if (StockItems == null)
				{
					StockItems = new Inventory();
				}
				pCurrData += StockItems.Deserialize(pCurrData);
			}
			else
			{
				StockItems = null;
			}
		}
		if (fieldCount > 71)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref WeaponInnerRatiosByTemplateId);
		}
		if (fieldCount > 72)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref WeaponInnerRatiosById);
		}
		if (fieldCount > 73)
		{
			pCurrData += TaiwuTreasuryResources.Deserialize(pCurrData);
		}
		if (fieldCount > 74)
		{
			ushort fieldSize9 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize9 > 0)
			{
				if (LockedItems == null)
				{
					LockedItems = new Inventory();
				}
				pCurrData += LockedItems.Deserialize(pCurrData);
			}
			else
			{
				LockedItems = null;
			}
		}
		if (fieldCount > 75)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillBreakPresets);
		}
		if (fieldCount > 76)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillBreakPlates);
		}
		if (fieldCount > 77)
		{
			IsExtraProfessionSkillUnlocked = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 78)
		{
			ushort elementsCount20 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount20 > 0)
			{
				if (ProfessionFeatures == null)
				{
					ProfessionFeatures = new List<short>(elementsCount20);
				}
				else
				{
					ProfessionFeatures.Clear();
				}
				for (int num14 = 0; num14 < elementsCount20; num14++)
				{
					ProfessionFeatures.Add(((short*)pCurrData)[num14]);
				}
				pCurrData += 2 * elementsCount20;
			}
			else
			{
				ProfessionFeatures?.Clear();
			}
		}
		if (fieldCount > 79)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref BuildingResourceOutputSettings);
		}
		if (fieldCount > 80)
		{
			FarmerAutoCollectStorageType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 81)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref VillagerRoleAutoActionStates);
		}
		if (fieldCount > 82)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref ComfortableHousesAutoCheckInType);
		}
		if (fieldCount > 83)
		{
			ushort fieldSize10 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize10 > 0)
			{
				if (BuildingDefaultStoreLocation == null)
				{
					BuildingDefaultStoreLocation = new BuildingDefaultStoreLocation();
				}
				pCurrData += BuildingDefaultStoreLocation.Deserialize(pCurrData);
			}
			else
			{
				BuildingDefaultStoreLocation = null;
			}
		}
		if (fieldCount > 84)
		{
			ushort elementsCount21 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount21 > 0)
			{
				if (AutoCheckInComfortableList == null)
				{
					AutoCheckInComfortableList = new List<short>(elementsCount21);
				}
				else
				{
					AutoCheckInComfortableList.Clear();
				}
				for (int num15 = 0; num15 < elementsCount21; num15++)
				{
					AutoCheckInComfortableList.Add(((short*)pCurrData)[num15]);
				}
				pCurrData += 2 * elementsCount21;
			}
			else
			{
				AutoCheckInComfortableList?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
