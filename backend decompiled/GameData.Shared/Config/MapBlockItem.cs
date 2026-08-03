using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockItem : ConfigItem<MapBlockItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 地形大类
	/// - 对应t_Type
	/// </summary>
	public readonly EMapBlockType Type;

	/// <summary>
	/// 地形细类
	/// - 对应t_SubType
	/// </summary>
	public readonly EMapBlockSubType SubType;

	/// <summary>
	/// 地块名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 奇遇编辑器内地格名
	/// </summary>
	public readonly string AdventureEditorName;

	/// <summary>
	/// 地块描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 本身尺寸大小
	/// - 地块在地图上的格子宽度
	/// </summary>
	public readonly byte Size;

	/// <summary>
	/// 属地大小
	/// - 地块周围多少距离的普通地块会成为该地块的从属地块
	/// </summary>
	public readonly byte Range;

	/// <summary>
	/// 视野范围
	/// - 能看见此地块周围几步之内的地块
	/// </summary>
	public readonly sbyte ViewRange;

	/// <summary>
	/// 通行消耗
	/// - 通过该地块的行动力消耗，填写-1时，该地块不可通行
	/// </summary>
	public readonly sbyte MoveCost;

	/// <summary>
	/// 寻路消耗
	/// - 仅在地图寻路时使用的消耗，数值越大越有可能在寻路时绕开
	/// </summary>
	public readonly sbyte PathFindingCost;

	/// <summary>
	/// 通行无消耗时是否同时忽略寻路消耗
	/// - 目前主要是旅人三技能寻路时会用到
	/// </summary>
	public readonly bool FreeStepIgnorePathCost;

	/// <summary>
	/// 是否显示鼠标Tips
	/// - 被破坏的地块无视此配置，必定显示Tips
	/// </summary>
	public readonly bool ShowTips;

	/// <summary>
	/// 美术名
	/// </summary>
	public readonly string Art;

	/// <summary>
	/// 地格差分序号
	/// </summary>
	public readonly int[] BlockNumbers;

	/// <summary>
	/// 地格有方位
	/// </summary>
	public readonly bool BlockHasDirection;

	/// <summary>
	/// 地格有季节
	/// </summary>
	public readonly bool BlockHasSeason;

	/// <summary>
	/// 地格有修正
	/// - 用于大地格或湖泊特效的单格尺寸地块图片
	/// </summary>
	public readonly bool BlockHasFix;

	/// <summary>
	/// 迷你场景差分序号
	/// </summary>
	public readonly int[] MiniSceneNumbers;

	/// <summary>
	/// 迷你场景有方位
	/// </summary>
	public readonly bool MiniSceneHaveDirection;

	/// <summary>
	/// 迷你场景有冬天
	/// </summary>
	public readonly bool MiniSceneHaveWinter;

	/// <summary>
	/// 对话框背景
	/// </summary>
	public readonly string ArtEventBackground;

	public readonly bool EventBackgroundWinter;

	/// <summary>
	/// 地块特效
	/// </summary>
	public readonly string[] Effect;

	/// <summary>
	/// 忽略毁坏地格贴图
	/// </summary>
	public readonly bool IgnoreDestroyed;

	/// <summary>
	/// 剧情事件会修改地格数据
	/// </summary>
	public readonly bool TaiwuEventChangedBlock;

	/// <summary>
	/// 可变换的模板 ID
	/// - 主要用于大小地格间互相转换
	/// </summary>
	public readonly short SplitOrMergeBlockId;

	/// <summary>
	/// 代表资源类型列表
	/// - 决定地块图片根据哪几种资源的丰富程度切换
	/// </summary>
	public readonly List<sbyte> MainResourceType;

	/// <summary>
	/// 资源列表
	/// - 地块上的资源上限，正数会在配置值的±25之间随机，负数会在配置值和配置值的一半之间随机
	/// </summary>
	public readonly short[] Resources;

	/// <summary>
	/// 资源采集类型
	/// - 对应ResourceCollection表中的ID
	/// </summary>
	public readonly sbyte ResourceCollectionType;

	/// <summary>
	/// 戾气上限
	/// </summary>
	public readonly short MaxMalice;

	/// <summary>
	/// 每个地块名称
	/// - 仅占多格的地块需配置，顺序为从左到右、从上到下
	/// </summary>
	public readonly string[] BlockNames;

	/// <summary>
	/// 背景音乐
	/// </summary>
	public readonly string Bgm;

	/// <summary>
	/// 近景环境音效
	/// </summary>
	public readonly string[] Bgs;

	/// <summary>
	/// 产业地图边长
	/// </summary>
	public readonly sbyte BuildingAreaWidth;

	/// <summary>
	/// 地形类型
	/// </summary>
	public readonly sbyte LandFormType;

	/// <summary>
	/// 中心建筑
	/// </summary>
	public readonly short CenterBuilding;

	/// <summary>
	/// 中心建筑初始规模上限
	/// </summary>
	public readonly sbyte CenterBuildingMaxLevel;

	/// <summary>
	/// 固定建筑配置图
	/// - 按配置图生成固定需要的建筑
	/// </summary>
	public readonly string FixedBuildingImage;

	/// <summary>
	/// 初始建筑列表
	/// - 对应BuildingBlock表中的模板ID
	/// </summary>
	public readonly List<short> PresetBuildingList;

	/// <summary>
	/// 随机建筑列表
	/// - 对应BuildingBlock表中的模板ID，但此列表的每个建筑只有50%几率生成
	/// </summary>
	public readonly List<short> RandomBuildingList;

	/// <summary>
	/// 对应相关见闻
	/// </summary>
	public readonly short InformationTemplateId;

	/// <summary>
	/// 奇遇地形权重
	/// - 该地块上生成奇遇时的地形配置：地形ID（在AdventureTerrain中的地形）：权重值
	/// </summary>
	public readonly List<(short, short)> AdventureTerrainWeights;

	/// <summary>
	/// 事件背景图片
	/// - 当在此地格发生事件，且事件配置中没有指定事件背景图片，则会根据事件发生的地块来取对应的背景图片
	/// </summary>
	public readonly string EventBack;

	/// <summary>
	/// 战斗场景
	/// </summary>
	public readonly short CombatScene;

	/// <summary>
	/// 地形战斗特效
	/// </summary>
	public readonly short CombatState;

	/// <summary>
	/// 是否可以生成
	/// </summary>
	public readonly bool CanGenerate;

	/// <summary>
	/// 装备界面对应背景图
	/// </summary>
	public readonly string BackgroundForMenuEquip;

	/// <summary>
	/// 奇遇周边地形
	/// </summary>
	public readonly short AdventureEnvironment;

	public MapBlockItem(short templateId, EMapBlockType type, EMapBlockSubType subType, string name, string adventureEditorName, string desc, byte size, byte range, sbyte viewRange, sbyte moveCost, sbyte pathFindingCost, bool freeStepIgnorePathCost, bool showTips, string art, int[] blockNumbers, bool blockHasDirection, bool blockHasSeason, bool blockHasFix, int[] miniSceneNumbers, bool miniSceneHaveDirection, bool miniSceneHaveWinter, string artEventBackground, bool eventBackgroundWinter, string[] effect, bool ignoreDestroyed, bool taiwuEventChangedBlock, short splitOrMergeBlockId, List<sbyte> mainResourceType, short[] resources, sbyte resourceCollectionType, short maxMalice, string[] blockNames, string bgm, string[] bgs, sbyte buildingAreaWidth, sbyte landFormType, short centerBuilding, sbyte centerBuildingMaxLevel, string fixedBuildingImage, List<short> presetBuildingList, List<short> randomBuildingList, short informationTemplateId, List<(short, short)> adventureTerrainWeights, string eventBack, short combatScene, short combatState, bool canGenerate, string backgroundForMenuEquip, short adventureEnvironment)
	{
		TemplateId = templateId;
		Type = type;
		SubType = subType;
		Name = name;
		AdventureEditorName = adventureEditorName;
		Desc = desc;
		Size = size;
		Range = range;
		ViewRange = viewRange;
		MoveCost = moveCost;
		PathFindingCost = pathFindingCost;
		FreeStepIgnorePathCost = freeStepIgnorePathCost;
		ShowTips = showTips;
		Art = art;
		BlockNumbers = blockNumbers;
		BlockHasDirection = blockHasDirection;
		BlockHasSeason = blockHasSeason;
		BlockHasFix = blockHasFix;
		MiniSceneNumbers = miniSceneNumbers;
		MiniSceneHaveDirection = miniSceneHaveDirection;
		MiniSceneHaveWinter = miniSceneHaveWinter;
		ArtEventBackground = artEventBackground;
		EventBackgroundWinter = eventBackgroundWinter;
		Effect = effect;
		IgnoreDestroyed = ignoreDestroyed;
		TaiwuEventChangedBlock = taiwuEventChangedBlock;
		SplitOrMergeBlockId = splitOrMergeBlockId;
		MainResourceType = mainResourceType;
		Resources = resources;
		ResourceCollectionType = resourceCollectionType;
		MaxMalice = maxMalice;
		BlockNames = blockNames;
		Bgm = bgm;
		Bgs = bgs;
		BuildingAreaWidth = buildingAreaWidth;
		LandFormType = landFormType;
		CenterBuilding = centerBuilding;
		CenterBuildingMaxLevel = centerBuildingMaxLevel;
		FixedBuildingImage = fixedBuildingImage;
		PresetBuildingList = presetBuildingList;
		RandomBuildingList = randomBuildingList;
		InformationTemplateId = informationTemplateId;
		AdventureTerrainWeights = adventureTerrainWeights;
		EventBack = eventBack;
		CombatScene = combatScene;
		CombatState = combatState;
		CanGenerate = canGenerate;
		BackgroundForMenuEquip = backgroundForMenuEquip;
		AdventureEnvironment = adventureEnvironment;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapBlockItem()
	{
		TemplateId = 0;
		Type = EMapBlockType.Invalid;
		SubType = EMapBlockSubType.Invalid;
		Name = null;
		AdventureEditorName = null;
		Desc = null;
		Size = 0;
		Range = 0;
		ViewRange = 1;
		MoveCost = -1;
		PathFindingCost = -1;
		FreeStepIgnorePathCost = false;
		ShowTips = false;
		Art = null;
		BlockNumbers = new int[0];
		BlockHasDirection = false;
		BlockHasSeason = false;
		BlockHasFix = false;
		MiniSceneNumbers = new int[0];
		MiniSceneHaveDirection = false;
		MiniSceneHaveWinter = false;
		ArtEventBackground = null;
		EventBackgroundWinter = true;
		Effect = new string[0];
		IgnoreDestroyed = false;
		TaiwuEventChangedBlock = false;
		SplitOrMergeBlockId = 0;
		MainResourceType = new List<sbyte>();
		Resources = new short[6];
		ResourceCollectionType = 0;
		MaxMalice = -1;
		BlockNames = new string[0];
		Bgm = null;
		Bgs = new string[0];
		BuildingAreaWidth = -1;
		LandFormType = 0;
		CenterBuilding = 0;
		CenterBuildingMaxLevel = -1;
		FixedBuildingImage = null;
		PresetBuildingList = new List<short>();
		RandomBuildingList = new List<short>();
		InformationTemplateId = 0;
		AdventureTerrainWeights = new List<(short, short)> { (1, 100) };
		EventBack = null;
		CombatScene = 0;
		CombatState = 0;
		CanGenerate = true;
		BackgroundForMenuEquip = "ui9_tex_character_menu_equip_test";
		AdventureEnvironment = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapBlockItem(short templateId, MapBlockItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		SubType = other.SubType;
		Name = other.Name;
		AdventureEditorName = other.AdventureEditorName;
		Desc = other.Desc;
		Size = other.Size;
		Range = other.Range;
		ViewRange = other.ViewRange;
		MoveCost = other.MoveCost;
		PathFindingCost = other.PathFindingCost;
		FreeStepIgnorePathCost = other.FreeStepIgnorePathCost;
		ShowTips = other.ShowTips;
		Art = other.Art;
		BlockNumbers = other.BlockNumbers;
		BlockHasDirection = other.BlockHasDirection;
		BlockHasSeason = other.BlockHasSeason;
		BlockHasFix = other.BlockHasFix;
		MiniSceneNumbers = other.MiniSceneNumbers;
		MiniSceneHaveDirection = other.MiniSceneHaveDirection;
		MiniSceneHaveWinter = other.MiniSceneHaveWinter;
		ArtEventBackground = other.ArtEventBackground;
		EventBackgroundWinter = other.EventBackgroundWinter;
		Effect = other.Effect;
		IgnoreDestroyed = other.IgnoreDestroyed;
		TaiwuEventChangedBlock = other.TaiwuEventChangedBlock;
		SplitOrMergeBlockId = other.SplitOrMergeBlockId;
		MainResourceType = other.MainResourceType;
		Resources = other.Resources;
		ResourceCollectionType = other.ResourceCollectionType;
		MaxMalice = other.MaxMalice;
		BlockNames = other.BlockNames;
		Bgm = other.Bgm;
		Bgs = other.Bgs;
		BuildingAreaWidth = other.BuildingAreaWidth;
		LandFormType = other.LandFormType;
		CenterBuilding = other.CenterBuilding;
		CenterBuildingMaxLevel = other.CenterBuildingMaxLevel;
		FixedBuildingImage = other.FixedBuildingImage;
		PresetBuildingList = other.PresetBuildingList;
		RandomBuildingList = other.RandomBuildingList;
		InformationTemplateId = other.InformationTemplateId;
		AdventureTerrainWeights = other.AdventureTerrainWeights;
		EventBack = other.EventBack;
		CombatScene = other.CombatScene;
		CombatState = other.CombatState;
		CanGenerate = other.CanGenerate;
		BackgroundForMenuEquip = other.BackgroundForMenuEquip;
		AdventureEnvironment = other.AdventureEnvironment;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapBlockItem Duplicate(int templateId)
	{
		return new MapBlockItem((short)templateId, this);
	}
}
