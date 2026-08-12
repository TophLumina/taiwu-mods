using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthItem : ConfigItem<MonthItem, sbyte>
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
	/// 月份指代图片
	/// </summary>
	public readonly string Texture;

	/// <summary>
	/// 地块恢复资源类型
	/// - 每个时节会恢复的资源类型，对应ResourceType表中的模板ID
	/// </summary>
	public readonly List<sbyte> RecoverResourceType;

	/// <summary>
	/// 命格五行
	/// - 0: 金, 1: 木, 2: 水, 3: 火, 4: 土.
	/// </summary>
	public readonly sbyte FiveElementsType;

	/// <summary>
	/// 命格五行描述
	/// </summary>
	public readonly string FiveElementsTypeDesc;

	/// <summary>
	/// 恢复伤势
	/// - 进入此月时，恢复对应部位的外伤、内伤伤势1层
	/// </summary>
	public readonly List<sbyte> RecoverBodyParts;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="texture">月份指代图片</param>
	/// <param name="recoverResourceType">地块恢复资源类型 - 每个时节会恢复的资源类型，对应ResourceType表中的模板ID</param>
	/// <param name="fiveElementsType">命格五行 - 0: 金, 1: 木, 2: 水, 3: 火, 4: 土.</param>
	/// <param name="fiveElementsTypeDesc">命格五行描述</param>
	/// <param name="recoverBodyParts">恢复伤势 - 进入此月时，恢复对应部位的外伤、内伤伤势1层</param>
	public MonthItem(sbyte templateId, string name, string texture, List<sbyte> recoverResourceType, sbyte fiveElementsType, string fiveElementsTypeDesc, List<sbyte> recoverBodyParts)
	{
		TemplateId = templateId;
		Name = name;
		Texture = texture;
		RecoverResourceType = recoverResourceType;
		FiveElementsType = fiveElementsType;
		FiveElementsTypeDesc = fiveElementsTypeDesc;
		RecoverBodyParts = recoverBodyParts;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MonthItem()
	{
		TemplateId = 0;
		Name = null;
		Texture = null;
		RecoverResourceType = new List<sbyte>();
		FiveElementsType = 0;
		FiveElementsTypeDesc = null;
		RecoverBodyParts = new List<sbyte>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MonthItem(sbyte templateId, MonthItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Texture = other.Texture;
		RecoverResourceType = other.RecoverResourceType;
		FiveElementsType = other.FiveElementsType;
		FiveElementsTypeDesc = other.FiveElementsTypeDesc;
		RecoverBodyParts = other.RecoverBodyParts;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MonthItem Duplicate(int templateId)
	{
		return new MonthItem((sbyte)templateId, this);
	}
}
