using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureItem : ConfigItem<AdventureItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly sbyte Type;

	public readonly sbyte CombatDifficulty;

	public readonly sbyte LifeSkillDifficulty;

	public readonly byte Interruptible;

	public readonly byte TimeCost;

	public readonly sbyte KeepTime;

	public readonly int[] ResCost;

	public readonly List<int[]> ItemCost;

	public readonly bool RestrictedByWorldPopulation;

	public readonly short[] Malice;

	public readonly List<(string, string, string, string)> AdventureParams;

	public readonly string EnterEvent;

	public readonly List<AdventureStartNode> StartNodes;

	public readonly List<AdventureTransferNode> TransferNodes;

	public readonly List<AdventureEndNode> EndNodes;

	public readonly List<AdventureBaseBranch> BaseBranches;

	public readonly List<AdventureAdvancedBranch> AdvancedBranches;

	public readonly bool DifficultyAddXiangshuLevel;

	public AdventureItem(short templateId, string name, string desc, sbyte type, sbyte combatDifficulty, sbyte lifeSkillDifficulty, byte interruptible, byte timeCost, sbyte keepTime, int[] resCost, List<int[]> itemCost, bool restrictedByWorldPopulation, short[] malice, List<(string, string, string, string)> adventureParams, string enterEvent, List<AdventureStartNode> startNodes, List<AdventureTransferNode> transferNodes, List<AdventureEndNode> endNodes, List<AdventureBaseBranch> baseBranches, List<AdventureAdvancedBranch> advancedBranches, bool difficultyAddXiangshuLevel)
	{
		for (int i = 0; i < adventureParams.Count; i++)
		{
			(string, string, string, string) tuple = adventureParams[i];
			tuple.Item2 = LocalStringManager.GetConfig("Adventure_language", tuple.Item2);
			adventureParams[i] = tuple;
		}
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Type = type;
		CombatDifficulty = combatDifficulty;
		LifeSkillDifficulty = lifeSkillDifficulty;
		Interruptible = interruptible;
		TimeCost = timeCost;
		KeepTime = keepTime;
		ResCost = resCost;
		ItemCost = itemCost;
		RestrictedByWorldPopulation = restrictedByWorldPopulation;
		Malice = malice;
		AdventureParams = adventureParams;
		EnterEvent = enterEvent;
		StartNodes = startNodes;
		TransferNodes = transferNodes;
		EndNodes = endNodes;
		BaseBranches = baseBranches;
		AdvancedBranches = advancedBranches;
		DifficultyAddXiangshuLevel = difficultyAddXiangshuLevel;
	}

	public AdventureItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Type = 0;
		CombatDifficulty = 0;
		LifeSkillDifficulty = 0;
		Interruptible = 0;
		TimeCost = 0;
		KeepTime = 0;
		ResCost = null;
		ItemCost = null;
		RestrictedByWorldPopulation = false;
		Malice = null;
		AdventureParams = null;
		EnterEvent = null;
		StartNodes = null;
		TransferNodes = null;
		EndNodes = null;
		BaseBranches = null;
		AdvancedBranches = null;
		DifficultyAddXiangshuLevel = false;
	}

	public AdventureItem(short templateId, AdventureItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Type = other.Type;
		CombatDifficulty = other.CombatDifficulty;
		LifeSkillDifficulty = other.LifeSkillDifficulty;
		Interruptible = other.Interruptible;
		TimeCost = other.TimeCost;
		KeepTime = other.KeepTime;
		ResCost = other.ResCost;
		ItemCost = other.ItemCost;
		RestrictedByWorldPopulation = other.RestrictedByWorldPopulation;
		Malice = other.Malice;
		AdventureParams = other.AdventureParams;
		EnterEvent = other.EnterEvent;
		StartNodes = other.StartNodes;
		TransferNodes = other.TransferNodes;
		EndNodes = other.EndNodes;
		BaseBranches = other.BaseBranches;
		AdvancedBranches = other.AdvancedBranches;
		DifficultyAddXiangshuLevel = other.DifficultyAddXiangshuLevel;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureItem Duplicate(int templateId)
	{
		return new AdventureItem((short)templateId, this);
	}
}
