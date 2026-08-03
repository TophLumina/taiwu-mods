using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureItem : ConfigItem<AdventureItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 简介
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 战斗难度
	/// - 1~9，事件、敌人难度
	/// </summary>
	public readonly sbyte CombatDifficulty;

	/// <summary>
	/// 技艺难度
	/// - 1~9，影响获得奖励所需要的技艺造诣
	/// </summary>
	public readonly sbyte LifeSkillDifficulty;

	/// <summary>
	/// 可中断
	/// - 0，不可中断
	/// - 1，可中断但消失
	/// - 2，可中断且不消失
	/// </summary>
	public readonly byte Interruptible;

	/// <summary>
	/// 消耗时间
	/// - 1~30
	/// </summary>
	public readonly byte TimeCost;

	/// <summary>
	/// 持续时节
	/// </summary>
	public readonly sbyte KeepTime;

	public readonly int[] ResCost;

	public readonly List<int[]> ItemCost;

	/// <summary>
	/// 生成被世界人口限制
	/// </summary>
	public readonly bool RestrictedByWorldPopulation;

	/// <summary>
	/// 戾气
	/// - 【开化地形戾气，野外地形戾气，城镇门派戾气】
	/// </summary>
	public readonly short[] Malice;

	/// <summary>
	/// 奇遇参数
	/// </summary>
	public readonly List<(string, string, string, string)> AdventureParams;

	/// <summary>
	/// 准备事件
	/// </summary>
	public readonly string EnterEvent;

	/// <summary>
	/// 起点数据
	/// - AdventureStartNode参数：事件，进入条件
	/// </summary>
	public readonly List<AdventureStartNode> StartNodes;

	/// <summary>
	/// 转点数据
	/// - AdventureTransferNode参数：事件，地形Id
	/// </summary>
	public readonly List<AdventureTransferNode> TransferNodes;

	/// <summary>
	/// 终点数据
	/// - AdventureEndNode参数：事件，地形Id
	/// </summary>
	public readonly List<AdventureEndNode> EndNodes;

	/// <summary>
	/// 分支
	/// - 起点index|终点index|分支key|路径长度|判定技艺组|{事件a，事件b，事件c}|地形配置（地形aId，a权重...）|七元配置|
	/// - 格子比重|普通资源比重|特殊资源比重|物品比重|物品类型（长度9）|敌人配置（长度4）
	/// </summary>
	public readonly List<AdventureBaseBranch> BaseBranches;

	public readonly List<AdventureAdvancedBranch> AdvancedBranches;

	/// <summary>
	/// 难度加上相枢等级
	/// - 勾上此选项将额外加上相枢等级的难度并自适应奖励
	/// </summary>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureItem Duplicate(int templateId)
	{
		return new AdventureItem((short)templateId, this);
	}
}
