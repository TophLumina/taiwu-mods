using System;
using Config.Common;

namespace Config;

[Serializable]
public class RelationDisplayTypeItem : ConfigItem<RelationDisplayTypeItem, short>
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
	/// 包含关系
	/// </summary>
	public readonly sbyte[] RelationTypeIds;

	/// <summary>
	/// 地格人物TIP里关系数量的显示顺序
	/// </summary>
	public readonly byte TipDisplayOrder;

	/// <summary>
	/// 地格人物TIP里对太吾的关系的显示顺序
	/// </summary>
	public readonly byte TipToTaiwuDisplayOrder;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="relationTypeIds">包含关系</param>
	/// <param name="tipDisplayOrder">地格人物TIP里关系数量的显示顺序</param>
	/// <param name="tipToTaiwuDisplayOrder">地格人物TIP里对太吾的关系的显示顺序</param>
	public RelationDisplayTypeItem(short templateId, string name, sbyte[] relationTypeIds, byte tipDisplayOrder, byte tipToTaiwuDisplayOrder)
	{
		TemplateId = templateId;
		Name = name;
		RelationTypeIds = relationTypeIds;
		TipDisplayOrder = tipDisplayOrder;
		TipToTaiwuDisplayOrder = tipToTaiwuDisplayOrder;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public RelationDisplayTypeItem()
	{
		TemplateId = 0;
		Name = null;
		RelationTypeIds = new sbyte[0];
		TipDisplayOrder = 0;
		TipToTaiwuDisplayOrder = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public RelationDisplayTypeItem(short templateId, RelationDisplayTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		RelationTypeIds = other.RelationTypeIds;
		TipDisplayOrder = other.TipDisplayOrder;
		TipToTaiwuDisplayOrder = other.TipToTaiwuDisplayOrder;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override RelationDisplayTypeItem Duplicate(int templateId)
	{
		return new RelationDisplayTypeItem((short)templateId, this);
	}
}
