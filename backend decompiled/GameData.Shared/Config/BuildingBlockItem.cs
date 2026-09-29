using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class BuildingBlockItem : ConfigItem<BuildingBlockItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly EBuildingBlockFuncType FuncType;

	public readonly string Desc;

	public readonly string FuncDesc;

	public readonly string Icon;

	public readonly string FuncIcon;

	public readonly bool HaveDynamicIcon;

	public readonly EBuildingBlockType Type;

	public readonly EBuildingBlockClass Class;

	public readonly sbyte MaxLevel;

	public readonly bool CanOpenManageOutTaiwu;

	public readonly sbyte Width;

	public readonly string Color;

	public readonly ushort[] BaseBuildCost;

	public readonly byte RemoveGetResourcePercent;

	public readonly sbyte MoveBuildCostResourceRate;

	public readonly sbyte[] CollectResourcePercent;

	public readonly short BuildingCoreItem;

	public readonly List<short> DependBuildings;

	public readonly List<short> ExpandBuildings;

	public readonly sbyte RequireLifeSkillType;

	public readonly sbyte RequireCombatSkillType;

	public readonly sbyte RequirePersonalityType;

	public readonly string LeaderName;

	public readonly string MemberName;

	public readonly short[] RecruitLifeSkillsAdjust;

	public readonly short[] RecruitCombatSkillsAdjust;

	public readonly short[] OperationTotalProgress;

	public readonly sbyte MaxDurability;

	public readonly List<ResourceInfo> BaseMaintenanceCost;

	public readonly int BaseRepairCost;

	public readonly bool MustMaintenance;

	public readonly bool IsUnique;

	public readonly sbyte DestoryType;

	public readonly sbyte AddReadingLifeSkillBookEfficiency;

	public readonly sbyte ReduceCombatSkillCost;

	public readonly sbyte AddCombatSkillBreakout;

	public readonly sbyte AddLifeSkillAttainment;

	public readonly sbyte AddReadingLifeSkillBookFlash;

	public readonly bool CanMakeItem;

	public readonly bool UpgradeMakeItem;

	public readonly sbyte ReduceMakeRequirementLifeSkillType;

	public readonly short[] VillagerRoleTemplateIds;

	public readonly bool IsShop;

	public readonly bool NeedLeader;

	public readonly bool NeedShopProgress;

	public readonly bool IsCollectResourceBuilding;

	public readonly bool ShowResourceStoreLocation;

	public readonly bool ShowItemStoreLocation;

	public readonly bool ShowItemLocationAsResourceLocation;

	public readonly short MaxProduceValue;

	public readonly sbyte RequireCulture;

	public readonly sbyte RequireSafety;

	public readonly List<short> SuccesEvent;

	public readonly List<short> FailEvent;

	public readonly short IdleEvent;

	public readonly List<ShortList> SpecialEvent;

	public readonly sbyte MerchantId;

	public readonly List<short> ExpandInfos;

	public readonly string EffectDesc;

	public readonly sbyte BelongOrganization;

	public readonly string[] BuildingAreaLevelBack;

	public readonly string[] BuildingAreaLevelInfoBackendPattern;

	public readonly bool ArtisanOrderAvailable;

	public readonly byte AvailableOnLoading;

	public readonly List<short> AvailableOrganization;

	public readonly short ApprovingRate;

	public readonly uint DlcAppId;

	public readonly string BaseIcon;

	public readonly short[] IconOffset;

	public MerchantTypeItem Merchant
	{
		[return: MaybeNull]
		get
		{
			return MerchantType.Instance.GetItemOrDefault(MerchantId);
		}
	}

	public BuildingBlockItem(short templateId, string name, EBuildingBlockFuncType funcType, string desc, string funcDesc, string icon, string funcIcon, bool haveDynamicIcon, EBuildingBlockType type, EBuildingBlockClass enumClass, sbyte maxLevel, bool canOpenManageOutTaiwu, sbyte width, string color, ushort[] baseBuildCost, byte removeGetResourcePercent, sbyte moveBuildCostResourceRate, sbyte[] collectResourcePercent, short buildingCoreItem, List<short> dependBuildings, List<short> expandBuildings, sbyte requireLifeSkillType, sbyte requireCombatSkillType, sbyte requirePersonalityType, string leaderName, string memberName, short[] recruitLifeSkillsAdjust, short[] recruitCombatSkillsAdjust, short[] operationTotalProgress, sbyte maxDurability, List<ResourceInfo> baseMaintenanceCost, int baseRepairCost, bool mustMaintenance, bool isUnique, sbyte destoryType, sbyte addReadingLifeSkillBookEfficiency, sbyte reduceCombatSkillCost, sbyte addCombatSkillBreakout, sbyte addLifeSkillAttainment, sbyte addReadingLifeSkillBookFlash, bool canMakeItem, bool upgradeMakeItem, sbyte reduceMakeRequirementLifeSkillType, short[] villagerRoleTemplateIds, bool isShop, bool needLeader, bool needShopProgress, bool isCollectResourceBuilding, bool showResourceStoreLocation, bool showItemStoreLocation, bool showItemLocationAsResourceLocation, short maxProduceValue, sbyte requireCulture, sbyte requireSafety, List<short> succesEvent, List<short> failEvent, short idleEvent, List<ShortList> specialEvent, sbyte merchantId, List<short> expandInfos, string effectDesc, sbyte belongOrganization, string[] buildingAreaLevelBack, string[] buildingAreaLevelInfoBackendPattern, bool artisanOrderAvailable, byte availableOnLoading, List<short> availableOrganization, short approvingRate, uint dlcAppId, string baseIcon, short[] iconOffset)
	{
		TemplateId = templateId;
		Name = name;
		FuncType = funcType;
		Desc = desc;
		FuncDesc = funcDesc;
		Icon = icon;
		FuncIcon = funcIcon;
		HaveDynamicIcon = haveDynamicIcon;
		Type = type;
		Class = enumClass;
		MaxLevel = maxLevel;
		CanOpenManageOutTaiwu = canOpenManageOutTaiwu;
		Width = width;
		Color = color;
		BaseBuildCost = baseBuildCost;
		RemoveGetResourcePercent = removeGetResourcePercent;
		MoveBuildCostResourceRate = moveBuildCostResourceRate;
		CollectResourcePercent = collectResourcePercent;
		BuildingCoreItem = buildingCoreItem;
		DependBuildings = dependBuildings;
		ExpandBuildings = expandBuildings;
		RequireLifeSkillType = requireLifeSkillType;
		RequireCombatSkillType = requireCombatSkillType;
		RequirePersonalityType = requirePersonalityType;
		LeaderName = leaderName;
		MemberName = memberName;
		RecruitLifeSkillsAdjust = recruitLifeSkillsAdjust;
		RecruitCombatSkillsAdjust = recruitCombatSkillsAdjust;
		OperationTotalProgress = operationTotalProgress;
		MaxDurability = maxDurability;
		BaseMaintenanceCost = baseMaintenanceCost;
		BaseRepairCost = baseRepairCost;
		MustMaintenance = mustMaintenance;
		IsUnique = isUnique;
		DestoryType = destoryType;
		AddReadingLifeSkillBookEfficiency = addReadingLifeSkillBookEfficiency;
		ReduceCombatSkillCost = reduceCombatSkillCost;
		AddCombatSkillBreakout = addCombatSkillBreakout;
		AddLifeSkillAttainment = addLifeSkillAttainment;
		AddReadingLifeSkillBookFlash = addReadingLifeSkillBookFlash;
		CanMakeItem = canMakeItem;
		UpgradeMakeItem = upgradeMakeItem;
		ReduceMakeRequirementLifeSkillType = reduceMakeRequirementLifeSkillType;
		VillagerRoleTemplateIds = villagerRoleTemplateIds;
		IsShop = isShop;
		NeedLeader = needLeader;
		NeedShopProgress = needShopProgress;
		IsCollectResourceBuilding = isCollectResourceBuilding;
		ShowResourceStoreLocation = showResourceStoreLocation;
		ShowItemStoreLocation = showItemStoreLocation;
		ShowItemLocationAsResourceLocation = showItemLocationAsResourceLocation;
		MaxProduceValue = maxProduceValue;
		RequireCulture = requireCulture;
		RequireSafety = requireSafety;
		SuccesEvent = succesEvent;
		FailEvent = failEvent;
		IdleEvent = idleEvent;
		SpecialEvent = specialEvent;
		MerchantId = merchantId;
		ExpandInfos = expandInfos;
		EffectDesc = effectDesc;
		BelongOrganization = belongOrganization;
		BuildingAreaLevelBack = buildingAreaLevelBack;
		BuildingAreaLevelInfoBackendPattern = buildingAreaLevelInfoBackendPattern;
		ArtisanOrderAvailable = artisanOrderAvailable;
		AvailableOnLoading = availableOnLoading;
		AvailableOrganization = availableOrganization;
		ApprovingRate = approvingRate;
		DlcAppId = dlcAppId;
		BaseIcon = baseIcon;
		IconOffset = iconOffset;
	}

	public BuildingBlockItem()
	{
		TemplateId = 0;
		Name = null;
		FuncType = EBuildingBlockFuncType.Other;
		Desc = null;
		FuncDesc = null;
		Icon = null;
		FuncIcon = null;
		HaveDynamicIcon = false;
		Type = EBuildingBlockType.Invalid;
		Class = EBuildingBlockClass.Invalid;
		MaxLevel = 1;
		CanOpenManageOutTaiwu = false;
		Width = 1;
		Color = null;
		BaseBuildCost = new ushort[8];
		RemoveGetResourcePercent = 50;
		MoveBuildCostResourceRate = -1;
		CollectResourcePercent = new sbyte[7];
		BuildingCoreItem = 0;
		DependBuildings = new List<short>();
		ExpandBuildings = new List<short>();
		RequireLifeSkillType = 0;
		RequireCombatSkillType = 0;
		RequirePersonalityType = 0;
		LeaderName = null;
		MemberName = null;
		RecruitLifeSkillsAdjust = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		RecruitCombatSkillsAdjust = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		OperationTotalProgress = new short[2] { -1, -1 };
		MaxDurability = -1;
		BaseMaintenanceCost = new List<ResourceInfo>();
		BaseRepairCost = -1;
		MustMaintenance = false;
		IsUnique = false;
		DestoryType = 0;
		AddReadingLifeSkillBookEfficiency = 0;
		ReduceCombatSkillCost = 0;
		AddCombatSkillBreakout = 0;
		AddLifeSkillAttainment = 0;
		AddReadingLifeSkillBookFlash = 0;
		CanMakeItem = false;
		UpgradeMakeItem = false;
		ReduceMakeRequirementLifeSkillType = 0;
		VillagerRoleTemplateIds = null;
		IsShop = false;
		NeedLeader = false;
		NeedShopProgress = false;
		IsCollectResourceBuilding = false;
		ShowResourceStoreLocation = false;
		ShowItemStoreLocation = false;
		ShowItemLocationAsResourceLocation = false;
		MaxProduceValue = -1;
		RequireCulture = 0;
		RequireSafety = 0;
		SuccesEvent = new List<short>();
		FailEvent = new List<short>();
		IdleEvent = 0;
		SpecialEvent = new List<ShortList>();
		MerchantId = 0;
		ExpandInfos = null;
		EffectDesc = null;
		BelongOrganization = 0;
		BuildingAreaLevelBack = new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" };
		BuildingAreaLevelInfoBackendPattern = new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" };
		ArtisanOrderAvailable = false;
		AvailableOnLoading = 0;
		AvailableOrganization = new List<short>();
		ApprovingRate = 0;
		DlcAppId = 0u;
		BaseIcon = null;
		IconOffset = null;
	}

	public BuildingBlockItem(short templateId, BuildingBlockItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		FuncType = other.FuncType;
		Desc = other.Desc;
		FuncDesc = other.FuncDesc;
		Icon = other.Icon;
		FuncIcon = other.FuncIcon;
		HaveDynamicIcon = other.HaveDynamicIcon;
		Type = other.Type;
		Class = other.Class;
		MaxLevel = other.MaxLevel;
		CanOpenManageOutTaiwu = other.CanOpenManageOutTaiwu;
		Width = other.Width;
		Color = other.Color;
		BaseBuildCost = other.BaseBuildCost;
		RemoveGetResourcePercent = other.RemoveGetResourcePercent;
		MoveBuildCostResourceRate = other.MoveBuildCostResourceRate;
		CollectResourcePercent = other.CollectResourcePercent;
		BuildingCoreItem = other.BuildingCoreItem;
		DependBuildings = other.DependBuildings;
		ExpandBuildings = other.ExpandBuildings;
		RequireLifeSkillType = other.RequireLifeSkillType;
		RequireCombatSkillType = other.RequireCombatSkillType;
		RequirePersonalityType = other.RequirePersonalityType;
		LeaderName = other.LeaderName;
		MemberName = other.MemberName;
		RecruitLifeSkillsAdjust = other.RecruitLifeSkillsAdjust;
		RecruitCombatSkillsAdjust = other.RecruitCombatSkillsAdjust;
		OperationTotalProgress = other.OperationTotalProgress;
		MaxDurability = other.MaxDurability;
		BaseMaintenanceCost = other.BaseMaintenanceCost;
		BaseRepairCost = other.BaseRepairCost;
		MustMaintenance = other.MustMaintenance;
		IsUnique = other.IsUnique;
		DestoryType = other.DestoryType;
		AddReadingLifeSkillBookEfficiency = other.AddReadingLifeSkillBookEfficiency;
		ReduceCombatSkillCost = other.ReduceCombatSkillCost;
		AddCombatSkillBreakout = other.AddCombatSkillBreakout;
		AddLifeSkillAttainment = other.AddLifeSkillAttainment;
		AddReadingLifeSkillBookFlash = other.AddReadingLifeSkillBookFlash;
		CanMakeItem = other.CanMakeItem;
		UpgradeMakeItem = other.UpgradeMakeItem;
		ReduceMakeRequirementLifeSkillType = other.ReduceMakeRequirementLifeSkillType;
		VillagerRoleTemplateIds = other.VillagerRoleTemplateIds;
		IsShop = other.IsShop;
		NeedLeader = other.NeedLeader;
		NeedShopProgress = other.NeedShopProgress;
		IsCollectResourceBuilding = other.IsCollectResourceBuilding;
		ShowResourceStoreLocation = other.ShowResourceStoreLocation;
		ShowItemStoreLocation = other.ShowItemStoreLocation;
		ShowItemLocationAsResourceLocation = other.ShowItemLocationAsResourceLocation;
		MaxProduceValue = other.MaxProduceValue;
		RequireCulture = other.RequireCulture;
		RequireSafety = other.RequireSafety;
		SuccesEvent = other.SuccesEvent;
		FailEvent = other.FailEvent;
		IdleEvent = other.IdleEvent;
		SpecialEvent = other.SpecialEvent;
		MerchantId = other.MerchantId;
		ExpandInfos = other.ExpandInfos;
		EffectDesc = other.EffectDesc;
		BelongOrganization = other.BelongOrganization;
		BuildingAreaLevelBack = other.BuildingAreaLevelBack;
		BuildingAreaLevelInfoBackendPattern = other.BuildingAreaLevelInfoBackendPattern;
		ArtisanOrderAvailable = other.ArtisanOrderAvailable;
		AvailableOnLoading = other.AvailableOnLoading;
		AvailableOrganization = other.AvailableOrganization;
		ApprovingRate = other.ApprovingRate;
		DlcAppId = other.DlcAppId;
		BaseIcon = other.BaseIcon;
		IconOffset = other.IconOffset;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override BuildingBlockItem Duplicate(int templateId)
	{
		return new BuildingBlockItem((short)templateId, this);
	}
}
