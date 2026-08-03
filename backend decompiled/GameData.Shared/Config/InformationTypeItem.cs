using System;
using Config.Common;

namespace Config;

[Serializable]
public class InformationTypeItem : ConfigItem<InformationTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 简介
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 获得方式
	/// </summary>
	public readonly string DescGain;

	/// <summary>
	/// 见闻作用
	/// </summary>
	public readonly string DescEffect;

	/// <summary>
	/// 通常效果
	/// </summary>
	public readonly string DescEffectWay;

	/// <summary>
	/// 标题
	/// </summary>
	public readonly string Title;

	/// <summary>
	/// 使用中
	/// </summary>
	public readonly bool InUse;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">简介</param>
	/// <param name="descGain">获得方式</param>
	/// <param name="descEffect">见闻作用</param>
	/// <param name="descEffectWay">通常效果</param>
	/// <param name="title">标题</param>
	/// <param name="inUse">使用中</param>
	public InformationTypeItem(sbyte templateId, string name, string desc, string descGain, string descEffect, string descEffectWay, string title, bool inUse)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		DescGain = descGain;
		DescEffect = descEffect;
		DescEffectWay = descEffectWay;
		Title = title;
		InUse = inUse;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InformationTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		DescGain = null;
		DescEffect = null;
		DescEffectWay = null;
		Title = null;
		InUse = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InformationTypeItem(sbyte templateId, InformationTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		DescGain = other.DescGain;
		DescEffect = other.DescEffect;
		DescEffectWay = other.DescEffectWay;
		Title = other.Title;
		InUse = other.InUse;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InformationTypeItem Duplicate(int templateId)
	{
		return new InformationTypeItem((sbyte)templateId, this);
	}
}
