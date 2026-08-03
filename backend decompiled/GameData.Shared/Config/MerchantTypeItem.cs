using System;
using Config.Common;

namespace Config;

[Serializable]
public class MerchantTypeItem : ConfigItem<MerchantTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 总部所在区域ID
	/// - 对应MapArea表中的模板ID
	/// </summary>
	public readonly short HeadArea;

	/// <summary>
	/// 总部商店等级
	/// </summary>
	public readonly sbyte HeadLevel;

	/// <summary>
	/// 分部所在区域ID
	/// - 对应MapArea表中的模板ID
	/// </summary>
	public readonly short BranchArea;

	/// <summary>
	/// 分部商店等级
	/// </summary>
	public readonly sbyte BranchLevel;

	/// <summary>
	/// 定居点影响
	/// </summary>
	public readonly EMerchantTypeCityAttributeType CityAttributeType;

	/// <summary>
	/// 商队头像
	/// - 在左侧人物列表中显示，并且都是野外版本。因为总部的只能看到动态立绘
	/// </summary>
	public readonly string CaravanAvatar;

	/// <summary>
	/// 商队野外动态立绘
	/// - 只有野外用得到
	/// </summary>
	public readonly string CaravanSpineName;

	/// <summary>
	/// 商会总部动态立绘
	/// </summary>
	public readonly string BuildingSpineName;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 商店的开场白
	/// </summary>
	public readonly string Prologue;

	/// <summary>
	/// 商店的介绍对话
	/// </summary>
	public readonly string IntroduceDialog;

	/// <summary>
	/// 商店的好感对话1-2
	/// </summary>
	public readonly string FavorDialog1;

	/// <summary>
	/// 商店的好感对话3-4
	/// </summary>
	public readonly string FavorDialog2;

	/// <summary>
	/// 商店的好感对话5-7
	/// </summary>
	public readonly string FavorDialog3;

	/// <summary>
	/// 春季额外商品对话
	/// </summary>
	public readonly string SpringSeasonDialog;

	/// <summary>
	/// 夏季额外商品对话
	/// </summary>
	public readonly string SummerSeasonDialog;

	/// <summary>
	/// 秋季额外商品对话
	/// </summary>
	public readonly string AutumnSeasonDialog;

	/// <summary>
	/// 冬季额外商品对话
	/// </summary>
	public readonly string WinterSeasonDialog;

	/// <summary>
	/// 春日集市奇遇的季节对话
	/// </summary>
	public readonly string SpringMarketsAdventureSeasonDialog;

	/// <summary>
	/// 事件中的商队占位符
	/// </summary>
	public readonly string EventContent;

	/// <summary>
	/// 事件中的商队对话框
	/// </summary>
	public readonly string EventDialogContent;

	/// <summary>
	/// 太吾村商人改变从属商会后的文案
	/// </summary>
	public readonly string TaiwuVillagerMerchantChangingTypeContent;

	/// <summary>
	/// 刷新货物的气泡文本
	/// </summary>
	public readonly string RefreshDesc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名字</param>
	/// <param name="headArea">总部所在区域ID - 对应MapArea表中的模板ID</param>
	/// <param name="headLevel">总部商店等级</param>
	/// <param name="branchArea">分部所在区域ID - 对应MapArea表中的模板ID</param>
	/// <param name="branchLevel">分部商店等级</param>
	/// <param name="cityAttributeType">定居点影响</param>
	/// <param name="caravanAvatar">商队头像 - 在左侧人物列表中显示，并且都是野外版本。因为总部的只能看到动态立绘</param>
	/// <param name="caravanSpineName">商队野外动态立绘 - 只有野外用得到</param>
	/// <param name="buildingSpineName">商会总部动态立绘</param>
	/// <param name="icon">图标</param>
	/// <param name="prologue">商店的开场白</param>
	/// <param name="introduceDialog">商店的介绍对话</param>
	/// <param name="favorDialog1">商店的好感对话1-2</param>
	/// <param name="favorDialog2">商店的好感对话3-4</param>
	/// <param name="favorDialog3">商店的好感对话5-7</param>
	/// <param name="springSeasonDialog">春季额外商品对话</param>
	/// <param name="summerSeasonDialog">夏季额外商品对话</param>
	/// <param name="autumnSeasonDialog">秋季额外商品对话</param>
	/// <param name="winterSeasonDialog">冬季额外商品对话</param>
	/// <param name="springMarketsAdventureSeasonDialog">春日集市奇遇的季节对话</param>
	/// <param name="eventContent">事件中的商队占位符</param>
	/// <param name="eventDialogContent">事件中的商队对话框</param>
	/// <param name="taiwuVillagerMerchantChangingTypeContent">太吾村商人改变从属商会后的文案</param>
	/// <param name="refreshDesc">刷新货物的气泡文本</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MerchantTypeItem Duplicate(int templateId)
	{
		return new MerchantTypeItem((sbyte)templateId, this);
	}
}
