using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureGenerateConditionItem : ConfigItem<AdventureGenerateConditionItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 奇遇ID
	/// </summary>
	public readonly int TargetId;

	/// <summary>
	/// 强制禁止生成
	/// </summary>
	public readonly bool ForceDisable;

	/// <summary>
	/// 生成月份要求
	/// - 每达到列表中的月份都尝试执行逻辑，如果逻辑行为处于进行中则不会尝试进行该行为
	/// </summary>
	public readonly List<sbyte> EnterMonthList;

	/// <summary>
	/// 地区生成数量上限
	/// - 在一个地区生成的上限.填写-1则是无上限限制
	/// </summary>
	public readonly int MaxCountInArea;

	/// <summary>
	/// 世界生成数量上限
	/// - 在世界生成的奇遇数量上限，填写-1则是无上限限制
	/// </summary>
	public readonly int MaxCountInWorld;

	/// <summary>
	/// 每月生成数量上限
	/// - 在全世界每月生成的数量上限，填 -1 是无上限限制
	/// </summary>
	public readonly int MaxCountInMonth;

	/// <summary>
	/// 州域生成权重
	/// </summary>
	public readonly int[] StateWeights;

	/// <summary>
	/// 地区类别生成权重
	/// </summary>
	public readonly int[] AreaWeights;

	/// <summary>
	/// 限定地形大类
	/// - 不填表示不限制
	/// </summary>
	public readonly EMapBlockType[] IncludeTypes;

	/// <summary>
	/// 可准备时长
	/// - 奇遇超过准备时长则判定发起失败
	/// </summary>
	public readonly sbyte PreparationDuration;

	/// <summary>
	/// 触发间隔
	/// - 距离最近一次触发该生成条目的最短月份数
	/// </summary>
	public readonly sbyte MinInterval;

	/// <summary>
	/// 生成触发
	/// - 奇遇生成时触发的过月通知
	/// </summary>
	public readonly short ActiveNotification;

	/// <summary>
	/// 准备触发
	/// - 奇遇准备时的过月通知
	/// </summary>
	public readonly short PrepareNotification;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="targetId">奇遇ID</param>
	/// <param name="forceDisable">强制禁止生成</param>
	/// <param name="enterMonthList">生成月份要求 - 每达到列表中的月份都尝试执行逻辑，如果逻辑行为处于进行中则不会尝试进行该行为</param>
	/// <param name="maxCountInArea">地区生成数量上限 - 在一个地区生成的上限.填写-1则是无上限限制</param>
	/// <param name="maxCountInWorld">世界生成数量上限 - 在世界生成的奇遇数量上限，填写-1则是无上限限制</param>
	/// <param name="maxCountInMonth">每月生成数量上限 - 在全世界每月生成的数量上限，填 -1 是无上限限制</param>
	/// <param name="stateWeights">州域生成权重</param>
	/// <param name="areaWeights">地区类别生成权重</param>
	/// <param name="includeTypes">限定地形大类 - 不填表示不限制</param>
	/// <param name="preparationDuration">可准备时长 - 奇遇超过准备时长则判定发起失败</param>
	/// <param name="minInterval">触发间隔 - 距离最近一次触发该生成条目的最短月份数</param>
	/// <param name="activeNotification">生成触发 - 奇遇生成时触发的过月通知</param>
	/// <param name="prepareNotification">准备触发 - 奇遇准备时的过月通知</param>
	public AdventureGenerateConditionItem(int templateId, int targetId, bool forceDisable, List<sbyte> enterMonthList, int maxCountInArea, int maxCountInWorld, int maxCountInMonth, int[] stateWeights, int[] areaWeights, EMapBlockType[] includeTypes, sbyte preparationDuration, sbyte minInterval, short activeNotification, short prepareNotification)
	{
		TemplateId = templateId;
		TargetId = targetId;
		ForceDisable = forceDisable;
		EnterMonthList = enterMonthList;
		MaxCountInArea = maxCountInArea;
		MaxCountInWorld = maxCountInWorld;
		MaxCountInMonth = maxCountInMonth;
		StateWeights = stateWeights;
		AreaWeights = areaWeights;
		IncludeTypes = includeTypes;
		PreparationDuration = preparationDuration;
		MinInterval = minInterval;
		ActiveNotification = activeNotification;
		PrepareNotification = prepareNotification;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureGenerateConditionItem()
	{
		TemplateId = 0;
		TargetId = 0;
		ForceDisable = false;
		EnterMonthList = new List<sbyte>();
		MaxCountInArea = -1;
		MaxCountInWorld = -1;
		MaxCountInMonth = 1;
		StateWeights = null;
		AreaWeights = null;
		IncludeTypes = new EMapBlockType[0];
		PreparationDuration = 3;
		MinInterval = 3;
		ActiveNotification = 0;
		PrepareNotification = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureGenerateConditionItem(int templateId, AdventureGenerateConditionItem other)
	{
		TemplateId = templateId;
		TargetId = other.TargetId;
		ForceDisable = other.ForceDisable;
		EnterMonthList = other.EnterMonthList;
		MaxCountInArea = other.MaxCountInArea;
		MaxCountInWorld = other.MaxCountInWorld;
		MaxCountInMonth = other.MaxCountInMonth;
		StateWeights = other.StateWeights;
		AreaWeights = other.AreaWeights;
		IncludeTypes = other.IncludeTypes;
		PreparationDuration = other.PreparationDuration;
		MinInterval = other.MinInterval;
		ActiveNotification = other.ActiveNotification;
		PrepareNotification = other.PrepareNotification;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureGenerateConditionItem Duplicate(int templateId)
	{
		return new AdventureGenerateConditionItem(templateId, this);
	}
}
