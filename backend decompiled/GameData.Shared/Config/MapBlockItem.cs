using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockItem : ConfigItem<MapBlockItem, short>
{
	public readonly short TemplateId;

	public readonly EMapBlockType Type;

	public readonly EMapBlockSubType SubType;

	public readonly string Name;

	public readonly string AdventureEditorName;

	public readonly string Desc;

	public readonly byte Size;

	public readonly byte Range;

	public readonly sbyte ViewRange;

	public readonly sbyte MoveCost;

	public readonly sbyte PathFindingCost;

	public readonly bool FreeStepIgnorePathCost;

	public readonly bool ShowTips;

	public readonly string Art;

	public readonly int[] BlockNumbers;

	public readonly bool BlockHasDirection;

	public readonly bool BlockHasSeason;

	public readonly bool BlockHasFix;

	public readonly int[] MiniSceneNumbers;

	public readonly bool MiniSceneHaveDirection;

	public readonly bool MiniSceneHaveWinter;

	public readonly string ArtEventBackground;

	public readonly bool EventBackgroundWinter;

	public readonly string[] Effect;

	public readonly bool IgnoreDestroyed;

	public readonly bool TaiwuEventChangedBlock;

	public readonly short SplitOrMergeBlockId;

	public readonly List<sbyte> MainResourceType;

	public readonly short[] Resources;

	public readonly sbyte ResourceCollectionType;

	public readonly short MaxMalice;

	public readonly string[] BlockNames;

	public readonly string Bgm;

	public readonly string[] Bgs;

	public readonly sbyte BuildingAreaWidth;

	public readonly sbyte LandFormType;

	public readonly short CenterBuilding;

	public readonly sbyte CenterBuildingMaxLevel;

	public readonly string FixedBuildingImage;

	public readonly List<short> PresetBuildingList;

	public readonly List<short> RandomBuildingList;

	public readonly short InformationTemplateId;

	public readonly List<(short, short)> AdventureTerrainWeights;

	public readonly string EventBack;

	public readonly short CombatScene;

	public readonly short CombatState;

	public readonly bool CanGenerate;

	public readonly string BackgroundForMenuEquip;

	public readonly short AdventureEnvironment;

	public MapBlockItem SplitOrMergeBlock
	{
		[return: MaybeNull]
		get
		{
			return MapBlock.Instance.GetItemOrDefault(SplitOrMergeBlockId);
		}
	}

	public InformationItem InformationTemplate
	{
		[return: MaybeNull]
		get
		{
			return Information.Instance.GetItemOrDefault(InformationTemplateId);
		}
	}

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

	public override MapBlockItem Duplicate(int templateId)
	{
		return new MapBlockItem((short)templateId, this);
	}
}
