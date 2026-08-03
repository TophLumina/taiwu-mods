using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class MapPickupsItem : ConfigItem<MapPickupsItem, short>
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
	/// 分类
	/// - 用于前端获取时的特效处理分类
	/// </summary>
	public readonly EMapPickupsType Type;

	/// <summary>
	/// 分类2
	/// - 用于自动拾取设置
	/// </summary>
	public readonly EMapPickupsType2 Type2;

	/// <summary>
	/// 地格图标
	/// - 地格事件在地图上显示的图标样式
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// Tips文本
	/// - 悬停在拾取物的按钮上，黑底
	/// </summary>
	public readonly string TipsContent;

	/// <summary>
	/// 特殊区域
	/// - 配置需要对特殊区域深谷等，生成多少次。对这些区域生成时，世界进度固定为0。
	/// </summary>
	public readonly byte SpecialAreaTimes;

	/// <summary>
	/// 生成州域
	/// - 每个州域填多少，就意味着这个州域总共生成几次。世界进度数量不为1时，生成数量为[州域数值]*[世界进度数量]，比如京畿配置为2，世界进度配置了3个等级，那么在京畿生成2*3=6份拾取物，每个世界进度各两次
	/// </summary>
	public readonly byte[] StateTimes;

	/// <summary>
	/// 生成地格
	/// - 如果只会生成在符合条件的地格上，使用此列，数据来源：MapBlock→SubType
	/// </summary>
	public readonly List<short> BlockList;

	/// <summary>
	/// 研读效果
	/// - 效果为主动研读一次，不消耗耐久
	/// </summary>
	public readonly bool ReadEffect;

	/// <summary>
	/// 周天效果
	/// - 效果为主动周天一次，不消耗耐久
	/// </summary>
	public readonly bool LoopEffect;

	/// <summary>
	/// 直接奖励历练
	/// </summary>
	public readonly bool IsExpBonus;

	/// <summary>
	/// 直接奖励恩义
	/// </summary>
	public readonly bool IsDebtBonus;

	/// <summary>
	/// 奖励数值
	/// - 和世界进度对应的奖励数值水平，数组条目数量和世界进度的数量一致：生成时±20%随机
	/// </summary>
	public readonly int[] BonusCount;

	/// <summary>
	/// 奖励品级
	/// - 和世界进度对应的奖励数值水平，数组条目数量和世界进度的数量一致：生成时物品品级，±1品级随机
	/// </summary>
	public readonly sbyte[] ItemGrade;

	/// <summary>
	/// 物品类型
	/// - 抽取品级时，可以根据分类抽到具体的物品
	/// </summary>
	public readonly PresetItemTemplateId ItemGroup;

	/// <summary>
	/// 世界进度
	/// - 代表相枢侵蚀进度，{0,2,5}表示在相枢侵蚀进度0,2,5三个情况下显示的不同级别拾取物
	/// </summary>
	public readonly sbyte[] XiangshuLevel;

	/// <summary>
	/// 资源列表
	/// - 产生拾取物的最少当前资源量
	/// </summary>
	public readonly short[] Resources;

	/// <summary>
	/// 显示月份
	/// - 决定此事件会在哪几个月份显示出来，为1时表示此事件会在此月显示出来
	/// </summary>
	public readonly bool[] CanShowMonths;

	/// <summary>
	/// 持有见闻
	/// - 持有对应见闻时才显示，引用InformationInfo
	/// </summary>
	public readonly short ShowConditionInformation;

	/// <summary>
	/// 需要的门派支持度
	/// - 格式为{门派名,支持度}，对应门派的支持度到达这个水平时才显示
	/// </summary>
	public readonly OrganizationApproving ShowConditionOrganizationApproving;

	/// <summary>
	/// 即时通知引用
	/// - 引用InstantNotification模板ID，在拾取时显示对应的通知
	/// </summary>
	public readonly short InstantNotification;

	/// <summary>
	/// 额外奖励时附加即时通知
	/// </summary>
	public readonly short ExtraBonusAddInstantNotification;

	/// <summary>
	/// 额外奖励时替换即时通知
	/// </summary>
	public readonly short ExtraBonusReplaceInstantNotification;

	/// <summary>
	/// 主事件描述
	/// </summary>
	public readonly string EventMainContent;

	/// <summary>
	/// 主选项文本
	/// </summary>
	public readonly string[] EventMainOptions;

	/// <summary>
	/// 次级事件文本
	/// - 每个主事件的选项，对应一个次级事件
	/// </summary>
	public readonly string[] EventSecondContents;

	/// <summary>
	/// 次级事件选项文本
	/// - 每个次级事件只有一个文本，但是可以配置的
	/// </summary>
	public readonly string[] EventSecondOptions;

	/// <summary>
	/// 次级事件道具奖励
	/// </summary>
	public readonly List<PresetItemWithCount> EventSecondItemRewards;

	/// <summary>
	/// 次级事件资源奖励
	/// </summary>
	public readonly List<ResourceInfo> EventSecondResourceRewards;

	/// <summary>
	/// 次级事件属性奖励
	/// - 角色属性奖励，目前支持资质、促织缘
	/// </summary>
	public readonly List<PropertyAndValue> EventSecondPropertyRewards;

	/// <summary>
	/// 次级事件恩义奖励
	/// </summary>
	public readonly List<int> EventSecondDebtRewards;

	/// <summary>
	/// 次级事件历练奖励
	/// </summary>
	public readonly List<int> EventSecondExpRewards;

	/// <summary>
	/// 次级事件选项1的道具奖励选择
	/// - 当配置此列时，替换选项1为道具选择
	/// </summary>
	public readonly List<PresetItemWithCount> EventSecondItemRewardSelection1;

	/// <summary>
	/// 次级事件选项2的道具奖励选择
	/// - 当配置此列时，替换选项2为道具选择
	/// </summary>
	public readonly List<PresetItemWithCount> EventSecondItemRewardSelection2;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">分类 - 用于前端获取时的特效处理分类</param>
	/// <param name="type2">分类2 - 用于自动拾取设置</param>
	/// <param name="icon">地格图标 - 地格事件在地图上显示的图标样式</param>
	/// <param name="tipsContent">Tips文本 - 悬停在拾取物的按钮上，黑底</param>
	/// <param name="specialAreaTimes">特殊区域 - 配置需要对特殊区域深谷等，生成多少次。对这些区域生成时，世界进度固定为0。</param>
	/// <param name="stateTimes">生成州域 - 每个州域填多少，就意味着这个州域总共生成几次。世界进度数量不为1时，生成数量为[州域数值]*[世界进度数量]，比如京畿配置为2，世界进度配置了3个等级，那么在京畿生成2*3=6份拾取物，每个世界进度各两次</param>
	/// <param name="blockList">生成地格 - 如果只会生成在符合条件的地格上，使用此列，数据来源：MapBlock→SubType</param>
	/// <param name="readEffect">研读效果 - 效果为主动研读一次，不消耗耐久</param>
	/// <param name="loopEffect">周天效果 - 效果为主动周天一次，不消耗耐久</param>
	/// <param name="isExpBonus">直接奖励历练</param>
	/// <param name="isDebtBonus">直接奖励恩义</param>
	/// <param name="bonusCount">奖励数值 - 和世界进度对应的奖励数值水平，数组条目数量和世界进度的数量一致：生成时±20%随机</param>
	/// <param name="itemGrade">奖励品级 - 和世界进度对应的奖励数值水平，数组条目数量和世界进度的数量一致：生成时物品品级，±1品级随机</param>
	/// <param name="itemGroup">物品类型 - 抽取品级时，可以根据分类抽到具体的物品</param>
	/// <param name="xiangshuLevel">世界进度 - 代表相枢侵蚀进度，{0,2,5}表示在相枢侵蚀进度0,2,5三个情况下显示的不同级别拾取物</param>
	/// <param name="resources">资源列表 - 产生拾取物的最少当前资源量</param>
	/// <param name="canShowMonths">显示月份 - 决定此事件会在哪几个月份显示出来，为1时表示此事件会在此月显示出来</param>
	/// <param name="showConditionInformation">持有见闻 - 持有对应见闻时才显示，引用InformationInfo</param>
	/// <param name="showConditionOrganizationApproving">需要的门派支持度 - 格式为{门派名,支持度}，对应门派的支持度到达这个水平时才显示</param>
	/// <param name="instantNotification">即时通知引用 - 引用InstantNotification模板ID，在拾取时显示对应的通知</param>
	/// <param name="extraBonusAddInstantNotification">额外奖励时附加即时通知</param>
	/// <param name="extraBonusReplaceInstantNotification">额外奖励时替换即时通知</param>
	/// <param name="eventMainContent">主事件描述</param>
	/// <param name="eventMainOptions">主选项文本</param>
	/// <param name="eventSecondContents">次级事件文本 - 每个主事件的选项，对应一个次级事件</param>
	/// <param name="eventSecondOptions">次级事件选项文本 - 每个次级事件只有一个文本，但是可以配置的</param>
	/// <param name="eventSecondItemRewards">次级事件道具奖励</param>
	/// <param name="eventSecondResourceRewards">次级事件资源奖励</param>
	/// <param name="eventSecondPropertyRewards">次级事件属性奖励 - 角色属性奖励，目前支持资质、促织缘</param>
	/// <param name="eventSecondDebtRewards">次级事件恩义奖励</param>
	/// <param name="eventSecondExpRewards">次级事件历练奖励</param>
	/// <param name="eventSecondItemRewardSelection1">次级事件选项1的道具奖励选择 - 当配置此列时，替换选项1为道具选择</param>
	/// <param name="eventSecondItemRewardSelection2">次级事件选项2的道具奖励选择 - 当配置此列时，替换选项2为道具选择</param>
	public MapPickupsItem(short templateId, string name, EMapPickupsType type, EMapPickupsType2 type2, string icon, string tipsContent, byte specialAreaTimes, byte[] stateTimes, List<short> blockList, bool readEffect, bool loopEffect, bool isExpBonus, bool isDebtBonus, int[] bonusCount, sbyte[] itemGrade, PresetItemTemplateId itemGroup, sbyte[] xiangshuLevel, short[] resources, bool[] canShowMonths, short showConditionInformation, OrganizationApproving showConditionOrganizationApproving, short instantNotification, short extraBonusAddInstantNotification, short extraBonusReplaceInstantNotification, string eventMainContent, string[] eventMainOptions, string[] eventSecondContents, string[] eventSecondOptions, List<PresetItemWithCount> eventSecondItemRewards, List<ResourceInfo> eventSecondResourceRewards, List<PropertyAndValue> eventSecondPropertyRewards, List<int> eventSecondDebtRewards, List<int> eventSecondExpRewards, List<PresetItemWithCount> eventSecondItemRewardSelection1, List<PresetItemWithCount> eventSecondItemRewardSelection2)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Type2 = type2;
		Icon = icon;
		TipsContent = tipsContent;
		SpecialAreaTimes = specialAreaTimes;
		StateTimes = stateTimes;
		BlockList = blockList;
		ReadEffect = readEffect;
		LoopEffect = loopEffect;
		IsExpBonus = isExpBonus;
		IsDebtBonus = isDebtBonus;
		BonusCount = bonusCount;
		ItemGrade = itemGrade;
		ItemGroup = itemGroup;
		XiangshuLevel = xiangshuLevel;
		Resources = resources;
		CanShowMonths = canShowMonths;
		ShowConditionInformation = showConditionInformation;
		ShowConditionOrganizationApproving = showConditionOrganizationApproving;
		InstantNotification = instantNotification;
		ExtraBonusAddInstantNotification = extraBonusAddInstantNotification;
		ExtraBonusReplaceInstantNotification = extraBonusReplaceInstantNotification;
		EventMainContent = eventMainContent;
		EventMainOptions = eventMainOptions;
		EventSecondContents = eventSecondContents;
		EventSecondOptions = eventSecondOptions;
		EventSecondItemRewards = eventSecondItemRewards;
		EventSecondResourceRewards = eventSecondResourceRewards;
		EventSecondPropertyRewards = eventSecondPropertyRewards;
		EventSecondDebtRewards = eventSecondDebtRewards;
		EventSecondExpRewards = eventSecondExpRewards;
		EventSecondItemRewardSelection1 = eventSecondItemRewardSelection1;
		EventSecondItemRewardSelection2 = eventSecondItemRewardSelection2;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapPickupsItem()
	{
		TemplateId = 0;
		Name = null;
		Type = EMapPickupsType.Invalid;
		Type2 = EMapPickupsType2.Invalid;
		Icon = null;
		TipsContent = null;
		SpecialAreaTimes = 0;
		StateTimes = new byte[15];
		BlockList = null;
		ReadEffect = false;
		LoopEffect = false;
		IsExpBonus = false;
		IsDebtBonus = false;
		BonusCount = new int[0];
		ItemGrade = new sbyte[0];
		ItemGroup = default(PresetItemTemplateId);
		XiangshuLevel = new sbyte[0];
		Resources = new short[6];
		CanShowMonths = new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		};
		ShowConditionInformation = 0;
		ShowConditionOrganizationApproving = new OrganizationApproving();
		InstantNotification = 0;
		ExtraBonusAddInstantNotification = 0;
		ExtraBonusReplaceInstantNotification = 0;
		EventMainContent = null;
		EventMainOptions = new string[0];
		EventSecondContents = new string[0];
		EventSecondOptions = new string[0];
		EventSecondItemRewards = new List<PresetItemWithCount>();
		EventSecondResourceRewards = new List<ResourceInfo>();
		EventSecondPropertyRewards = new List<PropertyAndValue>();
		EventSecondDebtRewards = new List<int>();
		EventSecondExpRewards = new List<int>();
		EventSecondItemRewardSelection1 = new List<PresetItemWithCount>();
		EventSecondItemRewardSelection2 = new List<PresetItemWithCount>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapPickupsItem(short templateId, MapPickupsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Type2 = other.Type2;
		Icon = other.Icon;
		TipsContent = other.TipsContent;
		SpecialAreaTimes = other.SpecialAreaTimes;
		StateTimes = other.StateTimes;
		BlockList = other.BlockList;
		ReadEffect = other.ReadEffect;
		LoopEffect = other.LoopEffect;
		IsExpBonus = other.IsExpBonus;
		IsDebtBonus = other.IsDebtBonus;
		BonusCount = other.BonusCount;
		ItemGrade = other.ItemGrade;
		ItemGroup = other.ItemGroup;
		XiangshuLevel = other.XiangshuLevel;
		Resources = other.Resources;
		CanShowMonths = other.CanShowMonths;
		ShowConditionInformation = other.ShowConditionInformation;
		ShowConditionOrganizationApproving = other.ShowConditionOrganizationApproving;
		InstantNotification = other.InstantNotification;
		ExtraBonusAddInstantNotification = other.ExtraBonusAddInstantNotification;
		ExtraBonusReplaceInstantNotification = other.ExtraBonusReplaceInstantNotification;
		EventMainContent = other.EventMainContent;
		EventMainOptions = other.EventMainOptions;
		EventSecondContents = other.EventSecondContents;
		EventSecondOptions = other.EventSecondOptions;
		EventSecondItemRewards = other.EventSecondItemRewards;
		EventSecondResourceRewards = other.EventSecondResourceRewards;
		EventSecondPropertyRewards = other.EventSecondPropertyRewards;
		EventSecondDebtRewards = other.EventSecondDebtRewards;
		EventSecondExpRewards = other.EventSecondExpRewards;
		EventSecondItemRewardSelection1 = other.EventSecondItemRewardSelection1;
		EventSecondItemRewardSelection2 = other.EventSecondItemRewardSelection2;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapPickupsItem Duplicate(int templateId)
	{
		return new MapPickupsItem((short)templateId, this);
	}
}
