using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateCommentItem : ConfigItem<DebateCommentItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 结算评价说明
	/// </summary>
	public readonly string ResultTip;

	/// <summary>
	/// 评价台词
	/// </summary>
	public readonly string BubbleContent;

	/// <summary>
	/// 发表立场
	/// - 指定立场的角色才会进行该评价
	/// </summary>
	public readonly sbyte BehaviorType;

	/// <summary>
	/// 心情变化
	/// - 该列由公式生成，修改请在左边行中进行
	/// </summary>
	public readonly short[] Happiness;

	/// <summary>
	/// A类好感增减
	/// </summary>
	public readonly short Favor;

	/// <summary>
	/// 是否正面评价
	/// </summary>
	public readonly bool IsPositive;

	/// <summary>
	/// 反面评价
	/// </summary>
	public readonly short Negation;

	/// <summary>
	/// 判断值
	/// </summary>
	public readonly int CheckValue;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="resultTip">结算评价说明</param>
	/// <param name="bubbleContent">评价台词</param>
	/// <param name="behaviorType">发表立场 - 指定立场的角色才会进行该评价</param>
	/// <param name="happiness">心情变化 - 该列由公式生成，修改请在左边行中进行</param>
	/// <param name="favor">A类好感增减</param>
	/// <param name="isPositive">是否正面评价</param>
	/// <param name="negation">反面评价</param>
	/// <param name="checkValue">判断值</param>
	public DebateCommentItem(short templateId, string name, string desc, string resultTip, string bubbleContent, sbyte behaviorType, short[] happiness, short favor, bool isPositive, short negation, int checkValue)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ResultTip = resultTip;
		BubbleContent = bubbleContent;
		BehaviorType = behaviorType;
		Happiness = happiness;
		Favor = favor;
		IsPositive = isPositive;
		Negation = negation;
		CheckValue = checkValue;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateCommentItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ResultTip = null;
		BubbleContent = null;
		BehaviorType = 0;
		Happiness = new short[5];
		Favor = 0;
		IsPositive = false;
		Negation = 0;
		CheckValue = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateCommentItem(short templateId, DebateCommentItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ResultTip = other.ResultTip;
		BubbleContent = other.BubbleContent;
		BehaviorType = other.BehaviorType;
		Happiness = other.Happiness;
		Favor = other.Favor;
		IsPositive = other.IsPositive;
		Negation = other.Negation;
		CheckValue = other.CheckValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateCommentItem Duplicate(int templateId)
	{
		return new DebateCommentItem((short)templateId, this);
	}
}
