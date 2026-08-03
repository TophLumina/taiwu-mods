using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RanshanGiveupLegendaryBookItem : ConfigItem<RanshanGiveupLegendaryBookItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 花费资源类型
	/// </summary>
	public readonly sbyte ResourceType;

	/// <summary>
	/// 花费历练数量
	/// </summary>
	public readonly int ExpCost;

	/// <summary>
	/// 花费资源数量
	/// </summary>
	public readonly int ResourceCost;

	/// <summary>
	/// 持续跟随时间
	/// </summary>
	public readonly int FollowDuration;

	/// <summary>
	/// 影响周期
	/// - 每x月对跟随NPC产生一次影响
	/// </summary>
	public readonly int ResponseCycle;

	/// <summary>
	/// 单次心情变化量
	/// - 每次产生影响时，心情的变化值。心情低于寻常时降低；心情高于寻常时提高
	/// </summary>
	public readonly int MoodChange;

	/// <summary>
	/// 判定属性
	/// - 用于判定NPC是否丢弃奇书时用的数值类型 GameData.Domains.Character.MainAttributeType
	/// </summary>
	public readonly List<sbyte> JudgeAttribute;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="resourceType">花费资源类型</param>
	/// <param name="expCost">花费历练数量</param>
	/// <param name="resourceCost">花费资源数量</param>
	/// <param name="followDuration">持续跟随时间</param>
	/// <param name="responseCycle">影响周期 - 每x月对跟随NPC产生一次影响</param>
	/// <param name="moodChange">单次心情变化量 - 每次产生影响时，心情的变化值。心情低于寻常时降低；心情高于寻常时提高</param>
	/// <param name="judgeAttribute">判定属性 - 用于判定NPC是否丢弃奇书时用的数值类型 GameData.Domains.Character.MainAttributeType</param>
	public RanshanGiveupLegendaryBookItem(byte templateId, sbyte resourceType, int expCost, int resourceCost, int followDuration, int responseCycle, int moodChange, List<sbyte> judgeAttribute)
	{
		TemplateId = templateId;
		ResourceType = resourceType;
		ExpCost = expCost;
		ResourceCost = resourceCost;
		FollowDuration = followDuration;
		ResponseCycle = responseCycle;
		MoodChange = moodChange;
		JudgeAttribute = judgeAttribute;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public RanshanGiveupLegendaryBookItem()
	{
		TemplateId = 0;
		ResourceType = 0;
		ExpCost = 0;
		ResourceCost = 0;
		FollowDuration = 0;
		ResponseCycle = 0;
		MoodChange = 0;
		JudgeAttribute = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public RanshanGiveupLegendaryBookItem(byte templateId, RanshanGiveupLegendaryBookItem other)
	{
		TemplateId = templateId;
		ResourceType = other.ResourceType;
		ExpCost = other.ExpCost;
		ResourceCost = other.ResourceCost;
		FollowDuration = other.FollowDuration;
		ResponseCycle = other.ResponseCycle;
		MoodChange = other.MoodChange;
		JudgeAttribute = other.JudgeAttribute;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override RanshanGiveupLegendaryBookItem Duplicate(int templateId)
	{
		return new RanshanGiveupLegendaryBookItem((byte)templateId, this);
	}
}
