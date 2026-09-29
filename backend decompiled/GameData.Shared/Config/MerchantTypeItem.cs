using System;
using Config.Common;

namespace Config;

[Serializable]
public class MerchantTypeItem : ConfigItem<MerchantTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly short HeadArea;

	public readonly sbyte HeadLevel;

	public readonly short BranchArea;

	public readonly sbyte BranchLevel;

	public readonly EMerchantTypeCityAttributeType CityAttributeType;

	public readonly string CaravanAvatar;

	public readonly string CaravanSpineName;

	public readonly string BuildingSpineName;

	public readonly string Icon;

	public readonly string Prologue;

	public readonly string IntroduceDialog;

	public readonly string FavorDialog1;

	public readonly string FavorDialog2;

	public readonly string FavorDialog3;

	public readonly string SpringSeasonDialog;

	public readonly string SummerSeasonDialog;

	public readonly string AutumnSeasonDialog;

	public readonly string WinterSeasonDialog;

	public readonly string SpringMarketsAdventureSeasonDialog;

	public readonly string EventContent;

	public readonly string EventDialogContent;

	public readonly string TaiwuVillagerMerchantChangingTypeContent;

	public readonly string RefreshDesc;

	public MerchantTypeItem(sbyte templateId, string name, short headArea, sbyte headLevel, short branchArea, sbyte branchLevel, EMerchantTypeCityAttributeType cityAttributeType, string caravanAvatar, string caravanSpineName, string buildingSpineName, string icon, string prologue, string introduceDialog, string favorDialog1, string favorDialog2, string favorDialog3, string springSeasonDialog, string summerSeasonDialog, string autumnSeasonDialog, string winterSeasonDialog, string springMarketsAdventureSeasonDialog, string eventContent, string eventDialogContent, string taiwuVillagerMerchantChangingTypeContent, string refreshDesc)
	{
		TemplateId = templateId;
		Name = name;
		HeadArea = headArea;
		HeadLevel = headLevel;
		BranchArea = branchArea;
		BranchLevel = branchLevel;
		CityAttributeType = cityAttributeType;
		CaravanAvatar = caravanAvatar;
		CaravanSpineName = caravanSpineName;
		BuildingSpineName = buildingSpineName;
		Icon = icon;
		Prologue = prologue;
		IntroduceDialog = introduceDialog;
		FavorDialog1 = favorDialog1;
		FavorDialog2 = favorDialog2;
		FavorDialog3 = favorDialog3;
		SpringSeasonDialog = springSeasonDialog;
		SummerSeasonDialog = summerSeasonDialog;
		AutumnSeasonDialog = autumnSeasonDialog;
		WinterSeasonDialog = winterSeasonDialog;
		SpringMarketsAdventureSeasonDialog = springMarketsAdventureSeasonDialog;
		EventContent = eventContent;
		EventDialogContent = eventDialogContent;
		TaiwuVillagerMerchantChangingTypeContent = taiwuVillagerMerchantChangingTypeContent;
		RefreshDesc = refreshDesc;
	}

	public MerchantTypeItem()
	{
		TemplateId = 0;
		Name = null;
		HeadArea = 0;
		HeadLevel = 0;
		BranchArea = 0;
		BranchLevel = 0;
		CityAttributeType = EMerchantTypeCityAttributeType.Invalid;
		CaravanAvatar = null;
		CaravanSpineName = null;
		BuildingSpineName = null;
		Icon = null;
		Prologue = null;
		IntroduceDialog = null;
		FavorDialog1 = null;
		FavorDialog2 = null;
		FavorDialog3 = null;
		SpringSeasonDialog = null;
		SummerSeasonDialog = null;
		AutumnSeasonDialog = null;
		WinterSeasonDialog = null;
		SpringMarketsAdventureSeasonDialog = null;
		EventContent = null;
		EventDialogContent = null;
		TaiwuVillagerMerchantChangingTypeContent = null;
		RefreshDesc = null;
	}

	public MerchantTypeItem(sbyte templateId, MerchantTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadArea = other.HeadArea;
		HeadLevel = other.HeadLevel;
		BranchArea = other.BranchArea;
		BranchLevel = other.BranchLevel;
		CityAttributeType = other.CityAttributeType;
		CaravanAvatar = other.CaravanAvatar;
		CaravanSpineName = other.CaravanSpineName;
		BuildingSpineName = other.BuildingSpineName;
		Icon = other.Icon;
		Prologue = other.Prologue;
		IntroduceDialog = other.IntroduceDialog;
		FavorDialog1 = other.FavorDialog1;
		FavorDialog2 = other.FavorDialog2;
		FavorDialog3 = other.FavorDialog3;
		SpringSeasonDialog = other.SpringSeasonDialog;
		SummerSeasonDialog = other.SummerSeasonDialog;
		AutumnSeasonDialog = other.AutumnSeasonDialog;
		WinterSeasonDialog = other.WinterSeasonDialog;
		SpringMarketsAdventureSeasonDialog = other.SpringMarketsAdventureSeasonDialog;
		EventContent = other.EventContent;
		EventDialogContent = other.EventDialogContent;
		TaiwuVillagerMerchantChangingTypeContent = other.TaiwuVillagerMerchantChangingTypeContent;
		RefreshDesc = other.RefreshDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MerchantTypeItem Duplicate(int templateId)
	{
		return new MerchantTypeItem((sbyte)templateId, this);
	}
}
