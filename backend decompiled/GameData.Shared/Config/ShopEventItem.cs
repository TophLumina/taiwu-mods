using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class ShopEventItem : ConfigItem<ShopEventItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数5" 共 6 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 能力成长几率
	/// - 完成工作时，对应资质+1的几率
	/// </summary>
	public readonly sbyte SkillGrowOdds;

	/// <summary>
	/// 采集资源
	/// - {资源类型,资源类型}，直接增加每月资源增长量，有人工作时就有效
	/// </summary>
	public readonly List<sbyte> ResourceList;

	/// <summary>
	/// 获取资源
	/// - {资源类型,资源类型}，完成工作进度时，在建筑的收获栏位中得到的资源类型
	/// </summary>
	public readonly sbyte ResourceGoods;

	/// <summary>
	/// 获取道具
	/// - {{道具类型,道具id,获取几率修正},{道具类型,道具id,获取几率修正}}
	/// </summary>
	public readonly List<PresetInventoryItem> ItemList;

	/// <summary>
	/// 获取心材
	/// - 表示采集类建筑可获得什么心材，当获得心材时不再判定获得道具，获取概率公式的系数放置于Globalconfig
	/// </summary>
	public readonly short BuildingCore;

	/// <summary>
	/// 获取道具品级概率
	/// </summary>
	public readonly List<sbyte> ItemGradeProbList;

	/// <summary>
	/// 学习技艺的几率
	/// - 根据世界侵袭进度，从低到高，学会相应技艺书中随机一页未学会的
	/// </summary>
	public readonly sbyte LearnLifeSkillProb;

	/// <summary>
	/// 学习功法的几率
	/// - 根据世界侵袭进度，从低到高，学习相应随机功法书中的一页未学会的，学会的种类，与同一核心建筑周边生效的不同种类的建筑相关
	/// </summary>
	public readonly sbyte LearnCombatSkillProb;

	/// <summary>
	/// 经营建筑出售物品获得资源类型
	/// </summary>
	public readonly sbyte ExchangeResourceGoods;

	/// <summary>
	/// 获取人才
	/// - 能获取各等级人才的概率基础值
	/// </summary>
	public readonly List<sbyte> RecruitPeopleProb;

	public readonly List<sbyte> RecruitPeopleProbAdd;

	public readonly List<sbyte> AttainmentFix;

	public readonly short CharacterPropertyFix;

	public readonly List<short> CharacterPropertyFixNum;

	/// <summary>
	/// 事件类型
	/// - 目前用于区分事件簿中的条目 0经营 1研读
	/// </summary>
	public readonly sbyte ShopEventType;

	public readonly sbyte Priority;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">说明</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数5" 共 6 个字段.</param>
	/// <param name="skillGrowOdds">能力成长几率 - 完成工作时，对应资质+1的几率</param>
	/// <param name="resourceList">采集资源 - {资源类型,资源类型}，直接增加每月资源增长量，有人工作时就有效</param>
	/// <param name="resourceGoods">获取资源 - {资源类型,资源类型}，完成工作进度时，在建筑的收获栏位中得到的资源类型</param>
	/// <param name="itemList">获取道具 - {{道具类型,道具id,获取几率修正},{道具类型,道具id,获取几率修正}}</param>
	/// <param name="buildingCore">获取心材 - 表示采集类建筑可获得什么心材，当获得心材时不再判定获得道具，获取概率公式的系数放置于Globalconfig</param>
	/// <param name="itemGradeProbList">获取道具品级概率</param>
	/// <param name="learnLifeSkillProb">学习技艺的几率 - 根据世界侵袭进度，从低到高，学会相应技艺书中随机一页未学会的</param>
	/// <param name="learnCombatSkillProb">学习功法的几率 - 根据世界侵袭进度，从低到高，学习相应随机功法书中的一页未学会的，学会的种类，与同一核心建筑周边生效的不同种类的建筑相关</param>
	/// <param name="exchangeResourceGoods">经营建筑出售物品获得资源类型</param>
	/// <param name="recruitPeopleProb">获取人才 - 能获取各等级人才的概率基础值</param>
	/// <param name="recruitPeopleProbAdd"> - 能获取各等级人才的概率随机加值(左闭右开)</param>
	/// <param name="attainmentFix"> - 各等级人才相应资质修正</param>
	/// <param name="characterPropertyFix"> - 特殊人物属性修正</param>
	/// <param name="characterPropertyFixNum"> - 各等级特殊人物属性修正值</param>
	/// <param name="shopEventType">事件类型 - 目前用于区分事件簿中的条目 0经营 1研读</param>
	/// <param name="priority"> - 优先级</param>
	public ShopEventItem(short templateId, string desc, string[] parameters, sbyte skillGrowOdds, List<sbyte> resourceList, sbyte resourceGoods, List<PresetInventoryItem> itemList, short buildingCore, List<sbyte> itemGradeProbList, sbyte learnLifeSkillProb, sbyte learnCombatSkillProb, sbyte exchangeResourceGoods, List<sbyte> recruitPeopleProb, List<sbyte> recruitPeopleProbAdd, List<sbyte> attainmentFix, short characterPropertyFix, List<short> characterPropertyFixNum, sbyte shopEventType, sbyte priority)
	{
		TemplateId = templateId;
		Desc = desc;
		Parameters = parameters;
		SkillGrowOdds = skillGrowOdds;
		ResourceList = resourceList;
		ResourceGoods = resourceGoods;
		ItemList = itemList;
		BuildingCore = buildingCore;
		ItemGradeProbList = itemGradeProbList;
		LearnLifeSkillProb = learnLifeSkillProb;
		LearnCombatSkillProb = learnCombatSkillProb;
		ExchangeResourceGoods = exchangeResourceGoods;
		RecruitPeopleProb = recruitPeopleProb;
		RecruitPeopleProbAdd = recruitPeopleProbAdd;
		AttainmentFix = attainmentFix;
		CharacterPropertyFix = characterPropertyFix;
		CharacterPropertyFixNum = characterPropertyFixNum;
		ShopEventType = shopEventType;
		Priority = priority;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ShopEventItem()
	{
		TemplateId = 0;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
		SkillGrowOdds = 0;
		ResourceList = new List<sbyte>();
		ResourceGoods = 0;
		ItemList = new List<PresetInventoryItem>();
		BuildingCore = 0;
		ItemGradeProbList = new List<sbyte>();
		LearnLifeSkillProb = 0;
		LearnCombatSkillProb = 0;
		ExchangeResourceGoods = 0;
		RecruitPeopleProb = new List<sbyte>();
		RecruitPeopleProbAdd = new List<sbyte>();
		AttainmentFix = new List<sbyte>();
		CharacterPropertyFix = 0;
		CharacterPropertyFixNum = new List<short>();
		ShopEventType = 0;
		Priority = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ShopEventItem(short templateId, ShopEventItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Parameters = other.Parameters;
		SkillGrowOdds = other.SkillGrowOdds;
		ResourceList = other.ResourceList;
		ResourceGoods = other.ResourceGoods;
		ItemList = other.ItemList;
		BuildingCore = other.BuildingCore;
		ItemGradeProbList = other.ItemGradeProbList;
		LearnLifeSkillProb = other.LearnLifeSkillProb;
		LearnCombatSkillProb = other.LearnCombatSkillProb;
		ExchangeResourceGoods = other.ExchangeResourceGoods;
		RecruitPeopleProb = other.RecruitPeopleProb;
		RecruitPeopleProbAdd = other.RecruitPeopleProbAdd;
		AttainmentFix = other.AttainmentFix;
		CharacterPropertyFix = other.CharacterPropertyFix;
		CharacterPropertyFixNum = other.CharacterPropertyFixNum;
		ShopEventType = other.ShopEventType;
		Priority = other.Priority;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ShopEventItem Duplicate(int templateId)
	{
		return new ShopEventItem((short)templateId, this);
	}
}
