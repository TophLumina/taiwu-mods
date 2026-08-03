using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedStructItem : ConfigItem<SecretInformationAppliedStructItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 所属回应组
	/// - 如果此列为空，代表这一行配置仅作为占位存在，所以没有装载到对应的回应组中
	/// </summary>
	public readonly short GroupTemplateId;

	/// <summary>
	/// 基础回应
	/// </summary>
	public readonly short ContentId1;

	/// <summary>
	/// 保密回应
	/// - 专用于可能会触发威胁保密事件的回应组，因为多个特殊条件的概率可以叠加，所以不可以与其他回应合并
	/// </summary>
	public readonly short ContentId2;

	/// <summary>
	/// 保密条件
	/// - 满足条件时，根据特殊条件中的配置判定跳转到威胁保密事件的概率
	/// </summary>
	public readonly List<ShortList> ActorSectPunishSpecialCondition;

	/// <summary>
	/// 拓展回应
	/// - 判定的优先级低于保密回应，但高于基础回应；有多个扩展回应时，按填写顺序从左往右依次判定
	/// </summary>
	public readonly List<ShortList> ExtraContentIds;

	/// <summary>
	/// 玩家身份
	/// </summary>
	public readonly sbyte TaiwuIndex;

	/// <summary>
	/// 对方身份
	/// </summary>
	public readonly sbyte CharIndex;

	/// <summary>
	/// 基础选项
	/// - 如果用特殊处理在出现回应时就跳走了，便不需要配选项
	/// </summary>
	public readonly short[] Selection1;

	/// <summary>
	/// 保密选项
	/// </summary>
	public readonly short[] Selection2;

	/// <summary>
	/// 拓展选项
	/// </summary>
	public readonly List<ShortList> ExtraSelections;

	/// <summary>
	/// 身份权重
	/// - 高权重的回应组具有对低权重回应组的排他性，所以，如果不希望某些事件必然出现，最好不要随意分配高于默认值的权重；具体抽取规则为，将同身份权重的回应排成集合，然后在集合中根据各回应的立场权重再进行一次抽取，决定最终出现的事件
	/// </summary>
	public readonly short RelationValue;

	/// <summary>
	/// 立场权重
	/// - 在身份权重选取出的回应组中，将对方立场对应的各回应的权重进行加权，然后抽取最终出现的回应；当所有立场都是-1（即1/n）时，选取成功的各个回应会获得均等的抽取概率；虽然有保底的权重计算规则，实际填写时也不应出现同等的身份权重下，可用的回应中有个别立场的数值为-1的情况，因为可能会导致所有填了-1的回应以100/n的权重参与计算；因此所有的除默认值外的立场权重都应为非负整数
	/// </summary>
	public readonly short[] BehaviorTypeValue;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="groupTemplateId">所属回应组 - 如果此列为空，代表这一行配置仅作为占位存在，所以没有装载到对应的回应组中</param>
	/// <param name="contentId1">基础回应</param>
	/// <param name="contentId2">保密回应 - 专用于可能会触发威胁保密事件的回应组，因为多个特殊条件的概率可以叠加，所以不可以与其他回应合并</param>
	/// <param name="actorSectPunishSpecialCondition">保密条件 - 满足条件时，根据特殊条件中的配置判定跳转到威胁保密事件的概率</param>
	/// <param name="extraContentIds">拓展回应 - 判定的优先级低于保密回应，但高于基础回应；有多个扩展回应时，按填写顺序从左往右依次判定</param>
	/// <param name="taiwuIndex">玩家身份</param>
	/// <param name="charIndex">对方身份</param>
	/// <param name="selection1">基础选项 - 如果用特殊处理在出现回应时就跳走了，便不需要配选项</param>
	/// <param name="selection2">保密选项</param>
	/// <param name="extraSelections">拓展选项</param>
	/// <param name="relationValue">身份权重 - 高权重的回应组具有对低权重回应组的排他性，所以，如果不希望某些事件必然出现，最好不要随意分配高于默认值的权重；具体抽取规则为，将同身份权重的回应排成集合，然后在集合中根据各回应的立场权重再进行一次抽取，决定最终出现的事件</param>
	/// <param name="behaviorTypeValue">立场权重 - 在身份权重选取出的回应组中，将对方立场对应的各回应的权重进行加权，然后抽取最终出现的回应；当所有立场都是-1（即1/n）时，选取成功的各个回应会获得均等的抽取概率；虽然有保底的权重计算规则，实际填写时也不应出现同等的身份权重下，可用的回应中有个别立场的数值为-1的情况，因为可能会导致所有填了-1的回应以100/n的权重参与计算；因此所有的除默认值外的立场权重都应为非负整数</param>
	public SecretInformationAppliedStructItem(short templateId, short groupTemplateId, short contentId1, short contentId2, List<ShortList> actorSectPunishSpecialCondition, List<ShortList> extraContentIds, sbyte taiwuIndex, sbyte charIndex, short[] selection1, short[] selection2, List<ShortList> extraSelections, short relationValue, short[] behaviorTypeValue)
	{
		TemplateId = templateId;
		GroupTemplateId = groupTemplateId;
		ContentId1 = contentId1;
		ContentId2 = contentId2;
		ActorSectPunishSpecialCondition = actorSectPunishSpecialCondition;
		ExtraContentIds = extraContentIds;
		TaiwuIndex = taiwuIndex;
		CharIndex = charIndex;
		Selection1 = selection1;
		Selection2 = selection2;
		ExtraSelections = extraSelections;
		RelationValue = relationValue;
		BehaviorTypeValue = behaviorTypeValue;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationAppliedStructItem()
	{
		TemplateId = 0;
		GroupTemplateId = 0;
		ContentId1 = 0;
		ContentId2 = 0;
		ActorSectPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ExtraContentIds = new List<ShortList>
		{
			new ShortList(-1)
		};
		TaiwuIndex = 0;
		CharIndex = 0;
		Selection1 = new short[0];
		Selection2 = new short[0];
		ExtraSelections = new List<ShortList>
		{
			new ShortList(-1)
		};
		RelationValue = 0;
		BehaviorTypeValue = new short[5] { -1, -1, -1, -1, -1 };
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationAppliedStructItem(short templateId, SecretInformationAppliedStructItem other)
	{
		TemplateId = templateId;
		GroupTemplateId = other.GroupTemplateId;
		ContentId1 = other.ContentId1;
		ContentId2 = other.ContentId2;
		ActorSectPunishSpecialCondition = other.ActorSectPunishSpecialCondition;
		ExtraContentIds = other.ExtraContentIds;
		TaiwuIndex = other.TaiwuIndex;
		CharIndex = other.CharIndex;
		Selection1 = other.Selection1;
		Selection2 = other.Selection2;
		ExtraSelections = other.ExtraSelections;
		RelationValue = other.RelationValue;
		BehaviorTypeValue = other.BehaviorTypeValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationAppliedStructItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedStructItem((short)templateId, this);
	}
}
