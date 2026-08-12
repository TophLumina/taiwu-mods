using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureLifeSkillRequirementItem : ConfigItem<AdventureLifeSkillRequirementItem, byte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 造诣要求基础值
	/// - 奇遇中节点地块获得奖励所需要的技艺基础值，最终使用的值将被乘以奇遇的等级，例如在等级为3的奇遇中生成七品（基础值为30）的造诣要求，实际生成的就是 90 。
	/// </summary>
	public readonly short RequiredValue;

	/// <summary>
	/// 出现的权重
	/// - 每种基础值出现的权重。最后每一项的生成概率为 该项权重/所有权重之和，权重为0的是预留值，不生成。
	/// </summary>
	public readonly short Weight;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="requiredValue">造诣要求基础值 - 奇遇中节点地块获得奖励所需要的技艺基础值，最终使用的值将被乘以奇遇的等级，例如在等级为3的奇遇中生成七品（基础值为30）的造诣要求，实际生成的就是 90 。</param>
	/// <param name="weight">出现的权重 - 每种基础值出现的权重。最后每一项的生成概率为 该项权重/所有权重之和，权重为0的是预留值，不生成。</param>
	public AdventureLifeSkillRequirementItem(byte templateId, short requiredValue, short weight)
	{
		TemplateId = templateId;
		RequiredValue = requiredValue;
		Weight = weight;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AdventureLifeSkillRequirementItem()
	{
		TemplateId = 0;
		RequiredValue = 0;
		Weight = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AdventureLifeSkillRequirementItem(byte templateId, AdventureLifeSkillRequirementItem other)
	{
		TemplateId = templateId;
		RequiredValue = other.RequiredValue;
		Weight = other.Weight;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureLifeSkillRequirementItem Duplicate(int templateId)
	{
		return new AdventureLifeSkillRequirementItem((byte)templateId, this);
	}
}
