using System;
using Config.Common;

namespace Config;

[Serializable]
public class ChickenItem : ConfigItem<ChickenItem, short>
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
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 显示素材名
	/// </summary>
	public readonly string Display;

	/// <summary>
	/// 品级
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 赋性类型
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 赋性加值
	/// - 伏龙特殊互动
	/// </summary>
	public readonly int PersonalityValue;

	/// <summary>
	/// 加成特性
	/// </summary>
	public readonly short FeatureId;

	/// <summary>
	/// 演员表模板id
	/// </summary>
	public readonly short EventActorTemplateId;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string EventDesc;

	/// <summary>
	/// 颜色
	/// </summary>
	public readonly EChickenChickenColor ChickenColor;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="display">显示素材名</param>
	/// <param name="grade">品级</param>
	/// <param name="personalityType">赋性类型</param>
	/// <param name="personalityValue">赋性加值 - 伏龙特殊互动</param>
	/// <param name="featureId">加成特性</param>
	/// <param name="eventActorTemplateId">演员表模板id</param>
	/// <param name="eventDesc">描述</param>
	/// <param name="chickenColor">颜色</param>
	public ChickenItem(short templateId, string name, string desc, string display, sbyte grade, sbyte personalityType, int personalityValue, short featureId, short eventActorTemplateId, string eventDesc, EChickenChickenColor chickenColor)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Display = display;
		Grade = grade;
		PersonalityType = personalityType;
		PersonalityValue = personalityValue;
		FeatureId = featureId;
		EventActorTemplateId = eventActorTemplateId;
		EventDesc = eventDesc;
		ChickenColor = chickenColor;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ChickenItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Display = null;
		Grade = 0;
		PersonalityType = 0;
		PersonalityValue = 0;
		FeatureId = 0;
		EventActorTemplateId = 0;
		EventDesc = null;
		ChickenColor = (EChickenChickenColor)0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ChickenItem(short templateId, ChickenItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Display = other.Display;
		Grade = other.Grade;
		PersonalityType = other.PersonalityType;
		PersonalityValue = other.PersonalityValue;
		FeatureId = other.FeatureId;
		EventActorTemplateId = other.EventActorTemplateId;
		EventDesc = other.EventDesc;
		ChickenColor = other.ChickenColor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ChickenItem Duplicate(int templateId)
	{
		return new ChickenItem((short)templateId, this);
	}
}
